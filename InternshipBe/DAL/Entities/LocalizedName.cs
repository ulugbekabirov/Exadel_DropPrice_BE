using Shared.Middleware.Localization;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;

namespace DAL.Entities
{
    [ComplexType]
    public class LocalizedName
    {
        public int Id { get; set; }

        public string Russian { get; set; }

        public string English { get; set; }

        [NotMapped]
        public string Current
        {
            get => (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName) switch
                {
                    Cultures.Russian => Russian,
                    Cultures.English => English,
                    _ => English,
                };
        }
    }
}
