// See https://aka.ms/new-console-template for more information


using The_Password_Validator;

bool KeepRunning = true;



while (KeepRunning)
{
    Console.WriteLine("Enter your password: ");
    string UsersPassword = Console.ReadLine();
    PasswordValidator passwordValidator = new PasswordValidator(UsersPassword);
    passwordValidator.PasswordValidatorLoop();
}