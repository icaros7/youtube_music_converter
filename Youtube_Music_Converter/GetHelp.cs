﻿using System;
using log4net;

namespace Youtube_Music_Converter
{
    public class GetHelp
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        
        public GetHelp()
        {
            log.Info("> Call GetHelp");
        }

        public string Print()
        {
            log.Info(@">> GetHelp Print");
            Console.WriteLine(Str.str_help_1);
            Console.WriteLine(Str.str_help_2);
            Console.WriteLine(Str.str_help_3);
            Console.WriteLine();
            Console.WriteLine(@"Linux :");
            Console.WriteLine(@"    " + Str.str_help_4_linux);
            Console.WriteLine(@"Windows :");
            Console.WriteLine(@"    " + Str.str_help_4_windows);
            Console.WriteLine();
            Console.WriteLine(Str.str_help_5);
            Console.WriteLine(@"https://github.com/icaros7/youtube_music_converter");
            Console.WriteLine();
            
            log.Info(@">> GetHelp Print Success");
            log.Info(@"");

            return "Normal";
        }
            
    }
}