using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class Product : IModel
    {
        public int ProductID
        { get; set; }

        public string ProductName
        { get; set; }

        public int ProductTypeID
        { get; set; }

        public string Description
        { get; set; }

        public double Price
        { get; set; }

        public int Quantity
        { get; set; }

        public string UOM
        { get; set; }

        public int BillID
        { get; set; }

        public Boolean IsDisable
        { get; set; }
    }
}
