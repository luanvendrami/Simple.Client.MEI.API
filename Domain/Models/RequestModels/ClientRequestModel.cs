using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.RequestModels
{
    public class ClientRequestModel
    {       
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Cpf { get; private set; }
        //public DateTime BirthDate { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }

        public ClientRequestModel(string firstName, string lastName, string cpf, string email, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Cpf = cpf;
            Email = email;
            Phone = phone;
        }
    }
}
