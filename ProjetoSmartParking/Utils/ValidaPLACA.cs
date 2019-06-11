using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ProjetoSmartParking.Utils
{
    public class ValidaPLACA
    {
        public bool ValidaPlaca(string placa)
        {
            Regex Rgx = new Regex(@"^\[a-zA-Z]{3}\-\d{4}$");

            if (Rgx.IsMatch(placa))
                return false;
            else
                return true;
        }
    }
}