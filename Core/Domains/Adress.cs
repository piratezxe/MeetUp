namespace PlayTogether.Core.Domains
{
    public class Adress
    {
        public string City { get; private set; } 

        public string ZipCode { get; private set; }

        public Coordinate Coordinate { get; private set; }

        public Adress(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }

        public Adress(Coordinate coordinate, string city)
        {
            City = city;
            Coordinate = coordinate;
        }
        public Adress( string city)
        {
            City = city;
        }
    }
}