﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using log4net;
using Xabe.FFmpeg;

namespace Youtube_Music_Converter
{
    public class GetMP3
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        private string[] _url;
        private int[] _successPath = {};

        public GetMP3()
        {
            log.Info(@"> Call GetMP3");
        }

        public void Init(List<int> _successPath, string[] url)
        {
            log.Info(@">> GetMP3 initializing");
            _url = url;
            this._successPath = _successPath.ToArray();
            log.Info(@">> GetMP3 initialized");
            log.Info(@"");
        }

        public string Convert()
        {
            log.Info(@">> GetMP3 Convert");
            Console.WriteLine(_successPath.Length);
            for (int i = 0; i < _successPath.Length; i++)
            {
                log.Info(@">>> Total Audio Task : ");
                try
                {
                    log.Info(@">>>> Task " + (i + 1) + @" start");

                    string output = Path.ChangeExtension(Path.GetTempFileName(), "mp3");
                    var conversion = FFmpeg.Conversions.FromSnippet.ExtractAudio(_url[_successPath[i]], output);
                    await conversion.Start();
                }
                catch (Exception e)
                {
                    log.Error(e);
                    log.Error(@">>>> Task " + (i + 1) + @" fail");

                    Console.WriteLine(e);
                    Console.WriteLine(Str.str_unknown);
                    return "Exception";
                }

            }

            log.Info(@">> GetMP3 Convert Success");
            log.Info(@"");
            return "Normal";
        }
    }
}