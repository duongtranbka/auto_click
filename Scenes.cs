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
    public partial class Scenes : Form
    {
        Auto_Click form1;
        public Scenes(Auto_Click _form)
        {
            InitializeComponent();
            form1 = new Auto_Click();
            form1 = _form;
            jUrlWebLabel.Visible = false;
            jCoordinateLabel.Visible = false;
            JImageUrlLable.Visible = false;
            jTimeoutLabel.Visible = false;
            jInputWebUrl.Visible = false;
            jInputCoordinate.Visible = false;
            jInputImageUrl.Visible = false;
            jInputTimeOut.Visible = false;
            jInputDrag.Visible = false;
            JDragLabel.Visible = false;
            LoadScenes();
        }

        private void jAddCommand_Click(object sender, EventArgs e)
        {
            string para = "";
            if (jDropCommand.SelectedIndex == 0)
            {
                if (jInputWebUrl.Text.Length > 0)
                {
                    para = "GOTO " + jInputWebUrl.Text;
                }
            }
            else if (jDropCommand.SelectedIndex == 1)
            {
                if (jInputCoordinate.Text.Length > 0)
                {
                    para = "CLICKTO_XY " + jInputCoordinate.Text;
                }
            }
            else if (jDropCommand.SelectedIndex == 2)
            {
                if (jInputImageUrl.Text.Length > 0)
                {
                    para = "CLICKTO_IMAGE " + jInputImageUrl.Text;
                }
            }
            else if (jDropCommand.SelectedIndex == 3)
            {
                if (jInputImageUrl.Text.Length > 0 && jInputTimeOut.Text.Length > 0)
                {
                    para = "WAIT_IMAGE " + jInputImageUrl.Text + "_" + jInputTimeOut.Text;
                }

            }
            else if (jDropCommand.SelectedIndex == 4)
            {
                if (jInputTimeOut.Text.Length > 0)
                {
                    para = "WAIT " + jInputTimeOut.Text;
                }
            }
            else if (jDropCommand.SelectedIndex == 5)
            {
                para = "Scroll_Down";
            }
            else if (jDropCommand.SelectedIndex == 6)
            {
                para = "Scroll_Up";
            }
            else if(jDropCommand.SelectedIndex == 7)
            {
                if(jInputDrag.Text.Length > 0)
                {
                    para = "Drag " + jInputDrag.Text;
                }
            }
            if(para.Length > 0 || para.Contains("Scroll")) {
                WriteScene(para);
                LoadScenes();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1_SelectedIndexChanged != null)
            {
                form1.sendLog("Selected : " + jDropCommand.Text);
                if (jDropCommand.SelectedIndex == 0)
                {
                    jUrlWebLabel.Visible = true;
                    jInputWebUrl.Visible = true;
                    jCoordinateLabel.Visible = false;
                    jInputCoordinate.Visible = false;
                    JImageUrlLable.Visible = false;
                    jInputImageUrl.Visible = false;
                    jTimeoutLabel.Visible = false;
                    jInputTimeOut.Visible = false;
                    jInputDrag.Visible = false;
                    JDragLabel.Visible = false;
                }
                else if (jDropCommand.SelectedIndex == 1)
                {
                    jCoordinateLabel.Visible = true;
                    jInputCoordinate.Visible = true;
                    jUrlWebLabel.Visible = false;
                    jInputWebUrl.Visible = false;
                    JImageUrlLable.Visible = false;
                    jInputImageUrl.Visible = false;
                    jTimeoutLabel.Visible = false;
                    jInputTimeOut.Visible = false;
                    jInputDrag.Visible = false;
                    JDragLabel.Visible = false;
                }
                else if (jDropCommand.SelectedIndex == 2)
                {
                    JImageUrlLable.Visible = true;
                    jInputImageUrl.Visible = true;
                    jCoordinateLabel.Visible = false;
                    jInputCoordinate.Visible = false;
                    jUrlWebLabel.Visible = false;
                    jInputWebUrl.Visible = false;
                    jTimeoutLabel.Visible = false;
                    jInputTimeOut.Visible = false;
                    jInputDrag.Visible = false;
                    JDragLabel.Visible = false;
                }
                else if (jDropCommand.SelectedIndex == 3)
                {
                    JImageUrlLable.Visible = true;
                    jInputImageUrl.Visible = true;
                    jTimeoutLabel.Visible = true;
                    jInputTimeOut.Visible = true;
                    jCoordinateLabel.Visible = false;
                    jInputCoordinate.Visible = false;
                    jUrlWebLabel.Visible = false;
                    jInputWebUrl.Visible = false;
                    jInputDrag.Visible = false;
                    JDragLabel.Visible = false;
                }
                else if (jDropCommand.SelectedIndex == 4)
                {
                    JImageUrlLable.Visible = false;
                    jInputImageUrl.Visible = false;
                    jTimeoutLabel.Visible = true;
                    jInputTimeOut.Visible = true;
                    jCoordinateLabel.Visible = false;
                    jInputCoordinate.Visible = false;
                    jUrlWebLabel.Visible = false;
                    jInputWebUrl.Visible = false;
                    jInputDrag.Visible = false;
                    JDragLabel.Visible = false;
                }
                else if (jDropCommand.SelectedIndex == 4)
                {
                    jInputDrag.Visible = false;
                    JDragLabel.Visible = false;
                    JImageUrlLable.Visible = false;
                    jInputImageUrl.Visible = false;
                    jTimeoutLabel.Visible = false;
                    jInputTimeOut.Visible = false;
                    jCoordinateLabel.Visible = false;
                    jInputCoordinate.Visible = false;
                    jUrlWebLabel.Visible = false;
                    jInputWebUrl.Visible = false;
                }
                else if (jDropCommand.SelectedIndex == 5)
                {
                    jInputDrag.Visible = false;
                    JDragLabel.Visible = false;
                    JImageUrlLable.Visible = false;
                    jInputImageUrl.Visible = false;
                    jTimeoutLabel.Visible = false;
                    jInputTimeOut.Visible = false;
                    jCoordinateLabel.Visible = false;
                    jInputCoordinate.Visible = false;
                    jUrlWebLabel.Visible = false;
                    jInputWebUrl.Visible = false;
                }
                else if(jDropCommand.SelectedIndex == 7)
                {
                    jInputDrag.Visible = true;
                    JDragLabel.Visible = true;
                    JImageUrlLable.Visible = false;
                    jInputImageUrl.Visible = false;
                    jTimeoutLabel.Visible = false;
                    jInputTimeOut.Visible = false;
                    jCoordinateLabel.Visible = false;
                    jInputCoordinate.Visible = false;
                    jUrlWebLabel.Visible = false;
                    jInputWebUrl.Visible = false;
                }
            }
        }
        //

        public void WriteScene(String sceneName)
        {
            if (File.Exists(Auto_Click.sceneDir))
            {
                string[] lines = File.ReadAllLines(Auto_Click.sceneDir);
                if (lines.Length > 0)
                {
                    File.AppendAllText(Auto_Click.sceneDir, Environment.NewLine + sceneName);
                }
                else
                {
                    File.WriteAllText(Auto_Click.sceneDir, sceneName);
                }
            }
        }
        public void LoadScenes()
        {
            if (File.Exists(Auto_Click.sceneDir))
            {
                jScreenTable.Rows.Clear();
                jScreenTable.Columns.Clear();
                jScreenTable.AllowUserToAddRows = false;
                jScreenTable.RowHeadersVisible = false;
                jScreenTable.Columns.Add("Command", "Command");
                jScreenTable.Columns.Add("Parameter", "Parameter");
                int totalWidth = jScreenTable.Width;
                jScreenTable.Columns["Command"].Width = (int)(totalWidth * 0.6);
                jScreenTable.Columns["Parameter"].Width = (int)(totalWidth * 0.39);
                string[] lines = File.ReadAllLines(Auto_Click.sceneDir);
                foreach (string line in lines)
                {
                    string[] data = line.Split(" ");
                    jScreenTable.Rows.Add(data);
                }
            }
        }

        private void jRemoveCMD_Click(object sender, EventArgs e)
        {
            if(jScreenTable.SelectedRows.Count > 0)
            {
                if (File.Exists(Auto_Click.sceneDir))
                {
                    string[] lines = File.ReadAllLines(Auto_Click.sceneDir);

                    foreach(DataGridViewRow row in jScreenTable.SelectedRows)
                    {
                        int rowIndex = row.Index + 1;
                        using (StreamWriter writer = new StreamWriter(Auto_Click.sceneDir, false))
                        {
                            for (int i = 0; i < lines.Length; i++)
                            {
                                if (i != rowIndex - 1) // Skip the line to remove
                                {
                                    writer.WriteLine(lines[i]);
                                }
                            }
                        }
                    }
                    LoadScenes();
                }
            }
        }
    }
}
