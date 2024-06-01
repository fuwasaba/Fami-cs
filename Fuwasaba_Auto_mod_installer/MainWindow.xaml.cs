using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Security.Principal;
using Microsoft.Win32;
using System.Net;
using System.Net.Http;
using System.Linq;
using System.Collections.Generic;


namespace Fuwasaba_Auto_mod_installer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string filePath = @$"C:\Users\{Environment.UserName}\AppData\Roaming\.minecraft\versions\1.20.1-forge-47.2.32";

            if (Directory.Exists(filePath))
            {
                OpenFolderDialog dialog = new OpenFolderDialog()
                {
                    Title = "フォルダ選択",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    Multiselect = false
                };

                string folderName = "";
                if (dialog.ShowDialog() == true)
                {
                    folderName = dialog.FolderName;
                }

                string remoteUri = "https://www.dropbox.com/scl/fi/094iy3s80b0ithw7xwmws/mods.zip?rlkey=ebiajl98y91db8biwwgj72jj9&st=ikvyt4sq&dl=1";
                string fileName = "mods.zip";
                string dest = @$"{folderName}\{fileName}";

                using (WebClient webClient = new WebClient())
                {
                    MessageBox.Show("ダウンロードしています。");

                    webClient.DownloadFile(remoteUri + fileName, dest);

                    MessageBox.Show("ダウンロードしました。");
                }

            }
            else
            {
                System.Diagnostics.Process.Start(@"C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe", "https://adfoc.us/serve/sitelinks/?id=271228&url=https://maven.minecraftforge.net/net/minecraftforge/forge/1.20.1-47.2.32/forge-1.20.1-47.2.32-installer.jar");
                MessageBox.Show("1.20.1 Forge 47.2.32が存在しません!\nダウンロードしてください。");
            }
        }
    }
}