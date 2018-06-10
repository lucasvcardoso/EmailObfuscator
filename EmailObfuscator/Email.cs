using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmailObfuscator
{
    public class Email
    {
        const int NUMBER_OF_ASTERISKS = 5;        

        public static string Obfuscate(string emailAddress, int numberOfAsterisks = NUMBER_OF_ASTERISKS, EmailOptions section = EmailOptions.ObfuscateBeggining)
        {
            string obfuscatedEmail = "";

            try
            {
                string[] parts = emailAddress.Split('@');                
                int endPosition = parts[0].Length < numberOfAsterisks ? parts[0].Length : numberOfAsterisks;
                string asterisks = new string('*', endPosition);

                if (section == EmailOptions.ObfuscateBeggining)
                {
                    string primeiraParte = parts[0].Substring(endPosition);
                    obfuscatedEmail = $"{asterisks}{primeiraParte}@{parts[1]}";
                }
                else
                {
                    string unbofuscatedSection = parts[0].Substring(0,parts[0].Length-endPosition);
                    obfuscatedEmail = $"{unbofuscatedSection}{asterisks}@{parts[1]}";
                }
            }
            catch (Exception)
            {
                throw new FormatException($"Invalid e-mail format: {emailAddress}"); 
            }

            return obfuscatedEmail;
        }
    }
}
