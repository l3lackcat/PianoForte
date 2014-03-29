using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PianoForte.Manager
{
    public class LogManager
    {
        public static void writeLog(string message)
        {
            // Create a writer and open the file:
            StreamWriter log;

            if (!File.Exists("log.txt"))
            {
                log = new StreamWriter("log.txt");
            }
            else
            {
                log = File.AppendText("log.txt");
            }

            // Write to the file:
            log.WriteLine(DateTime.Now + " : " + message);

            // Close the stream:
            log.Close();

            Console.WriteLine(message);
        }
    }
}
