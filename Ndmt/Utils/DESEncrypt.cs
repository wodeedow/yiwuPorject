using System;
using System.Security.Cryptography;
using System.Text;
using System.Security;

namespace Ndmt.Utils
{
    public sealed class DESEncrypt
    {
        private static readonly Byte[] DesKey = { 5, 7, 8, 9, 0, 2, 1, 6 };
        private static readonly Byte[] DesVi = { 6, 9, 8, 5, 1, 6, 2, 8 };
        
        /// <summary>
        /// 使用DES算法加密数据
        /// </summary>
        /// <param name="data">待加密数据</param>
        /// <returns>密文</returns>
        public static String Encrypt(String data)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            Encoding utf = new UTF8Encoding();
            ICryptoTransform encryptor = des.CreateEncryptor(DesKey, DesVi);

            byte[] bData = utf.GetBytes(data);
            byte[] bEnc = encryptor.TransformFinalBlock(bData, 0, bData.Length);
            return Convert.ToBase64String(bEnc);
        }

        /// <summary>
        /// 使用DES算法解密数据
        /// </summary>
        /// <param name="data">待解密数据</param>
        /// <returns>明文</returns>
        public static String Decrypt(String data)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            Encoding utf = new UTF8Encoding();
            ICryptoTransform decryptor = des.CreateDecryptor(DesKey, DesVi);

            byte[] bEnc = Convert.FromBase64String(data);
            byte[] bDec = decryptor.TransformFinalBlock(bEnc, 0, bEnc.Length);
            return utf.GetString(bDec);
        }
    }
}
