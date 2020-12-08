using System;
using System.IO;
using System.Threading.Tasks;
using log4net;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Downloader;

namespace Youtube_Music_Converter
{
    public class GetMP3
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        private string[] _path;
        public string Status;
        private int _successCnt = 0;

        public GetMP3()
        {
            log.Info(@"> Call GetMP3");
        }

        public void Init(string path)
        {
            log.Info(@">> GetMP3 initializing");

            log.Info(@">>> Read downloaded video files");
            this._path = Directory.GetFiles(path, "*.mp4");
            log.Info(@">>>> Found " + _path.Length + @" Files");
            
            FFmpegDownloader.GetLatestVersion(FFmpegVersion.Full, Environment.CurrentDirectory);
            FFmpeg.SetExecutablesPath(Environment.CurrentDirectory);
            
            log.Info(@">> GetMP3 initialized");
            log.Info(@"");
        }

        public async Task<int> Convert()
        {
            log.Info(@">> GetMP3 Convert");

            try
            {
                Console.WriteLine(@"-----------------------------");
                Console.WriteLine(Str.str_task_audio);
                Console.WriteLine();
                Console.WriteLine(Str.str_start);
                log.Info(@">>> Total Audio Task : " + _path.Length);
                Console.WriteLine(Str.str_total_task + _path.Length);
                Console.WriteLine();
                
                for (int i = 0; i < _path.Length; i++)
                {

                    try
                    {
                        log.Info(@">>>> Task " + (i + 1) + @" start");
                        
                        string output = Path.ChangeExtension(_path[i], "mp3");
                        log.Info(@">>>>> Check exist already converted file");
                        if (File.Exists(output))
                        {
                            log.Info(@">>>>>> Detected MP3 File. Try to delete");
                            try
                            {
                                File.Delete(output);
                            }
                            catch (IOException e)
                            {
                                log.Error(e);
                                Console.WriteLine(@"File Busy");
                            }
                        }
                        var conversion = await FFmpeg.Conversions.FromSnippet.ExtractAudio(_path[i], output);
                        // Intentional Synchronous Task
                        conversion.Start();
                        
                        log.Info(@">>>>> Task " + (i + 1) + @" extractAudio");
                        Console.WriteLine(Str.str_converting + Path.GetFileName(output));
                        _successCnt++;
                    }
                    catch (Exception e)
                    {
                        log.Error(e);
                        log.Error(@">>>> Task " + (i + 1) + @" fail");
                        Console.WriteLine(@"> " + Str.str_convert_fail + Path.GetFileName(_path[i]));
                        _successCnt--;
                    }
                    finally
                    {
                        log.Info(@">>>> Task " + (i + 1) + @" end");
                    }

                }
            }
            catch (Exception e)
            {
                log.Error(e);
                log.Error(@">> GetMP3 Convert Fail");
                
                Console.WriteLine(Str.str_unknown);
                Status = "Exception";
            }

            log.Info(@">> GetMP3 Convert Success");
            log.Info(@"");
            Console.WriteLine();
            Console.WriteLine(Str.str_success_video_task + _successCnt);
            Console.WriteLine(Str.str_end);
            Console.WriteLine(@"-----------------------------");
            
            Status = "Normal";
            return 0;
        }
    }
}