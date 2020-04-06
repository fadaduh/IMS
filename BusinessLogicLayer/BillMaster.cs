using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BusinessLogicLayer
{
    public class BillMaster : IModel
    {
        public int BillMID
        { get; set; }

        public int BillID
        { get; set; }

        public int ProductID
        { get; set; }

        public int Quantity
        { get; set; }

        public double BillRate
        { get; set; }

        public double BillValue
        { get; set; }
    }
}
