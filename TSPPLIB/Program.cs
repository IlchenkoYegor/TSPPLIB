using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSPPLIB.controller;
using TSPPLIB.model;
using TSPPLIB.view;

namespace TSPPLIB
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //LibraryForm libraryForm = new LibraryForm();
            MainModel mainModel = new MainModel();  
            EditForm editForm = new EditForm();
            Authorization form1 = new Authorization();
            LibraryForm libraryForm = new LibraryForm(mainModel);
            AddForm addForm = new AddForm();
            ControllerLibrary controllerLibrary = new ControllerLibrary(mainModel, libraryForm, editForm, form1, addForm);

            Application.Run(form1);
        }
    }
}
