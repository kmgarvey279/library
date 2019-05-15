using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.Models;
using System.Collections.Generic;
using System;

namespace Library.TestTools
{
  [TestClass]
  public class PatronTest : IDisposable
  {
    public PatronTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=library_test;";
    }

    public void Dispose()
    {
      Patron.ClearAll();
    }

    [TestMethod]
    public void PatronCounstructor_CreatesNewInstanceOfObject_Patron()
    {
      Patron newPatron = new Patron("test", "#");
      Assert.AreEqual(typeof(Patron), newPatron.GetType());
    }

    [TestMethod]
    public void Save_SavesPatronToDatabase_Patron()
    {
      Patron testPatron = new Patron("test", "#");
      testPatron.Save();
      List<Patron> result = Patron.GetAll();
      List<Patron> testList = new List<Patron>{testPatron};
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToPatron_Id()
    {
      Patron testPatron = new Patron("name", "#");
      testPatron.Save();
      Patron savedPatron = Patron.GetAll()[0];
      int result = savedPatron.GetId();
      int testId = testPatron.GetId();
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfArgumentsAreTheSame_Patron()
    {
      Patron newPatron1 = new Patron("test", "#");
      Patron newPatron2 = new Patron("test", "#");
      Assert.AreEqual(newPatron1, newPatron2);
    }

    [TestMethod]
    public void GetAll_PatronsEmptyAtFirst_List()
    {
      int result = Patron.GetAll().Count;
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllPatrons_PatronList()
    {
      Patron newPatron1 = new Patron("test1", "#");
      Patron newPatron2 = new Patron("test2", "#");
      newPatron1.Save();
      newPatron2.Save();
      List<Patron> result = Patron.GetAll();
      List<Patron> newList = new List<Patron> { newPatron1, newPatron2 };
      CollectionAssert.AreEqual(result, newList);
    }

    [TestMethod]
    public void Find_ReturnsPatronInDataBase_Patron()
    {
      Patron testPatron = new Patron("test", "#");
      testPatron.Save();
      Patron foundPatron = Patron.Find(testPatron.GetId());
      Assert.AreEqual(testPatron, foundPatron);
    }

    [TestMethod]
    public void GetBooks_ReturnsAllPatronBooks_BookList()
    {
      //Arrange
      Patron testPatron = new Patron("Mo", "#");
      testPatron.Save();
      Book testBook1 = new Book("Home");
      testBook1.Save();
      Book testBook2 = new Book("Work");
      testBook2.Save();

      //Act
      testPatron.AddBook(testBook1);
      List<Book> result = testPatron.GetBooks();
      List<Book> testList = new List<Book> {testBook1};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void AddBook_AddsBookToPatron_BookList()
    {
      //Arrange
      Patron testPatron = new Patron("Mo", "#");
      testPatron.Save();
      Book testBook = new Book("Homef");
      testBook.Save();

      //Act
      testPatron.AddBook(testBook);

      List<Book> result = testPatron.GetBooks();
      List<Book> testList = new List<Book>{testBook};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

  }
}
