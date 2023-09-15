namespace BCP.META.Framework.Logger
{
    public class Logger
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Logger));

        private Logger()
        {

        }

        private static Logger oLogger = new Logger();

        public static Logger LoggerInstance()
        {
            return oLogger;
        }

        public void RegisterError(Exception pE, string url, string ipUser, string serverName, string nameUser)
        {
            logger.Info($"Error Occurred on     : {DateTime.Now:dd/MM/yyyy hh:mm:ss tt}");
            logger.Info($"To the User           : {nameUser}");
            logger.Info($"Url                   : {url}");
            logger.Info($"Remote IP Address     : {ipUser}");
            logger.Info($"Server                : {serverName}");
            logger.Info($"Type of Error         : {pE.GetType().FullName}");
            logger.Info($"InnerException        : {pE.InnerException}");
            logger.Info($"StackTrace            : {pE.StackTrace}");
            logger.Info($"TargetSite            : {pE.TargetSite}");
            logger.Info($"Error Message         : {pE.Message}");
            logger.Info($"Source of Error       : {pE.Source}");
            logger.Info("----------------------------------------------------------------");
        }
    }
}
