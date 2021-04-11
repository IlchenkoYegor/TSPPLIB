using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSPP2.model;
using TSPPLIB.model;
using TSPPLIB.view;

namespace TSPPLIB.controller
{
    public class ControllerLibrary
    {
        private bool isWorker; 
        private MainModel model;
        private LibraryForm libraryForm;
        private EditForm edit;
        private Authorization authorizationForm;
        private AddForm addForm;

        public ControllerLibrary(MainModel model, LibraryForm libraryForm, EditForm edit, Authorization authorizationForm, AddForm addForm)
        {
            this.model = model ?? throw new ArgumentNullException(nameof(model));
            this.libraryForm = libraryForm ?? throw new ArgumentNullException(nameof(libraryForm));
            this.edit = edit ?? throw new ArgumentNullException(nameof(edit));
            this.authorizationForm = authorizationForm ?? throw new ArgumentNullException(nameof(authorizationForm));
            this.addForm = addForm ?? throw new ArgumentNullException(nameof(addForm));
            this.libraryForm.setController(this);
            this.edit.setController(this);
            this.authorizationForm.setController(this);
            this.addForm.setController(this);
        }

        public void StartTheAppBy()
        {
            isWorker = authorizationForm.getTypeOfCustomer();
            
            LoadAll();
            if (isWorker)
            {//client
                libraryForm.button2.Visible = false;
                libraryForm.button7.Visible = false;
                libraryForm.button3.Visible = true;
                libraryForm.button4.Visible = true;
                libraryForm.button5.Visible = true;
                libraryForm.button6.Visible = true;
            }
            else
            {//worker
                libraryForm.button2.Visible = true;
                libraryForm.button7.Visible = true;
                libraryForm.button3.Visible = false;
                libraryForm.button4.Visible = false;
                libraryForm.button5.Visible = false;
                libraryForm.button6.Visible = false;
            }
            authorizationForm.Visible = false;
            libraryForm.Visible = true;
        }

        private void CheckTheYearPole()
        {
            if (libraryForm.textBox3.Text.Equals("") || libraryForm.textBox3 == null)
            {
                libraryForm.errorProvider1.SetError(libraryForm.textBox1, "поле повинне бути заповнене.");
                libraryForm.errorProvider1.SetError(libraryForm.textBox2, "поле повинне бути заповнене.");
                //libraryForm.errorProvider1.SetError(libraryForm.textBox3, "поле повинне бути заповнене");
                return;
            }
            try
            {
                model.FilterByYear(Convert.ToInt32(libraryForm.textBox3.Text));
                LoadSelected();
            }
            catch
            {
                MessageBox.Show("Помиллка при введенні року!");
            }
        }
        public void Filter()
        {
            libraryForm.errorProvider1.Clear();
            if(libraryForm.textBox1.Text.Equals("") || libraryForm.textBox2.Text.Equals("")
                || libraryForm.textBox1 ==null || libraryForm.textBox2 == null)
            {
                CheckTheYearPole();
                return;
            }
            string author = libraryForm.textBox2.Text;
            string name = libraryForm.textBox1.Text;
            libraryForm.dataGridView1.Rows.Clear();
            model.FilterByAuthor(author, name);
            
            LoadSelected();
            MessageBox.Show("Пошук за автором " + author + " та назвою " + name + " був проведений.");
        }
        public void ToAuthorizationForm()
        {
            libraryForm.Visible = false;
            authorizationForm.Visible = true;
            model.UpdateDataState();
        }
        public void CancelSome(Form r)
        {
            r.Visible = false;
            libraryForm.Visible = true;
        }
        public void AddButtonHandler()
        {
            addForm.Visible = true;
            libraryForm.Visible = false;
            if (libraryForm.dataGridView1.Rows.Count < 10)
            {
                addForm.cancelAddBtn.Enabled = false;
            }
        }
        public void AddBook()
        {
            if(addForm.textBoxNameAdd.Text == null || addForm.textBoxAuthorAdd.Text == null 
                || addForm.textBoxNameAdd.Text.Equals("") || addForm.textBoxAuthorAdd.Text.Equals(""))
            {
                MessageBox.Show("Поля \"Назва\" та \"Автор\" повинні бути заповнені.");
                return;
            }
            try
            {
                int id = Convert.ToInt32(addForm.textBoxIdAdd.Text.ToString());
                string name = addForm.textBoxNameAdd.Text.ToString();
                string author = addForm.textBoxAuthorAdd.Text.ToString();
                int yearOfBook = Convert.ToInt32(addForm.textBoxYearAdd.Text.ToString());
                int location = Convert.ToInt32(addForm.textBoxLocationAdd.Text.ToString());
                Book currentBook = new TSPP2.model.Book(id, author, yearOfBook, name, location);
                model.Add(currentBook);
                if (libraryForm.dataGridView1.Rows.Count < 10)
                {
                    int remainingCount = 10 - libraryForm.dataGridView1.Rows.Count;
                    MessageBox.Show("Кількість записів повинна бути більше 10. Додайте ще " + remainingCount + " записів.");
                    libraryForm.dataGridView1.Rows.Add(currentBook.Id, currentBook.Name, currentBook.Author, currentBook.YearOfBook, currentBook.Location);
                    return;
                }
                addForm.Visible = false;
                libraryForm.Visible = true;
                libraryForm.dataGridView1.Rows.Add(currentBook.Id, currentBook.Name, currentBook.Author, currentBook.YearOfBook, currentBook.Location);
            }
            catch
            {
                MessageBox.Show("Помилкa при введенні даних.");
            }
            
            
            

        }
        public void LoadAll()
        {
            libraryForm.dataGridView1.Rows.Clear();
            List<Book> list = model.getAll();
            foreach (Book item in list)
            {
                libraryForm.dataGridView1.Rows.Add(item.Id, item.Name, item.Author, item.YearOfBook, item.Location);
            }

        }
        public void LoadSelected()
        {
            libraryForm.dataGridView1.Rows.Clear();
            List<Book> list = model.getFiltered();
            if (list.Count == 0)
            {
                MessageBox.Show("Пошук не дав результатів!");
                return;
            }
            foreach (Book item in list)
            {
                libraryForm.dataGridView1.Rows.Add(item.Id, item.Name, item.Author, item.YearOfBook, item.Location);
            }
        }

