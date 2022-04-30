using System.Net;
using System.Net.Mime;
using System.Security;
using System.Threading.Channels;
using EduSTAR.MC.API;
using EduSTAR.MC.API.Models;

var credentials = GetCredentials();

Console.WriteLine("Connecting to the eduSTAR Management Console...");
var eduStar = new EduSTARMC(credentials);
Console.WriteLine("  Connection succeeded.");

Console.WriteLine("Getting a list of schools...");
var schoolArray = eduStar.GetSchools();
Console.Write($"  Found {schoolArray.Length} school");
if (schoolArray.Length != 1) {
    Console.Write("s");
}
Console.WriteLine(".");

Console.WriteLine("Setting the default school ID...");
eduStar.SetDefaultSchool(8716);
Console.WriteLine("  Default school ID set.");


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