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

        public GetInit(string args)
        {
            this.args = args;
            
            log.Info(@"==== App Start ====");
        }

        public string Init()
        {
            // log.Info(@"");
            log.Info(@"> App Initializing");
            log.Info(@">> argument : " + args);
            log.Info(@">> Version : " + version);

            if (args.Length == 0 || args == "--help")
            {
                log.Info(">> Detected argument \"--help\"");
                return "GetHelp";
            }
            else
            {
                Console.WriteLine(Str.str_intro + @" - " + version);
                Console.WriteLine(@"Powered by iCAROS7.");
                Console.WriteLine(@"-----------------------------");
                Console.WriteLine();

                log.Info(@"> App Initialized");
                log.Info(@"");
                return "Normal";
            }
        }

        public void Exit(string status)
        {
            log.Info(@"> Call App Exit (Status : " + status + @")");
            log.Info(@"==== App Exit ====");
            log.Info(@"");
            System.Environment.Exit(0);
        }
    }
}