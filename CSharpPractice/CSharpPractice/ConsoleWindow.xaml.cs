using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace CSharpPractice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class ConsoleWindow : Window
    {
        // Это наш специальный класс TextWriter
        TextWriter _writer = null;
        
        public ConsoleWindow()
        {
            InitializeComponent();

            _writer = new Code.TextBoxStreamWriter(_Console);
            System.Console.SetOut(_writer);
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            Code.AppConsole.ProcessInput(_Input.Text);
            _Input.Text = "";
        }

        private void _Console_TextChanged(object sender, TextChangedEventArgs e)
        {
            _Console.ScrollToEnd();
        }
    }
}
