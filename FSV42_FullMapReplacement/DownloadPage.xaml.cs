using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;




namespace FSV42_FullMapReplacement
{
    /// <summary>
    /// Interaction logic for DownloadPage.xaml
    /// </summary>
    public partial class DownloadPage : Page
    {

        WebClient webClient = null;
        public DownloadPage(string val) 
        {
            InitializeComponent();

            
            //set variables
            filetodownload.Content = string.Empty;
            filesize.Content = string.Empty;
            string uri = string.Empty;
            string localpath = string.Empty;
            string filename = string.Empty;
            string programFiles = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles);

            //path selection
            switch (val)
            {
                case "Texas":                    
                    uri = @"\\XX.X.X.XX\CLIENTPATH\Outgoing\FullInstalls\TX.exe";
                    localpath = programFiles + @"\FSV42\TX.exe";
                    filename = "TX";
                    filetodownload.Content = "Downloading Texas map update";

                    break;
                case "Kentucky / Tennessee":
                    uri = @"\\XX.X.X.XX\CLIENTPATH\Outgoing\FullInstalls\KY-mid.exe";
                    localpath = programFiles + @"\FSV42\KY-mid.exe";
                    filename = "KY-Mid";
                    filetodownload.Content = "Downloading KY-Mid map update";
                    break;
                case "Mississippi":
                    uri = @"\\XX.X.X.XX\CLIENTPATH\Outgoing\FullInstalls\MS.exe";
                    localpath = programFiles + @"\FSV42\MS.exe";
                    filename = "MS";
                    filetodownload.Content = "Downloading Mississippi map update";
                    break;
            }

            webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WC_DownloadProgressChanged);
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(WC_DownloadFileCompleted);
            webClient.DownloadFileAsync(new System.Uri(uri), localpath, filename);
            
        }

        //eventhandlers
        private void WC_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            
            Dispatcher.BeginInvoke((Action)(() =>
            {

                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                double bytesRemaining = Math.Abs(totalBytes - bytesIn) / 1000;
                filesize.Content = "Remaining " + Math.Abs(e.TotalBytesToReceive - e.BytesReceived) / 1000 + "KB";
                progressBar.Value = e.ProgressPercentage;


            }));

        }
        private void WC_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            
            Dispatcher.BeginInvoke((Action)(() =>
            {

                if (e.Cancelled)
                {
                    MessageBox.Show("Download cancelled.");
                    webClient.Dispose();
                    // delete the partially-downloaded file
                }
                else if (e.Error != null)
                {
                    
                    Console.WriteLine(e.Error);
                    MessageBox.Show("File Access Error" + e.Error,"File Access Error",MessageBoxButton.OK, MessageBoxImage.Error);
                    Application.Current.Shutdown();
                }
                else
                {
                    filetodownload.Content = "Download Complete";
                    filesize.Content = "";
                    progressBar.Visibility = Visibility.Hidden;
                    string filename = (string)e.UserState;
                    try
                    {
                        ExtractUpdate(filename);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    filetodownload.Content = "Installing map files";
                }
            }));

        }
        private void ExtractUpdate(string filename)
        {

            try
            {
                ProcessStartInfo Info = new ProcessStartInfo();
                Info.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\FSV42\";
                Info.FileName = filename+".exe";
                Info.Arguments = " -y";                
                Process.Start(Info).WaitForExit();


                //rename config files to .old
                if (File.Exists(Info.WorkingDirectory + filename + @"\DV.ini.old"))
                {  //delete existing
                    File.Delete(Info.WorkingDirectory + filename + @"\DV.ini.old");

                }
                //rename current to old
                File.Move(Info.WorkingDirectory + filename + @"\DV.ini", Info.WorkingDirectory + filename + @"\DV.ini.old");

                if (File.Exists(Info.WorkingDirectory + filename + @"\gps.ini.old"))
                {
                    //delete existing
                    File.Delete(Info.WorkingDirectory + filename + @"\gps.ini.old");

                }
                //rename curren to old
                File.Move(Info.WorkingDirectory + filename + @"\gps.ini", Info.WorkingDirectory + filename + @"\gps.ini.old");
                switch (filename)
                {
                    case "TX":
                        if (Environment.Is64BitOperatingSystem)
                        {
                            ////supress SFSUpdate and GPS COM
                            File.WriteAllText(Info.WorkingDirectory + filename + @"\DV.ini", Properties.Resources.DV64BITTX);
                            File.WriteAllText(Info.WorkingDirectory + filename + @"\gps.ini", Properties.Resources.gps);

                        }
                        else
                        {
                            File.WriteAllText(Info.WorkingDirectory + filename + @"\DV.ini", Properties.Resources.DV32TX);
                            File.WriteAllText(Info.WorkingDirectory + filename + @"\gps.ini", Properties.Resources.gps);
                        }
                        break;
                    case "KY-Mid":
                        if (Environment.Is64BitOperatingSystem)
                        {
                            ////supress SFSUpdate and GPS COM
                            File.WriteAllText(Info.WorkingDirectory + filename + @"\DV.ini", Properties.Resources.DV64BITKY);
                            File.WriteAllText(Info.WorkingDirectory + filename + @"\gps.ini", Properties.Resources.gps);

                        }
                        else
                        {
                            File.WriteAllText(Info.WorkingDirectory + filename + @"\DV.ini", Properties.Resources.DV32KY);
                            File.WriteAllText(Info.WorkingDirectory + filename + @"\gps.ini", Properties.Resources.gps);
                        }
                        break;
                    case "MS":
                        if (Environment.Is64BitOperatingSystem)
                        {
                            ////supress SFSUpdate and GPS COM
                            File.WriteAllText(Info.WorkingDirectory + filename + @"\DV.ini", Properties.Resources.DV64BITMS);
                            File.WriteAllText(Info.WorkingDirectory + filename + @"\gps.ini", Properties.Resources.gps);

                        }
                        else
                        {
                            File.WriteAllText(Info.WorkingDirectory + filename + @"\DV.ini", Properties.Resources.DV32MS);
                            File.WriteAllText(Info.WorkingDirectory + filename + @"\gps.ini", Properties.Resources.gps);
                        }
                        break;                   
                }
               
                

               

                //persist to database
                atmos_mapupdate update = new atmos_mapupdate()
                {

                    date = DateTime.Now,
                    region = filename,
                    computer_name = Environment.MachineName,
                    username = Environment.UserName
                };

                using (MUDataClassesDataContext dc = new MUDataClassesDataContext(Properties.Settings.Default.map_updatesConnectionString))
                {
                    dc.atmos_mapupdates.InsertOnSubmit(update);
                    dc.SubmitChanges();
                    
                }
                ProcessStartInfo Info2 = new ProcessStartInfo();
                Info2.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\FSV42\"+filename+@"\";
                Info2.FileName = "FSShell.exe";                
                Process.Start(Info2);

                MessageBox.Show("Update installed. Opening FieldSmart.", "Success Message", MessageBoxButton.OK, MessageBoxImage.Information);

                Application.Current.Shutdown();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        private void Back_cancel_Click(object sender, RoutedEventArgs e)
        {
            webClient.CancelAsync();
            webClient.Dispose();
            NavigationService.Navigate(new StateSelectorPage());
        }
        private void App_Exit(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel this update?","Exit Application",MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            
        }

        
    }
}
