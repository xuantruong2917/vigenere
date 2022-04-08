using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testdataview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            string key = textBox1.Text;
            key = key.ToUpper();
            string plaintext = textBox2.Text;
            plaintext = plaintext.ToUpper();
            

            
            //tao key moi
            string key2 = key;
            while(key.Length <= plaintext.Length)
            {
                key += key2;
            }
            int n = key.Length - plaintext.Length;
            key = key.Remove(key.Length - n);
            //////
            ///

            char[] index = encrypt(key, plaintext);


            

            for(int i = 0; i < index.Length; i++)
            {
                textBox5.Text = textBox5.Text + index[i].ToString();
            }
             

        }
        char[] encrypt(string key, string plaintext)
        {
            char[] k = key.ToCharArray();
            char[] p = plaintext.ToCharArray();
            char[] index = new char[k.Length];
            int j = 0;// tạo biến đếm cho key
            for (int i = 0; i < k.Length; i++)
            {
                
                if (p[i] >= 65 && p[i] <= 90)// kí tự đang xét có phải chữ cái (A->Z) ?
                {
                    int a = (int)(k[j] - 65);
                    int b = (int)(p[i] - 65);
                    index[i] = (char)(((a + b) % 26) + 65);// thuật toán chính: lấy kí tự key + kí tự plaintext rồi mod 26
                    j++;//nếu plaintext là dấu cách thì không dịch key
                }
                else//bỏ qua dấu câu và dấu cách
                {
                    index[i] = p[i];
                }

            }
            return index;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            string key = textBox1.Text;
            key = key.ToUpper();
            string ciphertext = textBox5.Text;
            ciphertext = ciphertext.ToUpper();
            string key2 = key;
            while (key.Length <= ciphertext.Length)
            {

                key += key2;
            }
            int n = key.Length - ciphertext.Length;
            key = key.Remove(key.Length - n);

            //giai ma
           char[] index = decrypt(key, ciphertext);
            //

            for (int i = 0; i < index.Length; i++)
            {
                textBox2.Text = textBox2.Text + index[i].ToString();
            }
        }
        char[] decrypt(string key, string ciphertext)
        {
            char[] k = key.ToCharArray();
            char[] c = ciphertext.ToCharArray();
            char[] index = new char[k.Length];
            int j = 0;
            for (int i = 0; i < k.Length; i++)
            {

                if (c[i] >= 65 && c[i] <= 90)// cipher có phải chữ cái (A->Z)?
                {
                    int a = (int)(k[j] - 65);
                    int b = (int)(c[i] - 65);
                    if (b - a >= 0)
                    {
                        index[i] = (char)(b - a + 65);// thuật toán chính: kí tự plaintext = kí tự cipher - kí tự key
                    }
                    else
                        index[i] = (char)(b - a + 65 + 26);// trường hợp hiệu nằm ngoài (A->Z) + thêm 26
                    j++;
                }
                else// bỏ qua dấu câu và dấu cách
                {
                    index[i] = c[i];
                }

            }
            return index;
        }

    }
}
