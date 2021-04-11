using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSPP2.model;
using TSPPLIB.controller;
using TSPPLIB.model;

namespace TSPPLIB.view
{
    public partial class LibraryForm : Form
    {
        public LibraryForm(ControllerLibrary controllerLibrary)
        {
            InitializeComponent();
            this.controllerLibrary = controllerLibrary;
        }
        MainModel mainModel;

        public LibraryForm()
        {
            InitializeComponent();
        }

        public LibraryForm(MainModel mainModel)
        {
            InitializeComponent();
            this.mainModel = mainModel;
            LoadData();
            //this.dataGridView1.DataSource = mainModel.getAll();
        }

        ControllerLibrary controllerLibrary;
        public void setController(ControllerLibrary controllerLibrary)
        {
            this.controllerLibrary = controllerLibrary;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controllerLibrary.AddButtonHandler();
        }

        private void LoadData()
        {
            List<Book> list = mainModel.getAll();
            foreach (Book item in list)
            {
                dataGridView1.Rows.Add(item.Id, item.Name, item.Author, item.YearOfBook, item.Location);
            }
        }
    }
}
