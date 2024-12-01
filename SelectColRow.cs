using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using System.Security.Policy;
using Emgu.CV.CvEnum;
using Emgu.CV;
using Emgu.CV.Structure;
using OpenQA.Selenium.Interactions;

namespace Auto_Click
{
    public partial class SelectColRow : Form
    {
        Auto_Click form1;
        public SelectColRow(Auto_Click _form)
        {
            InitializeComponent();
            form1 = new Auto_Click();
            form1 = _form;
        }

        private async void jRun_Click(object sender, EventArgs e)
        {
            form1.chromePath = form1.loadBrowser();
            string pc_name = Environment.UserName;
            int column = -1;
            int row = -1;
            string selectedcol = jNumberCol.SelectedItem as string;
            string selectedrow = jNumberRow.SelectedItem as string;
            if (!int.TryParse(selectedcol, out column) || !int.TryParse(selectedrow, out row))
            {
                return;
            }
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height - 5;
            int frameWidth = screenWidth / column;
            int frameHeight = screenHeight / row;
            int profileWidth = frameWidth - 20;
            int profileHeight = frameHeight - 20;
            int startX = 0;
            int startY = 0;
            int cntX = 1;
            try
            {
                DataGridView dataGridViewFromForm1 = form1.dataGridView1;
                if (dataGridViewFromForm1.SelectedRows.Count == 0)
                {
                    return;
                }

                var tasks = new List<Task>();

                foreach (DataGridViewRow selectedRow in dataGridViewFromForm1.SelectedRows)
                {
                    int currentCntX = cntX;
                    int currentStartY = startY;
                    string id = selectedRow.Cells[1].Value.ToString();
                    string versionChrome = "130";
                    string userdir = getUserDir(id);
                    string profileN = getProfileName(id);
                    int port = GetRandomPort();
                    string chromePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
                    if (form1.chromePath.Contains("orbita")){
                        versionChrome = getVersionChrome(id);
                        chromePath = $@"C:\Users\{pc_name}\.gologin\browser\orbita-browser-{versionChrome}\chrome.exe";
                    }
                    string arguments = $"--user-data-dir=\"{userdir}\" --profile-directory=\"{profileN}\" --remote-debugging-port={port}";
                    int newStartX = (currentCntX - 1) * frameWidth;
                    form1.sendLog("Open profile id : " + id + "  at positon : " + newStartX + ":" + currentStartY + " with the size " + profileWidth + ":" + profileHeight);
                    tasks.Add(Task.Run(() =>
                    {


                        try
                        {
                            ProcessStartInfo startInfo = new ProcessStartInfo
                            {
                                FileName = chromePath,
                                Arguments = arguments,
                                UseShellExecute = false
                            };
                            Process chromeProcess = new Process
                            {
                                StartInfo = startInfo
                            };
                            chromeProcess.Start();
                            Auto_Click.listPID.Add(chromeProcess.Id);
                            System.Threading.Thread.Sleep(5000);
                            ReconnectDriver(versionChrome, port, profileWidth, profileHeight, newStartX, currentStartY);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed to start Chrome or reconnect driver: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }));

                    if (cntX == column)
                    {
                        cntX = 1;
                        startY += frameHeight;
                    }
                    else
                    {
                        cntX++;
                    }
                }
                await Task.WhenAll(tasks);
                form1.sendLog("Executed : Done open Profiles");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ReconnectDriver(string versionChrome, int port, int windowWidth, int windowHeight, int posX, int posY)
        {
            string chromedriver_path = Auto_Click.chromeDriverDir + versionChrome + "\\chromedriver.exe";
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.DebuggerAddress = $"127.0.0.1:{port}";
            chromeOptions.AddArgument("--force-device-scale-factor=0.5");
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(chromedriver_path);
            chromeOptions.AddArgument($"--window-size={windowWidth},{windowHeight}");
            chromeOptions.AddArgument($"--window-position={posX},{posY}");
            service.HideCommandPromptWindow = true;
            try
            {
                using (IWebDriver driver = new ChromeDriver(service, chromeOptions))
                {
                    driver.Manage().Window.Size = new System.Drawing.Size(windowWidth, windowHeight);
                    driver.Manage().Window.Position = new System.Drawing.Point(posX, posY);
                    //form1.sendLogFile("Set debug port : " + port.ToString() + " at position " + posX + ":" + posY);
                    RunScene(driver);
                    driver.Quit();
                }
            }
            catch (Exception ex)
            {
            }

        }
        public void RunScene(IWebDriver driver)
        {
            if (File.Exists(Auto_Click.sceneDir))
            {
                string[] lines = File.ReadAllLines(Auto_Click.sceneDir);
                foreach(string line in lines)
                {
                    if (line.Contains("CLICKTO_XY"))
                    {
                        string rawPara = line.Split(" ")[1];
                        string[] Parameter = rawPara.Split(",");
                        clickToCoordinate(driver, int.Parse(Parameter[0]), int.Parse(Parameter[1]));
                        Thread.Sleep(500);
                    } else if (line.Contains("GOTO"))
                    {
                        string rawPara = line.Split(" ")[1];
                        gotoWebUrl(driver, rawPara);
                    } else if (line.Contains("WAIT_IMAGE"))
                    {
                        string rawPara = line.Split(" ")[1];
                        string ImageName = rawPara.Split("_")[0];
                        string timeout = rawPara.Split("_")[1];
                        waitImageTimeout(driver, ImageName, int.Parse(timeout));
                    } else if (line.Contains("CLICKTO_IMAGE"))
                    {
                        string rawPara = line.Split(" ")[1];
                        clicktoImage(driver, rawPara);
                    }else if (line.Contains("WAIT"))
                    {
                        string rawPara = line.Split(" ")[1];
                        Thread.Sleep(int.Parse(rawPara) * 1000);
                    }else if (line.Contains("Scroll_Down"))
                    {
                        scrollDown(driver);
                    }
                    else if (line.Contains("Scroll_Up"))
                    {
                        scrollUp(driver);
                    }
                    else if (line.Contains("Drag"))
                    {
                        string rawPara = line.Split(" ")[1];
                        string[] para = rawPara.Split(",");
                        drag(driver, int.Parse(para[0]), int.Parse(para[1]), int.Parse(para[2]), int.Parse(para[3]));
                    }
                }
                //getIframe(driver);
            }
        }
        public void scrollDown(IWebDriver driver)
        {
            IWebElement scrollableElement = driver.FindElement(By.TagName("html"));
            int totalHeight = scrollableElement.Size.Height;
            double scrollPercent = 0.3;  
            int pixelsToScroll = (int)(totalHeight * scrollPercent);

            Actions actions = new Actions(driver);
            for (int i = 0; i < pixelsToScroll / 100; i++) 
            {
                actions.SendKeys(OpenQA.Selenium.Keys.PageDown).Perform();
            }
        }
        public void scrollUp(IWebDriver driver)
        {
            IWebElement scrollableElement = driver.FindElement(By.TagName("html"));
            int totalHeight = scrollableElement.Size.Height;
            double scrollPercent = 0.3;
            int pixelsToScroll = (int)(totalHeight * scrollPercent);

            Actions actions = new Actions(driver);
            for (int i = 0; i < pixelsToScroll / 100; i++)
            {
                actions.SendKeys(OpenQA.Selenium.Keys.PageUp).Perform();
            }
        }
        public void getIframe(IWebDriver driver)
        {
            Thread.Sleep(5000);
            var iframes = driver.FindElements(By.TagName("iframe"));

            foreach (var iframe in iframes)
            {
                // Get iframe's source attribute
                var src = iframe.GetAttribute("src");
                if (src != null && src.StartsWith("https://app.notpx.app"))
                {
                    runNot(driver, src.ToString());
                }
            }
            driver.Quit();
        }
        public void saveScreenShot(IWebDriver driver, string imagename)
        {
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            if (screenshotDriver != null)
            {
                //int x = 140;
                //int y = 330;

                Screenshot screenshot = screenshotDriver.GetScreenshot();
                string name = form1.getIDHash() + "screenshot.png";
                if(imagename != "")
                {
                    name = imagename;
                }
                string screenshotPath = Auto_Click.ImageDir + name;
                screenshot.SaveAsFile(screenshotPath);
                //
                //try
                //{
                //    // Load the image
                //    using (Bitmap bitmap = new Bitmap(screenshotPath))
                //    {
                //        // Check if the coordinates are within bounds
                //        if (x < 0 || x >= bitmap.Width || y < 0 || y >= bitmap.Height)
                //        {
                //            Console.WriteLine("The coordinates are out of bounds of the image.");
                //            return;
                //        }

                //        // Get the color at the specified coordinates
                //        Color color = bitmap.GetPixel(x, y);
                //        clickToCoordinate(driver, x, y);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine($"Error: {ex.Message}");
                //}
            }
        }
        public void checkDiff(IWebDriver driver, string newimage, string original)
        {
            string imagePath1 = Auto_Click.ImageDir + "\\" + original;
            string imagePath2 = Auto_Click.ImageDir + "\\" + newimage;

            try
            {
                using (Bitmap image1 = new Bitmap(imagePath1))
                using (Bitmap image2 = new Bitmap(imagePath2))
                {
                    // Ensure both images are the same size
                    if (image1.Width != image2.Width || image1.Height != image2.Height)
                    {
                        Console.WriteLine("The images are not the same size.");
                        return;
                    }

                    // List to store the differences
                    List<(int x, int y, Color color1, Color color2)> differences = new List<(int, int, Color, Color)>();

                    // Iterate through each pixel
                    for (int y = 0; y < image1.Height; y++)
                    { if(y < 61 || y > 215)
                        {
                            continue;
                        }
                        for (int x = 0; x < image1.Width; x++)
                        {
                            if(x< 65 || x > 531)
                            {
                                continue;
                            }
                            Color color1 = image1.GetPixel(x, y);
                            Color color2 = image2.GetPixel(x, y);
                            //65,61
                            // 531, 215
                            // Compare colors
                            if (color1 != color2)
                            {
                                differences.Add((x, y, color1, color2));
                                break;
                            }
                        }
                        if(differences.Count > 0)
                        {
                            break;
                        }
                    }

                    // Output the differences
                    if (differences.Count > 0)
                    {
                        Console.WriteLine($"Found {differences.Count} differences:");
                        var paintButton = driver.FindElement(By.XPath("//span[text()='Paint']"));
                        int PaintX = paintButton.Location.X;
                        int PaintY = paintButton.Location.Y;
                        foreach (var diff in differences)
                        {
                            Console.WriteLine($"Coordinate ({diff.x}, {diff.y}): Image1={diff.color1}, Image2={diff.color2}");
                            clickToCoordinate(driver, 137, 327);
                            Thread.Sleep(3000);
                            if(pickColer(driver, diff.color1))
                            {
                                Thread.Sleep(500);
                                drag(driver, 36, 186, 36, 296);
                                Thread.Sleep(2000);
                                string tmp_image = form1.getIDHash();
                                saveScreenShot(driver, tmp_image + ".png");
                                Bitmap lastimage = new Bitmap(Auto_Click.ImageDir + "\\"+ tmp_image + ".png");
                                Color lastColor = lastimage.GetPixel(diff.x, diff.y);
                                int R = lastColor.R;
                                int G = lastColor.G;
                                int B = lastColor.B;
                                if (isinrange(R, diff.color1.R) && isinrange(G, diff.color1.G) && isinrange(B, diff.color1.B))
                                {
                                    clickToCoordinate(driver, diff.x, diff.y);
                                    clickToCoordinate(driver, PaintX, PaintY);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("The images are identical.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public bool pickColer(IWebDriver driver, Color color)
        {
            var colorItems = driver.FindElements(By.CssSelector("div._color_item_epppt_22"));
            int compare_R = color.R;
            int compare_G = color.G;
            int compare_B = color.B;
            foreach (var colorItem in colorItems)
            {
                // Get the background color of the current element
                string backgroundColor = colorItem.GetCssValue("background-color").Replace("rgba(","").Replace(")","").Replace(" ","");
                string[] para = backgroundColor.Split(",");
                int R = int.Parse(para[0]);
                int G = int.Parse(para[1]);
                int B = int.Parse(para[2]);
                if(isinrange(compare_R, R) && isinrange(compare_G, G)&& isinrange(compare_B, B))
                {
                    clickToCoordinate( driver, colorItem.Location.X + 10, colorItem.Location.Y + 10);
                    Thread.Sleep(1000);
                    clickToCoordinate( driver, 470, 100);
                    return true;
                }
                
            }
            return false;
        }
        public bool isinrange(int number1, int number2)
        {
            return number1 >= number2 - 5 && number1 <= number2 + 5; 
        }
        public void runNot(IWebDriver driver, string iframe)
        {
            driver.Navigate().GoToUrl(iframe);
            Thread.Sleep(5000);
            clickToCoordinate(driver, 467, 38);
            Thread.Sleep(500);
            clickToCoordinate(driver, 35, 218);
            Thread.Sleep(1500);
            clickToCoordinate(driver,567,135);
            Thread.Sleep(500);
            clickToCoordinate(driver, 567, 135);
            Thread.Sleep(500);
            clickToCoordinate(driver, 310, 210);
            //saveScreenShot(driver);
            clickToCoordinate(driver, 36, 186);
            //36,296
            Thread.Sleep(1000);
            for(int i = 0;i < 5; i++)
            {
                drag(driver, 36, 186, 36, 296);
                Thread.Sleep(2000);
                saveScreenShot(driver, "image1.png");
                Thread.Sleep(100);
                clickToCoordinate(driver, 36, 186);
                Thread.Sleep(1000);
                saveScreenShot(driver, "image2.png");
                Thread.Sleep(1000);
                checkDiff(driver, "image1.png", "image2.png");
            }
        }


        public void drag(IWebDriver driver, int startX, int startY, int endX, int endY)
        {
            Actions actions = new Actions(driver);
            actions.MoveByOffset(startX, startY)  // Move to the starting point
                   .ClickAndHold()               // Click and hold
                   .MoveByOffset(endX - startX, endY - startY) // Drag to the ending point
                   .Release()
                   .Click()
                   .Perform();
            Thread.Sleep(1000);
            actions.MoveByOffset(-endX, -endY).Perform();

        }
        public void clickToCoordinate(IWebDriver driver, int x, int y)
        {
            var jsExecutor = (IJavaScriptExecutor)driver;
            int viewportWidth = Convert.ToInt32(jsExecutor.ExecuteScript("return window.innerWidth;"));
            int viewportHeight = Convert.ToInt32(jsExecutor.ExecuteScript("return window.innerHeight;"));

            // Check if the coordinates are within the viewport bounds
            if (x >= 0 && x < viewportWidth && y >= 0 && y < viewportHeight)
            {
                Actions actions = new Actions(driver);
                actions.MoveByOffset(x, y).Click().Perform();
                actions.MoveByOffset(-x, -y).Perform();
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Coordinates ({x}, {y}) are out of bounds. Viewport size: {viewportWidth}x{viewportHeight}");
            }
        }
        public void gotoWebUrl(IWebDriver driver, string UrlWeb)
        {
            driver.Navigate().GoToUrl("https://google.com/");

            Actions actions = new Actions(driver);
            actions.KeyDown(OpenQA.Selenium.Keys.Control)
                   .SendKeys("t")
                   .KeyUp(OpenQA.Selenium.Keys.Control)
                   .Perform();

            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.Navigate().GoToUrl(UrlWeb);
        }
        public void clicktoImage(IWebDriver driver, string ImageName) {
            //form1.sendLogFile("Click to image : " + ImageName);
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            if (screenshotDriver != null)
            {
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                string name = form1.getIDHash() + "screenshot.png";
                string screenshotPath = Auto_Click.ImageDir + name;
                screenshot.SaveAsFile(screenshotPath);
                string bigImagePath = screenshotPath;
                string smallImagePath = Auto_Click.ImageDir + ImageName;
                if (!File.Exists(smallImagePath))
                {
                    return;
                }
                Mat bigImage = CvInvoke.Imread(bigImagePath, ImreadModes.Color);
                Mat smallImage = CvInvoke.Imread(smallImagePath, ImreadModes.Color);
                int resultCols = bigImage.Cols - smallImage.Cols + 1;
                int resultRows = bigImage.Rows - smallImage.Rows + 1;
                Mat result = new Mat(resultRows, resultCols, DepthType.Cv32F, 1);
                CvInvoke.MatchTemplate(bigImage, smallImage, result, TemplateMatchingType.CcoeffNormed);
                double minVal = 0, maxVal = 0;
                Point minLoc = new Point(), maxLoc = new Point();
                CvInvoke.MinMaxLoc(result, ref minVal, ref maxVal, ref minLoc, ref maxLoc);

                // Define the threshold for a "good match"
                double threshold = 0.6; // Adjust based on your requirements
                if (maxVal >= threshold)
                {
                    int centerX = maxLoc.X + smallImage.Width / 2;
                    int centerY = maxLoc.Y + smallImage.Height / 2;
                    clickToCoordinate(driver, centerX, centerY);
                    if (File.Exists(screenshotPath))
                    {
                        File.Delete(screenshotPath);
                    }
                    return;
                }
                else
                {
                    if (File.Exists(screenshotPath))
                    {
                        File.Delete(screenshotPath);
                    }
                    Thread.Sleep(1000);
                }
            }
        }
        public void waitImageTimeout(IWebDriver driver, string ImageName, int timeout)
        {
            for(int i = 0; i < timeout; i++)
            {
                ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
                if (screenshotDriver != null)
                {
                    Screenshot screenshot = screenshotDriver.GetScreenshot();
                    string name = form1.getIDHash() + "screenshot.png";
                    string screenshotPath = Auto_Click.ImageDir + name;
                    screenshot.SaveAsFile(screenshotPath);
                    string bigImagePath = screenshotPath;
                    string smallImagePath = Auto_Click.ImageDir + ImageName;
                    if (!File.Exists(smallImagePath))
                    {
                        return;
                    }
                    Mat bigImage = CvInvoke.Imread(bigImagePath, ImreadModes.Color);
                    Mat smallImage = CvInvoke.Imread(smallImagePath, ImreadModes.Color);
                    int resultCols = bigImage.Cols - smallImage.Cols + 1;
                    int resultRows = bigImage.Rows - smallImage.Rows + 1;
                    Mat result = new Mat(resultRows, resultCols, DepthType.Cv32F, 1);
                    CvInvoke.MatchTemplate(bigImage, smallImage, result, TemplateMatchingType.CcoeffNormed);
                    double minVal = 0, maxVal = 0;
                    Point minLoc = new Point(), maxLoc = new Point();
                    CvInvoke.MinMaxLoc(result, ref minVal, ref maxVal, ref minLoc, ref maxLoc);

                    // Define the threshold for a "good match"
                    double threshold = 0.9; // Adjust based on your requirements
                    if (maxVal >= threshold)
                    {
                        if (File.Exists(screenshotPath))
                        {
                            File.Delete(screenshotPath);
                        }
                        return;
                    }
                    else
                    {
                        if(File.Exists(screenshotPath))
                        {
                            File.Delete(screenshotPath);
                        }
                        Thread.Sleep(1000);
                    }
                }
            }
        }
        public string getVersionChrome(string key)
        {
            string jsonContent = File.ReadAllText(Auto_Click.dataDir);
            JObject jsonObject = JObject.Parse(jsonContent);
            JArray profiles = (JArray)jsonObject["Profiles"];
            foreach(JObject profile in profiles)
            {
                if (profile.ContainsKey(key))
                {
                    string userdir = profile[key]["userDataDir"].ToString();
                    string profileN = profile[key]["profileName"].ToString();
                }
            }
            return "127";
        }
        public string getUserDir(string key)
        {
            string jsonContent = File.ReadAllText(Auto_Click.dataDir);
            JObject jsonObject = JObject.Parse(jsonContent);
            JArray profiles = (JArray)jsonObject["Profiles"];
            foreach (JObject profile in profiles)
            {
                if (profile.ContainsKey(key))
                {
                    string userdir = profile[key]["userDataDir"].ToString();
                    return userdir;
                }
            }
            return "";
        }
        public string getProfileName(string key)
        {
            string jsonContent = File.ReadAllText(Auto_Click.dataDir);
            JObject jsonObject = JObject.Parse(jsonContent);
            JArray profiles = (JArray)jsonObject["Profiles"];
            foreach (JObject profile in profiles)
            {
                if (profile.ContainsKey(key))
                {
                    string userdir = profile[key]["profileName"].ToString();
                    return userdir;
                }
            }
            return "";
        }
        public int GetRandomPort(int minPort = 9000, int maxPort = 9999)
        {
            Random random = new Random();
            int port = random.Next(minPort, maxPort);
            while (!IsPortAvailable(port))
            {
                port = random.Next(minPort, maxPort);
            }

            return port;
        }
        private bool IsPortAvailable(int port)
        {
            bool isAvailable = true;

            TcpListener listener = null;
            try
            {
                listener = new TcpListener(IPAddress.Loopback, port);
                listener.Start();
            }
            catch (SocketException)
            {
                isAvailable = false;
            }
            finally
            {
                listener?.Stop();
            }

            return isAvailable;
        }
    }
}
