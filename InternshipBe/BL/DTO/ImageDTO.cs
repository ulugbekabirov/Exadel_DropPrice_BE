namespace BL.DTO
{
    public class ImageDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] ImageData { get; set; }

        public string ContentType { get; set; }
    }
}
