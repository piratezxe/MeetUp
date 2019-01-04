namespace PlayTogether.Core.Domains
{
    public class Coordinate
    {
        public double Latitude { get; set; }
        
        public double Longnitude { get; set; }

        public Coordinate(double latitude, double longnitude)
        {
            Latitude = latitude;

            Longnitude = longnitude;
        }
    }
}