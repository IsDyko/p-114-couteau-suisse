//Ecole: ETML
//Auteur: Diogo Martins
//Programme Couteau Suisse

// Variables globales
string phraseToTranslate = string.Empty;
MorseDictionary morseDict = new MorseDictionary();

Title();
Menu();

void Title()
{
    string textTitle = @"
  _____          __                  ____     _            
 / ___/__  __ __/ /____ ___ ___ __  / __/_ __(_)__ ___ ___ 
/ /__/ _ \/ // / __/ -_) _ `/ // / _\ \/ // / (_-<(_-</ -_)
\___/\___/\_,_/\__/\__/\_,_/\_,_/ /___/\_,_/_/___/___/\__/

══════════════════════════════════════════════════════════
";
    Console.WriteLine(textTitle);
    Console.WriteLine("Bienvenue... \nCe programme actuellement ne fait que de la conversion");
}

void Menu()
{
    Console.WriteLine("Sélectionner le mode de conversion");
    Console.WriteLine("1. Phrase en Morse");
    Console.WriteLine("2. Morse en Phrase");

    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
    string pressedKey = keyInfo.KeyChar.ToString().ToUpper();

    if (!int.TryParse(pressedKey, out int menuChoice))
    {
        Console.WriteLine("Entrée invalide. Appuyer sur 1 ou 2");
    }

    switch (int.Parse(pressedKey))
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
        default:
            Console.Clear();
            Console.WriteLine("Choix innexistant");
            Thread.Sleep(1000);
            Console.Clear();
            Title();
            Menu();
            break;
    }
}

void Translation(string word)
{
    char[] letters = word.ToCharArray();

    foreach (char letter in letters)
    {
        string key = letter.ToString();
        if (morseDict.Morse.ContainsKey(key))
        {
            Console.Write(morseDict.Morse[key] + "  ");
        }
        else if (key == " ")
        {
            Console.Write("/ "); // séparation des mots
        }
    }
}