
using System;
using System.Diagnostics;
using System.Threading;

namespace WritingWindowsEventLogs
{
    class MySample
    {
        public static void Main()
        {

            // Create the source, if it does not already exist.
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                //An event log source should not be created and immediately used.
                //There is a latency time to enable the source, it should be created
                //prior to executing the application that uses the source.
                //Execute this sample a second time to use the new source.
                EventLog.CreateEventSource("MySource", "MyNewLog");
                Console.WriteLine("CreatedEventSource");
                Console.WriteLine("Exiting, execute the application a second time to use the source.");
                // The source is created.  Exit the application to allow it to be registered.
                //Trace.Assert(true);
                //Debug.Assert(true);


                return;
            }
           // new MySample().debuginClass();

            // Create an EventLog instance and assign its source.
            EventLog myLog = new EventLog();
            myLog.Source = "MySource";

            // Write an informational entry to the event log.
            myLog.WriteEntry("Writing to event log.");
        }

        void debuginClass()
        {
            int number;
            Console.WriteLine("Please type a number between 1 and 10, and then press Enter");
            string userInput = Console.ReadLine();
            Debug.Assert(int.TryParse(userInput, out number), string.Format("Unable to parse {0} as integer", userInput));
            Debug.WriteLine("The current value of userInput is: {0}", userInput);
            Debug.WriteLine("The current value of number is: {0}", number);
            Console.WriteLine("Press Enter to finish");
            Console.ReadLine();
        }
    }
}
