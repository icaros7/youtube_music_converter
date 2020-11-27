using System;
using System.Reflection;
using log4net;

namespace Youtube_Music_Converter
{
    public class GetInit
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        private string args;
        private String version = Assembly.GetExecutingAssembly().GetName().Version?.ToString();

        public GetInit()
        {
            log.Info(@"");
            log.Info(@"==== App Start ====");
            this.args = null;
        }
        public GetInit(string args)
        {
            this.args = args;
            
            log.Info(@"");
            log.Info(@"==== App Start ====");
        }

        public string Init()
        {
            // log.Info(@"");
            log.Info(@"> App Initializing");
            log.Info(@">> argument : " + args);
            log.Info(@">> Version : " + version);

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
            Console.WriteLine(Str.str_press_key_exit);
            Console.Read();
            log.Info(@"==== App Exit ====");
            log.Info(@"");
            System.Environment.Exit(0);
        }
    }
}