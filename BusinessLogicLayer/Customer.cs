using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class Customer : IModel
    {
        public int CustomerID
        { get; set; }

        public int UserID
        { get; set; }

        public string CustomerName
        { get; set; }

        public string CustomerMobile
        { get; set; }

        public string CustomerPhone
        { get; set; }

        public string Organization
        { get; set; }

        public string City
        { get; set; }

        public double CurrentBalance
        { get; set; }

        public string OrganizationAddress
        { get; set; }

        public Boolean IsOld
        { get; set; }

    }
}
