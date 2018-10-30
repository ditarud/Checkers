using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea1
{
    public class InvalidPositionException : Exception
    {
        private string advice;
        public InvalidPositionException()
        {
            advice = "Posición invalida";
        }

        public string Advice
        {
            get
            {
                return advice;
            }

            set
            {
                advice = value;
            }
        }
    }
}
