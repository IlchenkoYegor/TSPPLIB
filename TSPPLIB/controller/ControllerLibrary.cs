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
                libraryForm.errorProvider1.SetError(libraryForm.textBox1, "поле повинне бути заповнене");
                libraryForm.errorProvider1.SetError(libraryForm.textBox2, "поле повинне бути заповнене");
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
            MessageBox.Show("Пошук за автором " + author + " та назвою " + name + " був проведений");
        }
        public void ToAuthorizationForm()
        {
            libraryForm.Visible = false;
            authorizationForm.Visible = true;
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
        }
        public void AddBook()
        {
            if(addForm.textBoxNameAdd.Text == null || addForm.textBoxAuthorAdd.Text == null 
                || addForm.textBoxNameAdd.Text.Equals("") || addForm.textBoxAuthorAdd.Text.Equals(""))
            {
                MessageBox.Show("Поля \"Назва\" та \"Автор\" повинні бути заповнені");
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
                addForm.Visible = false;
                libraryForm.Visible = true;
                libraryForm.dataGridView1.Rows.Add(currentBook.Id, currentBook.Name, currentBook.Author, currentBook.YearOfBook, currentBook.Location);
                //libraryForm.dataGridView1.Rows.Add(currentBook);
            }
            catch
            {
                MessageBox.Show("Помилки при введенні даних");
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

}
}
