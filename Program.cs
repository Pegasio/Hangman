using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Random;

namespace Виселица
{
    internal class Program
    {
        private static void printHangman(int wrong) // функция, которая рисует пошагово повешенного человечка
        {
            if (wrong == 0)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }

            else if (wrong == 1)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("0   |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }

            else if (wrong == 2)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("0   |");
                Console.WriteLine("|   |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }


            else if (wrong == 3)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" 0  |");
                Console.WriteLine("/|  |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }


            else if (wrong == 4)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" 0  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }


            else if (wrong == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" 0  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("/   |");
                Console.WriteLine("   ===");
            }

            else if (wrong == 6)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" 0   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("   ===");
            }
        }

        private static int printWord(List<char> guessedLetters, String randomWord) // Вывод виселичного слова(т.е. выводятся не все буквы из слова,
                                                                                   // а только те, которые пользователь уже успел отгадать
                                                                                   // список уже угаданных букв | само рандомное слово

        {
            int counter = 0; // счётчик
            int rightLetters = 0; // счётчик правильно введённых букв
            Console.Write("\r\n"); // аналог enter

            foreach (char c in randomWord) // цикл работает, пока в рандомном слове не закончатся символы
            {
                if (guessedLetters.Contains(c)) // если введённый пользователем символ, есть в списке угаданных букв
                {
                    Console.Write(c + " "); // буквы выводятся через пробел
                    rightLetters++; // нужно для хэппи-энда
                }

                else
                {
                    Console.Write("  "); // иначе выводятся просто двойные пробелы
                }

                counter++; // счётчик увеличивается в любом случае,
                           // после каждой итерации цикла
            }

            return rightLetters;

        }

        private static void printLines(String randomWord) // печать пунктирных линий
                                                          // под самим "виселичным" словом
        {
            Console.Write("\r"); // аналог enter 

            foreach (char c in randomWord)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode; // внедрение юникод-библиотеки через консоль
                Console.Write("\u0305 "); // символ надчёркиваемой линии из юникода
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в виселицу, лучшую игру для начала следующего семестра!"); // мои типичные описания
            Console.WriteLine("-------------------------------------------------------------------------");// символьный разделитель

            Random random = new Random(); // внедрение функции рандома
            List<String> wordDictionary = new List<String> { "капуста", "драгович", "кравченко", "штайнер" }; // инициализация списка слов, которые будут использоваться во время игры в качестве загаданных

            int index = random.Next(wordDictionary.Count); // Это переменная будет использована ниже, чтобы рандомно выбрать одно слово из списка, созданного выше
            String randomWord = wordDictionary[index]; // тут мы создаём переменную, значением которой будет являться слово из списка выше.

            foreach (char x in randomWord) // эти линии выводятся в самом начале игры
            {
                Console.Write("_ ");
            }

            int lengthOfWordToGuess = randomWord.Length; // длина отгадываемого слова (измеряемая по кол-ву букв), будет измеряться при помощи .Length.
            int amountOfTimesWrong = 0; // Количество неверных попыток(это для функции(printHangman), в которой выводится пошагово повешенный человечек(при помощи int wrong)).
                                        // По сути, это инициализированная готовая переменная, которую можно вставить в то место функции(printHangman),
                                        // где изначально был записан безликий int wrong.

            List<char> currentLettersGuessed = new List<char>(); // инициализируем лист уже введённых из алфавита пользователем букв
            int currentLettersRight = 0; // кол-во угаданных пользователем букв

            while (amountOfTimesWrong != 6 && currentLettersRight != lengthOfWordToGuess)
            {
                Console.Write("\nБуквы, которые вы уже успели попробовать ввести:"); // мои типичные описания

                foreach (char letter in currentLettersGuessed)
                {
                    Console.Write(letter + " "); // Вывод введённых пользователем букв
                }


                Console.Write("\nВведите букву: "); // Предложение ввести пользователю букву
                char letterGuessed = Console.ReadLine()[0];


                if (currentLettersGuessed.Contains(letterGuessed)) // Проверить, ввёл ли пользователь данную букву до этого
                {
                    Console.Write("\r\nВы уже вводили эту букву ранее");
                    printHangman(amountOfTimesWrong);
                    currentLettersRight = printWord(currentLettersGuessed, randomWord);
                    printLines(randomWord);
                }

                else
                {
                    bool right = false; // Проверка того, есть ли введённая буква в самом слове.

                    for (int i = 0; i < randomWord.Length; i++)
                    {
                        if (letterGuessed == randomWord[i])
                        {
                            right = true;
                        }
                    }

                    if (right)
                    {
                        printHangman(amountOfTimesWrong);
                        currentLettersGuessed.Add(letterGuessed);
                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }

                    else
                    {
                        amountOfTimesWrong++;
                        currentLettersGuessed.Add(letterGuessed);
                        printHangman(amountOfTimesWrong);
                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }

                }
            }

            // мои типичные описания конца игры

            if (amountOfTimesWrong != 6)
            {
                Console.WriteLine("\r\nИгра окончена! Спасибо, что не повесили нашего человечка!)");
            }


            else
            {
                Console.WriteLine("\r\nВы повесили нашего человечка(((((((");
            }
        }
    }
}
