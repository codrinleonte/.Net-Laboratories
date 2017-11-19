using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnsureThat;

namespace Common
{
    public static class StringService
    {
        public static bool IsPalindome(this string input)
        {
           
            Ensure.That(input, "Not null").IsNotNullOrEmpty();
            string output = new string(input.ToCharArray().Reverse().ToArray());
            return (String.Compare(output,input)==0);
        }

        public static string Concatenate(params string[] values)
        {
            return String.Concat(values);
        }
    }
}
