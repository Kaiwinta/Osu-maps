using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Osu_maps.CustomException
{
    public class ParserInitException : Exception
    {
        public ParserInitException(string message) : base(message) { }

        public ParserInitException(string message, string filename) : base(string.Format("{0} : {1}", message, filename)) { }
    }
}
