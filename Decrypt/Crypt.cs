using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Decrypt
{
    public class Cript
    {
        public static string Encrypt(string ValueToEncrypt, string PassWd)
        {
            string str = string.Empty;
            byte[] bytes = Encoding.Unicode.GetBytes(ValueToEncrypt);
            MemoryStream memoryStream = new MemoryStream();
            SymmetricAlgorithm symmetricAlgorithm = Cript.GenerateKey(PassWd);
            CryptoStream cryptoStream = new CryptoStream((Stream)new CryptoStream((Stream)memoryStream, (ICryptoTransform)new ToBase64Transform(), CryptoStreamMode.Write), symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            return Encoding.ASCII.GetString(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }

        public static string Decrypt(string ValueToDecrypt, string PassWd)
        {
            try
            {
                string str = string.Empty;
                byte[] buffer = Convert.FromBase64String(ValueToDecrypt);
                MemoryStream memoryStream = new MemoryStream();
                SymmetricAlgorithm symmetricAlgorithm = Cript.GenerateKey(PassWd);
                CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Write);
                cryptoStream.Write(buffer, 0, buffer.Length);
                cryptoStream.FlushFinalBlock();
                return Encoding.Unicode.GetString(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            }
            catch
            {
                return "ErrorWodszyfrowaniu";
            }
        }

        public static SymmetricAlgorithm GenerateKey(string password)
        {
            string s = "aqa";
            SymmetricAlgorithm symmetricAlgorithm = (SymmetricAlgorithm)new RijndaelManaged();
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(password, bytes, "SHA1", 3);
            symmetricAlgorithm.Key = passwordDeriveBytes.GetBytes(symmetricAlgorithm.KeySize / 8);
            symmetricAlgorithm.IV = passwordDeriveBytes.GetBytes(symmetricAlgorithm.BlockSize / 8);
            return symmetricAlgorithm;
        }

        public static string PublicKey()
        {
            return "<DSAKeyValue><P>tf3cnJRlC7hwxryeRMeLDfkWkhmoyw5DqdN2YPjN772MnwayRxouOrNtPFwEgr97G3X8zGG81hUM/0jIBPgG+sxvZjB3/Dhpf0kmY4j11+Rw+GolRozcCjq6BRi6WyWc7+9e2dz4188oaHryNdgCzr1C/p8JAi7dkyc10YJPYK0=</P><Q>5fHeTvtGGFo0R8M4lO3fG6c+qjU=</Q><G>nIWnS8TbXno3SlY3mdKtGYZ4Y2g4un0/bfM+/RD3QJvA809YmDjC0UUC9w6kll5ptDSdEbCE8sZwVHrMYcvXq4yXrWH1hkgvZauRiE5+/CD1IZl5z2XhhYexm7P2SCQ8dKVD5epGmQQbBM9++zref8qkDQTsKXvb7wuTCt8eSck=</G><Y>PfKdMoAcx0D06mC9SI+yfq0Wt3q4dQIfd3dlxEF1+q+w4x4r5DazHXICLE7lCvAAhAoy1JeayLptAlSiFrfVLGKIPP0YASqaluKQ91PKpbB1zPoNN8qNmx0G+zehIpMhTyxXZe9hCEybOwBMZy6wjQYZcX39JKqR8z+Dd+SJfoY=</Y><J>ypz9nu5DWMVn/WZMvLVhSVpJrjKaVhcgTN193HCk/s42J2RQV48RrPFdVhh7hNEB91/wJ/XUT0WGbrK1yI0xgkZAO5vZyLdvF/lK0Tskuf39lPT7BIiGubiT8GzDvuS9Y8Vby5YmnnamZxN8</J><Seed>dlj6HFmCJiyItaiqym5crCkrjHk=</Seed><PgenCounter>aQ==</PgenCounter></DSAKeyValue>";
        }

        public static bool VerifySignature(string plainKey, string signedHashAsStr)
        {
            byte[] hash = new SHA1CryptoServiceProvider().ComputeHash(new UnicodeEncoding().GetBytes(plainKey));
            byte[] rgbSignature = Convert.FromBase64String(signedHashAsStr);
            DSACryptoServiceProvider cryptoServiceProvider = new DSACryptoServiceProvider();
            cryptoServiceProvider.FromXmlString(Cript.PublicKey());
            DSASignatureDeformatter signatureDeformatter = new DSASignatureDeformatter((AsymmetricAlgorithm)cryptoServiceProvider);
            signatureDeformatter.SetHashAlgorithm("SHA1");
            return signatureDeformatter.VerifySignature(hash, rgbSignature);
        }

        public static string FileChecksum(string filename)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    byte[] hash = new MD5CryptoServiceProvider().ComputeHash((Stream)fileStream);
                    fileStream.Close();
                    fileStream.Dispose();
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (byte num in hash)
                        stringBuilder.Append(num.ToString("x2"));
                    return ((object)stringBuilder).ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int IsFileChecksumOk(string filename, string checksum)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    byte[] hash = new MD5CryptoServiceProvider().ComputeHash((Stream)fileStream);
                    fileStream.Close();
                    fileStream.Dispose();
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (byte num in hash)
                        stringBuilder.Append(num.ToString("x2"));
                    return ((object)stringBuilder).ToString() == checksum ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                return -1;
            }
        }
    }

}
