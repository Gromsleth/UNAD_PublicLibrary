using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PublicLibrary.Entities;
using PublicLibrary.Data;

namespace PublicLibrary.Application
{
    public class Controller
    {
        readonly View _UI;
        bool bErr = false;
        bool bNoBook = false;
        bool ini = true;
        int iAux;
        Book bookToInsert;
        DataAccess _DA;
        string rta;
        List<Book> FilteredList;

        public Controller()
        {
            _UI = new View();
            _DA = new DataAccess();
            bookToInsert = new Book();
            FilteredList = new List<Book>();
        }

        public void Execute()
        {
            do
            {
                switch (MainMenu(bErr))
                {
                    case 0: //Salir
                        ini = false;
                        break;
                    case 1: //Registro de libros
                        ini = InsertBook();
                        break;
                    case 2: //Imprimir Listado de libros
                        ini = BookList();
                        break;
                    case 3: //Ordenar los libros por cantidad de mayor a menor
                        ini = HighToLow();
                        break;
                    case 4: //Ordenar los libros por cantidad de menor a mayor
                        ini = LowToHigh();
                        break;
                    case 5: //Consultar por autor
                        ini = BookByAuthor();
                        break;
                    default:
                        bErr = true;
                        break;
                }

            } while (ini);

            _DA.SaveData();
            _UI.Exit();
        }

        #region private        

        private bool InsertBook()
        {
            bookToInsert = new Book();

            do //Capturar referencia 
            {
                ini = true;
                if (!bErr)
                    iAux = 0;
                bookToInsert.ReferenceId = 0;
                _UI.IsertBook(0, iAux);
                rta = Console.ReadLine().Trim().ToUpper();

                if (rta == "E")
                    return false;
                if (rta == "R")
                    return true;

                iAux = ReadValue(rta);
                if (iAux > 0)
                {
                    bookToInsert.ReferenceId = iAux;
                    ini = false;
                }
            } while (ini);

            do //Capturar cantidad
            {
                ini = true;
                if (!bErr)
                    iAux = 0;
                bookToInsert.Quantity = 0;
                _UI.IsertBook(1, iAux, bookToInsert);
                rta = Console.ReadLine().Trim().ToUpper();

                if (rta == "E")
                    return false;
                if (rta == "R")
                    return true;

                iAux = ReadValue(rta);
                if (iAux >= 0)
                {
                    bookToInsert.Quantity = iAux;
                    ini = false;
                }
            } while (ini);

            do //Capturar el titulo
            {
                ini = true;
                if (!bErr)
                    iAux = 0;
                bErr = false;
                bookToInsert.Title = string.Empty;
                _UI.IsertBook(2, iAux, bookToInsert);
                rta = Console.ReadLine().Trim().ToUpper();

                if (rta == "E")
                    return false;
                if (rta == "R")
                    return true;

                if (rta.Length < 1)
                {
                    iAux = -3;
                    bErr = true;
                }
                else if (rta.Length > 50)
                {
                    iAux = -4;
                    bErr = true;
                }
                else
                {
                    bookToInsert.Title = rta;
                    ini = false;
                }
            } while (ini);

            do //Capturar el autor
            {
                ini = true;
                if (!bErr)
                    iAux = 0;
                bErr = false;
                bookToInsert.Author = string.Empty;
                _UI.IsertBook(3, iAux, bookToInsert);
                rta = Console.ReadLine().Trim().ToUpper();

                if (rta == "E")
                    return false;
                if (rta == "R")
                    return true;

                if (rta.Length < 1)
                {
                    iAux = -3;
                    bErr = true;
                }
                else if (rta.Length > 50)
                {
                    iAux = -4;
                    bErr = true;
                }
                else
                {
                    bookToInsert.Author = rta;
                    ini = false;
                }
            } while (ini);

            _DA.InsertBook(bookToInsert);
            _UI.IsertBook(4, 0, bookToInsert);
            Console.ReadLine();

            return true;
        }

        public bool BookList()
        {
            if (_DA.GetBooks().Count == 0)
                bNoBook = true;

            _UI.GetBookList(_DA.GetBooks(), 0);
            return true;
        }

        public bool HighToLow()
        {
            if (_DA.GetBooks().Count == 0)
                bNoBook = true;
            
            _UI.GetBookList(_DA.GetBooks().OrderByDescending(order => order.Quantity).ToList(), 1);
            return true;
        }

        public bool LowToHigh()
        {
            if (_DA.GetBooks().Count == 0)
                bNoBook = true;

            _UI.GetBookList(_DA.GetBooks().OrderBy(order => order.Quantity).ToList(), 2);
            return true;
        }

        public bool BookByAuthor()
        {
            iAux = 0;

            if (_DA.GetBooks().Count == 0)
                bNoBook = true;

            do
            {
                FilteredList.Clear();
                ini = true;
                _UI.FilterAuthor(iAux);
                rta = Console.ReadLine().Trim().ToUpper();

                if (rta == "E")
                    return false;
                if (rta == "R")
                    return true;

                if (rta.Length > 1)
                {
                    foreach (var book in _DA.GetBooks()
                          .OrderBy(s => s.Author)
                          .ToList())
                    {
                        if (book.Author.ToUpper().Contains(rta.ToUpper()))
                            FilteredList.Add(book);
                    }

                    if (FilteredList.Count > 0)
                    {
                        //ini = false;
                        _UI.GetBookList(FilteredList.OrderBy(order => order.Quantity).ToList(), 3);
                    }
                    else
                        iAux = -2;
                }
                else
                    iAux = -1;

            } while (ini);

            return true;
        }

        /// <summary>
        /// Valida que el valor ingresado sea un entero positivo.
        /// </summary>
        /// <param name="sIn"></param>
        /// <returns>Entero valido o -1</returns> 
        private int ReadValue(string sIn)
        {
            int iAux = -1;
            bErr = false;
            try
            {
                iAux = Convert.ToInt32(sIn);
                if (iAux < 0)
                {
                    bErr = true;
                    return -2;
                }
            }
            catch (Exception)
            {
                bErr = true;
            }

            return iAux;
        }

        private int MainMenu(bool bErr)
        {
            _UI.MainMenu(bErr, bNoBook);
            bNoBook = false;
            string rta = Console.ReadLine().Trim();
            return ReadValue(rta);
        }

        #endregion
    }
}
