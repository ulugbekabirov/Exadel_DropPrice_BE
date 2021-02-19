using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ImageRepository: Repository<Image>, IImageRepository 
    {
        public ImageRepository(ApplicationDbContext context)
            :base(context)
        {

        }

        public async Task<Image> CreateAndReturnImageAsync(byte[] imageData, string filename)
        {
            var image = new Image()
            {
                Name = filename,
                ImageData = imageData
            };

            var savedImage = await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync();

            return savedImage.Entity;
        }
    }
}
