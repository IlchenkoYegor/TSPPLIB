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

namespace TSPPLIB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ControllerLibrary controllerLibrary;
        public void setController(ControllerLibrary controllerLibrary)
        {
            this.controllerLibrary = controllerLibrary;
        }
        private void Button1_Click(object sender, EventArgs e)
        {

            MainModel mainmodel = new MainModel();
            mainmodel.Add(new Book(11, "RR", 1000, "@@@AA", 13));
            mainmodel.FilterByAuthor("RR", "@@@AA");
            mainmodel.ToWrite();
        }
    }
}
