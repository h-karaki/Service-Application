using System;
using System.Collections.Generic;
using ServiceApplication.Algorithm;
using ServiceApplication.Models;

namespace ServiceApplication.Modules
{
    class UI
    {
        public static void Intro()
        {
            Console.WriteLine("");
            Console.WriteLine("Hussein Karaki - Geocoding and Bounding");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();
            Logger.StartLog();
        }

        public static void PrintBoundingData(string boundingPolygon)
        {
            Console.WriteLine("Bounding Polygon Data set: ");
            Console.WriteLine(boundingPolygon);
        }

        public static void PrintAddressesWithinBound(List<Coordinate> boundingCoordinates, 
                                                     List<string> addressData, 
                                                     List<Coordinate> coordinateData)
        {
            Console.WriteLine();
            Console.WriteLine("Addresses within bound:");
            for (int i = 0; i < boundingCoordinates.Count; i++)
            {
                Logger.PrintToLog(addressData[i]);
                Logger.PrintToLog(coordinateData[i].ReturnCoordinatesInText());
                if (WithinBoundsChecker.IsPointInPolygon4(boundingCoordinates, coordinateData[i]))
                    Console.WriteLine("- " + addressData[i]);
            }
        }

        public static void Exit()
        {
            Console.Write("Press enter key to exit");
            Console.ReadLine();
        }
    }
}
