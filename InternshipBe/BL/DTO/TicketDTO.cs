using System;
using System.Reflection;

namespace BL.DTO
{
    public class TicketDTO
    {
        public int DiscountId { get; set; }

        public int VendorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public string VendorName { get; set; }

        public string DiscountName { get; set; }

        public string VendorEmail { get; set; }

        public string VendorPhone { get; set; }

        public string PromoCode { get; set; }

        public int DiscountAmount { get; set; }

        public DateTime OrderDate { get; set; }

        public bool IsExpired { get; set; }

        public bool DiscountActivity { get; set; }

        public bool IsSavedDiscount { get; set; }

        public override bool Equals(object obj)
        {
            var result = true;

            if (obj is TicketDTO ticketDTO)
            {
                var typeOfTicket = typeof(TicketDTO);
                var ticketFields = typeOfTicket.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                foreach (var field in ticketFields)
                {
                    var objValue = field.GetValue(this);
                    var ticketDTOValue = field.GetValue(ticketDTO);

                    if (!Equals(objValue, ticketDTOValue))
                    {
                        if (objValue is DateTime objDate)
                        {
                            result = objDate.Date == ((DateTime)ticketDTOValue).Date;
                            continue;
                        }

                        result = false;
                    }
                }
            }
            else
            {
                return false;
            }

            return result;
        }

        public override int GetHashCode()
        {
            return Guid.NewGuid().GetHashCode();
        }
    }
}
