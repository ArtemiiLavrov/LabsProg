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
                if (!isConvert || length < 0 || length > 2147483591)
                    BdCmplt("Ошибка! Повторите ввод.\n");
            } while (!isConvert || length < 0 || length > 2147483591);
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
                    BdCmplt("Ошибка! Такого пункта меню не существует.\n");
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
            int wholeLen = 0;
            for (int k = 0; k < array.Length; k++)
            {
                wholeLen += array[k].Length;
            }
            if (wholeLen==0)
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
                    if (array[i].Length==1)
                    {
                        for (int j = 0; j < array[i].Length; j++)
                        {
                            sb.Append(array[i][j]);
                        }
                    }
                    else
                    {
                        for (int j = 0; j < array[i].Length-1; j++)
                        {
                            sb.Append(array[i][j] + " ");
                            g++;
                        }
                    }
                    if (g == 0)
                    {
                        sb.Append("]\n");
                    }
                    
                    else
                    {
                        sb.Append(array[i][g]);
                        sb.Append("]");
                        sb.Append("\n");
                    }
                }
                string str = sb.ToString();
                GdCmplt(str);
            }
        }
        static int[] ManualAddNLmnts(ref int[] array)
        {
            int nNumber, kNumber = 0;
            double f = array.Length;
            Console.WriteLine("Введите количество элементов, которые должны быть добавлены");
            nNumber = GetNumber();
            while (nNumber < 0)
            {
                BdCmplt("Нельзя добавить отрицательное количество элементов.\nПовторите ввод.");
                nNumber = GetNumber();
            }
            while ((double) nNumber + f > 2147483591.0)
            {
                BdCmplt("Число элементов, которые будут в массиве после добавления, превышает допустимое\nПовторите ввод.");
                nNumber = GetNumber();
            }
            if (nNumber == 0)
            {
                Console.Clear();
                BdCmplt("Массив остаётся прежним. Ни один элемент не подлежит добавлению.\n");
                return array;
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
                int value = GetNumber();
                newArray[i] = value;
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
        static int[] AutoAddNLmnts(ref int[] array)
        {
            int nNumber, kNumber = 0;
            double f = array.Length;
            Console.WriteLine("Введите количество элементов, которые должны быть добавлены");
            nNumber = GetNumber();
            while (nNumber < 0)
            {
                BdCmplt("Нельзя добавить неположительное количество элементов.\nПовторите ввод.");
                nNumber = GetNumber();
            }
            while ((double)nNumber + f > 2147483591.0)
            {
                BdCmplt("Число элементов, которые будут в массиве после добавления, превышает допустимое\nПовторите ввод.");
                nNumber = GetNumber();
            }
            if (nNumber == 0)
            {
                Console.Clear();
                BdCmplt("Массив остаётся прежним. Ни один элемент не подлежит добавлению.\n");
                return array;
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
                Random rnd = new Random();
                int value = rnd.Next(0, 100);
                newArray[i] = value;
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
            while (columns > 2147483591)
            {
                BdCmplt("Количество столбцов слишком велико");
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
                double z = ((double)columns * (double)strings);
                while (strings < 0)
                {
                    BdCmplt("Количество строк не может быть меньше 0");
                    BdCmplt("Повторите ввод");
                    strings = GetNumber();
                    z = ((double)columns * (double)strings);
                }
                while (z > 2147483591.0)
                {
                    BdCmplt("Число элементов, которое вы хотите задать, слишком велико");
                    BdCmplt("Повторите ввод");
                    strings = GetNumber();
                    z = ((double)columns * (double)strings);
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
            while (strings > 2147483591)
            {
                BdCmplt("Число элементов, которое вы хотите задать, слишком велико. Попробуйте уменьшить его (<2147483592)");
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
                int k = 0;
                for (int i = 0; i < strings; i++)
                {
                    Console.WriteLine($"Введите количество столбцов строки {i + 1}");
                    int columns = GetNumber();
                    while (columns < 0)
                    {
                        BdCmplt("Количество столбцов не может быть меньше 1");
                        BdCmplt("Повторите ввод");
                        columns = GetNumber();
                    }
                    while (columns > 2147483591)
                    {
                        BdCmplt("Число элементов, которое вы хотите задать, слишком велико. Попробуйте уменьшить его (<2147483592)");
                        BdCmplt("Повторите ввод");
                        columns = GetNumber();
                    }
                    while(k > 2147483591)
                    {
                        BdCmplt($"Число элементов, которое вы хотите задать, слишком велико. Попробуйте уменьшить его\nВаше число элементов:{k}\nМаксимально допустимое число элементов: 2147483591\n Можно ввести элементов: {2147483591-k}");
                        BdCmplt("Повторите ввод");
                        columns = GetNumber();
                    }
                    k += columns;
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
            while (columns > 2147483591)
            {
                BdCmplt("Количество столбцов слишком велико");
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
                double z = ((double)columns * (double)strings);
                while (strings < 0)
                {
                    BdCmplt("Количество строк не может быть меньше 0");
                    BdCmplt("Повторите ввод");
                    strings = GetNumber();
                    z = ((double)columns * (double)strings);
                }
                while (z > 2147483591.0)
                {
                    BdCmplt("Число элементов, которое вы хотите задать, слишком велико");
                    BdCmplt("Повторите ввод");
                    strings = GetNumber();
                    z = ((double)columns * (double)strings);
                }
                array = new int[strings, columns];
                int i, j;
                for (i = 0; i < strings; i++)
                {
                    for (j = 0; j < columns; j++)
                    {
                        Console.WriteLine($"Введите элемент [{i + 1},{j + 1}]");
                        int value = GetNumber();
                        array[i, j] = value;
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
            while (strings > 2147483591)
            {
                BdCmplt("Число элементов, которое вы хотите задать, слишком велико. Попробуйте уменьшить его (<2147483592)");
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
                int k = 0;
                array = new int[strings][];
                for (int i = 0; i < strings; i++)
                {

                    Console.WriteLine($"Введите количество столбцов строки {i + 1}");
                    int columns = GetNumber();
                    while (columns < 0)
                    {
                        BdCmplt("Количество столбцов не может быть меньше 1");
                        BdCmplt("Повторите ввод");
                        columns = GetNumber();
                    }
                    while (columns > 2147483591)
                    {
                        BdCmplt("Число элементов, которое вы хотите задать, слишком велико. Попробуйте уменьшить его (<2147483592)");
                        BdCmplt("Повторите ввод");
                        columns = GetNumber();
                    }
                    while (k > 2147483591)
                    {
                        BdCmplt($"Число элементов, которое вы хотите задать, слишком велико. Попробуйте уменьшить его\nВаше число элементов:{k}\nМаксимально допустимое число элементов: 2147483591\n Можно ввести элементов: {2147483591 - k}");
                        BdCmplt("Повторите ввод");
                        columns = GetNumber();
                    }
                    k += columns;
                    array[i] = new int[columns];
                    for (int j = 0; j < columns; j++)
                    {
                        Console.WriteLine($"Введите элемент [{i + 1},{j + 1}]");
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
            else if (array.GetLength(0)==1)
            {
                BdCmplt("Не найдено ни одной чётной строки в массиве\nМассив остётся прежним.");
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
                array = arrayNew;
                return array;
            }
        }
        static int[][] ManualAddLastString(ref int[][]jagArr)
        {
            double z = 0;
            for (int g = 0; g < jagArr.GetLength(0); g++)
            {
                for (int j = 0; j < jagArr[g].Length; j++)
                {
                    z++;
                }
            }
            if (z < 2147483591.0)
            {
                int strings = jagArr.GetLength(0);
                Array.Resize(ref jagArr, strings + 1);
                Console.WriteLine($"Введите количество столбцов строки {strings + 1}");
                int columns = GetNumber();
                while (columns < 1)
                {
                    BdCmplt("Количество столбцов не может быть меньше 1");
                    BdCmplt("Повторите ввод");
                    columns = GetNumber();
                }
                while ((double)columns + z > 2147483591.0)
                {
                    BdCmplt("Число элементов, которое вы хотите ввести слишком большое.");
                    BdCmplt("Повторите ввод");
                    columns = GetNumber();
                    z = (double)jagArr.Length + (double)columns;
                }
                jagArr[strings] = new int[columns];
                for (int j = 0; j < columns; j++)
                {
                    Console.WriteLine($"Введите элемент [{strings + 1},{j + 1}]");
                    jagArr[strings][j] = GetNumber();
                }
                return jagArr;
            }
            else
            {
                BdCmplt("Массив слишком велик, в него нельзя добавить строку\n");
                return jagArr;
            }
        }
        static int[][] AutoAddLastString(ref int[][]jagArr) 
        {
            double z = 0;
            for (int g = 0; g< jagArr.GetLength(0); g++)
            {
                for (int j = 0;j < jagArr[g].Length; j++)
                {
                    z++;
                }
            }
            if (z < 2147483591.0)
            {
                int strings = jagArr.GetLength(0);
                Array.Resize(ref jagArr, strings + 1);
                Console.WriteLine($"Введите количество столбцов строки {strings + 1}");
                int columns = GetNumber();
                while (columns < 1)
                {
                    BdCmplt("Количество столбцов не может быть меньше 1");
                    BdCmplt("Повторите ввод");
                    columns = GetNumber();
                }
                while ((double)columns + z > 2147483591.0)
                {
                    BdCmplt("Число элементов, которое вы хотите ввести слишком большое.");
                    BdCmplt("Повторите ввод");
                    columns = GetNumber();
                    z = (double)jagArr.Length + (double)columns;
                }
                jagArr[strings] = new int[columns];
                for (int j = 0; j < columns; j++)
                {
                    Random rnd = new Random();
                    jagArr[strings][j] = rnd.Next(0, 100);
                }
                return jagArr;
            }
            else
            {
                BdCmplt("Массив слишком велик, в него нельзя добавить строку\n");
                return jagArr;
            }
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
                                            do
                                            {
                                                InputSelectMenu();
                                                ans = Answer();
                                                switch (ans)
                                                {
                                                    case 1:
                                                        {
                                                            ManualAddNLmnts(ref oneDimensArr);
                                                            PrintArray(oneDimensArr);
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            AutoAddNLmnts(ref oneDimensArr);
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
