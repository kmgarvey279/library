using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Library.Models
{
  public class Author
  {
    private string _name;
    private int _id;

    public Author(string name, int id = 0)
    {
      _name = name;
      _id = id;
    }

    public string GetName()
    {
      return _name;
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
      cmd.CommandText = @"DELETE FROM authors;";
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
      cmd.CommandText = @"INSERT INTO authors (author_name) VALUES (@authorName);";
      MySqlParameter authorName = new MySqlParameter();
      authorName.ParameterName = "@authorName";
      authorName.Value = this._name;
      cmd.Parameters.Add(authorName);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Author> GetAll()
    {
      List<Author> allAuthors = new List<Author>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM authors;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int AuthorId = rdr.GetInt32(0);
        string AuthorName = rdr.GetString(1);
        Author newAuthor = new Author(AuthorName, AuthorId);
        allAuthors.Add(newAuthor);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return allAuthors;
    }

    public override bool Equals(System.Object otherAuthor)
    {
      if(!(otherAuthor is Author))
      {
        return false;
      }
      else
      {
        Author newAuthor = (Author) otherAuthor;
        bool idEquality = this.GetId().Equals(newAuthor.GetId());
        bool nameEquality = this.GetName().Equals(newAuthor.GetName());
        return (idEquality && nameEquality);
      }
    }

    public static Author Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM authors WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int AuthorId = 0;
      string AuthorName = "";
      while(rdr.Read())
      {
        AuthorId = rdr.GetInt32(0);
        AuthorName = rdr.GetString(1);
      }
      Author newAuthor = new Author(AuthorName, AuthorId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newAuthor;
    }

    public List<Book> GetBooks()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT book_id FROM authors_books WHERE author_id = @authorId;";
      MySqlParameter authorIdParameter = new MySqlParameter();
      authorIdParameter.ParameterName = "@authorId";
      authorIdParameter.Value = _id;
      cmd.Parameters.Add(authorIdParameter);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<int> bookIds = new List<int> {};
      while(rdr.Read())
      {
        int bookId = rdr.GetInt32(0);
        bookIds.Add(bookId);
      }
      rdr.Dispose();
      List<Book> books = new List<Book> {};
      foreach (int bookId in bookIds)
      {
        var bookQuery = conn.CreateCommand() as MySqlCommand;
        bookQuery.CommandText = @"SELECT * FROM books WHERE id = @BookId;";
        MySqlParameter bookIdParameter = new MySqlParameter();
        bookIdParameter.ParameterName = "@BookId";
        bookIdParameter.Value = bookId;
        bookQuery.Parameters.Add(bookIdParameter);
        var bookQueryRdr = bookQuery.ExecuteReader() as MySqlDataReader;
        while(bookQueryRdr.Read())
        {
          int thisBookId = bookQueryRdr.GetInt32(0);
          string bookName = bookQueryRdr.GetString(1);
          Book foundBook = new Book(bookName, thisBookId);
          books.Add(foundBook);
        }
        bookQueryRdr.Dispose();
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return books;
    }

    public void AddBook(Book newBook)
     {
       MySqlConnection conn = DB.Connection();
       conn.Open();
       var cmd = conn.CreateCommand() as MySqlCommand;
       cmd.CommandText = @"INSERT INTO authors_books (book_id, author_id) VALUES (@BookId, @AuthorId);";
       MySqlParameter book_id = new MySqlParameter();
       book_id.ParameterName = "@BookId";
       book_id.Value = newBook.GetId();
       cmd.Parameters.Add(book_id);
       MySqlParameter author_id = new MySqlParameter();
       author_id.ParameterName = "@AuthorId";
       author_id.Value = _id;
       cmd.Parameters.Add(author_id);
       cmd.ExecuteNonQuery();
       conn.Close();
       if (conn != null)
       {
         conn.Dispose();
       }
     }

  }
}
