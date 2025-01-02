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
        bool PasswordLengthIsLongEnough = false;
        bool containssNumber = false;
        bool containsUpperCase = false;
        bool ContainsLowerCase = false;
        bool containsSpecialCharacter = false;
        
        if (Password.Length < 6)
        {
            PasswordLengthIsLongEnough = false;
        }
        else
        {
            {
                Console.WriteLine("Password is long enough.");
                PasswordLengthIsLongEnough = true;
            }
        }
        foreach (char letter in Password)
        {
            if (char.IsDigit(letter))
            {
                containssNumber = true;
            }
            else
            {
                containssNumber = false;
            }
           

            if (char.IsUpper(letter))
            {
                containsUpperCase = true;
            }
            else
            {
                containsUpperCase = false;
            }
            
            
            if (char.IsLower(letter))
            {
                ContainsLowerCase = true;
            }
            else
            {
                ContainsLowerCase = false;
            }
            
        }
        
        if(PasswordLengthIsLongEnough && containssNumber && containsUpperCase && ContainsLowerCase)
        {
            Console.WriteLine("Password is valid.");
        }
        else
        {
            Console.WriteLine("Password is invalid.");
        }
    }
}