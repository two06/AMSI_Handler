using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Helpers
{
    class RandomData
    {
        private static Random random = new Random();
        /// <summary>
        /// Generates a random string of given length
        /// </summary>
        /// <param name="length">Lenght of random string required</param>
        /// <returns>Random alpha-numeric string</returns>
        public static string RandomString(int length)
        {
            //https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomMultiLineString(int length, int lineLength)
        {
            var s = "";
            for(int i = 0; i < length; i++)
            {
                s += RandomString(lineLength) + System.Environment.NewLine;
            }
            return s;
        }
    }
}
