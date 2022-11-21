using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.RequestModels
{
    public class ClientRequestModel : MessageError
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Cpf { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }

        public ClientRequestModel(string firstName, string lastName, string cpf, DateTime birthDate, string email, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Cpf = cpf;
            BirthDate = birthDate;
            Email = email;
            Phone = phone;
        }

        public ClientRequestModel(string firstName, string lastName, string cpf)
        {
            FirstName = firstName;
            LastName = lastName;
            Cpf = cpf;
        } 

        public bool Validations()
        {
            var cpfValid = CpfValidation(Cpf);
            if (!cpfValid)
            {
                Message.Add("Cpf invalid!");
            }

            if(Message.Count > 0)
            {
                return false;
            }
            return true;
        }

        public bool CpfValidation(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma, resto;
            string tempCpf, digito;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf == null) return false;
            if (cpf.Length != 11) return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++) soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2) resto = 0;
            else resto = 11 - resto;

            digito = resto.ToString();

            tempCpf += digito;

            soma = 0;
            for (int i = 0; i < 10; i++) soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2) resto = 0;
            else resto = 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }


    }
}
