using Microsoft.Win32;
using Sonluk.Utility.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sonluk.Utility.Kit
{
    /// <summary>
    /// Security.xaml 的交互逻辑
    /// </summary>
    public partial class Security : Window
    {

        private string _MakecertPath = "";
        public Security()
        {
            InitializeComponent();
        }

        private void GetMD5Hash(object sender, RoutedEventArgs e)
        {
            MD5VerifyResult.Content = "";
            if (MD5Text.Text.Length > 0)
            {

                MD5TextHash.Text = MD5Hash.GetMd5Hash(MD5Text.Text);
            }

        }

        private void VerifyMd5Hash(object sender, RoutedEventArgs e)
        {
            MD5VerifyResult.Content = "";
            if (MD5Text.Text.Length > 0 && MD5TextHash.Text.Length > 0)
            {
                if (MD5Hash.VerifyMd5Hash(MD5Text.Text, MD5TextHash.Text))
                    MD5VerifyResult.Content = "字符文本与散列值匹配";
                else
                    MD5VerifyResult.Content = "字符文本与散列值不匹配";

            }

        }

        private void DESGenerateKey(object sender, RoutedEventArgs e)
        {
            int length = Convert.ToInt16(this.DESKeyLength.Text);
            int numberOfNonAlphanumericCharacters = Convert.ToInt16(this.DESNumberOfNonAlphanumericCharacters.Text);
            RandomString rs = new RandomString();
            this.DESKey.Text = rs.Create(length, numberOfNonAlphanumericCharacters);
        }

        private void DESEncrypt(object sender, RoutedEventArgs e)
        {
            string key = this.DESKey.Text;
            if (key != null && key.Length > 0)
            {
                try
                {
                    this.DESCipherText.Text = DESE.Encrypt(this.DESPlainText.Text, key);
                }
                catch (Exception exception)
                {
                    this.DESCipherText.Text = exception.Message;
                }
            }
        }

        private void DESDecrypt(object sender, RoutedEventArgs e)
        {
            string key = this.DESKey.Text;
            if (key != null && key.Length > 0)
            {
                try
                {
                    this.DESPlainText.Text = DESE.Decrypt(this.DESCipherText.Text, key);
                }
                catch (Exception exception)
                {
                    this.DESPlainText.Text = exception.Message;
                }
            }
        }

        private void RSAGenerateKey(object sender, RoutedEventArgs e)
        {
            using (RSACryptoServiceProvider rsacsp = new RSACryptoServiceProvider())
            {
                RSAPrivateKey.Text = RSAE.XmlStrToHexStr(rsacsp.ToXmlString(true));
                RSAPublicKey.Text = RSAE.XmlStrToHexStr(rsacsp.ToXmlString(false));
            }
        }

        private void RSAEncrypt(object sender, RoutedEventArgs e)
        {
            try
            {

                RSACipherText.Text = RSAE.Encrypt(RSAPlainText.Text,RSAPublicKey.Text);

            }
            catch (Exception exception)
            {
                RSACipherText.Text = exception.Message;

            }

        }

        private void RSADecrypt(object sender, RoutedEventArgs e)
        {
            try
            {
                RSAPlainText.Text = RSAE.Decrypt(RSACipherText.Text,RSAPrivateKey.Text );
            }
            catch (Exception exception)
            {
                RSAPlainText.Text = exception.Message;

            }
        }

        private void CertificateGenerate(object sender, RoutedEventArgs e)
        {
            if (_MakecertPath.Length == 0)
            {
                if (MessageBox.Show("请设置Makecert.exe路径！", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    if (ofd.ShowDialog() == true)
                    {
                        _MakecertPath = ofd.FileName;
                    }
                }
            }
          
        }

        private void CertificateExportPfx(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == true)
            {
                //获得文件路径
                string localFilePath = sfd.FileName.ToString();

                //获取文件名，不带路径
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);

                //获取文件路径，不带文件名
                string filePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));

                //在文件名里加字符
                sfd.FileName.Insert(1, "dameng");
                //为用户使用 SaveFileDialog 选定的文件名创建读/写文件流。
                System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();//输出文件

                //fs可以用于其他要写入的操作
            }
        }

        private void CertificateExportCer(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == true)
            {
                //获得文件路径
                string localFilePath = sfd.FileName.ToString();

                //获取文件名，不带路径
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);

                //获取文件路径，不带文件名
                string filePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));

                //在文件名里加字符
                sfd.FileName.Insert(1, "dameng");
                //为用户使用 SaveFileDialog 选定的文件名创建读/写文件流。
                System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();//输出文件

                //fs可以用于其他要写入的操作
            }
        }

        private void CertificateRead(object sender, RoutedEventArgs e)
        {
            if (_MakecertPath.Length == 0)
            {
                if (MessageBox.Show("请设置Makecert.exe路径！", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    if (ofd.ShowDialog() == true)
                    {
                        _MakecertPath = ofd.FileName;
                    }
                }
            }

        }
    }

}
