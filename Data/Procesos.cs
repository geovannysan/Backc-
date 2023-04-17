using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backrest.Data
{
    public class Procesos
    {
        public string Obtenertoken(string operador)
        {
            switch (operador)
            {
                case "0941089492":

                    return "NXJzUzNRNGljN0JOOWRpK252QXFzdz09";
                case "0930570395":

                    return "UThDZ05vd2NkQzV1STVhV0lyeitpUT09";
                case "0999999999":

                    return "T1lQWkh0MW8rTkwyUm9PeU03N2UzUT09";
                case "0926653197":

                    return "Q3QzcXd2NDRCUVRWRzZKL1RoaFFkZz09";
                case "0925474942":

                    return "SHUvNnI3RlVDQXhBamFMMVloaXpyUT09";
                default:

                    return "";
            }
        }
    }
}
