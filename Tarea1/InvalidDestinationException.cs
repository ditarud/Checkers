using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea1
{
    public class InvalidDestinationException : Exception
    {
        private string advice;
        public InvalidDestinationException()
        {
            advice = "Destino invalido";
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
