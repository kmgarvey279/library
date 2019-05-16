using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Library.Models
{
  public class Book
  {
    private string _title;
    private int _id;

    public Book(string title, int id = 0)
    {
      _title = title;
      _id = id;
    }

    public string GetTitle()
    {
      return _title;
    }


    public int GetId()
    {
      return _id;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM books;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if ( conn != null)
      {
        conn.Dispose();
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO books (book_title) VALUES (@bookTitle);";
      MySqlParameter bookTitle = new MySqlParameter();
      bookTitle.ParameterName = "@bookTitle";
      bookTitle.Value = this._title;
      cmd.Parameters.Add(bookTitle);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Book> GetAll()
    {
      List<Book> allBooks = new List<Book>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM books;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int BookId = rdr.GetInt32(0);
        string BookTitle = rdr.GetString(1);
        Book newBook = new Book(BookTitle, BookId);
        allBooks.Add(newBook);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return allBooks;
    }

    public override bool Equals(System.Object otherBook)
    {
      if(!(otherBook is Book))
      {
        return false;
      }
      else
      {
        Book newBook = (Book) otherBook;
        bool idEquality = this.GetId().Equals(newBook.GetId());
        bool titleEquality = this.GetTitle().Equals(newBook.GetTitle());
        return (idEquality && titleEquality);
      }
    }

    public static Book Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM books WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int BookId = 0;
      string BookTitle = "";
      while(rdr.Read())
      {
        BookId = rdr.GetInt32(0);
        BookTitle = rdr.GetString(1);
      }
      Book newBook = new Book(BookTitle, BookId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newBook;
    }

    public void AddAuthor(Author newAuthor)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO authors_books (author_id, book_id) VALUES (@authorId, @bookId);";
      MySqlParameter authorIdParameter = new MySqlParameter();
      authorIdParameter.ParameterName = "@authorId";
      authorIdParameter.Value = newAuthor.GetId();
      cmd.Parameters.Add(authorIdParameter);
      MySqlParameter bookIdParameter = new MySqlParameter();
      bookIdParameter.ParameterName = "@bookId";
      bookIdParameter.Value = _id;
      cmd.Parameters.Add(bookIdParameter);
      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<Author> GetAuthors()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT author_id FROM authors_books WHERE book_id = @BookId;";
      MySqlParameter bookIdParameter = new MySqlParameter();
      bookIdParameter.ParameterName = "@BookId";
      bookIdParameter.Value = _id;
      cmd.Parameters.Add(bookIdParameter);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<int> authorIds = new List<int>{};
      while(rdr.Read())
      {
        int authorId = rdr.GetInt32(0);
        authorIds.Add(authorId);
      }
      rdr.Dispose();
      List<Author> authors = new List<Author> {};
      foreach (int authorId in authorIds)
      {
        var authorQuery = conn.CreateCommand() as MySqlCommand;
        authorQuery.CommandText = @"SELECT * FROM authors WHERE id = @AuthorId;";
        MySqlParameter authorIdParameter = new MySqlParameter();
        authorIdParameter.ParameterName = "@AuthorId";
        authorIdParameter.Value = authorId;
        authorQuery.Parameters.Add(authorIdParameter);
        var authorQueryRdr = authorQuery.ExecuteReader() as MySqlDataReader;
        while(authorQueryRdr.Read())
        {
          int thisAuthorId = authorQueryRdr.GetInt32(0);
          string authorName = authorQueryRdr.GetString(1);
          Author foundAuthor = new Author(authorName, thisAuthorId);
          authors.Add(foundAuthor);
        }
        authorQueryRdr.Dispose();
      }
      conn.Close();
      if (conn != null)
      {
      conn.Dispose();
      }
      return authors;
    }

    public void AddPatron(Patron newPatron)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO checkouts (patron_id, book_id) VALUES (@patronId, @bookId);";
      MySqlParameter patronIdParameter = new MySqlParameter();
      patronIdParameter.ParameterName = "@patronId";
      patronIdParameter.Value = newPatron.GetId();
      cmd.Parameters.Add(patronIdParameter);
      MySqlParameter bookIdParameter = new MySqlParameter();
      bookIdParameter.ParameterName = "@bookId";
      bookIdParameter.Value = _id;
      cmd.Parameters.Add(bookIdParameter);
      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<Patron> GetPatrons()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT patron_id FROM checkouts WHERE book_id = @BookId;";
      MySqlParameter bookIdParameter = new MySqlParameter();
      bookIdParameter.ParameterName = "@BookId";
      bookIdParameter.Value = _id;
      cmd.Parameters.Add(bookIdParameter);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<int> patronIds = new List<int>{};
      while(rdr.Read())
      {
        int patronId = rdr.GetInt32(0);
        patronIds.Add(patronId);
      }
      rdr.Dispose();
      List<Patron> patrons = new List<Patron> {};
      foreach (int patronId in patronIds)
      {
        var patronQuery = conn.CreateCommand() as MySqlCommand;
        patronQuery.CommandText = @"SELECT * FROM patrons WHERE id = @PatronId;";
        MySqlParameter patronIdParameter = new MySqlParameter();
        patronIdParameter.ParameterName = "@PatronId";
        patronIdParameter.Value = patronId;
        patronQuery.Parameters.Add(patronIdParameter);
        var patronQueryRdr = patronQuery.ExecuteReader() as MySqlDataReader;
        while(patronQueryRdr.Read())
        {
          int thisPatronId = patronQueryRdr.GetInt32(0);
          string patronName = patronQueryRdr.GetString(1);
          string patronNumber = patronQueryRdr.GetString(2);
          Patron foundPatron = new Patron(patronName, patronNumber, thisPatronId);
          patrons.Add(foundPatron);
        }
        patronQueryRdr.Dispose();
      }
      conn.Close();
      if (conn != null)
      {
      conn.Dispose();
      }
      return patrons;
    }

    public void Delete()
   {
     MySqlConnection conn = DB.Connection();
     conn.Open();
     MySqlCommand cmd = new MySqlCommand("DELETE FROM books WHERE id = @BookId; DELETE FROM checkouts WHERE book_id = @BookId; DELETE FROM authors_books WHERE book_id = @BookId", conn);
     MySqlParameter bookIdParameter = new MySqlParameter();
     bookIdParameter.ParameterName = "@BookId";
     bookIdParameter.Value = this.GetId();
     cmd.Parameters.Add(bookIdParameter);
     cmd.ExecuteNonQuery();
     if (conn != null)
     {
       conn.Close();
     }
   }

  }
}
