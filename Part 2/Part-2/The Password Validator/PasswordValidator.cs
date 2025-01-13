namespace The_Password_Validator;

public class PasswordValidator
{
    public string Password { get; }
    
    public PasswordValidator(string password)
    {
        Password = password;
    }

    public void PasswordValidatorLoop()
    {
        bool PasswordIsLongEnough = PasswordLengthIsLongEnough(Password);
        bool containsNumber = PasswordContainsNumber(Password);
        bool containsUpperCase = PasswordContainsUpperCase(Password);
        bool ContainsLowerCase = PasswordContainsLowerCase(Password);
        bool containsSpecialCharacter = PasswordContainsSpecialCharacter(Password);

        
        if(PasswordIsLongEnough && containsNumber && containsUpperCase && ContainsLowerCase & !containsSpecialCharacter)
        {
            Console.WriteLine("Password is valid.");
        }
        else
        {
            Console.WriteLine("Password is invalid.");
        }
    }
    
    private bool PasswordLengthIsLongEnough(string password)
    {
        return Password.Length >= 6;
    }

   private bool PasswordContainsNumber(string password)
   {
       return password.Any(char.IsDigit);
   }

   private bool PasswordContainsUpperCase(string password)
   {
       return password.Any(char.IsUpper);
   }

   private bool PasswordContainsLowerCase(string password)
   {
       return password.Any(char.IsLower);
   }

   private bool PasswordContainsSpecialCharacter(string password)
   {
       char[] specialCharacters = { 'T', '&' };
       return password.Any(specialCharacters.Contains);
   }
   
}