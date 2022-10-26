namespace Naloga
{
    class Naloga1
    {
        // FOR TESTING PURPOSES
        private string searchString = "L?V5??E";
        private string[] dbInputs = {
            "LJV502E Miha Novak",
            "MBA60R2 Maja Kos",
            "LJV511E Spela Cadonic Vidic"
        };

        private string[] GenerateRandomLicencePlates(int numberOfOutputs = 1000)
        {
            string[] output = new string[numberOfOutputs];
            Random random = new Random();
            for (int i = 0; i < numberOfOutputs; i++)
            {
                string s = "";
                for (int j = 0; j < 7; j++)
                {
                    int lower = 0;
                    int upper = 10;
                    int chooser = random.Next(0, 2);
                    if (chooser == 0)
                    {
                        lower = 65;
                        upper = 91;
                    }
                    int ascii_index = random.Next(lower, upper);
                    char myRandomUpperCase = Convert.ToChar(ascii_index);
                    s += myRandomUpperCase;
                }
                output[i] = s + " " + GenerateName(random.Next(10, 201)) + " " + GenerateName(20);
            }
            output[364] = "LJV502E Miha Novak";
            output[999] = "LJV511E Spela Cadonic Vidic";

            return output;
        }

        private string RandomSearchString()
        {
            Random random = new Random();
            string s = "";
            for (int j = 0; j < 7; j++)
            {
                int lower = 0;
                int upper = 10;
                int chooser = random.Next(0, 2);
                if (chooser == 0)
                {
                    lower = 65;
                    upper = 91;
                }
                int ascii_index = random.Next(lower, upper);
                char myRandomUpperCase = Convert.ToChar(ascii_index);
                int neki = random.Next(0, 2);
                if (neki == 0)
                {
                    s += myRandomUpperCase;
                }
                else
                {
                    s += "?";
                }
            }
            return s;
        }

        private string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;


        }


        // CODE

        /**
        Splits licence plates from name
        **/
        private KeyValuePair<string, string> Split(string input)
        {
            string[] output = input.Split(' ', 2);
            return new KeyValuePair<string, string>(output[0], output[1]);
        }


        /** 
        Checks if a word matches to a search string
        **/
        private bool WordMatches(string word, string searchString = "L?V5??E", char specialCharacter = '?')
        {
            bool isMatch = true;
            for (int i = 0; i < word.Length; i++)
            {
                if (searchString[i] == specialCharacter) continue;
                if (word[i] != searchString[i])
                {
                    isMatch = false;
                    break;
                }
            }
            return isMatch;
        }

        public void execute()
        {
            // string[] licencePlates = GenerateRandomLicencePlates();
            string[] licencePlates = dbInputs;

            foreach (string input in licencePlates)
            {
                KeyValuePair<string, string> splitInput = Split(input);
                if (WordMatches(splitInput.Key, searchString))
                {
                    Console.WriteLine(splitInput.Value);
                }
            }
        }
    }
}