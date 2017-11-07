namespace CommonInformation.ModalWindow
{
    /// <summary>
    /// Логика взаимодействия для ConfirmationTextControl.xaml
    /// </summary>
    public partial class ConfirmationTextControl : IModalWindowSettings
    {
        public ConfirmationTextControl(string confirmationText, ModalWindowSettings settings = null)
        {
            InitializeComponent();
            PART_Text.Text = confirmationText;
            WindowSettings = settings;
        }

        public ModalWindowSettings WindowSettings { get; }
    }
}
