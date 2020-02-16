using System.Text.RegularExpressions;


namespace PasswordChecker.Application
{
    public enum PasswordScore
    {
        Blank = 0,
        VeryWeak = 2,
        Weak = 4,
        Mediocre = 6,
        Average = 8,   
        Strong = 10,
        VeryStrong = 12        
    }
    public class PasswordChecker
    {
        public static PasswordScore CheckStrength(string password)
        {
            int score = 0;

            //if the password length is 0, score=0
           if (string.IsNullOrEmpty(password))
                return PasswordScore.Blank;
           if (password.Length == 0)
                return PasswordScore.Blank;

          //if the password length is greater than 5, score=1
            if (password.Length >= 5)         
                score = score + 1;            
            

            //if have letters, add pts to score
            if (Regex.Match(password, @"^[a-zA-Z]").Success)
                score = score + 1;

            // if the password length is 8 or greater, add pts to score
            if (password.Length >= 8)
                score = score + 1;

            //if the password length is 12 or greater, add pts to score
            if (password.Length >= 12)
                score = score + 2;

            //if have numbers, add pts to score
            if (Regex.Match(password, @"[0-9]").Success)
                score = score + 1;

            //if have lower and uppercase letters, add pts to score
            if (Regex.Match(password, @"([a-z].*[A-Z])|([A-Z].*[a-z])").Success)
                score = score + 2;

            //if with special characters, add pts to score
            if (Regex.Match(password, @"[.,/,\,|,<,>,!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]").Success)
                score = score + 2;

            //if no consecutive the same characters, add pts to score
            if ((password.Length >= 8) && (!Regex.Match(password, @"(\w)(\1)+").Success))
                score = score + 1;

            ///[\n# $&:\n\t]/g no space
            if ((password.Length >= 8) && (!Regex.Match(password, @"(\s)+").Success))
                score = score + 1;

            if (score == 11)
                score = score + 1;

            return (PasswordScore)score;
        }
    }
}