﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace lab1SisProg
{
    public class Converter
    {
        public static int ConvertHexToDec(string str)
        {
            int decNumber = 0;
            str = str.ToUpper();
            var hexNumbers = new List<char>{'0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F'};

            var chrs = str.ToCharArray();

            double k = 0;
            for (int i = chrs.Length - 1; i >= 0; i--)
            {
                decNumber += hexNumbers.IndexOf(chrs[i]) * (int)(Math.Pow(16, k));
                k++;
            }

            return decNumber;
        }

        public static string ConvertDecToHex(int decNumber)
        {
            string hexNumber = "";
            char[] hexMass = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            int tempNumber = decNumber;
            var mod = new List<int>();
  
            if (tempNumber < 16)
                hexNumber += hexMass[tempNumber];
            else
            {

                while (tempNumber >= 1)
                {
                    tempNumber /= 16;
                    mod.Add(decNumber % 16);
                    decNumber /= 16;
                }

                for (int i = mod.Count - 1; i >= 0; i--)
                    hexNumber += hexMass[mod[i]];
            }

            return hexNumber;
        }

        public static string ConvertToTwoChars(string str)
        {
            const int lenghtNumber = 2;
            var chars = str.ToCharArray();
            var sum = new char[lenghtNumber];
            string convertNumber = "";

            if (str == "")
                return "";

            if (chars.Length <= lenghtNumber)
            {
                int needZero = lenghtNumber - chars.Length;

                for (int i = lenghtNumber - 1; i >= needZero; i--)
                    sum[i] = chars[i - needZero];

                for (int i = 0; i < needZero; i++)
                    sum[i] = '0';

                foreach (var s in sum)
                    convertNumber += s;
            }
            return convertNumber;
        }

        public static string ConvertToSixChars(string number)
        {
            const int lenghtNumber = 6;
            var chrs = number.ToCharArray();
            var sum = new char[lenghtNumber];
            string convertNumber = "";
            if (number == "")
                return "";
            if (chrs.Length <= lenghtNumber)
            {
                int needZero = lenghtNumber - chrs.Length;

                for (int i = lenghtNumber - 1; i >= needZero; i--)
                    sum[i] = chrs[i - needZero];

                for (int i = 0; i < needZero; i++)
                    sum[i] = '0';

                foreach (var s in sum)
                    convertNumber += s;
            }
            return convertNumber;
        }

        public static string ConvertASCII(string str)
        {
            string res = "";
            byte[] bytes = Encoding.ASCII.GetBytes(str);

            for (int i = 0; i < bytes.Length; i++)
                res += ConvertDecToHex(Convert.ToInt32(bytes[i]));

            return res;
        }

        public static string ConvertToBinaryCodeSTART(string address, string command, string OP1)
        {
             return "H" + " " + address + " " + command + " " + Converter.ConvertToSixChars(Converter.ConvertDecToHex(Convert.ToInt32(OP1)));
        }

        public static string ConvertToBinaryCode(string address, string command, string length, string OP1, string OP2)
        {
            string str = "";
            str += "T" + " ";

            if (address.Length > 0)
                str += address + " ";

            str += length + " " + command + " ";

            if (OP1.Length > 0)
                str += OP1 + " ";
            if (OP2.Length > 0)
                str += OP2;

            return str;
        }

        public static string ConvertToBinaryCodeEND(string address)
        {
            return "E" + " " + address;
        }
    }
}
