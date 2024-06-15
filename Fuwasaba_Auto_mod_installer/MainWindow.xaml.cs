using System.Windows;
using System.IO;
using System.Net.Http;
using Microsoft.Win32;
using System.IO.Compression;
using Newtonsoft.Json.Linq;
using System.Diagnostics;


namespace Fuwasaba_Auto_mod_installer
{
    public partial class MainWindow : Window
    {
        private static readonly HttpClient client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
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

                string Famifolder = Directory.GetCurrentDirectory();

                var app = new ProcessStartInfo();

                app.FileName = @$"{Famifolder}\download.exe";

                Process.Start(app);

                MessageBox.Show("構成を作成しています。");

                System.Threading.Thread.Sleep(10000);

                File.Move(@$"{Famifolder}\fuwasaba.zip", @$"{folderName}\fuwasaba.zip");

                string zipPath = @$"{folderName}\fuwasaba.zip";
                string extractPath = @$"{folderName}";

                await Task.Run(() => ZipFile.ExtractToDirectory(zipPath, extractPath));
                File.Delete(zipPath);

                string launcherPath = System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    ".minecraft", "launcher_profiles.json"
                );

                if (!File.Exists(launcherPath))
                {
                    MessageBox.Show("launcher_profiles.jsonが見つかりませんでした。");
                    return;
                }

                string jsonText = await File.ReadAllTextAsync(launcherPath);
                JObject launcherProfiles = JObject.Parse(jsonText);

                JObject newProfile = new JObject
                {
                    ["name"] = "ふわ鯖1.5期専用",
                    ["lastVersionId"] = "1.20.1-forge-47.2.32",
                    ["created"] = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                    ["lastUsed"] = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                    ["type"] = "custom",
                    ["icon"] = "Grass",
                    ["gameDir"] = folderName,
                    ["javaArgs"] = "-Xmx4G -XX:+UnlockExperimentalVMOptions -XX:+UseG1GC -XX:G1NewSizePercent=20 -XX:G1ReservePercent=20 -XX:MaxGCPauseMillis=50 -XX:G1HeapRegionSize=32M"
                };

                JObject profiles = (JObject)launcherProfiles["profiles"];
                profiles["MyNewProfile"] = newProfile;

                await File.WriteAllTextAsync(launcherPath, launcherProfiles.ToString());

                MessageBox.Show("構成を作成しました。\nふわ鯖を楽しんでください！");

                System.Diagnostics.Process.Start(@"C:\XboxGames\Minecraft Launcher\Content\Minecraft.exe");

                this.Close();
            }
            else
            {
                System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe", "https://adfoc.us/serve/sitelinks/?id=271228&url=https://maven.minecraftforge.net/net/minecraftforge/forge/1.20.1-47.2.32/forge-1.20.1-47.2.32-installer.jar");
                MessageBox.Show("1.20.1 Forge 47.2.32が存在しません!\nダウンロードしてください。");
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
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

                var app = new ProcessStartInfo();

                app.FileName = "download.exe";

                Process.Start(app);

                MessageBox.Show("構成を作成しています。");

                string zipPath = @$"{folderName}\fuwasaba.zip";
                string extractPath = @$"{folderName}";

                await Task.Run(() => ZipFile.ExtractToDirectory(zipPath, extractPath));
                File.Delete(zipPath);

                string launcherPath = System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    ".minecraft", "launcher_profiles.json"
                );

                if (!File.Exists(launcherPath))
                {
                    MessageBox.Show("launcher_profiles.jsonが見つかりませんでした。");
                    return;
                }

                string jsonText = await File.ReadAllTextAsync(launcherPath);
                JObject launcherProfiles = JObject.Parse(jsonText);

                JObject newProfile = new JObject
                {
                    ["name"] = "ふわ鯖1.5期専用軽量化構成",
                    ["lastVersionId"] = "1.20.1-forge-47.2.32",
                    ["created"] = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                    ["lastUsed"] = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                    ["type"] = "custom",
                    ["icon"] = "Grass",
                    ["gameDir"] = folderName,
                    ["javaArgs"] = "-Xmx4G -XX:+UnlockExperimentalVMOptions -XX:+UseG1GC -XX:G1NewSizePercent=20 -XX:G1ReservePercent=20 -XX:MaxGCPauseMillis=50 -XX:G1HeapRegionSize=32M"
                };

                JObject profiles = (JObject)launcherProfiles["profiles"];
                profiles["MyNewProfile"] = newProfile;

                await File.WriteAllTextAsync(launcherPath, launcherProfiles.ToString());

                MessageBox.Show("構成を作成しました。");

                System.Diagnostics.Process.Start(@"C:\XboxGames\Minecraft Launcher\Content\Minecraft.exe");

                this.Close();
            }
            else
            {
                System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe", "https://adfoc.us/serve/sitelinks/?id=271228&url=https://maven.minecraftforge.net/net/minecraftforge/forge/1.20.1-47.2.32/forge-1.20.1-47.2.32-installer.jar");
                MessageBox.Show("1.20.1 Forge 47.2.32が存在しません!\nダウンロードしてください。");
            }
        }
    }
}