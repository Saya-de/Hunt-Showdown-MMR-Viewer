using System;
using System.Windows.Forms;
using System.Xml;

namespace HuntStats
{
    public partial class Form1 : Form
    {

        public static string text2;
        public bool toptoggle = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {




        }


        private void button2_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(@"D:\Steam\steamapps\common\Hunt Showdown\user\profiles\default\attributes.xml");

                foreach (XmlNode node in doc.DocumentElement)
                {

                    if (node.Attributes[1].Value.Contains("〩Saya〩"))
                    {
                        //there are multiple mmr values for the local player inside the attributes.xml, because they are logged after each round 
                        //and idfk which one the last logged value is so im just gonna take the first (All values fit the mmr bracket)
                        var text = node.Attributes[0].InnerText;
                        text2 = text.Replace("blood_line_name", "mmr");
                        break;

                    }
                }
                foreach (XmlNode node in doc.DocumentElement)
                {
                    if (node.Attributes[0].Value.Contains(text2))
                    {
                        label2.Text = node.Attributes[1].InnerText;
                    }


                }

            }
            catch (Exception ex) { }

           
        }

        private void topmostbox_CheckedChanged(object sender, EventArgs e)
        {
            toptoggle = !toptoggle;
            ActiveForm.TopMost = toptoggle;
        }
    }
}
