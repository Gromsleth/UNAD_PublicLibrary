using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicLibrary.Presentation
{
    public class View
    {
        readonly List<string> _options;

        public View()
        {
            _options = new List<string>();
        }

        void DrawInterface(bool bRead = false)
        {
            Console.Clear();
            Console.WriteLine("    ************************************");
            Console.WriteLine("    *****    Biblioteca pública    *****");
            Console.WriteLine("    ************************************");
            Console.WriteLine("    *                                  *");
            foreach (var item in _options)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("    ************************************\n");
            if (bRead)
            {
                Console.Write("    Ingrese una opción:  ");
            }
        }

        public string MainMenu()
        {
            _options.Clear();
            _options.Add("    * Menú principal.                  *");
            _options.Add("    *                                  *");
            _options.Add("    *   1. Registro de libros.         *");
            _options.Add("    *   2. Imprimir Listado de libros. *");
            _options.Add("    *                                  *");
            _options.Add("    *   0. Guardar y Salir.            *");
            _options.Add("    *                                  *");
            DrawInterface(true);
            var rta = Console.ReadKey(true).KeyChar.ToString();
            return rta;
        }

        public void NegativeValues()
        {
            _options.Add(" Por favor ingrese valores que no sean negativos ");
            _options.Add(" presione cualquier tecla para continuar. \n");
            DrawInterface();
        }

        public void InvalidOption()
        {
            _options.Add(" Por favor ingrese una opción válida ");
            _options.Add(" presione cualquier tecla para continuar. \n");
            DrawInterface();
        }

        public void ValueError()
        {
            _options.Add(" Por favor ingrese un valor entero valido ");
            _options.Add(" presione cualquier tecla para continuar. \n");
            DrawInterface();
        }

        public void Exit()
        {
            _options.Add(" Fin del programa. \n");
            DrawInterface();
        }
    }
}
