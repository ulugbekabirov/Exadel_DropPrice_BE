namespace DAL.Entities
{
    public class Image
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] ImageData { get; set; }
    }
}
