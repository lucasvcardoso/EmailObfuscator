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
        public void ObfuscateLocalPart()
        {
            //Arrange
            string email = $"name.surname@emailprovider.com";
            string expected = $"*****surname@emailprovider.com";

            //Act
            string result = Email.Obfuscate(email);

            //Assert
            Console.WriteLine(result);
            Assert.AreEqual(expected, result, $"Obfuscation result: {result}");
        }

        [Test]
        public void ThrowExceptionWhenEmailIsInvalid()
        {
            try
            {
                //Arrange
                string invalidEmail = "emailWithoutAtSymbol.com";
                //Act
                Email.Obfuscate(invalidEmail);
                //Assert
                Assert.Fail();
            }
            catch (Exception ex)
            {
                //Assert
                Assert.Pass(ex.Message);
                Console.WriteLine(ex.Message);
            }            
        }

        [Test]
        public void ObfuscateWithNumberOfAsteriskLesserThenEmailPrefix()
        {
            //Arrange
            string email = "name.surname@emailprovider.com";
            string expected = "****.surname@emailprovider.com";

            //Act
            string result = Email.Obfuscate(email, 4);

            //Assert
            Assert.AreEqual(expected, result, $"Obfuscation result: {result}");
            Console.WriteLine(result);
        }

        [Test]
        public void ObfuscateWithNumberOfAsteriskGreaterThenEmailPrefix()
        {
            //Arrange
            string email = "name.surname@emailprovider.com";
            string expected = "************@emailprovider.com";

            //Act
            string result = Email.Obfuscate(email, 14);

            //Assert
            Assert.AreEqual(expected, result, $"Obfuscation result: {result}");
            Console.WriteLine(result);
        }

        [Test]
        public void ObfuscatePassingTheSectionToObfuscate()
        {
            //Arrange
            string email = "name.surname@emailprovider.com";
            string expected = "name.su*****@emailprovider.com";

            //Act
            string result = Email.Obfuscate(email, section: EmailOptions.ObfuscateEndLocalPart);

            //Assert
            Assert.AreEqual(expected, result, $"Obfuscation result: {result}");
            Console.WriteLine(result);
        }

        [Test]
        public void ObfuscateDomain()
        {
            //Arrange
            string email = $"name.surname@emailprovider.com";
            string expected = $"name.surname@*****provider.com";

            //Act
            string result = Email.Obfuscate(email, section: EmailOptions.ObfuscateDomain);

            //Assert
            Console.WriteLine(result);
            Assert.AreEqual(expected, result, $"Obfuscation result: {result}");
        }
    }
}
