using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class AppUser : IModel   
    {
        public int UserID
        { get; set; }

        public string UserName
        { get; set; }

        public string Password
        { get; set; }

        public string Name
        { get; set; }

        public string Phone
        { get; set; }

        public string Mobile
        { get; set; }

        public string Email
        { get; set; }

        public string Type
        { get; set; }

        public string City
        { get; set; }

        public string AccountNumber
        { get; set; }

        public string BankName
        { get; set; }

        public string Address
        { get; set; }
    }
}
