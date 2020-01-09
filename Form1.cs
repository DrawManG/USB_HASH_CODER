
using MaterialSkin.Controls;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace FlashUSB
{
   
    public partial class Form1 : MaterialForm
    {
      
        public Form1()
        {
            InitializeComponent();
        }

        private void MaterialFlatButton1_Click(object sender, EventArgs e)
        {
         
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo d in drives)
                {
                checkedListBox1.Items.Add(d.Name + d.VolumeLabel);
                }
                Console.ReadLine();
            }
        private readonly Random random = new Random();
        public static class SHA
        {
            public static string GenerateSHA512String(string inputString)
            {
                SHA512 sha512 = SHA512Managed.Create();
                byte[] bytes = Encoding.UTF8.GetBytes(inputString);
                byte[] hash = sha512.ComputeHash(bytes);
                return GetStringFromHash(hash);
                
            }
            
            private static string GetStringFromHash(byte[] hash)
            {
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    result.Append(hash[i].ToString("X2"));
                   
                }
                return result.ToString();
                
            }
        }
        private void MaterialFlatButton2_Click(object sender, EventArgs e)
        {
            materialLabel1.Text = null;
            int[] arr = new int[255];
            Random rnd = new Random();
            string Password = "";
            string Keylog = "";
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(33, 125);
                Password += (char)arr[i];
                arr[i] = rnd.Next(33, 125);
                Keylog += (char)arr[i];
            }
            materialLabel1.Text = Password;
            


            materialLabel4.Text = SHA.GenerateSHA512String(Password);
            textBox1.Text = SHA.GenerateSHA512String(Password);
            textBox2.Text = Password;
          //  materialLabel5.Text = 




        }
    }
   

}
    

