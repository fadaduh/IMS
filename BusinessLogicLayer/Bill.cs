using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class Bill : IModel
    {
        public int BillID
        { get; set; }

        public string BillNumber
        { get; set; }

        public int CustomerID
        { get; set; }

        public DateTime CreatedOn
        { get; set; }

        public double TotalAmount
        { get; set; }

        public string Remark
        { get; set; }
    }
}
