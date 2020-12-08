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
            else if (status == "No Args")
            {
                GetHelp help = new GetHelp();
                help.Print();
                init.Exit(status);
            }
            else if (status == "Normal")
            {
                GetVideo video = new GetVideo();
                status = video.Init(args[0]);
                if (status == "Wrong Args" || status == "Unknown Type")
                {
                    init.Exit(status);
                }
                else if (status == "Normal")
                {
                    video.ShowQueue();
                    status = video.Start();
                    if (status == "Normal")
                    {
                        GetMP3 mp3 = new GetMP3();
                        mp3.Init(video.Path);
                        // Intentional Synchronous Task
                        mp3.Convert();
                        status = mp3.Status;
                        
                        init.Exit(status);
                    }
                }
            }

            Console.WriteLine(Str.str_unknown);
            init.Exit(status);
        }
    }
}