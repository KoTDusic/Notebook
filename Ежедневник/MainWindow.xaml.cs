using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using CommonInformation.Repozitorys;
namespace Notebook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MaxWidth = SystemParameters.WorkArea.Width / 2;
            Height = SystemParameters.WorkArea.Height;
            Width = MinWidth;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }
    }
}
