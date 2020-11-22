using PublicLibrary.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicLibrary.Presentation
{
    public class Controller
    {
        readonly View _UI;
        readonly Logic _BL;

        public Controller()
        {
            _UI = new View();
            _BL = new Logic();
        }

        public void Execute()
        {
            int ini = 1;
            int iAux;

            do
            {
                //Método para mostrar menu principal
                iAux = ReadValue(_UI.MainMenu());

                switch (iAux)
                {
                    case 0: //Salir
                        ini = 0;
                        break;
                    case 1: //Registro de libros
                        //ini = 
                        break;
                    case 2: //Imprimir Listado de libros
                        //ini = 
                        break;
                    case -1:
                        break;
                    default:
                        _UI.InvalidOption();
                        break;
                }

            } while (ini == 1);

            _UI.Exit();
        }

        #region private
        /// <summary>
        /// Valida que el valor ingresado sea un entero positivo.
        /// </summary>
        /// <param name="sIn"></param>
        /// <returns>Entero valido o -1</returns> 
        private int ReadValue(string sIn)
        {
            int iAux = -1;

            try
            {
                iAux = Convert.ToInt32(sIn);
                if (iAux < 0)
                    _UI.NegativeValues();
            }
            catch (Exception)
            {
                _UI.ValueError();
            }

            return iAux;
        }

        #endregion
    }
}
