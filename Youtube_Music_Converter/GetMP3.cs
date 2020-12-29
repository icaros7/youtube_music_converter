using System;
using System.Diagnostics;
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
            
            log.Info(@">> GetMP3 initialized");
            log.Info(@"");
        }

        public string Convert()
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
                        
                        string _output = Path.ChangeExtension(_path[i], "mp3");
                        log.Info(@">>>>> Check exist already converted file");
                        if (File.Exists(_output))
                        {
                            log.Info(@">>>>>> Detected MP3 File. Try to delete");
                            try
                            {
                                File.Delete(_output);
                            }
                            catch (IOException e)
                            {
                                log.Error(e);
                                Console.WriteLine(@"File Busy");
                            }
                        }
                        log.Info(@">>>>> Task " + (i + 1) + @" extractAudio");
                        
                        var ffmpegProcess = new Process();
                        ffmpegProcess.StartInfo.UseShellExecute = false;
                        ffmpegProcess.StartInfo.RedirectStandardInput = true;
                        ffmpegProcess.StartInfo.RedirectStandardOutput = true;
                        ffmpegProcess.StartInfo.RedirectStandardError = true;
                        ffmpegProcess.StartInfo.CreateNoWindow = true;
                        log.Info(_path[i]);
                        log.Info(_output);
                        ffmpegProcess.StartInfo.FileName = Environment.CurrentDirectory + @"\ffmpeg.exe";
                        ffmpegProcess.StartInfo.Arguments = " -i " + "\""+ _path[i] + "\"" + " -vn -f mp3 -ab 320k " + "\"" + _output + "\"";
                        log.Info(ffmpegProcess.StartInfo.Arguments.ToString());
                        ffmpegProcess.Start();
                        log.Info(@"Started");
                        Console.WriteLine(Str.str_converting + Path.GetFileName(_output));
                        // ffmpegProcess.StandardOutput.ReadToEnd();
                        // log.Info(@"ReadToEnded");
                        
                        var outputmp3 = ffmpegProcess.StandardError.ReadToEnd();
                        log.Info(@"output = ReadToEnded");
                        ffmpegProcess.WaitForExit();
                        log.Info(@"WaitforExited");
                        if (!ffmpegProcess.HasExited)
                        {
                            log.Info(@"HasExited");
                            ffmpegProcess.Kill();
                            log.Info(@"Killed");
                        }
                        Console.WriteLine(outputmp3);
                        
                        _successCnt++;
                    }
                    catch (Exception e)
                    {
                        log.Error(e);
                        log.Error(@">>>> Task " + (i + 1) + @" fail");
                        Console.WriteLine(@"> " + Str.str_convert_fail + Path.GetFileName(_path[i]));
                        if (_successCnt > 0)
                        {
                            _successCnt--;
                        }
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
                return "Exception";
            }

            log.Info(@">> GetMP3 Convert Success");
            log.Info(@"");
            Console.WriteLine();
            Console.WriteLine(Str.str_success_video_task + _successCnt);
            Console.WriteLine(Str.str_end);
            Console.WriteLine(@"-----------------------------");
            
            return "Normal";
        }
    }
}