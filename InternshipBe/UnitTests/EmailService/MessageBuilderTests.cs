using BL.EmailService;
using DAL.Entities;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.EmailService
{
    public class MessageBuilderTests
    {
        private User _user;
        private Ticket _ticket;

        public MessageBuilderTests()
        {
            _user = new User();
            _ticket = new Ticket();
        }

        [Fact]
        public void GenerateMessageForUserAsync_WhenCalled_StringModifiedWithRegulars()
        {

        }
    }
}
