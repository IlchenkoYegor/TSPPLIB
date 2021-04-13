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
    public partial class Authorization : Form
    {
        private bool isWorker;
        public bool getTypeOfCustomer()
        {
            return isWorker;
        }
        public Authorization()
        {
            InitializeComponent();
            groupBox1.CausesValidation = true;
        }
        ControllerLibrary controllerLibrary;
        public void setController(ControllerLibrary controllerLibrary)
        {
            this.controllerLibrary = controllerLibrary;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if(!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Визначте свій вибір");
                return;
            }
            isWorker = radioButton1.Checked;
            controllerLibrary.StartTheAppBy();
        }

        private void Authorization_Load(object sender, EventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
