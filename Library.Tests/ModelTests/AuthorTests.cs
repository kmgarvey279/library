using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.Models;
using System.Collections.Generic;
using System;

namespace Library.TestTools
{
  [TestClass]
  public class AuthorTest : IDisposable
  {
    public AuthorTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=library_test;";
    }

    public void Dispose()
    {
      Author.ClearAll();
    }

    [TestMethod]
    public void AuthorCounstructor_CreatesNewInstanceOfObject_Author()
    {
      Author newAuthor = new Author("title");
      Assert.AreEqual(typeof(Author), newAuthor.GetType());
    }

    [TestMethod]
    public void Save_SavesAuthorToDatabase_Author()
    {
      Author testAuthor = new Author("test");
      testAuthor.Save();
      List<Author> result = Author.GetAll();
      List<Author> testList = new List<Author>{testAuthor};
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToAuthor_Id()
    {
      Author testAuthor = new Author("name");
      testAuthor.Save();
      Author savedAuthor = Author.GetAll()[0];
      int result = savedAuthor.GetId();
      int testId = testAuthor.GetId();
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfArgumentsAreTheSame_Author()
    {
      Author newAuthor1 = new Author("test");
      Author newAuthor2 = new Author("test");
      Assert.AreEqual(newAuthor1, newAuthor2);
    }

    [TestMethod]
    public void GetAll_AuthorsEmptyAtFirst_List()
    {
      int result = Author.GetAll().Count;
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllAuthors_AuthorList()
    {
      Author newAuthor1 = new Author("test1");
      Author newAuthor2 = new Author("test2");
      newAuthor1.Save();
      newAuthor2.Save();
      List<Author> result = Author.GetAll();
      List<Author> newList = new List<Author> { newAuthor1, newAuthor2 };
      CollectionAssert.AreEqual(result, newList);
    }

    [TestMethod]
    public void Find_ReturnsAuthorInDataBase_Author()
    {
      Author testAuthor = new Author("test");
      testAuthor.Save();
      Author foundAuthor = Author.Find(testAuthor.GetId());
      Assert.AreEqual(testAuthor, foundAuthor);
    }

    [TestMethod]
    public void GetBooks_ReturnsAllAuthorBooks_BookList()
    {
      //Arrange
      Author testAuthor = new Author("Mo");
      testAuthor.Save();
      Book testBook1 = new Book("Home");
      testBook1.Save();
      Book testBook2 = new Book("Work");
      testBook2.Save();

      //Act
      testAuthor.AddBook(testBook1);
      List<Book> result = testAuthor.GetBooks();
      List<Book> testList = new List<Book> {testBook1};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void AddBook_AddsBookToAuthor_BookList()
    {
      //Arrange
      Author testAuthor = new Author("Mo");
      testAuthor.Save();
      Book testBook = new Book("Homef");
      testBook.Save();

      //Act
      testAuthor.AddBook(testBook);

      List<Book> result = testAuthor.GetBooks();
      List<Book> testList = new List<Book>{testBook};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

  }
}
