using System;
using System.IO;
using System.Reflection;
using System.Text;
using VideoLibrary;

namespace Youtube_Music_Converter
{
    static class Program
    {
        private class GetHelp
        {
            public GetHelp()
            {
                // Print Help String
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
                Console.WriteLine("\n{0}", Str.str_help_6);
                Console.ReadKey();  // Pause to exit
                System.Environment.Exit(0);
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
            else
            {
                GetVideo video = new GetVideo(args[0]);
                video.ShowQueue();
                video.Start();
            }
        }

        private class GetVideo
        {
            private string[] _url;
            private string path;
            
            public GetVideo(string args)
            {
                _url = File.Exists(args) ? File.ReadAllLines(args, Encoding.UTF8) : null;
                if (_url == null || _url.Length == 0)
                {
                    Console.WriteLine(Str.str_no_args);
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
    
                Console.WriteLine(Str.str_target + args);
                this.path = System.Environment.CurrentDirectory + @"\" + args.Replace(@".txt", @"");
            }

            public void ShowQueue()
            {
                Console.WriteLine(Str.str_show_queue);
                Console.WriteLine(@"-----------------------------");
                foreach (string s in _url)
                {
                    Console.WriteLine(s);
                }
            }

            public void Start()
            {
                try
                {
                    Console.WriteLine(@"-----------------------------" + "\n");
                    Console.WriteLine(Str.str_start);
                    Console.WriteLine(Str.str_total_task + _url.Length);
                    Console.WriteLine();
                    Console.WriteLine(@"-----------------------------");

                    // Check Dir exist
                    DirectoryInfo dir = new DirectoryInfo(path);
                    if (dir.Exists == false)
                    {
                        dir.Create();
                    }

                    var yt = YouTube.Default;
                    for (int i = 0; i < _url.Length; i++)
                    {
                        var vid = yt.GetVideo(_url[i]);

                        File.WriteAllBytes(path + @"\" + vid.FullName, vid.GetBytes());
                        Console.WriteLine(@"Success : " + vid.FullName);

                        // TODO: NReco 대신 다른 라이브러리 사용
                        // NReco.VideoConverter free binary doesn't support .net Core.
                        // var convert = new NReco.VideoConverter.FFMpegConverter();
                        // String mp3 = path + vid.FullName.Replace(".mp4", ".mp3");
                        // convert.ConvertMedia(vid.FullName, mp3, "mp3");
                        // File.Delete(vid.FullName);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e + "\nPress any key to continue...");
                    Console.ReadKey();
                }

                Console.WriteLine(@"-----------------------------");
                Console.WriteLine(Str.str_end);
                return;
            }
        }
    }
}