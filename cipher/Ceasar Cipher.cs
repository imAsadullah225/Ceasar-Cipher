using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cipher
{
    public partial class CeasarCipher : Form
    {
        public CeasarCipher()
        {
            InitializeComponent();
        }

        List<char> encryptedText = new  List<char>();
        List<char> decryptedText = new List<char>();
        
        char[] alphabates = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        char[] deAlphabates = { 'z', 'y', 'x', 'w', 'v', 'u', 't', 's', 'r', 'q', 'p', 'o', 'n', 'm', 'l', 'k', 'j', 'i', 'h', 'g', 'f', 'e', 'd', 'c', 'b', 'a' };
        
        int getKey()
        {
            if (key_TB.Text != "0")
                return Convert.ToInt32(key_TB.Text) - 1;

            else
            {
                key_TB.Text = "4";
                return Convert.ToInt32(key_TB.Text) - 1;
            }
        }

        public void doEncryption(string text)
        {           
            char[] charArray = text.ToArray();

            for (int i = 0; i < charArray.Count(); i++)
            {
                for (int j = 0; j < alphabates.Count(); j++)
                {
                    try
                    {
                        if (charArray[i] == alphabates[j])
                            encryptedText.Add(alphabates[(j + getKey()) % 26]);

                        else if (charArray[i] == ' ')
                        {
                            encryptedText.Add(' ');
                            break;
                        }
                    }
                    catch (Exception) { };
                }
            }
        }

        public void doDecryption(string text)
        {
            char[] charArray = text.ToArray();

            for (int i = 0; i < charArray.Count(); i++)
            {
                for (int j = 0; j < deAlphabates.Count(); j++)
                {
                    try
                    {
                        if (charArray[i] == deAlphabates[j])
                            decryptedText.Add(deAlphabates[(j + getKey()) % 26]);

                        else if (charArray[i] == ' ')
                        {
                            decryptedText.Add(' ');
                            break;
                        }
                    }
                    catch (Exception) { };
                }
            }
        }

        private void encrypt_BTN_Click(object sender, EventArgs e)
        {
            doEncryption(inputText_TB.Text);
            string encrypt = string.Join("", encryptedText);
            encryptedText_TB.Text = encrypt;
            encryptedText.Clear();
        }

        private void decrypt_BTN_Click(object sender, EventArgs e)
        {
            doDecryption(encryptedText_TB.Text);
            string decrypt = string.Join("", decryptedText);
            decryptedText_TB.Text = decrypt;
            decryptedText.Clear();
        }

        private void inputText_TB_TextChanged(object sender, EventArgs e)
        {
            encryptedText.Clear();
            decryptedText.Clear();

            encryptedText_TB.Clear();
            decryptedText_TB.Clear();
        }
    }
}