        public void EditDataButtonHandler()
        {
            if (libraryForm.dataGridView1.SelectedRows.Count > 0 &&
            libraryForm.dataGridView1.SelectedRows[0].Index !=
            libraryForm.dataGridView1.Rows.Count)
            {
                edit.Visible = true;
                edit.textBoxIdEdit.Text = libraryForm.dataGridView1.Rows
                    [libraryForm.dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString();
                edit.textBoxNameEdit.Text = libraryForm.dataGridView1.Rows
                    [libraryForm.dataGridView1.SelectedRows[0].Index].Cells[1].Value.ToString();
                edit.textBoxAuthorEdit.Text = libraryForm.dataGridView1.Rows
                    [libraryForm.dataGridView1.SelectedRows[0].Index].Cells[2].Value.ToString();
                edit.textBoxYearEdit.Text = libraryForm.dataGridView1.Rows
                    [libraryForm.dataGridView1.SelectedRows[0].Index].Cells[3].Value.ToString();
                edit.textBoxLocationEdit.Text = libraryForm.dataGridView1.Rows
                    [libraryForm.dataGridView1.SelectedRows[0].Index].Cells[4].Value.ToString();
                

            }
        }

        public void Remover()
        {
            int idToDel = Convert.ToInt32(libraryForm.dataGridView1.Rows
     [libraryForm.dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());
            string nameToDel = libraryForm.dataGridView1.Rows
                [libraryForm.dataGridView1.SelectedRows[0].Index].Cells[1].Value.ToString();
            string authorToDel = libraryForm.dataGridView1.Rows
                [libraryForm.dataGridView1.SelectedRows[0].Index].Cells[2].Value.ToString();
            int yearOfBookToDel = Convert.ToInt32(libraryForm.dataGridView1.Rows
                 [libraryForm.dataGridView1.SelectedRows[0].Index].Cells[3].Value.ToString());
            int locationToDel = Convert.ToInt32(libraryForm.dataGridView1.Rows
                 [libraryForm.dataGridView1.SelectedRows[0].Index].Cells[4].Value.ToString()); ;
            Book bookToDel = new Book(idToDel, authorToDel, yearOfBookToDel, nameToDel, locationToDel);
            //Book bookToDel = libraryForm.dataGridView1.Rows[libraryForm.dataGridView1.SelectedRows[0].Index].DataBoundItem as Book;
           
            model.Delete(bookToDel);
        }
        public void Remove()
        {
            Remover();
            libraryForm.dataGridView1.Rows.RemoveAt(libraryForm.dataGridView1.SelectedRows[0].Index);
        }
        public void EditData()
        {
            if (edit.textBoxNameEdit.Text == null || edit.textBoxAuthorEdit.Text == null
    || edit.textBoxNameEdit.Text.Equals("") || edit.textBoxAuthorEdit.Text.Equals(""))
            {
                MessageBox.Show("Поля \"Назва\" та \"Автор\" повинні бути заповнені");
                return;
            }
            try
            {
                int id = Convert.ToInt32(edit.textBoxIdEdit.Text.ToString());
                string name = edit.textBoxNameEdit.Text.ToString();
                string author = edit.textBoxAuthorEdit.Text.ToString();
                int yearOfBook = Convert.ToInt32(edit.textBoxYearEdit.Text.ToString());
                int location = Convert.ToInt32(edit.textBoxLocationEdit.Text.ToString());
                Book currentBook = new TSPP2.model.Book(id, author, yearOfBook, name, location);
                Remover();

                model.Add(currentBook);
                edit.Visible = false;
                libraryForm.Visible = true;
                libraryForm.dataGridView1.Rows.Insert(libraryForm.dataGridView1.SelectedRows[0].Index,
                     id, name,
                     author, yearOfBook, location);
                libraryForm.dataGridView1.Rows.RemoveAt(libraryForm.dataGridView1.SelectedRows[0].Index);
                
                edit.Visible = false;
                libraryForm.Visible = true;
                //libraryForm.dataGridView1.Rows.Add(currentBook.Id, currentBook.Name, currentBook.Author, currentBook.YearOfBook, currentBook.Location);
                //libraryForm.dataGridView1.Rows.Add(currentBook);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Помилки при введенні даних ");
            }
            
        }
        public void SaveDataButtonHandler()
        {
            MessageBox.Show("файл listofbooks.txt успішно збережений");
            model.SaveChanges();
        }
        public void WriteData()
        {
            model.ToWrite();
            MessageBox.Show("Список відібраних книг збережено до файлу resultofsearch.txt.");
        }
        public void Remove()
        {
            if (libraryForm.dataGridView1.Rows.Count <= 10)
            {
                MessageBox.Show("Неможливо видалаити запис. Кількість записів повинна бути більше 10.");        
                return;
            }
        }
    }
}
