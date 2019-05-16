using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.Models;
using System.Collections.Generic;
using System;

namespace Library.TestTools
{
  [TestClass]
  public class BookTest : IDisposable
  {
    public BookTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=library_test;";
    }

    public void Dispose()
    {
      Book.ClearAll();
    }

    [TestMethod]
    public void BookCounstructor_CreatesNewInstanceOfObject_Book()
    {
      Book newBook = new Book("title");
      Assert.AreEqual(typeof(Book), newBook.GetType());
    }

    [TestMethod]
    public void Save_SavesBookToDatabase_Book()
    {
      Book testBook = new Book("test");
      testBook.Save();
      List<Book> result = Book.GetAll();
      List<Book> testList = new List<Book>{testBook};
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToBook_Id()
    {
      Book testBook = new Book("name");
      testBook.Save();
      Book savedBook = Book.GetAll()[0];
      int result = savedBook.GetId();
      int testId = testBook.GetId();
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfArgumentsAreTheSame_Book()
    {
      Book newBook1 = new Book("test");
      Book newBook2 = new Book("test");
      Assert.AreEqual(newBook1, newBook2);
    }

    [TestMethod]
    public void GetAll_BooksEmptyAtFirst_List()
    {
      int result = Book.GetAll().Count;
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllBooks_BookList()
    {
      Book newBook1 = new Book("test1");
      Book newBook2 = new Book("test2");
      newBook1.Save();
      newBook2.Save();
      List<Book> result = Book.GetAll();
      List<Book> newList = new List<Book> { newBook1, newBook2 };
      CollectionAssert.AreEqual(result, newList);
    }

    [TestMethod]
    public void Find_ReturnsBookInDataBase_Book()
    {
      Book testBook = new Book("test");
      testBook.Save();
      Book foundBook = Book.Find(testBook.GetId());
      Assert.AreEqual(testBook, foundBook);
    }

    [TestMethod]
    public void Test_AddAuthor_AddsAuthorToBook()
    {
    //Arrange
    Book testBook = new Book("name");
    testBook.Save();
    Author testAuthor = new Author("name");
    testAuthor.Save();
    Author testAuthor2 = new Author("name");
    testAuthor2.Save();

    //Act
    testBook.AddAuthor(testAuthor);
    testBook.AddAuthor(testAuthor2);
    List<Author> result = testBook.GetAuthors();
    List<Author> testList = new List<Author>{testAuthor, testAuthor2};

    //Assert
    CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetAuthors_ReturnsAllBookAuthors_AuthorList()
    {
    //Arrange
    Book testBook = new Book("name");
    testBook.Save();
    Author testAuthor1 = new Author("name");
    testAuthor1.Save();
    Author testAuthor2 = new Author("name");
    testAuthor2.Save();

    //Act
    testBook.AddAuthor(testAuthor1);
    List<Author> savedAuthors = testBook.GetAuthors();
    List<Author> testList = new List<Author> {testAuthor1};

    //Assert
    CollectionAssert.AreEqual(testList, savedAuthors);
    }

    [TestMethod]
    public void Test_AddPatron_AddsPatronToBook()
    {
    //Arrange
    Book testBook = new Book("name");
    testBook.Save();
    Patron testPatron = new Patron("name", "#");
    testPatron.Save();
    Patron testPatron2 = new Patron("name", "#");
    testPatron2.Save();

    //Act
    testBook.AddPatron(testPatron);
    testBook.AddPatron(testPatron2);
    List<Patron> result = testBook.GetPatrons();
    List<Patron> testList = new List<Patron>{testPatron, testPatron2};

    //Assert
    CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetPatrons_ReturnsAllBookPatrons_PatronList()
    {
    //Arrange
    Book testBook = new Book("name");
    testBook.Save();
    Patron testPatron1 = new Patron("name", "#");
    testPatron1.Save();
    Patron testPatron2 = new Patron("name", "#");
    testPatron2.Save();

    //Act
    testBook.AddPatron(testPatron1);
    List<Patron> savedPatrons = testBook.GetPatrons();
    List<Patron> testList = new List<Patron> {testPatron1};

    //Assert
    CollectionAssert.AreEqual(testList, savedPatrons);
    }

    [TestMethod]
    public void Delete_DeletesBookAssociationsWithAuthorsFromDatabase_BookList()
    {
      Book testBook = new Book("test");
      testBook.Save();
      Author testAuthor = new Author("test");
      testAuthor.Save();
      testBook.AddAuthor(testAuthor);
      testBook.Delete();
      List<Book> resultAuthorBooks = testAuthor.GetBooks();
      List<Book> testAuthorBooks = new List<Book> {};
      CollectionAssert.AreEqual(resultAuthorBooks, testAuthorBooks);
    }

    [TestMethod]
    public void Delete_DeletesBookAssociationsWithPatronsFromDatabase_BookList()
    {
      Book testBook = new Book("test");
      testBook.Save();
      Patron testPatron = new Patron("test", "#");
      testPatron.Save();
      testBook.AddPatron(testPatron);
      testBook.Delete();
      List<Book> resultBookPatrons = testPatron.GetBooks();
      List<Book> testBookPatrons = new List<Book> {};
      CollectionAssert.AreEqual(resultBookPatrons, testBookPatrons);
    }

  }
}
