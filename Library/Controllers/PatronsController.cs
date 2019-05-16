using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;

namespace Library.Controllers
{
  public class PatronsController : Controller
  {

    [HttpGet("/patrons")]
    public ActionResult Index()
    {
      List<Patron> allPatrons = Patron.GetAll();
      return View(allPatrons);
    }

    [HttpGet("/patrons/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/patrons")]
    public ActionResult Create(string name, string phoneNumber)
    {
      Patron newPatron = new Patron(name, phoneNumber);
      newPatron.Save();
      List<Patron> allPatrons = Patron.GetAll();
      return View("Index", allPatrons);
    }

    [HttpGet("/patrons/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Patron selectedPatron = Patron.Find(id);
      List<Book> patronBooks = selectedPatron.GetBooks();
      List<Book> allBooks = Book.GetAll();
      model.Add("selectedPatron", selectedPatron);
      model.Add("patronBooks", patronBooks);
      model.Add("allBooks", allBooks);
      return View(model);
    }

    [HttpPost("/patrons/{patronId}/books/new")]
    public ActionResult AddBook(int patronId, int bookId)
    {
      Patron patron = Patron.Find(patronId);
      Book book = Book.Find(bookId);
      patron.AddBook(book);
      return RedirectToAction("Show", new { id = patronId });
    }

    [HttpGet("/patrons/{patronId}/delete")]
    public ActionResult Delete(int patronId)
    {
      Patron newPatron = Patron.Find(patronId);
      newPatron.Delete();
      return RedirectToAction("Index");
    }

    [HttpGet("/patrons/{patronId}/edit")]
    public ActionResult Edit(int patronId)
    {
      Patron newPatron = Patron.Find(patronId);
      return View(newPatron);
    }

    [HttpPost("/patrons/{patronId}/edit")]
    public ActionResult Update(int patronId, string name, string number)
    {
    Patron newPatron = Patron.Find(patronId);
    newPatron.Edit(name, number);
    return RedirectToAction("Index");
    }

  }
}
