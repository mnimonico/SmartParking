using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ProjetoSmartParking.Utils
{
    public class ValidaCPF
    {

        public static bool VerificaCpf(String cpf)

        {

            if (Regex.IsMatch(cpf, @"(^(\d{3}.\d{3}.\d{3}-\d{2})$)"))

            {

                return ValidaCpf(cpf);

            }

            else

            {

                return false;

            }

        }
        public static bool ValidaCpf(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");
            switch (cpf)
            {
                case "11111111111":
                    return false;
                case "22222222222":
                    return false;
                case "33333333333":
                    return false;
                case "44444444444":
                    return false;
                case "55555555555":
                    return false;
                case "66666666666":
                    return false;
                case "77777777777":
                    return false;
                case "88888888888":
                    return false;
                case "99999999999":
                    return false;
                default:
                    break;
            }
            if (cpf.Length != 11)
            {
                return false;
            }

            char[] vetor = cpf.ToCharArray();
            int peso = 10, soma = 0, digito1, digito2;

            //Digito 1
            for (int i = 0; i < 9; i++)
            {
                int mult = Convert.ToInt32(vetor[i].ToString()) * peso;
                soma += mult;
                peso--;
            }
            if (soma % 11 < 2)
            {
                digito1 = 0;
            }
            else
            {
                digito1 = 11 - (soma % 11);
            }

            //Digito 2
            peso = 11;
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                int mult = Convert.ToInt32(vetor[i].ToString()) * peso;
                soma += mult;
                peso--;
            }
            if (soma % 11 < 2)
            {
                digito2 = 0;
            }
            else
            {
                digito2 = 11 - (soma % 11);
            }
            //Comparação dos digitos
            if (Convert.ToInt32(vetor[9].ToString()) == digito1 &&
                Convert.ToInt32(vetor[10].ToString()) == digito2)
            {
                return true;
            }
            return false;
        }
    }
}
