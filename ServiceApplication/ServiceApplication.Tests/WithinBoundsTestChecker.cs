using ServiceApplication.Models;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace ServiceApplication.Tests
{
    [TestFixture]
    class WithinBoundsCheckerTest
    {
        [Test] //TODO: Randomize Test Data to help check for Algorithm flaws and increase unit test quality.
        public void Giving_it_a_point_and_should_give_me_true_if_in_bounds()
        {
            //arrange
            Coordinate testingPoint = new Coordinate((float) 10, (float) 10);

            List<Coordinate> boundingCoordinates = new List<Coordinate>();
            boundingCoordinates.Add(new Coordinate((float) (20), (float) (20)));
            boundingCoordinates.Add(new Coordinate((float) (0), (float) (20)));
            boundingCoordinates.Add(new Coordinate((float) (0), (float) (0)));
            boundingCoordinates.Add(new Coordinate((float) (20), (float) (0)));

            //act
            bool result = IsPointInPolygon4(boundingCoordinates, testingPoint);

            //assert 
            Assert.AreEqual(result, true);
        }


        public static bool IsPointInPolygon4(List<Coordinate> polygon, Coordinate testPoint)
        {
            bool result = false;
            int j = polygon.Count() - 1;
            for (int i = 0; i < polygon.Count(); i++)
            {
                if (polygon[i].Y < testPoint.Y && polygon[j].Y >= testPoint.Y ||
                    polygon[j].Y < testPoint.Y && polygon[i].Y >= testPoint.Y)
                {
                    if (polygon[i].X + (testPoint.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) *
                        (polygon[j].X - polygon[i].X) < testPoint.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }
    }
}
