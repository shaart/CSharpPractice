using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ISaPI.Code
{
    public static class Console
    {
        public static void ProcessInput(ref TextBox console, string input)
        {
            console.Text += '>' + input + '\n';

            int firstSpace = input.IndexOf(' ');
            string command = input.Trim().Substring(0, (firstSpace > 0 ? firstSpace : input.Length) ).ToLower();

            switch (command)
            {
                case "hello":
                    console.Text += "Hi, user!" + '\n';
                    break;
                default:
                    console.Text += "Received command: " + command + '\n';
                    break;
            }
        }
    }
}
