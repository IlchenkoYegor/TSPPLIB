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
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
        }
        ControllerLibrary controllerLibrary;
        public void setController(ControllerLibrary controllerLibrary)
        {
            this.controllerLibrary = controllerLibrary;
        }
    }
}
