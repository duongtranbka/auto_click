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

namespace Auto_Click
{
    public partial class Form2 : Form
    {
        public Auto_Click form1;
        public Form2(Auto_Click _form1)
        {
            InitializeComponent();
            form1 = _form1;
        }

        private void saveVersionChrome_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(getVersionChrome.Text))
            {
                MessageBox.Show("Version Chrome cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string jsonContent = File.ReadAllText(Auto_Click.dataDir);
            JObject jsonObject = JObject.Parse(jsonContent);
            jsonObject["versionChrome"] = getVersionChrome.Text;
            File.WriteAllText(Auto_Click.dataDir, jsonObject.ToString());
            Auto_Click.versionChrome = getVersionChrome.Text;
            MessageBox.Show("Version Chrome updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
