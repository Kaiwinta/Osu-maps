using Osu_maps.CustomException;
using Osu_maps.Interfaces;
using System;

namespace Osu_maps.Class
{
    public class BaseMusicParser : IMusicParser
    {
        public string Filename { get; private set; }
        public string Format { get; private set; }

        public BaseMusicParser(string filename, string format = "mp3")
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ParserInitException("No filename provided");
            }

            if (!filename.EndsWith("." + format, StringComparison.OrdinalIgnoreCase))
            {
                throw new ParserInitException("Invalid file Extension", filename);
            }

            Filename = filename;
            Format = format;
        }

        public virtual void ParseFile()
        {
            // Throwing NotImplementedException to indicate that the method must be implemented by derived classes
            throw new NotImplementedException("ParseFile must be implemented in a derived class.");
        }
    }
}
