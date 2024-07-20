using System;

interface ID_CRYPT
{
    char[] encrypt(char[] _password, char[] _message);
    char[] DE_Crypt(char[] _password, char[] _en_message);


}


class EN_DE_CRYPTION : ID_CRYPT
{
    private char[] message;
    private char[] password;

    public EN_DE_CRYPTION()
    {
        message = new char[0];
        password = new char[0];

    }

    public EN_DE_CRYPTION(char[] _password, char[] _message)
    {
        this.password = _password;
        this.message = _message;
    }

    private bool Is_Password_Valid(char[] _password)
    {


        foreach (char ch in _password)
        {
            if ((int)ch < 65 || (int)ch > 90)
                return false;

            if (ch == ' ')
                return false;

        }
        return true;
    }

    private bool Is_Message_Valid(char[] _message)
    {
        foreach (char ch in _message)
        {
            if (ch == ' ')
            {
                continue;
            }
            if ((int)ch < 65 || (int)ch > 90)
                return false;
        }
        return true;
    }

    public void Start_Program()
    {

        string[] tokens;
        char[] _password;
        char[] _message;
        bool flag;
        do
        {

            tokens = Input();
            _password = tokens[0].ToCharArray();
            _message = tokens[1].ToCharArray();
            flag = Final_Validation(_password, _message);

            if (flag)
            {
                char[] encryptedMessage = encrypt(_password, _message);
                char[] decryptedMessage = DE_Crypt(_password, encryptedMessage);
                Console.WriteLine("Encrypted Message: " + new string(encryptedMessage));
                Console.WriteLine("\n\n");
                Console.WriteLine("Decrypted Message: " + new string(decryptedMessage));
            }
            else
            {
                Console.WriteLine("Your password shouldn't contain any spaces, " +
                                  "it should be shorter than your message, ");
            }

        } while (!flag);
    }

    private string[] Input()
    {
        string[] arr = new string[2];
        string? _pass = string.Empty;
        string? _mess = string.Empty;

        while (string.IsNullOrEmpty(_pass))
        {
            Console.WriteLine("Enter a password: ");
            _pass = Console.ReadLine()?.ToUpper();

            if (string.IsNullOrEmpty(_pass))
            {
                Console.WriteLine("Input cannot be empty. Please try again.");
            }
        }
        arr[0] = _pass;

        while (string.IsNullOrEmpty(_mess))
        {
            Console.WriteLine("Enter a message: ");
            _mess = Console.ReadLine()?.ToUpper();

            if (string.IsNullOrEmpty(_mess))
            {
                Console.WriteLine("Input cannot be empty. Please try again.");
            }
        }
        arr[1] = _mess;

        return arr;
    }

    private bool Final_Validation(char[] _password, char[] _message)
    {

        if (_password.Length > _message.Length || !Is_Password_Valid(_password) || !Is_Message_Valid(_message))
        {
            return false;
        }
        return true;
    }

    public char[] encrypt(char[] _password, char[] _message)
    {
        char[] Result_Array = new char[_message.Length];
        int counter = 0;
        int Password_Length = _password.Length;

        for (int i = 0; i < _message.Length; i++)
        {
            if (_message[i] == ' ')
            {
                Result_Array[i] = ' ';
                continue;
            }

            int sum = _password[counter % Password_Length] + _message[i];

            if (sum <= 155)
            {
                Result_Array[i] = (char)(sum - 65);
            }
            else
            {
                Result_Array[i] = (char)(sum - 90 - 1);
            }

            counter++;
        }

        return Result_Array;
    }

    public char[] DE_Crypt(char[] _password, char[] _en_message)
    {
        char[] Result_Array = new char[_en_message.Length];
        int counter = 0;
        int Password_Length = _password.Length;

        for (int i = 0; i < _en_message.Length; i++)
        {
            if (_en_message[i] == ' ')
            {
                Result_Array[i] = ' ';
                continue;
            }

            int sum = _en_message[i] - (_password[counter % Password_Length]);

            if (_en_message[i] >= (_password[counter % Password_Length]))
            {
                Result_Array[i] = (char)(sum + 65);
            }
            else
            {
                Result_Array[i] = (char)(sum + 90 + 1);

            }

            counter++;
        }

        return Result_Array;
    }



}


class OOP_2
{
    static public void Main(string[] args)
    {
        EN_DE_CRYPTION eN_DE_CRYPTION = new EN_DE_CRYPTION();

        eN_DE_CRYPTION.Start_Program();

    }
}
