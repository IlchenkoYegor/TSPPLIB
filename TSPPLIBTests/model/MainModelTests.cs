using Microsoft.VisualStudio.TestTools.UnitTesting;
using TSPPLIB.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSPP2.model;
using TSPPLIB.view;
using System.Windows;
using TSPPLIB.controller;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TSPPLIB.model.Tests
{
    [TestClass()]
    public class MainModelTests
    {
        [TestMethod()]
        public void FilterByAuthorTest()
        {
            MainModel mainModel = new MainModel();
            var target = new LibraryForm();
            ControllerLibrary controllerLibrary = new ControllerLibrary(mainModel, target, new EditForm(), new Authorization(), new AddForm());
            target.setController(controllerLibrary);

            List<Book> expected = new List<Book>();
            expected.Add(new Book(9999, "Scott Fitzgerald", 1925, "The Great Gatsby", 77));
            expected.Add(new Book(8888, "Scott Fitzgerald", 2001, "The Great Gatsby", 78));
            expected.Add(new Book(7777, "Scott Fitzgerald", 2021, "The Great Gatsby", 79));
            expected.Add(new Book(9999, "Scott Fitzgerald", 1925, "The Great Gatsby", 80));
            expected.Add(new Book(8888, "Scott Fitzgerald", 2001, "The Great Gatsby", 81));
            expected.Add(new Book(7777, "Scott Fitzgerald", 2021, "The Great Gatsby", 82));
            expected.Add(new Book(9999, "Scott Fitzgerald", 1925, "The Great Gatsby", 83));
            expected.Add(new Book(8888, "Scott Fitzgerald", 2001, "The Great Gatsby", 84));
            expected.Add(new Book(7777, "Scott Fitzgerald", 2021, "The Great Gatsby", 85));
            expected.Add(new Book(9999, "Scott Fitzgerald", 1925, "The Great Gatsby", 86));
            expected.Add(new Book(8888, "Scott Fitzgerald", 2001, "The Great Gatsby", 87));
            expected.Add(new Book(7777, "Scott Fitzgerald", 2021, "The Great Gatsby", 88));

            object sender = target;
            RoutedEventArgs e = null;
            target.InitializeComponent();
            target.textBox1.Text = "The Great Gatsby";
            target.textBox2.Text = "Scott Fitzgerald";
            // пошук
            target.Button2_Click(sender, e);
            List<Book> actual;
            actual = mainModel.getFiltered();
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Name, actual[i].Name);
                Assert.AreEqual(expected[i].Author, actual[i].Author);
                Assert.AreEqual(expected[i].YearOfBook, actual[i].YearOfBook);
                Assert.AreEqual(expected[i].Location, actual[i].Location);
            }

        }

        [TestMethod()]
        public void DeleteTest()
        {
            MainModel mainModel = new MainModel();
            var target = new LibraryForm();
            ControllerLibrary controllerLibrary = new ControllerLibrary(mainModel, target, new EditForm(), new Authorization(), new AddForm());
            target.setController(controllerLibrary);

            List<Book> expected = new List<Book>();
            expected.Add(new Book(9999, "Scott Fitzgerald", 1925, "The Great Gatsby", 77));
            expected.Add(new Book(8888, "Scott Fitzgerald", 2001, "The Great Gatsby", 78));
            expected.Add(new Book(7777, "Scott Fitzgerald", 2021, "The Great Gatsby", 79));
            expected.Add(new Book(9999, "Scott Fitzgerald", 1925, "The Great Gatsby", 80));
            expected.Add(new Book(8888, "Scott Fitzgerald", 2001, "The Great Gatsby", 81));
            expected.Add(new Book(7777, "Scott Fitzgerald", 2021, "The Great Gatsby", 82));
            expected.Add(new Book(9999, "Scott Fitzgerald", 1925, "The Great Gatsby", 83));
            expected.Add(new Book(8888, "Scott Fitzgerald", 2001, "The Great Gatsby", 84));
            expected.Add(new Book(7777, "Scott Fitzgerald", 2021, "The Great Gatsby", 85));
            expected.Add(new Book(9999, "Scott Fitzgerald", 1925, "The Great Gatsby", 86));
            expected.Add(new Book(8888, "Scott Fitzgerald", 2001, "The Great Gatsby", 87));
            expected.Add(new Book(7777, "Scott Fitzgerald", 2021, "The Great Gatsby", 88));

            object sender = target;
            RoutedEventArgs e = null;
            target.InitializeComponent();
            controllerLibrary.LoadAll();
            // пошук
            target.dataGridView1.ClearSelection();
            for (int i = target.dataGridView1.RowCount - 1; i >= 0; i--)
            {

                target.dataGridView1.Rows[i].Selected = true;


                if (!target.dataGridView1.SelectedRows[0].Cells["Column3"].Value.ToString().Equals("Scott Fitzgerald"))
                {
                    target.Button5_Click(sender, e);
                }
            }
            List<Book> actual;
            actual = mainModel.getAll();
            Assert.AreEqual(expected.Count, actual.Count, 0, "actual and expected sizes of arrays are not equal");
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Name, actual[i].Name);
                Assert.AreEqual(expected[i].Author, actual[i].Author);
                Assert.AreEqual(expected[i].YearOfBook, actual[i].YearOfBook);
                Assert.AreEqual(expected[i].Location, actual[i].Location);
            }
        }

        [TestMethod()]
        public void FilterByYearTest()
        {
            MainModel mainModel = new MainModel();
            var target = new LibraryForm();
            ControllerLibrary controllerLibrary = new ControllerLibrary(mainModel, target, new EditForm(), new Authorization(), new AddForm());
            target.setController(controllerLibrary);

            List<Book> expected = new List<Book>();
            expected.Add(new Book(9999, "Scott Fitzgerald", 1925, "The Great Gatsby", 77));
            expected.Add(new Book(9999, "Scott Fitzgerald", 1925, "The Great Gatsby", 80));
            expected.Add(new Book(9999, "Scott Fitzgerald", 1925, "The Great Gatsby", 83));
            expected.Add(new Book(9999, "Scott Fitzgerald", 1925, "The Great Gatsby", 86));

            object sender = target;
            RoutedEventArgs e = null;
            target.InitializeComponent();
            target.textBox3.Text = "1925";
            // пошук
            target.Button2_Click(sender, e);

            List<Book> actual;
            actual = mainModel.getFiltered();
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Name, actual[i].Name);
                Assert.AreEqual(expected[i].Author, actual[i].Author);
                Assert.AreEqual(expected[i].YearOfBook, actual[i].YearOfBook);
                Assert.AreEqual(expected[i].Location, actual[i].Location);
            }
        }
    }
}