using System;
using System.Threading;

namespace PhotoTransfer.Data
{
    public static class KeyGenerator
    {
        private static Random rnd = new Random(unchecked((int)(DateTime.Now.Ticks)));

        /// <summary>
        /// Gets the unique key for identification of object.
        /// </summary>
        /// <param name="inStrCode">The in STR code.</param>
        /// <returns>The unique key.</returns>
        public static string GetKey(string inStrCode)
        {
            if (inStrCode.Length == 0)
                inStrCode = "SYST";
            else
            {
                inStrCode += "SYST";
                inStrCode = inStrCode.Substring(0, 4);
            }

            return DateTime.Now.ToString("yyMMddHHmmss") + inStrCode + rnd.Next(1000000).ToString("000000");
        }
    }
}
