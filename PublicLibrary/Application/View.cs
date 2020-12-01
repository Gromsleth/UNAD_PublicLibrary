using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PublicLibrary.Entities;

namespace PublicLibrary.Application
{
    public class View
    {
        readonly List<string> _options;
        readonly List<string> _request;
        string sAux = string.Empty;

        public View()
        {
            _options = new List<string>();
            _request = new List<string>();
        }

        void DrawInterface()
        {
            Console.Clear();
            Console.WriteLine("    **************************************************************************");
            Console.WriteLine("    **************************  Biblioteca pública  **************************");
            Console.WriteLine("    **************************************************************************");
            Console.WriteLine("    **                                                                      **");
            foreach (var item in _options)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("    **************************************************************************");
            Console.WriteLine("    **************************************************************************\n");
            if (_request.Count > 0)
            {
                foreach (var item in _request)
                {
                    Console.Write(item);
                }
            }
            sAux = string.Empty;
        }

        public void MainMenu(bool err, bool noBook = false)
        {
            Console.WindowWidth = 120;

            _options.Clear();
            _options.Add("    ** Menú principal.                                                      **");
            _options.Add("    **                                                                      **");
            _options.Add("    **   1. Registro de libros.                                             **");
            _options.Add("    **   2. Imprimir Listado de libros.                                     **");
            _options.Add("    **                                                                      **");
            _options.Add("    **   0. Guardar y Salir.                                                **");
            _options.Add("    **                                                                      **");

            _request.Clear();
            if (err)
                _request.Add("    ¡Por favor ingrese una opción válida¡ \n");
            else
                if (noBook)
                    _request.Add("    ¡No hay libros registrados¡ \n");
            _request.Add("    Ingrese una opción:  ");

            DrawInterface();
        }

        public void IsertBook(int option, int iErr = 0, Book refBook = null)
        {
            _options.Clear();
            _options.Add("    ** Registro de libros.                                                  **");
            _options.Add("    **                                                                      **");
            switch (option)
            {
                case 0:
                    _options.Add("    ** Por favor ingrese el código de referencia                            **");
                    sAux = "    Código de referencia: ";
                    break;
                case 1:
                    _options.Add(string.Format("    ** Referencia:                                            {0}    **", refBook.ReferenceId.ToString().PadLeft(10, ' ')));
                    _options.Add("    **                                                                      **");
                    _options.Add("    **                                                                      **");
                    _options.Add("    ** Por favor ingrese la cantidad                                        **");
                    sAux = "    Cantidad: ";
                    break;
                case 2:
                    _options.Add(string.Format("    ** Referencia:                                            {0}    **", refBook.ReferenceId.ToString().PadLeft(10, ' ')));
                    _options.Add(string.Format("    ** Cantidad:                                              {0}    **", refBook.Quantity.ToString().PadLeft(10, ' ')));
                    _options.Add("    **                                                                      **");
                    _options.Add("    **                                                                      **");
                    _options.Add("    ** Por favor ingrese el título                                          **");
                    sAux = "    Título: ";
                    break;
                case 3:
                    _options.Add(string.Format("    ** Referencia:                                            {0}    **", refBook.ReferenceId.ToString().PadLeft(10, ' ')));
                    _options.Add(string.Format("    ** Cantidad:                                              {0}    **", refBook.Quantity.ToString().PadLeft(10, ' ')));
                    _options.Add(string.Format("    ** Título:        {0}    **", refBook.Title.PadLeft(50, ' ')));
                    _options.Add("    **                                                                      **");
                    _options.Add("    **                                                                      **");
                    _options.Add("    ** Por favor ingrese el autor                                           **");
                    sAux = "    Autor: ";
                    break;
                case 4:
                    _options.Add(string.Format("    ** Referencia:                                            {0}    **", refBook.ReferenceId.ToString().PadLeft(10, ' ')));
                    _options.Add(string.Format("    ** Cantidad:                                              {0}    **", refBook.Quantity.ToString().PadLeft(10, ' ')));
                    _options.Add(string.Format("    ** Título:        {0}    **", refBook.Title.PadLeft(50, ' ')));
                    _options.Add(string.Format("    ** Autor:         {0}    **", refBook.Author.PadLeft(50, ' ')));
                    _options.Add("    **                                                                      **");
                    _options.Add("    **                                                                      **");
                    _options.Add("    ** Registro guardado.                                                   **");
                    sAux = string.Empty;
                    break;
                default:
                    break;
            }
            if (option == 4)
                _options.Add("    ** Presione cualquier tecla para continuar:                             **");
            else
            {
                _options.Add("    **                                                                      **");
                _options.Add("    ** o presione:                                                          **");
                _options.Add("    ** 'E' para salir                                                       **");
                _options.Add("    ** 'R' para volver                                                      **");
            }
            _options.Add("    **                                                                      **");

            _request.Clear();
            switch (iErr)
            {
                case -1: //Valor incorrecto
                    _request.Add("    ¡Por favor ingrese un valor entero valido¡ \n");
                    break;
                case -2: //Valor Negativo
                    _request.Add("    ¡Por favor ingrese valores que no sean negativos¡ \n");
                    break;
                case -3: //Sin ingresar
                    _request.Add(string.Format("    ¡Por favor ingrese {0}¡ \n", sAux.Replace(":", "").Trim()));
                    break;
                case -4: //Cadena superior a 50 caracteres
                    _request.Add(string.Format("    ¡El {0} no puede contener más de 50 caracteres¡ \n", sAux.Replace(":", "").Trim()));
                    break;
                default:
                    break;
            }
            _request.Add(sAux);

            DrawInterface();
        }

        public void GetBookList(List<Book> books)
        {
            Console.WindowWidth = 140;
            string ReferenceId = "Referencia";
            string Quantity = "Cantidad";
            string Title = "Título";
            string Author = "Autor";
            string sAuxSep = "-";
            //string sAuxSep2 = "_";
            _options.Clear();
            _request.Clear();
            _options.Add("    ** Listado de Libros                                                    **");
            _options.Add("    **                                                                      **");
            _options.Add("    ** Presione cualquier tecla para continuar:                             **");
            _options.Add("    **                                                                      **");
            _request.Add(String.Format(" | {0} | {1} | {2} | {3} |\n", ReferenceId.PadLeft(10, ' '), Quantity.PadLeft(10, ' '), Title.PadLeft(50, ' '), Author.PadLeft(50, ' ')));
            _request.Add(String.Format(" | {0} | {0} | {1} | {1} |\n", sAuxSep.PadLeft(10, '-'),  sAuxSep.PadLeft(50, '-')));
            foreach (var book in books)
            {
                _request.Add(book.ForList());
            }
            _request.Add(String.Format(" | {0} | {0} | {1} | {1} |\n", sAuxSep.PadLeft(10, '-'), sAuxSep.PadLeft(50, '-')));
            //_request.Add(String.Format(" | {0} | {0} | {1} | {1} |\n", sAuxSep2.PadLeft(10, '_'), sAuxSep2.PadLeft(50, '_')));
            DrawInterface();
            Console.ReadKey();
        }

        public void Exit()
        {
            _options.Clear();
            _request.Clear();
            _options.Add("    ** Fin del programa.                                                    **");
            _options.Add("    **                                                                      **");
            _options.Add("    ** Desarrollado por Sergio Cedeño.                                      **");
            _options.Add("    **                                                                      **");
            DrawInterface();
            Console.ReadKey();
        }
    }
}
