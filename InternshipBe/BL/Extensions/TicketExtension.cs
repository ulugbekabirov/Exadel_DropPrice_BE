using DAL.Entities;
using System;

namespace BL.Extensions
{
    public static class TicketExtension
    {
        public static bool IsExpired(this Ticket ticket)
        {
            return ticket.OrderDate.Date != DateTime.Now.Date;
        }
    }
}
