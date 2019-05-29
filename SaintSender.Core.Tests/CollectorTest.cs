using System;
using System.Linq;
using NUnit.Framework;
using SaintSender.Core.Entities;

namespace SaintSender.Core.Tests
{
    [TestFixture]
    class CollectorTest
    {
        [Test]
        public void GetAllEmails()
        {
            var mailRepository = new MailKitPractice("imap.gmail.com", 993, true, "colos.menesi@gmail.com", "AtomicBlonde2017");
            var allEmails = mailRepository.GetAllMails();

            foreach (var email in allEmails)
            {
                Console.WriteLine(email);
            }

            Assert.IsTrue(true);
        }
    }
}
