using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

internal static class Program
{
    public delegate void DReform(string ReformName);

    public static string GetReformNameFromDate(string DateRequest)
    {
        string ReformName = String.Empty;

        int day = int.Parse(DateRequest.Substring(0, DateRequest.IndexOf('-')));
        int month = int.Parse(DateRequest.Substring(DateRequest.IndexOf('-') + 1, DateRequest.Substring(DateRequest.IndexOf('-') + 1).IndexOf('-')));

        DateRequest = DateRequest.Substring(DateRequest.IndexOf('-') + 1);

        int year = int.Parse(DateRequest.Substring(DateRequest.IndexOf('-') + 1));

        string[] FromDay = new string[] { "ліберальна", "надихаюча", "незалежна", "проривна",
                                          "демократична", "вільна", "громадьска", "цифрова",
                                          "лідерьска", "інноваційна" };

        string[] FromMonth = new string[] { "економічна", "судова", "європейська", "інституційна",
                                            "урядова", "поодаткова", "інтегрована", "післявоєнна",
                                            "інфаструктурна", "державна", "президентьска", "законотворча" };

        string[] FromYear = new string[] { "стратегія", "місія", "реформа", "візія",
                                           "модернація", "екосистема", "реконструкція", "політика",
                                           "спроможність", "відбудова"};

        return FromDay[(day % 10 + day / 10) % 10 - 1] + " " + FromMonth[month - 1] + " " + FromYear[(year / 10 + year % 10 + year / 10 / 10 % 10) % 10 - 1];
    }

    public static void DoWithReform(DReform Do, string ReformName) => Do(ReformName);
    

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.Clear();

            Console.Write("введіть дату (день-місяць-рік):\n\n-> ");

            string Input = new string(Console.ReadLine());

            Regex regex = new Regex(@"^(0?[1-9]|[12][0-9]|3[01])-(0?[1-9]|1[0-2])-((19|20)\d\d)$");

            if (!regex.IsMatch(Input))
            {
                Console.WriteLine("\nневірний формат дати");
                Console.ReadKey();
                continue;
            }

            Console.WriteLine("\n\nрезультат:\n");

            DoWithReform(Console.WriteLine, GetReformNameFromDate(Input));

            Console.ReadKey();
        }
    }
}