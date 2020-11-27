using log4net;

namespace Youtube_Music_Converter
{
    public class GetMP3
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        public GetMP3()
        {
            log.Info(@"> Call GetMP3");
        }

        public void Init()
        {
            log.Info(@">> GetMP3 initializing");

            log.Info(@">> GetMP3 initialized");
        }

        public void Convert()
        {
            log.Info(@">> GetMP3 Convert");

            log.Info(@">> GetMP3 Convert Success");
        }
    }
}