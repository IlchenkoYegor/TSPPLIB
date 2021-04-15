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
            
            object sender = target;
            RoutedEventArgs e = null;
            target.InitializeComponent();
            target.textBox1.Text = "The Great Gatsby";
            target.textBox2.Text = "Scott Fitzgerald";
            // пошук
            target.Button2_Click(sender, e);

            //mainModel.FilterByAuthor(target.textBox1.Text, target.textBox2.Text);

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