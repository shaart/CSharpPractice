using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Collections.Generic;

namespace CSharpPractice
{
    public partial class ConsoleWindow : Window
    {
        TextWriter _writer = null;

        public ConsoleWindow()
        {
            InitializeComponent();
            
            _writer = new TextBoxStreamWriter(_Console);
            System.Console.SetOut(_writer);
            AppConsole.LoadPlugins("Plugins");
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            AppConsole.RunCommand(_Input.Text);
            _Input.Text = "";
        }

        private void _Console_TextChanged(object sender, TextChangedEventArgs e)
        {
            _Console.ScrollToEnd();
        }

        private void ConsoleWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _Input.Focus();
        }
    }
}
