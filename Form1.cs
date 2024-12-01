namespace Auto_Click
{
    using Emgu.CV.CvEnum;
    using Emgu.CV.Structure;
    using Emgu.CV;
    using Emgu.CV.Util;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System.Security.Cryptography;
    using System.Text;
    using System.Diagnostics;
    using System.Text;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using System.Security.Policy;
    using System.Net;

    public partial class Auto_Click : Form
    {

        // Init Variable
        public string chromePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
        public static string currentDir = Environment.CurrentDirectory;
        public static string dataDir = Environment.CurrentDirectory + @"\Resource\data.json";
        public static string sceneDir = Environment.CurrentDirectory + @"\Resource\scenes.txt";
        public static string ImageDir = Environment.CurrentDirectory + @"\Resource\Image\";
        public static string chromeDriverDir = Environment.CurrentDirectory + @"\Resource\chromdriver\";
        public static List<int> listPID = new List<int>();
        public static string versionChrome = getVersionChrome();
        public static string key = "ECQSgnpmQU";
        public static bool updateNow = false;
        public string chromeDriverPath = currentDir + @"\Resource\" + versionChrome + @"\chromedriver.exe";
        //public DataGridView dataGridView;
        public List<(string, string)> listData;
        //
        public Auto_Click()
        {
            InitializeComponent();
            this.Icon = new Icon(Environment.CurrentDirectory + "\\pb.ico");
            listData = new List<(string, string)>();
            updateData();
            displayData(listData);
            chromePath = loadBrowser();
            jHashID.Text = key;
        }
        private async void InitializeAsync()
        {
            if (updateNow) {
                jCheckforupdatesbutton.BackColor = Color.Red;
                jCheckforupdatesbutton.Text = "Updating";
                string UpdateUrl = "https://github.com/duongtranbka/update/raw/refs/heads/main/Auto_Click.dll";
                string DllPath = Environment.CurrentDirectory + "\\Auto_Click.dll";
                string TempUpdaterPath = Environment.CurrentDirectory + "\\updater.exe";
                using (HttpClient client = new HttpClient())
                {
                    string url = "https://raw.githubusercontent.com/duongtranbka/update/refs/heads/main/update.json";
                    try
                    {
                        string json = await client.GetStringAsync(url);

                        JObject jsonObject = JObject.Parse(json);
                        var jsonData = (JObject)jsonObject["Click"];
                        foreach (var property in jsonData)
                        {
                            UpdateUrl = property.Value.ToString();
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                string tempDllPath = Environment.CurrentDirectory + "\\Auto_Click_new.dll";
                using (var client = new WebClient())
                {
                    client.DownloadFile(UpdateUrl, tempDllPath);
                }
                string args = $"\"{DllPath}\" \"{tempDllPath}\" \"{Application.ExecutablePath}\"";
                Process.Start(TempUpdaterPath, args);
                Application.Exit();
            }
            bool isUpdateAvailable = await checkforUpdate();
            if (isUpdateAvailable)
            {
                jCheckforupdatesbutton.BackColor = Color.Green;
                jCheckforupdatesbutton.Text = "Click for Update";
                updateNow = true;
            }
        }
        public async Task<bool> checkforUpdate()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://raw.githubusercontent.com/duongtranbka/update/refs/heads/main/update.json";
                try
                {
                    string json = await client.GetStringAsync(url);

                    //var jsonObject = JsonConvert.DeserializeObject<dynamic>(json);

                    JObject jsonObject = JObject.Parse(json);
                    var jsonData = (JObject)jsonObject["Click"];
                    foreach (var property in jsonData)
                    {
                        if (property.Key == key)
                        {
                            return false;
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return true;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            chromePath = loadBrowser();
            SelectColRow selectCRForm = new SelectColRow(this);
            selectCRForm.Show();
        }

        // Function

        public class Profiles
        {
            public string id { get; set; }
            public ProfileDetail Detail { get; set; }
            public class ProfileDetail
            {
                public string userDir { get; set; }
                public string ProfileName { get; set; }
                public ProfileDetail(string mUserDir, string mProfileName)
                {
                    this.userDir = mUserDir;
                    this.ProfileName = mProfileName;
                }
            }
            public Profiles(string id)
            {
                this.id = id;

            }
        }
        private void displayData(List<(string, string)> listData)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns.Add("Path", "Path");
            dataGridView1.Columns.Add("Key", "Key");

            int totalWidth = dataGridView1.Width;
            dataGridView1.Columns["Path"].Width = (int)(totalWidth * 0.39);
            dataGridView1.Columns["Key"].Width = (int)(totalWidth * 0.6);
            foreach (var item in listData)
            {
                string profileName = item.Item1.Split("|")[1];
                string status = item.Item2;
                dataGridView1.Rows.Add(profileName, status);
            }
        }
        public void updateData()
        {
            listData = new List<(string, string)>();
            string jsonContent = File.ReadAllText(dataDir);
            JObject jsonObject = JObject.Parse(jsonContent);
            JArray profilesArray = (JArray)jsonObject["Profiles"];
            if (profilesArray != null)
            {
                foreach (JObject obj in profilesArray)
                {
                    foreach (var val in obj.Properties())
                    {
                        String key = val.Name;
                        JObject profileDetails = (JObject)val.Value;
                        string content = "";
                        content += profileDetails["userDataDir"] + "|" + profileDetails["profileName"];
                        listData.Add((content, key));
                    }
                }
                displayData(listData);
            }
        }
        public static string getVersionChrome()
        {
            string jsonContent = File.ReadAllText(dataDir);
            JObject jsonObject = JObject.Parse(jsonContent);
            return jsonObject["versionChrome"].ToString();
        }
        public string getIDHash()
        {
            long milliseconds = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            return HashToId(milliseconds.ToString(), 10);
        }
        static string HashToId(string input, int length)
        {
            if (length <= 0) throw new ArgumentException("Length must be greater than 0.");

            // Compute the hash of the input
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert hash bytes to a Base62 string
                const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                StringBuilder idBuilder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length && idBuilder.Length < length; i++)
                {
                    idBuilder.Append(chars[hashBytes[i] % chars.Length]);
                }

                // Ensure the ID is exactly the desired length
                while (idBuilder.Length < length)
                {
                    idBuilder.Append(chars[new Random().Next(chars.Length)]);
                }

                return idBuilder.ToString();
            }
        }
        public void takeScreenShot()
        {
            IWebDriver driver = new ChromeDriver();

            try
            {
                // Navigate to a URL
                driver.Navigate().GoToUrl("https://google.com");

                // Take a screenshot
                ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
                Screenshot screenshot = screenshotDriver.GetScreenshot();

                // Save the screenshot to a file
                string filePath = @"C:\Screenshots\screenshot.png";
                //screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);

                Console.WriteLine($"Screenshot saved at: {filePath}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
            finally
            {
                // Quit the driver
                driver.Quit();
            }
        }
        public void checkImage()
        {
            string bigImagePath = @"D:\CSharp\Auto_Click\bin\Debug\net8.0-windows\Resource\screenshot.png";
            string smallImagePath = @"C:\Users\LUCKY\Pictures\1thunder.PNG";

            // Load the images
            Mat bigImage = CvInvoke.Imread(bigImagePath, ImreadModes.Color);
            Mat smallImage = CvInvoke.Imread(smallImagePath, ImreadModes.Color);

            // Result matrix to store match scores
            int resultCols = bigImage.Cols - smallImage.Cols + 1;
            int resultRows = bigImage.Rows - smallImage.Rows + 1;
            Mat result = new Mat(resultRows, resultCols, DepthType.Cv32F, 1);

            // Perform template matching
            CvInvoke.MatchTemplate(bigImage, smallImage, result, TemplateMatchingType.CcoeffNormed);

            // Find the best match location
            double minVal = 0, maxVal = 0;
            Point minLoc = new Point(), maxLoc = new Point();
            CvInvoke.MinMaxLoc(result, ref minVal, ref maxVal, ref minLoc, ref maxLoc);

            // Define the threshold for a "good match"
            double threshold = 0.95; // Adjust based on your requirements
            if (maxVal >= threshold)
            {
                Console.WriteLine($"Match found with confidence {maxVal} at location {maxLoc}");

                // Optional: Draw a rectangle around the detected area
                Rectangle matchArea = new Rectangle(maxLoc, smallImage.Size);
                CvInvoke.Rectangle(bigImage, matchArea, new MCvScalar(0, 255, 0), 2);
                CvInvoke.Imwrite(@"D:\path\to\result_image.jpg", bigImage);
            }
            else
            {
                Console.WriteLine("No match found.");
            }
        }
        public void startProfile()
        {
            String s = Environment.CurrentDirectory;
            string chromePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";

            string chromeDriverPath = @"D:\chromedriver\130\chromedriver.exe";
            string userDataDir = @"D:\multithread\Thread1";
            string profileName = "Profile 5";
            int debugPort = 9222;

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = chromePath,
                Arguments = $"--remote-debugging-port={debugPort} " +
                       $"--user-data-dir=\"{userDataDir}\" " +
                       $"--profile-directory=\"{profileName}\"",
                UseShellExecute = false,
                CreateNoWindow = true,  // Prevent terminal window
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            try
            {
                // Start Chrome with the specified arguments
                Process chromeProcess = Process.Start(startInfo);
                if (chromeProcess == null)
                {
                    Console.WriteLine("Failed to start Chrome process.");
                    return;
                }

                // Give Chrome time to start and establish the debug connection
                System.Threading.Thread.Sleep(3000);
                ChromeDriverService service = ChromeDriverService.CreateDefaultService(chromeDriverPath);
                service.HideCommandPromptWindow = true; // Hides the terminal window
                service.SuppressInitialDiagnosticInformation = true;
                ChromeOptions options = new ChromeOptions();
                options.DebuggerAddress = "127.0.0.1:9222";

                // Increase command timeout
                IWebDriver driver = new ChromeDriver(service, options);

                // Perform actions
                driver.Navigate().GoToUrl("https://google.com");
                Console.WriteLine($"Page Title: {driver.Title}");
                ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
                if (screenshotDriver != null)
                {
                    Screenshot screenshot = screenshotDriver.GetScreenshot();
                    string screenshotPath = s + "\\Resource\\screenshot.png";
                    screenshot.SaveAsFile(screenshotPath);
                    Console.WriteLine($"Screenshot saved at: {screenshotPath}");
                }
                driver.Quit();
                chromeProcess.Kill();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void updateVersionChrome_Click(object sender, EventArgs e)
        {
            Form2 _form2 = new Form2(this);
            _form2.Show();
        }

        private void AddProfile_Click(object sender, EventArgs e)
        {
            AddProfile _addProfile = new AddProfile(this);
            _addProfile.Show();
        }

        private void RemoveProfile_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                List<string> list = new List<string>();

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    string key = row.Cells["Key"].Value?.ToString();

                    list.Add(key);
                }

                foreach (string key in list)
                {
                    string jsonContent = File.ReadAllText(dataDir);

                    // Parse the JSON content
                    JObject jsonObject = JObject.Parse(jsonContent);

                    // Access the "Profiles" array
                    JArray profilesArray = (JArray)jsonObject["Profiles"];

                    // Find and remove the object with the specific key
                    string keyToRemove = key; // The key of the object to remove
                    for (int i = profilesArray.Count - 1; i >= 0; i--)
                    {
                        JObject profileObject = (JObject)profilesArray[i];
                        if (profileObject.ContainsKey(keyToRemove))
                        {
                            profilesArray.RemoveAt(i);
                            break; // Exit the loop after removing the object
                        }
                    }

                    // Save the modified JSON back to the file
                    File.WriteAllText(dataDir, jsonObject.ToString());
                    sendLog("Removed profile : " + keyToRemove);
                }
                updateData();
            }
            else
            {
                MessageBox.Show("No rows selected.");
            }
        }
        public string loadBrowser()
        {
            string jsonContent = File.ReadAllText(dataDir);
            JObject jsonObject = JObject.Parse(jsonContent);
            string browser = jsonObject["browser"].ToString();
            if (browser == "chrome")
            {
                return @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            }
            return @"orbita";
        }
        public void sendLog(string text)
        {
            jLog.AppendText(text + "\n");
            //sendLogFile(text);
        }
        public void sendLogFile(string text)
        {
            string directoryPath = currentDir + "\\Resource"; // Change this to your desired directory
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string fileName = $"{DateTime.Now:yyyy-MM-dd}.txt"; // File name with current date
            string filePath = Path.Combine(directoryPath, fileName);

            if (File.Exists(filePath))
            {
                // Append the string to the file
                File.AppendAllText(filePath, text + Environment.NewLine);
            }
            else
            {
                // Create the file and write the string to it
                File.WriteAllText(filePath, text + Environment.NewLine);
            }
        }

        private void EditScenes_Click(object sender, EventArgs e)
        {
            Scenes _scene = new Scenes(this);
            _scene.Show();
        }

        private void jEditButton_Click(object sender, EventArgs e)
        {
            config config_form = new config(this);
            config_form.Show();
        }

        private void jStop_Click(object sender, EventArgs e)
        {
            foreach (int id in listPID)
            {
                try
                {
                    Process process = Process.GetProcessById(id);
                    process.Kill();

                    process.WaitForExit();
                }
                catch (ArgumentException)
                {
                    // 
                    sendLog($"The process with the given ID does not exist");
                }
                catch (Exception ex)
                {
                    sendLog($"An error occurred: {ex.Message}");
                }

            }
            listPID.Clear();
        }

        private void jCheckforupdatesbutton_Click(object sender, EventArgs e)
        {

            InitializeAsync();
        }
    }
}
