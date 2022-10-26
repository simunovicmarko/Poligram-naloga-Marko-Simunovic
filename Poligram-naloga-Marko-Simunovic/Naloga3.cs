namespace Naloga
{
    class Naloga3
    {
        // private string input = ".X.XXXXX..";
        private string input = "XX.X...X.X";
        private string GenerateInput(int length = 50)
        {
            Random random = new Random();
            string s = "";
            for (int i = 0; i < length; i++)
            {
                if (random.Next(0, 2) == 1)
                {
                    s += 'X';
                }
                else s += '.';

            }
            return s;
        }


        private static void swapItemsInArray<T>(ref T[] arr, int i1, int i2)
        {
            T temp = arr[i1];
            arr[i1] = arr[i2];
            arr[i2] = temp;
        }


        private void swapFromPivotToTheEnd(ref char[] arr, ref int counter, char specialCharacter = '.')
        {
            int pivot = arr.Length / 2;
            for (int i = pivot - 1; i < arr.Length; i++)
            {
                if (arr[i] == specialCharacter)
                {
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[j] != specialCharacter)
                        {
                            swapItemsInArray(ref arr, i, j);
                            counter += j - i;
                            break;
                        }
                    }
                }
            }
        }
        private void swapFromPivotToTheStart(ref char[] arr, ref int counter, char specialCharacter = '.')
        {
            int pivot = arr.Length / 2;
            for (int i = pivot; i > -1; i--)
            {
                if (arr[i] == specialCharacter)
                {
                    for (int j = i - 1; j > -1; j--)
                    {
                        if (arr[j] != specialCharacter)
                        {
                            swapItemsInArray(ref arr, i, j);
                            counter += i - j;
                            break;
                        }
                    }
                }
            }

        }


        private void UI()
        {
            System.Console.WriteLine("Vnesite vrstico:");
            this.input = Console.ReadLine();

        }
        public int execute(int len = 10)
        {
            UI();
            if (this.input != null)
            {

                char[] arr = input.ToCharArray();
                // FOR TESTiN PURPOSES
                // arr = GenerateInput(len).ToCharArray();
                System.Console.WriteLine(arr);

                int counter = 0;
                swapFromPivotToTheEnd(ref arr, ref counter);
                swapFromPivotToTheStart(ref arr, ref counter);
                Console.WriteLine(counter);
                return counter;
            }
            return 0;
        }
    }
}


