using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSPPLIB.controller;

namespace TSPPLIB.view
{
    public partial class AddForm : Form
    {
        public AddForm(ControllerLibrary controllerLibrary)
        {
            InitializeComponent();
            this.controllerLibrary = controllerLibrary;
        }

        public AddForm()
        {
            InitializeComponent();
        }

        ControllerLibrary controllerLibrary;

        public void setController(ControllerLibrary controllerLibrary)
        {
            this.controllerLibrary = controllerLibrary;
        }
        private void saveAddBtn_Click(object sender, EventArgs e)
        {
            controllerLibrary.AddBook();
        }
    }
}
