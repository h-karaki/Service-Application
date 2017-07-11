namespace ServiceApplication.Models
{
    public class Coordinate
    {
        float _lat;
        float _lng;

        public float X { get => _lat; set => _lat = value; }
        public float Y { get => _lng; set => _lng = value; }

        public Coordinate()
        {
        }

        public Coordinate(float x, float y)
        {
            this._lat = x;
            this._lng = y;
        }

        public void SetCoordinates(float x, float y)
        {
            this._lat = x;
            this._lng = y;
        }

        public string ReturnCoordinatesInText()
        {
            return "X: " + X + " Y: " + Y;
        }

    }//End Class
}
