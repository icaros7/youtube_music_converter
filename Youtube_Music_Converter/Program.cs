using System;

namespace Youtube_Music_Converter
{
    static class Program
    {
        static void Main(String[] args)
        {
            GetInit init;
            if (args.Length == 0)
            {
                init = new GetInit();
            }
            else
            {
                init = new GetInit(args[0]);
            }

            string status = init.Init();

            if (status == "GetHelp")
            {
                GetHelp help = new GetHelp();
                status = help.Print();
                init.Exit(status);
            }
            else if (status == "Normal")
            {
                GetVideo video = new GetVideo();
                status = video.Init(args[0]);
                if (status == "Wrong Args")
                {
                    init.Exit(status);
                }
                else if (status == "Normal")
                {
                    video.ShowQueue();
                    status = video.Start();
                    if (status == "Normal")
                    {
                        // init.Exit(status);
                        
                        // TODO: GetMP3 here
                        GetMP3 mp3 = new GetMP3();
                        mp3.Init();
                        mp3.Convert();
                        
                        init.Exit(status);
                    }
                }
            }

            Console.WriteLine(Str.str_unknown);
            init.Exit(status);
        }
    }
}