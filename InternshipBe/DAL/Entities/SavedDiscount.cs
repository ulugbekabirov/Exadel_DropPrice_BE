namespace DAL.Entities
{
    public class SavedDiscount
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int DiscountId { get; set; }

        public virtual Discount Discount { get; set; }
    }
}
