using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using BlowfishNET;

namespace TopitUp
{
    class clsCrypt
    {



        private byte[] getbytes(string toget)
        {
            byte[] retVal = new byte[toget.Length];
            Array.Clear(retVal, 0, toget.Length);
            for (int i = 0; i < toget.Length; i++)
            {
                retVal[i] = (byte)toget[i];
            }
            return retVal;
        }
        private string getstring(byte[] toget)
        {
            string retVal = "";
            for (int i = 0; i < toget.Length; i++)
            {
                retVal += (char)toget[i];
            }
            return retVal;
        }
        public string decryptString(string encrypted)
        {
            byte[] iv = getbytes("12345678");
            byte[] plain = getbytes(encrypted);
            byte[] decrypted = new byte[plain.Length];
            Array.Clear(decrypted, 0, decrypted.Length);
            byte[] key = getbytes("p1zz@p1zz@p1zz@p1zz@p1zz@p1zz@p1");
            BlowfishCBC bfc = new BlowfishCBC();
            bfc.IV = iv;
            bfc.Initialize(key, 0, key.Length);
            bfc.Decrypt(plain, 0, decrypted, 0, plain.Length);
            return getstring(decrypted);
        }

        public string encryptString(string decrypted, string password)
        {
            byte[] iv = getbytes("12345678");
            int blocksize = iv.Length;
            int numblocks = (decrypted.Length / blocksize) + 1;
            int decSize = decrypted.Length;
            //pad the string with nulls so that it is a multiple of blocksize
            for (int i = decSize; i < numblocks * blocksize; i++)
            {
                decrypted += '\0';
            }

            byte[] plain = getbytes(decrypted);
            byte[] encrypted = new byte[plain.Length];
            Array.Clear(encrypted, 0, encrypted.Length);
            byte[] key = getbytes(password);
            BlowfishCBC bfc = new BlowfishCBC();
            bfc.IV = iv;
            bfc.Initialize(key, 0, key.Length);
            bfc.Encrypt(plain, 0, encrypted, 0, plain.Length);
            return string2hex(getstring(encrypted));
        }

        public string string2hex(string asciiString)
        {
            string hex = "";
            foreach (char c in asciiString)
            {
                int tmp = c;
                hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
            }
            return hex;
        }
        public string hex2string(string Data)
        {
            string Data1 = "";
            string sData = "";
            while (Data.Length > 0)
            //first take two hex value using substring.
            //then convert Hex value into ascii.
            //then convert ascii value into character.
            {
                Data1 = System.Convert.ToChar(System.Convert.ToUInt32(Data.Substring(0, 2), 16)).ToString();
                sData = sData + Data1;
                Data = Data.Substring(2, Data.Length - 2);
            }
            return sData;
        }
        public string decryptVoucher(string wsPin)
        {
            return decryptString(hex2string(wsPin));
            //            return hex2string(wsPin);
        }


    }
}
