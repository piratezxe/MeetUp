namespace PlayTogether.Core.Domains
{
    public class Company
    {
        public Adress Adress { get; protected set; }

        public int Founded { get; protected set; }

        public string Sector { get; protected set; }

        public string Revenue { get; protected set; }

        public string Headquarters { get; protected set; }

        public Company()
        {

        }
    }
}