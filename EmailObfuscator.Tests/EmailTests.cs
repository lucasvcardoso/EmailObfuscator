using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailObfuscator;

namespace EmailObfuscator
{
    public class EmailTests
    {
        [Test]
        public void ObfuscateTest()
        {
            //Arrange
            string email = $"name.surname@emailprovider.com";
            string expected = $"*****surname@emailprovider.com";

            //Act
            string obfuscated = Email.Obfuscate(email);

            //Assert
            Assert.AreEqual(expected, obfuscated);
        }
    }
}
