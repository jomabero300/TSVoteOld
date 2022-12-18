namespace TSVoteWeb.Common
{
    public class Utilities
    {
        public static string StartCharacterToUpper(string str)
        {
            string x = str.Substring(0, 1);

            x = x.ToUpper();

            str = x + str.Substring(1, str.Length - 1);

            return str;
        }
        
    }
}