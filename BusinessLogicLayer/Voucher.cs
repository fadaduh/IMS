using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class Voucher : IModel
    {
        public int VoucherID
        { get; set; }

        public int CustomerID
        { get; set; }

        public DateTime Date
        { get; set; }

        public double Amount
        { get; set; }

        public string Remark
        { get; set; }

        public string VoucherNumber
        { get; set; }

    }
}
