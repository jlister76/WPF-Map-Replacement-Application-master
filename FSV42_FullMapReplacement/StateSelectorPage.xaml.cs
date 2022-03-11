using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace FSV42_FullMapReplacement
{
    /// <summary>
    /// Interaction logic for StateSelectorPage.xaml
    /// </summary>
    public partial class StateSelectorPage : Page
    {
        public string state;
        public StateSelectorPage()
        {
            
            InitializeComponent();

            //set data context for combobox
            DataContext = new ComboBoxViewModel();
        }

        private void NEXTBTN_Click(object sender, RoutedEventArgs e)
        {
            state = comboBox.Text;

            if (comboBox.SelectedItem != null)
            {
                NavigationService.Navigate(new DownloadPage(state));
            }

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //checks for user selection
            if (comboBox.SelectedIndex > -1)
            {
                NEXT_BTN.IsEnabled = true;
            }
        }
    }
}
