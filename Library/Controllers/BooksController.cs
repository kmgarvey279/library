using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;

namespace Library.Controllers
{
  public class BooksController : Controller
  {

    [HttpGet("/books")]
    public ActionResult Index()
    {
      List<Book> allBooks = Book.GetAll();
      return View(allBooks);
    }

    [HttpGet("/books/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/books")]
    public ActionResult Create(string title)
    {
      Book newBook = new Book(title);
      newBook.Save();
      List<Book> allBooks = Book.GetAll();
      return View("Index", allBooks);
    }

    [HttpGet("/books/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Book selectedBook = Book.Find(id);
      List<Author> bookAuthors = selectedBook.GetAuthors();
      List<Author> allAuthors = Author.GetAll();
      model.Add("selectedBook", selectedBook);
      model.Add("bookAuthors", bookAuthors);
      model.Add("allAuthors", allAuthors);
      return View(model);
    }

    [HttpPost("/books/{bookId}/authors/new")]
    public ActionResult AddAuthor(int bookId, int authorId)
    {
      Book book = Book.Find(bookId);
      Author author = Author.Find(authorId);
      book.AddAuthor(author);
      return RedirectToAction("Show", new { id = bookId });
    }

    [HttpGet("/books/{bookId}/delete")]
    public ActionResult Delete(int bookId)
    {
      Book newBook = Book.Find(bookId);
      newBook.Delete();
      return RedirectToAction("Index");
    }
  }
}
