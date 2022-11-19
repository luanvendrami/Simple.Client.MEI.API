using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ResponseModels
{
    public class FetchClientResponseModel
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Cpf { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public FetchClientResponseModel(string firstName, string lastName, string cpf, DateTime birthDate, string email, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Cpf = cpf;
            BirthDate = birthDate;
            Email = email;
            Phone = phone;
        }
    }
}
