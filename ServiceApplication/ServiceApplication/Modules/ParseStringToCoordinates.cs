using ServiceApplication.Models;
using System.Collections.Generic;

namespace ServiceApplication.Modules
{
    class ParseStringToCoordinates
    {
        public static List<Coordinate> GiveMeCoordinates(string inputString)
        {
            List<Coordinate> coordinates = new List<Coordinate>();

            int iterator = 0;

            //TODO: Relax rules.
            while (iterator != inputString.Length -1)
            {
                int startLocationOfX = inputString.IndexOf('(', iterator) + 1;
                int endLocationOfX = inputString.IndexOf(',', iterator + 3);
                iterator = endLocationOfX;
                int startLocationOfY = inputString.IndexOf(' ', iterator) + 1;
                int endLocationOfY = inputString.IndexOf(')', iterator);

                string xCor = inputString.Substring(startLocationOfX, endLocationOfX - startLocationOfX);
                string yCor = inputString.Substring(startLocationOfY, endLocationOfY - startLocationOfY);

                coordinates.Add(new Coordinate(float.Parse(xCor), float.Parse(yCor)));

                iterator = endLocationOfY ;
            }

            return coordinates;
        }
    }
}
