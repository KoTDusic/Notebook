using System.Windows;

namespace CommonInformation
{
    /// <summary>
    /// Логика взаимодействия для CommonModalWindow.xaml
    /// </summary>
    public partial class CommonModalWindow : Window
    {
        public CommonModalWindow(FrameworkElement content, params ModalWindowControl[] items)
        {
            InitializeComponent();
            PART_ContentPresenter.Content = content;
            foreach (var item in items)
            {
                if (item.Location == ControlLocation.Left)
                {
                    PART_LeftPanel.Children.Add(item.Item);
                }
                if (item.Location == ControlLocation.Right)
                {
                    PART_RightPanel.Children.Add(item.Item);
                }
                if (item.Location == ControlLocation.Center)
                {
                    PART_CenterPanel.Children.Add(item.Item);
                }
            }
        }
    }
}
