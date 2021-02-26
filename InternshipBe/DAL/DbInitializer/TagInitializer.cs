using DAL.DataContext;
using DAL.Entities;

namespace DAL.DbInitializer
{
    public class TagInitializer 
    {
        private readonly ApplicationDbContext _context;

        public TagInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddTag(string name)
        {
            _context.Tags.Add(new Tag
            {
                Name = name,
            });

            _context.SaveChanges();
        }

        public void InitializeTags()
        {
            AddTag("Кондитерские изделия");
            AddTag("Фастфуд");
            AddTag("Напитки");
            AddTag("Пицца");
            AddTag("Уютное место");
            AddTag("Еда навынос");
            AddTag("Доставка");
            AddTag("KFC");
            AddTag("Курица");
            AddTag("Мебель");
            AddTag("Дешево");
            AddTag("Для дома"); 
            AddTag("Выгодно");
            AddTag("Быстро");
            AddTag("Вкусно");
            AddTag("Мода");
            AddTag("Парфюмерия");
            AddTag("Уход за кожей");
            AddTag("Роскошь");
            AddTag("Одежда");
            AddTag("Обувь");
            AddTag("Красота");
            AddTag("Макияж");
            AddTag("Дорого");
            AddTag("Тренировка");
            AddTag("Голод");
            AddTag("Лекарство");
            AddTag("Духи");
            AddTag("Светильник");       
            AddTag("Сантеника");
            AddTag("Уют");
            AddTag("Электротехника");   
            AddTag("Комфорт");
            AddTag("Equipment");
            AddTag("For home");
        }
    }
}
