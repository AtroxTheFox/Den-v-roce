using Microsoft.VisualBasic;
using System;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;
class Program
{
    static void Main()
    {

        //metoda while; diky ni se program neukonci po zadani jednoho data
        while (true)
        {

        Console.Write("Zadejte datum (dd.MM.yyyy); pro vypnuti exit: ");
        string input = Console.ReadLine();
        
        //pokud uzivatel zada exit, program se ukonci
        if (input.ToLower() == "exit")
        {
            break;
        }
        //validace, vypise se chyba, program se neukonci
        string[] parts = input.Split('.');

        if (parts.Length != 3)
        {
            Console.WriteLine("Chyba: Neplatny format data. Zadejte datum ve formatu 'dd.MM.yyyy'.");
            continue;
        }

        int den, mesic, rok;

        //pokud se nepodari prevest string na int, vypise se chyba
        if (!int.TryParse(parts[0], out den) || !int.TryParse(parts[1], out mesic) || !int.TryParse(parts[2], out rok ))
        {
            Console.WriteLine("Chyba: Neplatny format data. Zadejte datum ve formatu 'dd.MM.yyyy'.");
            continue;
        }
        //pokud se nepodari prevest string na datum, vypise se chyba
        DateTime dateInput;
        if (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out dateInput))
        {
            Console.WriteLine("Chyba: Neplatne datum.");
            continue;
        }
        //pokud uzivatel zada datum vetsi nez dnesni, vypise se chyba
        if (dateInput > DateTime.Now)
        {
            Console.WriteLine("Chyba: Datum nemuze byt vetsi nez dnesni datum.");
            continue;
        }
        //pokud uzivatel zada datum mensi nez 1.1.1583, vypise se chyba; v tomto roce byl zaveden gregorian calendar; probíhá výpočet data
        int a = (14 - mesic) / 12;
        int y = rok - a;
        int m = mesic + 12 * a - 2;
        int d = (den + y + y / 4 - y / 100 + y / 400 + (31 * m) / 12) % 7;

        //pole s dny v tydnu
        string[] dny = { "Nedele", "Pondeli", "Utery", "Streda", "Ctvrtek", "Patek", "Sobota" };
        Console.WriteLine("V tento den byl den v tydnu: " + dny[d]);
        }
    }
}
