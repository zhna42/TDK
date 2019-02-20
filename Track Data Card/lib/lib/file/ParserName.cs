using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track_Data_Card.lib.lib.file
{
    class ParserName
    {
        public string IntToName(int num)
        {
            string name = "";
            if (num < 1000)
                name = "A";
            else if (num < 2000)
                name = "B";
            else if (num < 3000)
                name = "C";
            else if (num < 4000)
                name = "D";
            else if (num < 5000)
                name = "E";
            else if (num < 6000)
                name = "F";
            else if (num < 7000)
                name = "G";
            else if (num < 8000)
                name = "H";
            else if (num < 9000)
                name = "I";
            else if (num < 10000)
                name = "J";
            else if (num < 11000)
                name = "K";
            else if (num < 12000)
                name = "L";
            else if (num < 13000)
                name = "M";
            else if (num < 14000)
                name = "N";
            else if (num < 15000)
                name = "O";
            else if (num < 16000)
                name = "P";
            else if (num < 17000)
                name = "Q";
            else if (num < 18000)
                name = "R";
            else if (num < 19000)
                name = "S";
            else if (num < 20000)
                name = "T";
            else if (num < 21000)
                name = "U";
            else if (num < 22000)
                name = "V";
            else if (num < 23000)
                name = "W";
            else if (num < 24000)
                name = "X";
            else if (num < 25000)
                name = "Y";
            else if (num < 26000)
                name = "Z";

            char[] characters = num.ToString().ToCharArray();
            if (characters.Length - 1 < 1)
                name += "0" + "0" + characters[0].ToString();
            else if (characters.Length - 1 < 2)
                name += "0" + characters[0].ToString() + characters[1].ToString();
            else if (characters.Length - 1 < 3)
                name += characters[0].ToString() + characters[1].ToString() + characters[2].ToString();
            else if (characters.Length - 1 < 4)
                name += characters[1].ToString() + characters[2].ToString() + characters[3].ToString();
            else if (characters.Length - 1 < 5)
                name += characters[2].ToString() + characters[3].ToString() + characters[4].ToString();
            return name;
        }

        public int NameToInt(string str)
        {
            Console.WriteLine(str);
            char[] characters = str.ToCharArray();
            string name = "";
            if (characters[1] == 'B')
                name += "1";
            else if (characters[1] == 'C')
                name += "2";
            else if (characters[1] == 'D')
                name += "3";
            else if (characters[1] == 'E')
                name += "4";
            else if (characters[1] == 'F')
                name += "5";
            else if (characters[1] == 'G')
                name += "6";
            else if (characters[1] == 'H')
                name += "7";
            else if (characters[1] == 'I')
                name += "8";
            else if (characters[1] == 'J')
                name += "9";
            else if (characters[1] == 'K')
                name += "10";
            else if (characters[1] == 'L')
                name += "11";
            else if (characters[1] == 'M')
                name += "12";
            else if (characters[1] == 'N')
                name += "13";
            else if (characters[1] == 'O')
                name += "14";
            else if (characters[1] == 'P')
                name += "15";
            else if (characters[1] == 'Q')
                name += "16";
            else if (characters[1] == 'R')
                name += "17";
            else if (characters[1] == 'S')
                name += "18";
            else if (characters[1] == 'T')
                name += "19";
            else if (characters[1] == 'U')
                name += "20";
            else if (characters[1] == 'V')
                name += "21";
            else if (characters[1] == 'W')
                name += "22";
            else if (characters[1] == 'X')
                name += "23";
            else if (characters[1] == 'Y')
                name += "24";
            else if (characters[1] == 'Z')
                name += "25";
            name += characters[2].ToString() + characters[3].ToString() + characters[4].ToString();
            return Int32.Parse(name);
        }
    }
}
