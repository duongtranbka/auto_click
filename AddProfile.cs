using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Auto_Click.Auto_Click;

namespace Auto_Click
{
    public partial class AddProfile : Form
    {
        Auto_Click form1;
        public AddProfile(Auto_Click _form1)
        {
            InitializeComponent();
            form1 = _form1;
        }

        private void SaveProfile_Click(object sender, EventArgs e)
        {
            if (inputProfileName.Text == "" || inputUserDir.Text == "")
            {
                return;
            }
            string[] array = inputUserDir.Text.Split("\\");
            string tagId = array[array.Length-1];
            string jsonContent = File.ReadAllText(Auto_Click.dataDir);
            JObject jsonObject = JObject.Parse(jsonContent);
            JArray profilesArray = (JArray)jsonObject["Profiles"];
            Profiles profile = new Profiles(form1.getIDHash() + "_" + tagId);

            // Assign ProfileDetail to the Profiles object
            profile.Detail = new Profiles.ProfileDetail(inputUserDir.Text, inputProfileName.Text);
            JObject profileObject = new JObject
            {
                [profile.id] = new JObject
                {
                    ["userDataDir"] = profile.Detail.userDir,
                    ["profileName"] = profile.Detail.ProfileName
                }
            };
            profilesArray.Add(profileObject);
            File.WriteAllText(Auto_Click.dataDir, jsonObject.ToString());
            form1.updateData();
            form1.sendLog("Added profile : " + profile.Detail.ProfileName);
        }
    }
}
