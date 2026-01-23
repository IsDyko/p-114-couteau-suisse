//Ecole: ETML
//Auteur: Diogo Martins
//Programme: Couteau Suisse

// Constantes

const string TEXT_TITLE = @"
  _____          __                  ____     _            
 / ___/__  __ __/ /____ ___ ___ __  / __/_ __(_)__ ___ ___ 
/ /__/ _ \/ // / __/ -_) _ `/ // / _\ \/ // / (_-<(_-</ -_)
\___/\___/\_,_/\__/\__/\_,_/\_,_/ /___/\_,_/_/___/___/\__/

══════════════════════════════════════════════════════════
";
string[] OPTIONS = { "1. Phrase en Morse", "2. Conversions", "0. Quitter" };
string[] CONVERT_OPTIONS = { "1. Décimal > Binaire", "2. Binaire > Décimal", "3. Binaire > Octal", "4. Octal > Binire" };

// Variables globales
string phraseToTranslate = string.Empty;

//Programme

Title();
Menu();

//Fonctions
void Title()
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(TEXT_TITLE);
    Console.ResetColor();
    Console.WriteLine("Bienvenue...\nCe programme actuellement ne fait que de la conversion\n");
}

void Menu()
{
    while (true) 
    { 
        Console.WriteLine("Sélectionner le mode de conversion");
        for (int i = 0; i < OPTIONS.Length; i++)
        {
            Console.WriteLine(OPTIONS[i]);
        }

        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        string pressedKey = keyInfo.KeyChar.ToString().ToUpper();

        if (!int.TryParse(pressedKey, out int menuChoice))
        {
            Console.Clear();
            Console.WriteLine("Entrée invalide. Appuyer sur 1 ou 2");
            Thread.Sleep(1000);
            Console.Clear();
            Title();
            continue;
        }

        switch (menuChoice)
        {
            case 1:
                Console.WriteLine("Ecrivez dés à présent votre phrase en dessous:");
                phraseToTranslate = Console.ReadLine().ToUpper();
                Translation(phraseToTranslate);
                break;
            case 2:
                Console.Clear();
                for (int i = 0; i < CONVERT_OPTIONS.Length; i++)
                {
                    Console.WriteLine(CONVERT_OPTIONS[i]);
                }
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.NumPad1 or ConsoleKey.D1:
                        Console.WriteLine("Insérez votre numéro: ");
                        ConvertTo(Convert.ToInt32(Console.ReadLine()), keyInfo.Key);
                        break;
                    case ConsoleKey.NumPad2 or ConsoleKey.D2:
                        Console.WriteLine("Insérez votre numéro: ");
                        ConvertTo(Convert.ToInt32(Console.ReadLine()), keyInfo.Key);
                        break;
                }
                break;
            case 0:
                Environment.Exit(0);
                break;
            default:
                Console.Clear();
                Console.WriteLine("Choix innexistant");
                Thread.Sleep(1000);
                Console.Clear();
                Title();
                Menu();
                break;
        }
        Console.WriteLine("\nAppuyer sur n'importe quelle touche pour recommencer");
        Console.ReadKey();
        Console.Clear();
        Title();
    }
}

void Translation(string word)
{
    char[] letters = word.ToCharArray();

    foreach (char letter in letters)
    {
        string key = letter.ToString();
        if (MorseDictionary.Morse.ContainsKey(key))
        {
            Console.Write(MorseDictionary.Morse[key] + "  ");

            foreach (char symbol in MorseDictionary.Morse[key])
            {
                if (symbol == '.')
                {
                    Console.Beep(800, 150);
                }
                else if (symbol == '-')
                {
                    Console.Beep(800, 400);
                }
                Thread.Sleep(100);
            }
            Thread.Sleep(300);
        }     
    }
}

void ConvertTo(int number, ConsoleKey key)
{
    if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
    {
        List<int> binaryNumber = new();

        while (number > 0)
        {
            binaryNumber.Add(number % 2);
            number /= 2;
        }

        binaryNumber.Reverse();

        Console.WriteLine(string.Join("", binaryNumber));
    }

    else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
    {
        int decimalResult = 0;
        int power = 1;

        while (number > 0)
        {
            int lastDigit = number % 10;
            decimalResult += lastDigit * power;
            power *= 2;
            number /= 10;
        }

        Console.WriteLine(decimalResult);
    }
}