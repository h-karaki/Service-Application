using NUnit.Framework;
using ServiceApplication.Models;
using System.Collections.Generic;

namespace ServiceApplication.Tests
{
    [TestFixture]
    public class ParseStringsToCoordinatesTest
    {
        [Test]
        public void Giving_It_An_Input_String_Should_return_a_List_of_Coordinates()
        {
            //arrange
            string inputString = "(37.5, -122.5), (38.2, -121.6), (37.0, -121.4), (36.6, -121.3)";
            Coordinate coor1 = new Coordinate((float)37.5, (float)-122.5);
            Coordinate coor2 = new Coordinate((float)38.2, (float)-121.6);
            Coordinate coor3 = new Coordinate((float)37.0, (float)-121.4);
            Coordinate coor4 = new Coordinate((float)36.6, (float)-121.3);
            List<Coordinate> expected = new List<Coordinate>();
            expected.Add(coor1);
            expected.Add(coor2);
            expected.Add(coor3);
            expected.Add(coor4);

            //act
            List<Coordinate> actual = GiveMeCoordinates(inputString);

            //assert
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(expected[i].X, actual[i].X);
                Assert.AreEqual(expected[i].Y, actual[i].Y);
            }
        }

        public static List<Coordinate> GiveMeCoordinates(string inputString)
        {
            List<Coordinate> coordinates = new List<Coordinate>();

            int iterator = 0;

            while (iterator != inputString.Length - 1)
            {
                int startLocationOfX = inputString.IndexOf('(', iterator) + 1;
                int endLocationOfX = inputString.IndexOf(',', iterator + 3);
                iterator = endLocationOfX;
                int startLocationOfY = inputString.IndexOf(' ', iterator) + 1;
                int endLocationOfY = inputString.IndexOf(')', iterator);

                string xCor = inputString.Substring(startLocationOfX, endLocationOfX - startLocationOfX);
                string yCor = inputString.Substring(startLocationOfY, endLocationOfY - startLocationOfY);

                coordinates.Add(new Coordinate(float.Parse(xCor), float.Parse(yCor)));

                iterator = endLocationOfY;
            }

            return coordinates;
        }
    }
}
