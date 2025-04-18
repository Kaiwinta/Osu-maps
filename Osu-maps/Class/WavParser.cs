using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osu_maps.CustomException;

namespace Osu_maps.Class
{
    public class WavParser : BaseMusicParser
    {
        public WavParser(string filepath) : base(filepath, "wav")
        {

        }

        public override void ParseFile()
        {
            Console.WriteLine("Wav parser");
        }
    }
}
