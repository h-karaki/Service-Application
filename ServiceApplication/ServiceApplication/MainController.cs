using System;
using System.Collections.Generic;
using ServiceApplication.Models;
using ServiceApplication.Modules;

namespace ServiceApplication
{
    class MainController
    {
        public MainController(string[] args)
        {
            ContainerWrapper myContainer = new ContainerWrapper();
            myContainer.Build();
            
            UI.Intro();
            List<string> dataFromInputFile;

            if (args.Length == 0)
            {
                try
                {
                    dataFromInputFile = myContainer.ReadDataFromSource("input.txt");
                }
                catch(Exception e)
                {
                    dataFromInputFile = new List<string>(); //TODO: Remove this quickfix. was added only so "string boundingPolygon = dataFromInputFile[0];" compiles.
                    Console.WriteLine("Error: MainController CODE:X1");
                    Console.WriteLine("Could not find input.txt. Press enter key to exit.");
                    Console.Read();
                    Environment.Exit(1);
                }
            }
            else
            {
                dataFromInputFile = myContainer.ReadDataFromSource(args[0]);
            }
            
                
            //TODO: List Factory
            List<string> addressData = new List<string>();
            List<Coordinate> coordinateData = new List<Coordinate>();

            string boundingPolygon = dataFromInputFile[0];
            UI.PrintBoundingData(boundingPolygon);

            //Low Code Durability
            for (int i = 1; i < dataFromInputFile.Count; i++)
            { //seperating bounding box from address data
                addressData.Add(dataFromInputFile[i]);
            }

            

            for (int i = 0; i < addressData.Count; i++)
            {
                coordinateData.Add(myContainer.ConvertAddressToCoordinate(addressData[i]));
            }

            try
            {
                List<Coordinate> boundingCoordinates = ParseStringToCoordinates.GiveMeCoordinates(boundingPolygon);
                UI.PrintAddressesWithinBound(boundingCoordinates, addressData, coordinateData);
                UI.Exit();
            }
            catch (Exception e) //TODO: More elaboreate Exception handling. 
            {
                Console.WriteLine("Error: MainController CODE:X3");
                Console.WriteLine("Check the format of your bounding coordinates. Refer to readme.txt.");
                Console.WriteLine(e);
                Console.Read();
                Environment.Exit(1);
            }
        }
        
        
    }//END Class
}//END Namespace
