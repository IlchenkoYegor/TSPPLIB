using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ControllerLibrary(MainModel model, LibraryForm libraryForm, EditForm edit, Form1 authorizationForm)
        {
            this.model = model ?? throw new ArgumentNullException(nameof(model));
            this.libraryForm = libraryForm ?? throw new ArgumentNullException(nameof(libraryForm));
            this.edit = edit ?? throw new ArgumentNullException(nameof(edit));
            this.authorizationForm = authorizationForm ?? throw new ArgumentNullException(nameof(authorizationForm));
        }

        
    }
}
