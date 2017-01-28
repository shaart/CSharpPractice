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
            console.Text += input + '\n' + '>';
        }
    }
}
