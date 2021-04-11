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
        private MainModel model;
        private LibraryForm libraryForm;
        private EditForm edit;
        private Form1 authorizationForm;
        private AddForm addForm;

        public ControllerLibrary(MainModel model, LibraryForm libraryForm, EditForm edit, Form1 authorizationForm, AddForm addForm)
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
            }
            catch
            {
                MessageBox.Show("Помилки при введенні даних");
            }
            
            
        }
        
    }
}
