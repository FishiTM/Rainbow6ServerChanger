using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Management;
using System.Net;

namespace Rainbow6ServerChanger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string dir = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\My Games\Rainbow Six - Siege\";
                foreach (var account in Directory.GetDirectories(dir))
                {
                    try
                    {
                        string file = $@"{account}\GameSettings.ini";
                        string[] lines = File.ReadAllLines(file);
                        int line_no = 170;
                        foreach (string line in lines)
                        {
                            if (line.Contains("DataCenterHint="))
                            {
                                line_no = Array.IndexOf(lines, line);
                            }
                        }
                        if (this.comboBox1.SelectedItem.ToString() == "default")
                        {
                            lines[line_no] = "DataCenterHint=default";
                        }
                        else
                        {
                            lines[line_no] = $"DataCenterHint=playfab/{comboBox1.SelectedItem.ToString()}";
                        }
                        File.WriteAllLines(file, lines);
                    }
                    catch { }
                }
                SystemSounds.Exclamation.Play();
                MessageBox.Show("Servers Have Been Changed");
            } else
            {
                SystemSounds.Beep.Play();
                MessageBox.Show("Please Select A Server");
            }
        }
    }
}
