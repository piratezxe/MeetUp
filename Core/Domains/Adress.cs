namespace PlayTogether.Core.Domains
{
    public class Adress
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string City { get; set; }

        public Adress(double lat, double longi, string city)
        {
            Latitude = lat;
            Longitude = longi;
            City = city;
        }

    }
}