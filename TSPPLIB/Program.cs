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
            Authorization authorization = new Authorization();
            LibraryForm libraryForm = new LibraryForm(mainModel);
            AddForm addForm = new AddForm();
            ControllerLibrary controllerLibrary = new ControllerLibrary(mainModel, libraryForm, editForm, authorization, addForm);

            Application.Run(authorization);
        }
    }
}
