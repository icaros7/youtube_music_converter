using System;
using System.Net.Mime;
using System.Reflection;
using log4net;

namespace Youtube_Music_Converter
{
    public class GetInit
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        private string args;
        private int GUI = 1;
        private String version = Assembly.GetExecutingAssembly().GetName().Version?.ToString();

        public GetInit()
        {
            log.Info(@"");
            log.Info(@"==== App Start ====");
        }
        public GetInit(string args, int gui)
        {
            log.Info(@"");
            log.Info(@"==== App Start ====");
            
            this.args = args;
            GUI = gui;
        }

        public string Init()
        {
            // log.Info(@"");
            log.Info(@"> App Initializing");
            log.Info(@">> argument : " + args);
            log.Info(@">> Version : " + version);
            if (GUI == 0){ log.Info(@">> GUI Mode : 0"); }

            Console.WriteLine(Str.str_intro + @" - " + version);
            Console.WriteLine(@"Powered by iCAROS7.");
            Console.WriteLine(@"-----------------------------");
            Console.WriteLine();
            
            if (args == null)
            {
                log.Info(@">> Detected no argument");
                log.Info(@"> App Initialized");
                log.Info(@"");
                Console.WriteLine(Str.str_no_args);
                Console.WriteLine();
                return "No Args";
            }
            else if (args == "--help")
            {
                log.Info(">> Detected argument \"--help\"");
                log.Info(@"> App Initialized");
                log.Info(@"");
                return "GetHelp";
            }
            else
            {
                log.Info(@"> App Initialized");
                log.Info(@"");
                return "Normal";
            }
        }

        public void Exit(string status)
        {
            log.Info(@"> Call App Exit (Status : " + status + @")");
            if (GUI == 0)
            {
                Console.WriteLine(@"End of Program");
            }
            else
            {
                Console.WriteLine(Str.str_press_key_exit);
                Console.Read();
            }
            log.Info(@"==== App Exit ====");
            log.Info(@"");
            Environment.Exit(0);
        }
    }
}