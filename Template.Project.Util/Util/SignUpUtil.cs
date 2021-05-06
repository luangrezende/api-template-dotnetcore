using System.Linq;
using System;

namespace Template.Project.Util.Util
{
    public class SignUpUtil
    {
        public static string GenereteNewRandomPassword()
        {
            Random random = new Random();

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            return new string(Enumerable.Repeat(chars, 5)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
