//Ecole: ETML
//Auteur: Diogo Martins
//Programme Couteau Suisse

// Constantes

const string TEXT_TITLE = @"
  _____          __                  ____     _            
 / ___/__  __ __/ /____ ___ ___ __  / __/_ __(_)__ ___ ___ 
/ /__/ _ \/ // / __/ -_) _ `/ // / _\ \/ // / (_-<(_-</ -_)
\___/\___/\_,_/\__/\__/\_,_/\_,_/ /___/\_,_/_/___/___/\__/

══════════════════════════════════════════════════════════
";

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
        Console.WriteLine("1. Phrase en Morse");
        Console.WriteLine("2. Morse en Phrase");

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
                Console.WriteLine("Ecrivez dés à présent votre phrase en Morse:");
                string morseToTranslate = Console.ReadLine().ToUpper();
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