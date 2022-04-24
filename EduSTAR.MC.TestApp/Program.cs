using System.Net;
using System.Net.Mime;
using System.Security;
using EduSTAR.MC.API;

var credentials = GetCredentials();

EduSTARMC.Connect(credentials);

Exit();




static SecureString GetPassword() {
    // Source: https://stackoverflow.com/a/40869537
    var pass = new SecureString();
    ConsoleKeyInfo key;

    do {
        key = Console.ReadKey(true);

        // Backspace Should Not Work
        if (!char.IsControl(key.KeyChar)) {
            pass.AppendChar(key.KeyChar);
            Console.Write("*");
        }
        else {
            if (key.Key == ConsoleKey.Backspace && pass.Length > 0) {
                pass.RemoveAt(pass.Length - 1);
                Console.Write("\b \b");
            }
        }
    }
    // Stops Receving Keys Once Enter is Pressed
    while (key.Key != ConsoleKey.Enter);

    Console.WriteLine();
    return pass;
}

static NetworkCredential GetCredentials() {
    Console.Write("Enter your department username : ");
    var username = Console.ReadLine();

    Console.Write("Enter your department password : ");
    var password = GetPassword();

    return new NetworkCredential(username, password);
}

static void Exit() {
    //Console.WriteLine("Press any key to exit");
    //Console.ReadLine();

    Environment.Exit(0);
}