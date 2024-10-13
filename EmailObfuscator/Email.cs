using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmailObfuscator
{
    public class Email
    {
        const int NUMBER_OF_ASTERISKS = 5;

        public static string Obfuscate(string emailAddress, int numberOfAsterisks = NUMBER_OF_ASTERISKS, EmailOptions section = EmailOptions.ObfuscateBegginingLocalPart)
        {
            string obfuscatedEmail = "";

            try
            {
                string[] parts = emailAddress.Split('@');


                if (section != EmailOptions.ObfuscateDomain)
                {
                    obfuscatedEmail = ObfuscateLocalPart(section, parts, numberOfAsterisks);
                }
                else
                {
                    obfuscatedEmail = ObfuscateDomain(section, parts, numberOfAsterisks);
                }
            }
            catch (Exception)
            {
                throw new FormatException($"Invalid e-mail format: {emailAddress}");
            }

            return obfuscatedEmail;
        }

        private static string ObfuscateDomain(EmailOptions section, string[] parts, int numberOfAsterisks)
        {
            string obfuscatedEmail;
            int endPosition = parts[1].Length < numberOfAsterisks ? parts[1].Length : numberOfAsterisks;
            string asterisks = new string('*', endPosition);

            string domain = parts[1].Substring(endPosition);
            obfuscatedEmail = $"{parts[0]}@{asterisks}{domain}";
            return obfuscatedEmail;
        }

        private static string ObfuscateLocalPart(EmailOptions section, string[] parts, int numberOfAsterisks)
        {
            string obfuscatedEmail;
            int endPosition = parts[0].Length < numberOfAsterisks ? parts[0].Length : numberOfAsterisks;
            string asterisks = new string('*', endPosition);

            if (section == EmailOptions.ObfuscateBegginingLocalPart)
            {
                string localPart = parts[0].Substring(endPosition);
                obfuscatedEmail = $"{asterisks}{localPart}@{parts[1]}";
            }
            else
            {
                string unbofuscatedSection = parts[0].Substring(0, parts[0].Length - endPosition);
                obfuscatedEmail = $"{unbofuscatedSection}{asterisks}@{parts[1]}";
            }

            return obfuscatedEmail;
        }
    }
}
