using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ReadPic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string willReadPath = "";

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                FormToExcel(textBox1.Text);
            }
        }
        //打开图片路径
        private void btnOPen_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = fbd.SelectedPath;

            }
            textBox1.Text = path;
        }
        //调用百度识图API
        public static void FormToExcel(string picPath)
        {
            var form = new Baidu.Aip.Ocr.Form("mQgLfOLfbgjSE7NEY0aoruWD", "8js5uXvSqPdDPrKyod1qsXcE8ISjyxDZ");
            var image = File.ReadAllBytes(picPath);
            form.DebugLog = true;  // 是否开启调试日志

            // 识别为Excel
            var result = form.RecognizeToExcel(image);
            //MessageBox.Show(result);
            Console.Write(result);
        }
    }
}
