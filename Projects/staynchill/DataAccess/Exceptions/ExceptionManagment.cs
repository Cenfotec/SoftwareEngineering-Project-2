using System;
using System.IO;

namespace DataAccess.Exceptions
{
    public class ExceptionManagment
    {
        
        private static ExceptionManagment _instance;

        public ExceptionManagment()
        {

        }

        public static ExceptionManagment GetInstance()
        {
            return _instance ?? (_instance = new ExceptionManagment());
        }

        public void ManageException(Exception exception)
        {
            using (var log = File.AppendText(Path.GetDirectoryName(Environment.CurrentDirectory) + "\\Log\\"+"Log.txt"))
            {
                log.Write("Log Entry:");
                log.WriteLine(DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                log.WriteLine("    :");
                log.WriteLine(exception);
                log.WriteLine("---------------------------------------------------");
            }
        }
    }
}
