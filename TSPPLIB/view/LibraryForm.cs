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

        public void LoadData()
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            controllerLibrary.ToAuthorizationForm();
        }

        public void Button2_Click(object sender, EventArgs e)
        {
            controllerLibrary.Filter();
        }

        private void LibraryForm_Load(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            controllerLibrary.EditDataButtonHandler();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            controllerLibrary.WriteData();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            controllerLibrary.SaveDataButtonHandler();
        }

        public void Button5_Click(object sender, EventArgs e)
        {
            controllerLibrary.Remove();
        }
    }
}
