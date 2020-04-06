using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class FormatDetails : IModel
    {
        public int FormatID
        { get; set; }

        public string FormatText
        { get; set; }

        public string FormatFor
        { get; set; }

        public int Counter
        { get; set; }

    }
}
