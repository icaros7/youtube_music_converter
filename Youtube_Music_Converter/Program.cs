using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Youtube_Music_Converter
{
    static class Program
    {
        private class getHelp
        {
            private int page;

            public getHelp()
            {

            }

            public getHelp(string page_number)
            {
                this.page = int.Parse(page_number);
            }
        }

        static void Main(string[] args)
        {
            if (args.Length == 0 || args.Length > 3)
            {
                Console.WriteLine(str.str_no_args);
                return;
            }
            else if (args[0] == "--help")
            {
                getHelp(args[1]);
            }
            else
            {
                string[] url = File.ReadAllLines(args[0], Encoding.UTF8);
                if (url.Length == 0)
                {
                    Console.WriteLine(str.str_no_args);
                    return;
                }
            }

            string version = Assembly.GetExecutingAssembly().GetName().Version?.ToString();
            Console.WriteLine(str.str_intro + @" - " + version);
            Console.WriteLine(@"Powered by iCAROS7.");
            Console.WriteLine(@"-----------------------------");
            Console.WriteLine();
            Console.WriteLine(str.str_target + args[0]);
            
        }
    }
}