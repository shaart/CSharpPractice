using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace ISaPI
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
            Code.MyConsole.ProcessInput(_Input.Text);
            _Input.Text = "";
        }
    }
}
