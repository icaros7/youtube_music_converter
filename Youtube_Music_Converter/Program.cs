using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Youtube_Music_Converter
{
    static class Program
    {
        private class GetHelp
        {
            public GetHelp()
            {
                this.Print();
            }

            public void Print()
            {
                Console.WriteLine(Str.str_help_1);
                Console.WriteLine(Str.str_help_2);
                Console.WriteLine(Str.str_help_3);
                Console.WriteLine();
                Console.WriteLine(@"    " + Str.str_help_4 + "\n");
                Console.WriteLine(Str.str_help_5);
                Console.WriteLine(@"https://github.com/icaros7/youtube_music_converter");
            }
        }

        static void Main(String[] args)
        {
            String version = Assembly.GetExecutingAssembly().GetName().Version?.ToString();
            Console.WriteLine(Str.str_intro + @" - " + version);
            Console.WriteLine(@"Powered by iCAROS7.");
            Console.WriteLine(@"-----------------------------");
            Console.WriteLine();
            
            if (args.Length == 0 || args[0] == "--help")
            {
                GetHelp help = new GetHelp();
                return;
            }
            
            string[] url = File.Exists(args[0]) ? File.ReadAllLines(args[0], Encoding.UTF8) : null;
            if (url == null || url.Length == 0)
            {
                Console.WriteLine(Str.str_no_args);
                return;
            }

            Console.WriteLine(Str.str_target + args[0]);
            
        }
    }
}