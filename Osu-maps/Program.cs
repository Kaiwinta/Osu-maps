using Osu_maps.Class;
using Osu_maps.CustomException;
using System;

namespace Osu_maps
{

    public class Program
    {
        public static int Main(string[] args)
        {
            String musicPath = GetArg(args, new string[] { "--music", "-m" });
            if (musicPath == String.Empty)
            {
                Console.Error.WriteLine("No music file provided, use -m or --music");
                return 84;
            }
            BaseMusicParser parser = null;
            try
            {
                if (musicPath.EndsWith("mp3", StringComparison.OrdinalIgnoreCase))
                {
                    parser = new Mp3Parser(musicPath);
                }
                else if (musicPath.EndsWith("wav", StringComparison.OrdinalIgnoreCase))
                {
                    parser = new WavParser(musicPath);
                }
                else
                {
                    throw new ParserInitException("No available parser for this extension");
                }
                parser?.ParseFile();
            }
            catch (NotImplementedException ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return 84;
            }
            catch (ParserInitException ex)
            {
                Console.Error.WriteLine($"Parser Error: {ex.Message}");
                return 84;
            }
            return 0;
        }

        public static string GetArg(string[] args, string[] flags, string def = "")
        {
            foreach (var flag in flags)
            {
                int index = Array.IndexOf(args, flag);
                if (index >= 0 && index + 1 < args.Length)
                    return args[index + 1];
            }
            return def;
        }
    }
}