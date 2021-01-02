using System;
using System.IO;
using System.Text;
using log4net;
using VideoLibrary;

namespace Youtube_Music_Converter
{
    public class GetVideo
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        private string[] _url;
        public string Path;
        private int SuccessCnt = 0;
        
        
        public GetVideo()
        {
            log.Info(@"> Call GetVideo");
        }

        public string Init(string args)
        {
            log.Info(@">> GetVideo Initializing");

            log.Info(@">>> Try read " + args);
            _url = File.Exists(args) ? File.ReadAllLines(args, Encoding.UTF8) : null;
            if (_url == null || _url.Length == 0)
            {
                log.Error(@">>> Fail read " + args);
                Console.Write(Str.str_no_args);
                Console.WriteLine(Str.str_no_args_with);
                return "Wrong Args";
            }

            if (args == @"Youtube_Music_Converter_tmp.txt")
            {
                Console.WriteLine(Str.str_target + Str.str_temp_txt);
            }
            else
            {
                Console.WriteLine(Str.str_target + args);
            }
            Console.WriteLine();

            log.Info(@">>> Check args is full directory url");
            int isFull = args.IndexOf(":", StringComparison.Ordinal);
            switch (isFull)
            {
                case -1:
                    log.Info(@">>>> Detected only file name");
                    Path = System.IO.Path.Combine(Environment.CurrentDirectory, args.Replace(@".txt", @""));
                    break;
                case 1:
                    log.Info(@">>>> Detected full directory url");
                    Path = args.Replace(@".txt", @"");
                    break;
                default:
                    log.Info(@">>> Detected unknown format");
                    Console.WriteLine(Str.str_no_args);
                    Console.WriteLine(Str.str_no_args_with);
                    log.Info(@">> GetVideo Initialized");
                    return "Wrong Args";
            }
            
            
            // Check Dir exist
            log.Info(@">>> Check output dir exist");
            try
            {
                DirectoryInfo dir = new DirectoryInfo(Path);
                if (dir.Exists == false)
                {
                    dir.Create();
                    log.Info(@">>>> Create directory");
                }
                else
                {
                    log.Info(@">>>> Skip create directory");
                }
            }
            catch (IOException e)
            {
                log.Error(e);
                log.Error(@">>>> Not supported type : " + Path);
                Console.WriteLine(Str.str_unknown_type);
                return "Unknown Type";
            }
            catch (Exception e)
            {
                log.Error(e);
                return "Exception";
            }
            finally
            {
                log.Info(@">> GetVideo Initialized");
                log.Info(@"");
            }
            
            return "Normal";
        }

        public void ShowQueue()
        {
            log.Info(@">> GetVideo ShowQueue");
            Console.WriteLine(@"-----------------------------");
            Console.WriteLine(Str.str_show_queue);
            Console.WriteLine();
            foreach (string s in _url)
            {
                log.Info(@">>> " + s);
                Console.WriteLine(s);
            }

            log.Info(@">> GetVideo ShowQueue Success");
            log.Info(@"");
        }

        public string Start()
        {
            log.Info(@">> GetVideo Start");
            try
            {
                Console.WriteLine(@"-----------------------------");
                Console.WriteLine(Str.str_task_video);
                Console.WriteLine();
                Console.WriteLine(Str.str_start);
                log.Info(@">>> Total Video Task : " + _url.Length);
                Console.WriteLine(Str.str_total_task + _url.Length);
                Console.WriteLine();

                var yt = YouTube.Default;
                for (int i = 0; i < _url.Length; i++)
                {
                    log.Info(@">>>> Task " + (i + 1) + " start");

                    try
                    {
                        log.Info(@">>>>> Task " + (i + 1) + @" WriteAllBytes");
                        SuccessCnt++;
                        var vid = yt.GetVideo(_url[i]);
                        Console.WriteLine(Str.str_downloading + vid.FullName);
                        File.WriteAllBytes(Path + @"\" + vid.FullName, vid.GetBytes());
                    }
                    catch (ArgumentException e)
                    {
                        log.Error(e);
                        log.Error(@">>>>> Task " + (i + 1) + @" WriteAllBytes Fail. Not valid Youtube URL.");
                        if (SuccessCnt > 0)
                        {
                            SuccessCnt--;
                        }
                        Console.WriteLine(@"> " + Str.str_not_support_type + _url[i]);
                    }
                    catch (VideoLibrary.Exceptions.UnavailableStreamException e)
                    {
                        log.Error(e);
                        log.Error(@">>>>> Task" + (i + 1) + @" WriteAllBytes Fail. Video has unavailable stream");
                        if (SuccessCnt > 0)
                        {
                            SuccessCnt--;
                        }
                        Console.WriteLine(@"> " + Str.str_unavailable_stream + _url[i]);
                    }
                    catch (Exception e)
                    {
                        log.Error(e);
                        log.Error(@">>>>> Task " + (i + 1) + @" WriteAllBytes Fail");
                        if (SuccessCnt > 0)
                        {
                            SuccessCnt--;
                        }
                        Console.WriteLine(@"> " + Str.str_download_fail + _url[i]);
                    }
                    finally
                    {
                        log.Info(@">>>> Task " + (i + 1) + @" end");
                    }
                }
            }
            catch(Exception e)
            {
                log.Error(@">> " + e);
                log.Error(@">> GetVideo Start Fail");
                
                Console.WriteLine(e);
                return "Exception";
            }

            log.Info(@">>> Total Video Task End");

            log.Info(@">> GetVideo Start Success");
            log.Info(@"");
            Console.WriteLine();
            Console.WriteLine(Str.str_success_video_task + SuccessCnt);
            Console.WriteLine(Str.str_end);

            return "Normal";
        }
    }
}