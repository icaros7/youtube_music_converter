using System;
using System.IO;
using System.Reflection;
using System.Text;
using VideoLibrary;
using log4net;

namespace Youtube_Music_Converter
{
    static class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        private class GetHelp
        {
            public GetHelp()
            {
                // Print Help String
                this.Print();
                log.Info("GetHelp.Print");
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
                log.Info(@"====== App Exit Normally ======");
                System.Environment.Exit(0);
            }
        }

        static void Main(String[] args)
        {
            String version = Assembly.GetExecutingAssembly().GetName().Version?.ToString();
            log.Info(@"====== App Start ======");
            log.Info(@"args : " + args.ToString());
            log.Info(@"Version : " + version);
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
                    log.Error(@"No Queue or file.");
                    Console.WriteLine(Str.str_no_args);
                    Console.ReadKey();
                    log.Info(@"====== App Exit Normally ======");
                    System.Environment.Exit(0);
                }
    
                Console.WriteLine(Str.str_target + args);
                Console.WriteLine();
                this.path = System.Environment.CurrentDirectory + @"\" + args.Replace(@".txt", @"");
            }

            public void ShowQueue()
            {
                log.Info(@"Output queue list");
                Console.WriteLine(@"-----------------------------");
                Console.WriteLine(Str.str_show_queue);
                Console.WriteLine();
                foreach (string s in _url)
                {
                    Console.WriteLine(s);
                }
            }

            public void Start()
            {
                log.Info(@"== Task Start ==");
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
                        log.Info(@"Create " + path + @" directory");
                    }
                    else
                    {
                        log.Info(@"Skip create " + path + @" directory");
                    }

                    var yt = YouTube.Default;
                    int er = 0;
                    for (int i = 0; i < _url.Length; i++)
                    {
                        var vid = yt.GetVideo(_url[i]);

                        try
                        {
                            log.Info(@"WriteAllBytes " + _url[i]);
                            File.WriteAllBytes(path + @"\" + vid.FullName, vid.GetBytes());
                            
                            // TODO: NReco 대신 다른 라이브러리 사용
                            // NReco.VideoConverter free binary doesn't support .net Core.
                            // log.Info(ConvertMedia " + _url[i]);
                            // var convert = new NReco.VideoConverter.FFMpegConverter();
                            // String mp3 = path + vid.FullName.Replace(".mp4", ".mp3");
                            // convert.ConvertMedia(vid.FullName, mp3, "mp3");
                            // File.Delete(vid.FullName);
                        }
                        catch (Exception e)
                        {
                            log.Error(e);
                            log.Error(_url[i] + @" WriteAllBytes failed.");
                            Console.WriteLine(@"Fail : " + _url[i]);
                            er++;
                        }
                        finally
                        {
                            if (er == 0)
                            {
                                Console.WriteLine(@"Success : " + vid.FullName);
                            }
                        }

                        
                    }
                }
                catch(Exception e)
                {
                    log.Error(e);
                    log.Error(@"== Task Interrupt ==");
                    Console.WriteLine(e + "\nPress any key to continue...");
                    Console.ReadKey();
                }

                log.Info(@"== Task End Normally ==");
                Console.WriteLine(@"-----------------------------" + "\n");
                Console.WriteLine(Str.str_end);
                log.Info(@"====== App Exit Normally ======");
                System.Environment.Exit(0);
            }
        }
    }
}