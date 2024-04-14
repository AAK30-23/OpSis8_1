using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace OpSis8_1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            string keyName = "Software\\MyRegistryKey";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName);
            if (key != null)
            {
                string value = key.GetValue("ValueName") as string;
                MessageBox.Show("Значение, считанное из реестра: " + value);
            }
            else
            {
                MessageBox.Show("Значение реестра не найдено");
            }
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            string keyName = "Software\\MyRegistryKey";
            string valueName = "ValueName";
            string value = textBox1.Text;

            RegistryKey key = Registry.CurrentUser.CreateSubKey(keyName);
            key.SetValue(valueName, value);
            key.Close();

            MessageBox.Show("Значение, записанное в реестр");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string keyName = "Software\\MyRegistryKey";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true);
            if (key != null)
            {
                key.DeleteValue("ValueName");
                key.Close();
                MessageBox.Show("Значение удалено из реестра");
            }
            else
            {
                MessageBox.Show("Значение реестра не найдено");
            }
        }
    }
}


