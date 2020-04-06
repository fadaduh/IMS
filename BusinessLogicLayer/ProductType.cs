using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class ProductType : IModel
    {

        public int ProductTypeID
        { get; set; }

        public string ProductTypeName
        { get; set; }

        public string PTDescription
        { get; set; }

    }
}
