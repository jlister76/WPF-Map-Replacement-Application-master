using System;
using System.Diagnostics;
using System.Net;
using System.Windows;

namespace FSV42_FullMapReplacement  
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

           
            InitializeComponent();
            _mainFrame.NavigationService.Navigate(new StateSelectorPage());            
            try
            {
                //test for VPN connection via ip
                string externalip = new WebClient().DownloadString("http://icanhazip.com");
                if (externalip.Trim() != "xxx.xx.xxx.xxx")
                {

                    MessageBox.Show("Connect to Heath VPN." + Environment.NewLine + Environment.NewLine + "For assistance with VPN, contact the Help Desk at helpdesk@heathus.com.", "VPN connection required", MessageBoxButton.OK, MessageBoxImage.Stop);
                    Application.Current.Shutdown();
                }

                
                //Exit out FieldSmart and Map Manager
                foreach (Process process in Process.GetProcessesByName("FSShell"))

                {

                    process.Kill();


                }
                foreach (Process process in Process.GetProcessesByName("MapMgr"))

                {

                    process.Kill();


                }
            }
            catch (WebException ex)
            {
                MessageBox.Show("No internet connection detected. Connect to the internet, and try again."+ ex.Message);
               
                Application.Current.Shutdown();
            }
        }
        
    }
}
