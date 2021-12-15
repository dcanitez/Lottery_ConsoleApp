using System;

namespace Lottery_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string optionNo = string.Empty;
            Random rnd = new Random();
            do
            {
                MenuOptions();

                optionNo = Console.ReadLine();
                Console.ResetColor();

                switch (optionNo)
                {
                    case "1":
                        //6 kolonlu 8 satırlı tahmin üret 
                        RandomRowGenerator(rnd, 8);
                        break;
                    case "2":
                        //verilen satır sayısına göre tahmin üret

                        int rowCount = 0;
                        do
                        {
                            Console.Write("Please enter a row number : ");
                            rowCount = int.Parse(Console.ReadLine());

                            if (rowCount > 8 || rowCount < 1)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine("You cannot write a number greater than 8\n According to the game rules you can play 8 rows for a single lottery ticket");
                                Console.ResetColor();
                            }

                        } while (rowCount > 8 || rowCount < 1);
                        RandomRowGenerator(rnd, rowCount);

                        Console.WriteLine();
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Please choose a number from the menu above!");
                        break;
                }

            } while (optionNo != "3");

            Console.ReadKey();
        }

        private static void RandomRowGenerator(Random rnd, int rowCount)
        {
            for (int i = 0; i < rowCount; i++)
            {
                int[] row = new int[6];

                for (int j = 0; j < 6; j++)
                {
                    bool isSameNumber;
                    int num;
                    do
                    {
                        num = rnd.Next(1, 91);
                        isSameNumber = false;

                        for (int m = 0; m < row.Length; m++)
                        {
                            if (num == row[m])
                            {
                                isSameNumber = true;
                            }
                        }
                    } while (isSameNumber);

                    row[j] = num;
                }
                Array.Sort(row);

                for (int k = 0; k < row.Length; k++)
                {
                    if (k < row.Length - 1)
                    {
                        Console.Write(row[k] + " - ");
                    }
                    else
                    {
                        Console.Write(row[k]);
                    }
                }

                Console.WriteLine();
            }
        }
        private static void MenuOptions()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            string menu = "Menu Options :";
            Console.WriteLine(menu);
            for (int i = 0; i < menu.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            Console.WriteLine("[1]- Produce New Guess For 8 Rows");
            Console.WriteLine("[2]- New Guess For Given Row Count");
            Console.WriteLine("[3]- Exit");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Choose an Action : ");
        }
    }
}
