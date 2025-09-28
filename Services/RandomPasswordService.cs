using System.Net;

namespace LoginService.Services
{
    public class RandomPasswordService : IRandomPasswordService
    {
        public string GenerateRandomPassword(int lenght, bool upperCase, bool specialChar)
        {
            List<List<char>> charlist = GenerateCharArray();
            Random r = new Random();
            string password = string.Empty;

            List<char> letters = charlist[0];
            List<char> symbols = charlist[1];

            for(int i = 0; i < lenght; i++)
            {
                if (specialChar)
                {
                    List<char> thisCharList = charlist[r.Next(0,2)];
                    string c = thisCharList[r.Next(0, thisCharList.Count)].ToString();
                    bool upperORNot = r.Next(0, 2) == 1 ? true : false;
                    password = upperORNot ? password + c : password + c.ToLower();
                }
            }
            return password;
        }


        public List<List<char>> GenerateCharArray()
        {
            List<char> letters = new List<char>();
            List<char> symbols = new List<char>();
            Random r = new Random();
            List<List<char>> lists = new List<List<char>>();

            for(char c = 'A'; c <= 'Z'; c++)
            {
                letters.Add(c);
            }

            symbols.Add('!');
            symbols.Add('@');
            symbols.Add('#');
            symbols.Add('$');

            lists.Add(symbols);
            lists.Add(letters);

            return lists;
        }      
    }
}
