using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Osu_maps.Interfaces
{
    interface IMusicParser
    {
        void ParseFile();
        string Filename { get; }
        string Format { get; }
    }
}
