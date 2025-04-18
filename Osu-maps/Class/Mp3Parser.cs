using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osu_maps.CustomException;

namespace Osu_maps.Class
{
    public class Mp3Parser : BaseMusicParser
    {
        public Mp3Parser(string filepath) : base(filepath, "mp3")
        {

        }

        public override void ParseFile()
        {
            Console.WriteLine("MP3 parser");
        }
    }
}
