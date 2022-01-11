using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmPractice
{
    public class Challenge
    {
        public static string ToBase64(string str)
        {
            Dictionary<string, string> sextet = new Dictionary<string, string>
            {
                {"000000", "A"},{"000001", "B"},{"000010", "C"},{"000011", "D"},
                {"000100", "E"},{"000101", "F"},{"000110", "G"},{"000111", "H"},
                {"001000", "I"},{"001001", "J"},{"001010", "K"},{"001011", "L"},
                {"001100", "M"},{"001101", "N"},{"001110", "O"},{"001111", "P"},
                {"010000", "Q"},{"010001", "R"},{"010010", "S"},{"010011", "T"},
                {"010100", "U"},{"010101", "V"},{"010110", "W"},{"010111", "X"},
                {"011000", "Y"},{"011001", "Z"},{"011010", "a"},{"011011", "b"},
                {"011100", "c"},{"011101", "d"},{"011110", "e"},{"011111", "f"},
                {"100000", "g"},{"100001", "h"},{"100010", "i"},{"100011", "j"},
                {"100100", "k"},{"100101", "l"},{"100110", "m"},{"100111", "n"},
                {"101000", "o"},{"101001", "p"},{"101010", "q"},{"101011", "r"},
                {"101100", "s"},{"101101", "t"},{"101110", "u"},{"101111", "v"},
                {"110000", "w"},{"110001", "x"},{"110010", "y"},{"110011", "z"},
                {"110100", "0"},{"110101", "1"},{"110110", "2"},{"110111", "3"},
                {"111000", "4"},{"111001", "5"},{"111010", "6"},{"111011", "7"},
                {"111100", "8"},{"111101", "9"},{"111110", "+"},{"111111", "/"},
                {"------", "=" }
            };

            var sr = "";
            foreach (var ch in str)
            {
                sr += BinaryConverter.ToBinary(ch);
            }
            if (sr.Length % 24 != 0)
            {
                sr += "000000"[(sr.Length % 6)..];
                sr += "------------------------"[(sr.Length % 24)..];
            }
            string b64 = "";
            for (int i = 0; i < sr.Length; i += 6)
            {
                    b64 += sextet[sr[i..(i + 6)]];
            }

            return b64;
        }
    }

    public class BinaryConverter
    {
        public static string ToBinary(int num, int size = 8)
        {
            string bin = "";
            while (num > 0)
            {
                bin = num % 2 == 0 ? "0" + bin : "1" + bin;
                num /= 2;
            }

            string zeros = "";
            for (int i = 0; i < size; i++)
            {
                zeros += "0";
            }

            return zeros[bin.Length..] + bin;
        }
    }
}
