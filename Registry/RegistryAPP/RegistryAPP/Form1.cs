using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistryAPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void ShowReg(String parametr)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\KONCHA");
            if (key != null && key.GetValue(parametr) != null)
            {
                String showmessage = "";
                var stringList = new List<string>(key.GetValue(parametr) as string[]);
                stringList.ForEach(a => showmessage += $"{a}\n");
                MessageBox.Show(showmessage);
            }
            else MessageBox.Show("nope");
        }


        private void button1_Click(object sender, EventArgs e) => ShowReg("P5");
        private void button3_Click(object sender, EventArgs e) => ShowReg("P6");

        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\KONCHA", true);
            if (key != null)
            {
                string[] values = new string[] { "Я - студент / студентка", "кафедрі", "комп’ютерної", "інженерії!" };
                key.SetValue("P6", values, RegistryValueKind.MultiString);
                MessageBox.Show("done.");
            }

        }


        /*
         *             using (RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\KONCHA"))
                if (key != null) key.SetValue("P6", "Я - студент/\nкафедрі\nкомп’ютерної\nінженер!");
            // key.Close();
        */
    }
}
