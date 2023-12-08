using Microsoft.VisualBasic;
using System.Collections.Concurrent;
using System.Text;

namespace lab5
{
    internal class Program
    {
        /// <summary>
        /// Функция возвращения длины массива
        /// </summary>
        /// <returns>Функция возвращает длину массива, вводимую пользователем</returns>
        static int ArrLength()
        {
            int length;
            string inputStr;
            bool isConvert;
            do
            {
                Console.WriteLine("Введите целое неотрицательное число - длину массива.");
                inputStr = Console.ReadLine();
                Console.WriteLine();
                isConvert = int.TryParse(inputStr, out length);
                if (!isConvert || length < 0)
                    Console.WriteLine("Ошибка! Повторите ввод.\n");
            } while (!isConvert || length < 0);
            return length;
        }
        /// <summary>
        /// Функция возвращения номера пункта меню
        /// </summary>
        /// <returns>Функция возвращает номер пункта меню, вводимый пользователем с клавиатуры</returns>
        static int Answer()
        {
            int number;
            string inputStr;
            bool isConvert;
            do
            {
                Console.WriteLine("Введите выбранный Вами номер пункта меню.");
                inputStr = Console.ReadLine();
                Console.WriteLine();
                isConvert = int.TryParse(inputStr, out number);
                if (!isConvert)
                {
                    BdCmplt("Ошибка! Такого пункта меню не существует.");
                }
            } while (!isConvert);
            return number;
        }
        /// <summary>
        /// Функция возвращения индекса
        /// </summary>
        /// <returns>Функция возвращает индекс искомого элемента, запрашиваемый пользователем</returns>
        static int GetIndex()
        {
            int index;
            string inputStr;
            bool isConvert;
            do
            {
                inputStr = Console.ReadLine();
                Console.WriteLine();
                isConvert = int.TryParse(inputStr, out index);
                if (!isConvert || index < 0)
                {
                    BdCmplt("Ошибка! Повторите ввод.\n");
                }
            } while (!isConvert);
            return index;
        }
        /// <summary>
        /// Функция возвращения числа
        /// </summary>
        /// <returns>Функция возвращает число, вводимое пользователем с клавиатуры</returns>
        static int GetNumber()
        {
            int number;
            string inputStr;
            bool isConvert;
            do
            {
                inputStr = Console.ReadLine();
                Console.WriteLine();
                isConvert = int.TryParse(inputStr, out number);
                if (!isConvert)
                {
                    BdCmplt("Ошибка! Повторите ввод.\n");
                }
            } while (!isConvert);
            return number;
        }
        static void PrintArray(int[] array)
        {
            if (array.Length == 0)
            {
                BdCmplt("Массив пуст\n");
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Полученный массив: [{0}] \n", string.Join(", ", array));
                Console.ResetColor();
            }
        }
        static void PrintArray(int[,] array)
        {
            if (array.Length == 0)
            {
                BdCmplt("Массив пуст\n");
            }
            else 
            {
                StringBuilder sb = new StringBuilder("Полученный массив\n");
                for (int w = 0; w < array.GetLength(0); w += 1)
                {
                    for (int e = 0; e < array.GetLength(1); e += 1)
                        sb.Append(array[w, e] + " ");
                    sb.Append("\n");
                }
                string str = sb.ToString();
                GdCmplt(str);
            }
        }
        static void PrintArray(int[][] array)
        {
            if (array.Length==0)
            {
                BdCmplt("Массив пуст\n");
            }
            else
            {
                StringBuilder sb = new StringBuilder("Полученный массив\n");
                for (int i = 0; i < array.Length; i++)
                {
                    sb.Append("[");
                    int g = 0;
                    for (int j = 0; j < array[i].Length-1; j++)
                    {
                        sb.Append(array[i][j] + " ");
                        g++;
                    }
                    sb.Append(array[i][g]);
                    sb.Append("]");
                    sb.Append("\n");
                }
                string str = sb.ToString();
                GdCmplt(str);
            }
        }
        static int[] AddLmnts(ref int[] array)
        {
            int nNumber = 0, kNumber = 0;
            Console.WriteLine("Введите количество элементов, которые должны быть добавлены");
            nNumber = GetNumber();
            while (nNumber < 1)
            {
                BdCmplt("Нельзя добавить неположительное количество элементов.\nПовторите ввод.");
                nNumber = GetNumber();
            }
            if (nNumber == 0)
            {
                Console.Clear();
                BdCmplt("Массив остаётся прежним. Ни один элемент не подлежит добавлению.\n");
            }
            else if (nNumber == 1)
            {
                Console.WriteLine($"Введите номер элемента, начиная с которого будет добавлен {nNumber} последующий");
                kNumber = GetIndex();
            }
            else
            {
                Console.WriteLine($"Введите номер элемента, начиная с которого будут добавлены {nNumber} последующих");
                kNumber = GetIndex();

            }
            if (kNumber > array.Length + 1 || kNumber < 1)
            {
                do
                {
                    BdCmplt("\nВведите индекс ещё раз. Индекс не соответствует размеру массива.");
                    kNumber = GetIndex();
                } while (kNumber > array.Length + 1 || kNumber < 1);
            }
            int[] newArray = new int[array.Length + nNumber];
            for (int i = kNumber - 1; i < nNumber + kNumber - 1; i++) //этим циклом добавляем в массив элементы, вводимые пользователем
            {
                Console.WriteLine($"Введите целочисленный элемент массива номер {i + 1}");
                newArray[i] = GetNumber();
            }
            int j = 0;
            for (int z = 0; z < kNumber - 1; z++) //этим циклом добавляем в массив элементы, которые стоят на позициях до вводимых
            {
                newArray[z] = array[j++];
            }
            for (int z = kNumber + nNumber - 1; z < array.Length + nNumber; z++) //этим циклом добавляем в массив элементы, которые стоят на позициях после вводимых
            {
                newArray[z] = array[j++];
            }
            array = newArray;
            return array;

        }
        static int[] AddRndLmnts(ref int[] array)
        {
            Console.Clear();
            int length = ArrLength();
            array = new int[length];
            for (int i = 0; i < length; i++)
            {
                Random rnd = new Random();
                int value = rnd.Next(1, 100);
                array[i] = value;
            }
            return array;
        }
        static int[,] AddRndLmnts(ref int[,] array)
        {
            Console.Clear();
            Console.WriteLine("Введите целое неотрицательное число - количество столбцов");
            int columns = GetNumber();
            while (columns < 0)
            {
                BdCmplt("Количество столбцов не может быть меньше 0");
                BdCmplt("Повторите ввод");
                columns = GetNumber();
            }
            if (columns == 0)
            {
                return array;
            }
            else
            {
                Console.WriteLine("Введите целое неотрицательное число - количество строк");
                int strings = GetNumber();
                while (strings < 0)
                {
                    BdCmplt("Количество строк не может быть меньше 0");
                    BdCmplt("Повторите ввод");
                    strings = GetNumber();
                }
                array = new int[strings, columns];
                int i, j;
                for (i = 0; i < strings; i++)
                {
                    for (j = 0; j < columns; j++)
                    {
                        Random rnd = new Random();
                        array[i, j] = rnd.Next(1, 100);
                    }
                }
                return array;
            }
        }
        static int[][] AddRndLmnts(ref int[][] array)
        {
            Console.Clear();
            Console.WriteLine("Введите целое неотрицательное число - количество строк");
            int strings = GetNumber();
            while (strings < 0)
            {
                BdCmplt("Количество строк не может быть меньше 0");
                BdCmplt("Повторите ввод");
                strings = GetNumber();
            }
            array = new int[strings][];
            if (strings == 0)
            {
              return array;
            }
            else 
            {
                for (int i = 0; i < strings; i++)
                {

                    Console.WriteLine($"Введите количество столбцов строки {i + 1}");
                    int columns = GetNumber();
                    while (columns < 1)
                    {
                        BdCmplt("Количество столбцов не может быть меньше 1");
                        BdCmplt("Повторите ввод");
                        columns = GetNumber();
                    }
                    array[i] = new int[columns];
                    for (int j = 0; j < columns; j++)
                    {
                        Random rnd = new Random();
                        array[i][j] = rnd.Next(0, 100);
                    }
                }
                return array;
            }
        }
        static int[] ManualAddLmnts(ref int[] array)
        {
            Console.Clear();
            int length = ArrLength();
            if (length == 0)
            {
                return array;
            }
            else
            {
                array = new int[length];
                for (int i = 0; i < length; i++)
                {
                    Console.WriteLine($"Введите элемент номер {i + 1}");
                    int value = GetNumber();
                    array[i] = value;
                }
                return array;
            }
        }
        static int[,] ManualAddLmnts(ref int[,] array)
        {
            Console.Clear();
            Console.WriteLine("Введите целое неотрицательное число - количество столбцов");
            int columns = GetNumber();
            while (columns < 0)
            {
                BdCmplt("Количество столбцов не может быть меньше 0");
                BdCmplt("Повторите ввод");
                columns = GetNumber();
            }
            if (columns==0)
            {
                return array;
            }
            else
            {
                Console.WriteLine("Введите целое неотрицательное число - количество строк");
                int strings = GetNumber();
                while (strings < 1)
                {
                    BdCmplt("Количество строк не может быть меньше 1");
                    BdCmplt("Повторите ввод");
                    strings = GetNumber();
                }
                array = new int[strings, columns];
                int i, j;
                for (i = 0; i < strings; i++)
                {
                    for (j = 0; j < columns; j++)
                    {
                        Console.WriteLine($"Введите элемент [{i + 1},{j + 1}]");
                        array[i, j] = GetNumber();
                    }
                }
                return array;
            }
        }
        static int[][] ManualAddLmnts(ref int[][] array)
        {
            Console.Clear();
            Console.WriteLine("Введите целое неотрицательное число - количество строк");
            int strings = GetNumber();
            while (strings < 0)
            {
                BdCmplt("Количество строк не может быть меньше 0");
                BdCmplt("Повторите ввод");
                strings = GetNumber();
            }
            if (strings == 0)
            {
                int[][] jagArr = new int[strings][];
                return jagArr;
            }
            else
            {
                array = new int[strings][];
                for (int i = 0; i < strings; i++)
                {

                    Console.WriteLine($"Введите количество столбцов строки {i + 1}");
                    int columns = GetNumber();
                    while (columns < 1)
                    {
                        BdCmplt("Количество столбцов не может быть меньше 1");
                        BdCmplt("Повторите ввод");
                        columns = GetNumber();
                    }
                    array[i] = new int[columns];
                    for (int j = 0; j < columns; j++)
                    {
                        Console.WriteLine($"Введите элемент [{i + 1}][{j + 1}]");
                        int value = GetNumber();
                        array[i][j] = value;
                    }
                }
                return array;
            }
        }
        static int[,] DelEvenStr(ref int[,] array) 
        {
            if (array.Length == 0)
            {
                return array;
            }
            else
            {
                int count = 0;
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    if (i % 2 == 0 || i == 0)
                    {
                        count++;
                    }
                }
                int[,] arrayNew = new int[count, array.GetLength(1)];
                int rowsTmp = 0;
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    if (i == 0 || i % 2 == 0)
                    {
                        for (int j = 0; j < arrayNew.GetLength(1); j++)
                        {
                            arrayNew[rowsTmp, j] = array[i, j];
                        }
                        rowsTmp++;
                    }
                }
                return arrayNew;
            }
        }
        static int[][] ManualAddLastString(ref int[][]jagArr)
        {
            int strings = jagArr.GetLength(0);
            Array.Resize(ref jagArr, strings + 1);
            Console.WriteLine($"Введите количество столбцов строки {strings+1}");
            int columns = GetNumber();
            while (columns < 1)
            {
                BdCmplt("Количество столбцов не может быть меньше 1");
                BdCmplt("Повторите ввод");
                columns = GetNumber();
            }
            jagArr[^1] = new int[columns];
            for (int j = 0; j < columns; j++)
            {
                Console.WriteLine($"Введите число {j+1}");
                jagArr[strings][j] = GetNumber();
            }
            return jagArr;
        }
        static int[][] AutoAddLastString(ref int[][]jagArr) 
        {
            int strings = jagArr.GetLength(0);
            Array.Resize(ref jagArr, strings+1);
            Console.WriteLine($"Введите количество столбцов строки {strings + 1}");
            int columns = GetNumber();
            while (columns < 1)
            {
                BdCmplt("Количество столбцов не может быть меньше 1");
                BdCmplt("Повторите ввод");
                columns = GetNumber();
            }
            jagArr[strings] = new int[columns];
            for (int j = 0; j < columns; j++)
            {
                Random rnd = new Random();
                jagArr[strings][j] = rnd.Next(0, 100);
            }
            return jagArr;
        }
        /// <summary>
        /// Функция изменения цвета текста при успешном выполнении
        /// </summary>
        /// <param name="str"></param>
        static void GdCmplt(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ResetColor();
        }
        /// <summary>
        /// Функция изменения цвета текста при неуспешном выполнении
        /// </summary>
        /// <param name="str"></param>
        static void BdCmplt(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.ResetColor();
        }
        static void MainMenu()
        {
            Title("╔╦╗╔═╗╦╔╗╔  ╔╦╗╔═╗╔╗╔╦ ╦\r\n║║║╠═╣║║║║  ║║║║╣ ║║║║ ║\r\n╩ ╩╩ ╩╩╝╚╝  ╩ ╩╚═╝╝╚╝╚═╝");
            Console.WriteLine("1.Работа с одномерными массивами");
            Console.WriteLine("2.Работа с двумерными массивами");
            Console.WriteLine("3.Работа с рваными массивами");
            Console.WriteLine("4.Выход\n");
        }
        static void Title(string str = "MENU")
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(str);
            Console.ResetColor();
        }
        static void OneDimensArrMenu()
        {
            Title("╦ ╦╔═╗╦═╗╦╔═  ╦ ╦╦╔╦╗╦ ╦  ╔═╗╔╗╔╔═╗ ╔╦╗╦╔╦╗╔═╗╔╗╔╔═╗╦╔═╗╔╗╔╔═╗╦    ╔═╗╦═╗╦═╗╔═╗╦ ╦\r\n║║║║ ║╠╦╝╠╩╗  ║║║║ ║ ╠═╣  ║ ║║║║║╣───║║║║║║║╣ ║║║╚═╗║║ ║║║║╠═╣║    ╠═╣╠╦╝╠╦╝╠═╣╚╦╝\r\n╚╩╝╚═╝╩╚═╩ ╩  ╚╩╝╩ ╩ ╩ ╩  ╚═╝╝╚╝╚═╝ ═╩╝╩╩ ╩╚═╝╝╚╝╚═╝╩╚═╝╝╚╝╩ ╩╩═╝  ╩ ╩╩╚═╩╚═╩ ╩ ╩ ");
            Console.WriteLine("1.Сформировать динамический одномерный массив, заполнить его указанным способом и вывести на печать");
            Console.WriteLine("2.Добавить К элементов, начиная с номера N");
            Console.WriteLine("3.Очистить консоль");
            Console.WriteLine("4.Выйти из подменю\n");
        }
        static void TwoDimensArrMenu()
        {
            Title("╦ ╦╔═╗╦═╗╦╔═  ╦ ╦╦╔╦╗╦ ╦  ╔╦╗╦ ╦╔═╗  ╔╦╗╦╔╦╗╔═╗╔╗╔╔═╗╦╔═╗╔╗╔╔═╗╦    ╔═╗╦═╗╦═╗╔═╗╦ ╦\r\n║║║║ ║╠╦╝╠╩╗  ║║║║ ║ ╠═╣   ║ ║║║║ ║───║║║║║║║╣ ║║║╚═╗║║ ║║║║╠═╣║    ╠═╣╠╦╝╠╦╝╠═╣╚╦╝\r\n╚╩╝╚═╝╩╚═╩ ╩  ╚╩╝╩ ╩ ╩ ╩   ╩ ╚╩╝╚═╝  ═╩╝╩╩ ╩╚═╝╝╚╝╚═╝╩╚═╝╝╚╝╩ ╩╩═╝  ╩ ╩╩╚═╩╚═╩ ╩ ╩ ");
            Console.WriteLine("1.Сформировать динамический двумерный массив, заполнить его заполнить его указанным способом и вывести на печать");
            Console.WriteLine("2.Удалить все чётные строки");
            Console.WriteLine("3.Очистить консоль");
            Console.WriteLine("4.Выйти из подменю\n");
        }
        static void JagArrMenu()
        {
            Title("╦ ╦╔═╗╦═╗╦╔═  ╦ ╦╦╔╦╗╦ ╦   ╦╔═╗╔═╗╔═╗╔═╗╔╦╗  ╔═╗╦═╗╦═╗╔═╗╦ ╦\r\n║║║║ ║╠╦╝╠╩╗  ║║║║ ║ ╠═╣   ║╠═╣║ ╦║ ╦║╣  ║║  ╠═╣╠╦╝╠╦╝╠═╣╚╦╝\r\n╚╩╝╚═╝╩╚═╩ ╩  ╚╩╝╩ ╩ ╩ ╩  ╚╝╩ ╩╚═╝╚═╝╚═╝═╩╝  ╩ ╩╩╚═╩╚═╩ ╩ ╩ ");
            Console.WriteLine("1.Сформировать динамический рваный массив, заполнить его заполнить его указанным способом и вывести на печать");
            Console.WriteLine("2.Добавить строку в конец массива");
            Console.WriteLine("3.Очистить консоль");
            Console.WriteLine("4.Выйти из подменю\n");
        }
        static void ExitMenu()
        {
            Console.Clear();
            Console.WriteLine("Вы уверены, что хотите завершить работу?");
            Console.WriteLine("1.Да");
            Console.WriteLine("2.Нет");
        }
        static void InputSelectMenu()
        {
            Title("╦╔╗╔╔═╗╦ ╦╔╦╗  ╔═╗╔═╗╦  ╔═╗╔═╗╔╦╗╦╔═╗╔╗╔\r\n║║║║╠═╝║ ║ ║   ╚═╗║╣ ║  ║╣ ║   ║ ║║ ║║║║\r\n╩╝╚╝╩  ╚═╝ ╩   ╚═╝╚═╝╩═╝╚═╝╚═╝ ╩ ╩╚═╝╝╚╝");
            Console.WriteLine("1.Ввести элементы вручную");
            Console.WriteLine("2.Ввести рандомные числа");
            Console.WriteLine("3.Выйти из подменю");
        }
        static void Main(string[] args)
        {
            int ans;
            int[] oneDimensArr = new int[0];
            int[,] twoDimensArr = new int[0,0];
            int[][] jagArr = new int[0][];
            do
            {
                MainMenu();
                ans = Answer();
                switch (ans)
                {
                    case 1:
                        {
                            Console.Clear();
                            do
                            {
                                OneDimensArrMenu();
                                ans = Answer();
                                switch (ans)
                                {
                                    case 1:
                                        do
                                        {
                                            InputSelectMenu();
                                            ans = Answer();
                                            switch (ans)
                                            {
                                                case 1:
                                                    {
                                                        ManualAddLmnts(ref oneDimensArr);
                                                        PrintArray(oneDimensArr);
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        AddRndLmnts(ref oneDimensArr);
                                                        PrintArray(oneDimensArr);
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                default:
                                                    {
                                                        Console.Clear();
                                                        BdCmplt("Нет такого пункта меню.\nПовторите попытку ввода.");
                                                        break;
                                                    }
                                            }
                                        } while (ans != 3);
                                        break;
                                    case 2:
                                        {
                                            AddLmnts(ref oneDimensArr);
                                            PrintArray(oneDimensArr);
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                    default:
                                        {
                                            Console.Clear();
                                            BdCmplt("Нет такого пункта меню.\nПовторите попытку ввода.");
                                            break;
                                        }
                                }
                            } while (ans != 4);
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            do
                            {
                                TwoDimensArrMenu();
                                ans = Answer();
                                switch(ans)
                                {
                                    case 1:
                                        do
                                        {
                                            InputSelectMenu();
                                            ans = Answer();
                                            switch (ans)
                                            {
                                                case 1:
                                                    {
                                                        ManualAddLmnts(ref twoDimensArr);
                                                        PrintArray(twoDimensArr);
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        AddRndLmnts(ref twoDimensArr);
                                                        PrintArray(twoDimensArr);
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        Console.Clear();
                                                        break;
                                                    }
                                                default:
                                                    {
                                                        Console.Clear();
                                                        BdCmplt("Нет такого пункта меню.\nПовторите попытку ввода.");
                                                        break;
                                                    }
                                            }
                                        } while (ans != 3);
                                        break;
                                    case 2:
                                        {
                                            if (twoDimensArr.Length == 0)
                                                BdCmplt("Массив пуст. Нельзя удалить чётные строки.\n");
                                            else
                                            {
                                                DelEvenStr(ref twoDimensArr);
                                                PrintArray(twoDimensArr);
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                    default:
                                        {
                                            Console.Clear();    
                                            BdCmplt("Нет такого пункта меню.\nПовторите попытку ввода.");
                                            break;
                                        }
                                }
                            } while (ans != 4);
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            do
                            {
                                JagArrMenu();
                                ans = Answer();
                                switch (ans)
                                {
                                    case 1:
                                        {
                                            do
                                            {
                                                InputSelectMenu();
                                                ans = Answer();
                                                switch (ans)
                                                {
                                                    case 1:
                                                        {
                                                            ManualAddLmnts(ref jagArr);
                                                            PrintArray(jagArr);
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            AddRndLmnts(ref jagArr);
                                                            PrintArray(jagArr);
                                                            break;
                                                        }
                                                    case 3:
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                    default:
                                                        {
                                                            Console.Clear();
                                                            BdCmplt("Нет такого пункта меню.\nПовторите попытку ввода.");
                                                            break;
                                                        }
                                                }
                                            } while (ans != 3);
                                            break;
                                        }
                                    case 2:
                                        {
                                            do
                                            { 
                                                InputSelectMenu();
                                                ans = Answer();
                                                switch(ans)
                                                {
                                                    case 1:
                                                        {
                                                            ManualAddLastString(ref jagArr);
                                                            PrintArray(jagArr);
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            AutoAddLastString(ref jagArr);
                                                            PrintArray(jagArr);
                                                            break;
                                                        }
                                                    case 3:
                                                        {
                                                            Console.Clear();
                                                            break;
                                                        }
                                                    default:
                                                        {
                                                            Console.Clear();
                                                            BdCmplt("Нет такого пункта меню.\nПовторите попытку ввода.");
                                                            break;
                                                        }
                                                }
                                            } while (ans != 3);
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                    default:
                                        {
                                            Console.Clear();
                                            BdCmplt("Нет такого пункта меню.\nПовторите попытку ввода.");
                                            break;
                                        }
                                }
                            } while (ans != 4);
                            break;
                        }
                    case 4:
                        {
                            do
                            {
                                ExitMenu();
                                ans = Answer();
                                switch (ans)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            GdCmplt("Программа завершена");
                                            System.Environment.Exit(0);
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                    default:
                                        {
                                            Console.Clear();
                                            BdCmplt("Нет такого пункта меню.\nПовторите попытку ввода.");
                                            break;
                                        }
                                }
                            } while (ans != 2);
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            BdCmplt("Такого пункта меню не существует.\nПовторите попытку ввода.\n");
                            break;
                        }
                }
            } while (true);
        }
    }
}