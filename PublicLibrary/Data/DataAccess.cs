using System.Collections.Generic;
using System;
using System.IO;
using PublicLibrary.Entities;

namespace PublicLibrary.Data
{
    public class DataAccess
    {
        string path = string.Format("{0}\\DB.txt", Directory.GetCurrentDirectory());
        char[] delimiterChars = { '|' };
        readonly List<Book> _DataBooks;

        public DataAccess()
        {
            _DataBooks = new List<Book>();
            LoadData();
        }

        public void InsertBook(Book book)
        {
            _DataBooks.Add(book);
        }

        public List<Book> GetBooks()
        {
            return _DataBooks;
        }

        public void SaveData()
        {
            try
            {
                File.Delete(path);
                using (StreamWriter writer = new StreamWriter(path, false))
                {
                    foreach (var book in _DataBooks)
                    {
                        writer.WriteLine(book.ForData());
                    }
                }
            }
            catch (Exception)
            {
                File.Delete(path);
            }
        }

        public void LoadData()
        {
            string line;
            string[] delimiteLine;
            try
            {
                if (File.Exists(path))
                    using (StreamReader reader = new StreamReader(path))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            delimiteLine = line.Split(delimiterChars);
                            _DataBooks.Add(new Book { ReferenceId = int.Parse(delimiteLine[0]), Quantity = int.Parse(delimiteLine[1]), Title = delimiteLine[2], Author = delimiteLine[3] });
                        }
                    }
            }
            catch (Exception)
            {
                File.Delete(path);
            }
        }

    }
}
