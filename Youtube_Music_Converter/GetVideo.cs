using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using log4net;
using VideoLibrary;

namespace Youtube_Music_Converter
{
    public class GetVideo
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        
        public string[] _url;
        private string path;
        
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

            Console.WriteLine(Str.str_target + args);
            Console.WriteLine();

            log.Info(@">>> Check args is full directory url");
            int isFull = args.IndexOf(":", StringComparison.Ordinal);
            if (isFull == -1)
            {
                log.Info(@">>>> Detected only file name");
                path = System.Environment.CurrentDirectory + @"\" + args.Replace(@".txt", @"");
            }
            else if (isFull == 1)
            {
                log.Info(@">>>> Detected full directory url");
                path = args.Replace(@".txt", @"");
            }
            else
            {
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
                DirectoryInfo dir = new DirectoryInfo(path);
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
                log.Error(@">>>> Not supported type : " + path);
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

        public List<int> mp3path = new List<int>();

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
                        var vid = yt.GetVideo(_url[i]);
                        Console.WriteLine(Str.str_downloading + vid.FullName);
                        File.WriteAllBytes(path + @"\" + vid.FullName, vid.GetBytes());
                        mp3path.Add(i);
                    }
                    catch (ArgumentException e)
                    {
                        log.Error(e);
                        log.Error(@">>>>> Task " + (i + 1) + @" WriteAllBytes Fail. Not valid Youtube URL.");
                        mp3path.Remove(i);
                        Console.WriteLine(@"> " + Str.str_not_support_type + _url[i]);
                    }
                    catch (VideoLibrary.Exceptions.UnavailableStreamException e)
                    {
                        log.Error(e);
                        log.Error(@">>>>> Task" + (i + 1) + @" WriteAllBytes Fail. Video has unavailable stream");
                        mp3path.Remove(i);
                        Console.WriteLine(@"> " + Str.str_unavailable_stream + _url[i]);
                    }
                    catch (Exception e)
                    {
                        log.Error(e);
                        log.Error(@">>>>> Task " + (i + 1) + @" WriteAllBytes Fail");
                        mp3path.Remove(i);
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
            Console.WriteLine(Str.str_success_video_task + mp3path.Count);
            Console.WriteLine(Str.str_end);
            Console.WriteLine(@"-----------------------------");

            return "Normal";
        }
    }
}