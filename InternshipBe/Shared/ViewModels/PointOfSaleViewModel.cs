namespace WebApi.ViewModels
{
    public class PointOfSaleViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}