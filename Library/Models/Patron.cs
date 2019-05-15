using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Library.Models
{
  public class Patron
  {
    private string _name;
    private string _phoneNumber;
    private int _id;

    public Patron(string name, string phoneNumber, int id = 0)
    {
      _name = name;
      _phoneNumber = phoneNumber;
      _id = id;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetPhoneNumber()
    {
      return _phoneNumber;
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
      cmd.CommandText = @"DELETE FROM patrons;";
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
      cmd.CommandText = @"INSERT INTO patrons (patron_name, phone_number) VALUES (@patronName, @phoneNumber);";
      MySqlParameter patronName = new MySqlParameter();
      patronName.ParameterName = "@patronName";
      patronName.Value = this._name;
      cmd.Parameters.Add(patronName);
      MySqlParameter phoneNumber = new MySqlParameter();
      phoneNumber.ParameterName = "@phoneNumber";
      phoneNumber.Value = this._phoneNumber;
      cmd.Parameters.Add(phoneNumber);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Patron> GetAll()
    {
      List<Patron> allPatrons = new List<Patron>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM patrons;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int PatronId = rdr.GetInt32(0);
        string PatronName = rdr.GetString(1);
        string PhoneNumber = rdr.GetString(2);
        Patron newPatron = new Patron(PatronName, PhoneNumber, PatronId);
        allPatrons.Add(newPatron);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return allPatrons;
    }

    public override bool Equals(System.Object otherPatron)
    {
      if(!(otherPatron is Patron))
      {
        return false;
      }
      else
      {
        Patron newPatron = (Patron) otherPatron;
        bool idEquality = this.GetId().Equals(newPatron.GetId());
        bool nameEquality = this.GetName().Equals(newPatron.GetName());
        bool phoneEquality = this.GetPhoneNumber().Equals(newPatron.GetPhoneNumber());
        return (idEquality && nameEquality && phoneEquality);
      }
    }

    public static Patron Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM patrons WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int PatronId = 0;
      string PatronName = "";
      string PhoneNumber = "";
      while(rdr.Read())
      {
        PatronId = rdr.GetInt32(0);
        PatronName = rdr.GetString(1);
        PhoneNumber = rdr.GetString(2);
      }
      Patron newPatron = new Patron(PatronName, PhoneNumber, PatronId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newPatron;
    }

    public List<Book> GetBooks()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT book_id FROM checkouts WHERE patron_id = @patronId;";
      MySqlParameter patronIdParameter = new MySqlParameter();
      patronIdParameter.ParameterName = "@patronId";
      patronIdParameter.Value = _id;
      cmd.Parameters.Add(patronIdParameter);
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
       cmd.CommandText = @"INSERT INTO checkouts (book_id, patron_id) VALUES (@BookId, @PatronId);";
       MySqlParameter book_id = new MySqlParameter();
       book_id.ParameterName = "@BookId";
       book_id.Value = newBook.GetId();
       cmd.Parameters.Add(book_id);
       MySqlParameter patron_id = new MySqlParameter();
       patron_id.ParameterName = "@PatronId";
       patron_id.Value = _id;
       cmd.Parameters.Add(patron_id);
       cmd.ExecuteNonQuery();
       conn.Close();
       if (conn != null)
       {
         conn.Dispose();
       }
     }


  }
}
