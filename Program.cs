namespace lab4
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
        static int answer()
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
                    BdCmpl();
                    Console.WriteLine("Ошибка! Такого пункта меню не существует.");
                    RstClr();
                }
            } while (!isConvert);
            return number;
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
                    BdCmpl();
                    Console.WriteLine("Ошибка! Повторите ввод.\n");
                    RstClr();
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
                    BdCmpl();
                    Console.WriteLine("Ошибка! Повторите ввод.\n");
                    RstClr();
                }
            } while (!isConvert);
            return index;
        }
        static void NrmCmpl() // функция чисто для удобства написания создана
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        static void BdCmpl() // функция чисто для удобства написания создана
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        static void RstClr() // функция чисто для удобства написания создана
        {
            Console.ResetColor();
        }
        /// <summary>
        /// Функция сортировки
        /// </summary>
        /// <param name="array"></param>
        /// <param name="lenght"></param>
        /// <returns>Функция возвращает отсортированный массив</returns>
        static int[] ArraySort(int[] array, int length)
        {
            int  g, lmnt;
            for (int i = 1; i < length; i++)
            {
                lmnt = array[i];
                g = i - 1;
                while (g >= 0 && lmnt < array[g])
                {
                    array[g + 1] = array[g];
                    g--;
                }
                array[g + 1] = lmnt;

            }
            return array;
        }
        /// <summary>
        /// Функция поиска элемента по заданному ключу
        /// </summary>
        /// <param name="array"></param>
        /// <param name="lenght"></param>
        static void Finder(int[] array, int length)
        {
            Console.WriteLine("Введите значение, которое будет искаться в массиве");
            int k = GetNumber();
            int numOfFinds = 0;
            int succesFinds = 0;
            for (int i = 0; i < length; i++)
            {
                numOfFinds++;
                if (array[i] == k)
                {
                    NrmCmpl();
                    Console.WriteLine($"Значение {k} найдено в массиве. Для этого потребовалось {numOfFinds} сравнений");
                    RstClr();
                    succesFinds++;
                    break;
                }
            }
            Console.WriteLine();
            if (succesFinds == 0)
            {
                Console.Clear();
                BdCmpl();
                Console.WriteLine($"Значение {k} не было найдено в массиве\n");
                RstClr();
            }
        }
        /// <summary>
        /// Функция быстрой сортировки
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="first"></param>
        /// <param name="last"></param>
        static void QuickSort(int[] arr, int first, int last)
        {
            int p = arr[(last - first) / 2 + first]; //Берём за опорный элемент средний в массиве
            int temp;
            int i = first, j = last;
            while (i <= j)
            {
                while (arr[i] < p && i <= last) ++i; //Ищем элементы, которые меньше опорного. Если находим, увеличиваем предполагаемое начало диапазона нахождения опорного
                while (arr[j] > p && j >= first) --j; //Ищем элементы, которые больше опорного. Если находим, уменьшаем предполагаемый конец диапазона индекса опорного
                if (i <= j) //если диапазон не уменьшился до -1
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    ++i; --j; //меняем местами элменты массива, уменьшаем диапазон
                }
            }
            if (j > first) QuickSort(arr, first, j);
            if (i < last) QuickSort(arr, i, last);
        }
        /// <summary>
        /// Функция бинарного поиска
        /// </summary>
        /// <param name="array"></param>
        /// <param name="k"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="finds"></param>
        /// <returns>Функция возвращает количество сравнений, потребовавшихся для поиска заданного элемента </returns>
        public static object BinaryFinder(int[] array, int k, int min, int max, int finds)
        {
            if (min > max)
            {
                return "0";
            }
            else
            {
                int mid = (min + max) / 2;
                if (k == array[mid])
                {
                    ++mid;
                    return ++finds;

                }
                else if (k < array[mid])
                {
                    ++finds;
                    return BinaryFinder(array, k, min, mid - 1,finds);
                    
                }
                else
                {
                    finds += 1;
                    return BinaryFinder(array, k, mid + 1, max, finds);
                }
            }
        }
        static void Main(string[] args)
        {
            int ans;
            int[] array = new int[0];
            int length = 0;
            do
            {
                Console.WriteLine("1.Сформировать массив заданной длины из случайных чисел");
                Console.WriteLine("2.Сформировать массив из заданных Вами чисел");
                Console.WriteLine("3.Вывести массив на экран");
                Console.WriteLine("4.Удалить из массива элементы с чётными индексами");
                Console.WriteLine("5.Добавить в массив указанные Вами элементы");
                Console.WriteLine("6.Перевернуть массив");
                Console.WriteLine("7.Выполнить поиск указанных в массиве элементов и подсчитать количество сравнений, необходимых для поиска нужного элемента.");
                Console.WriteLine("8.Выполнить сортировку массива с помощью простого включения");
                Console.WriteLine("9.Выполнить бинарный поиск указанного Вами элемента, посчитать количество сравнений, необходимых для поиска.");
                Console.WriteLine("10.Очистить консоль");
                Console.WriteLine("11.Быстрая сортировка");
                Console.WriteLine("12.Выход\n");
                ans = answer();
                switch (ans)
                {
                    case 1:
                        {
                            length = ArrLength();
                            array = new int[length];
                            for (int i = 0; i < length; i++)
                            {
                                Random rnd = new Random();
                                int value = rnd.Next(1, 100);
                                array[i] = value;
                            }
                            Console.Clear();
                            NrmCmpl();
                            Console.WriteLine($"Массив успешно сформирован из {length} элементов\n");
                            RstClr();
                            break;
                        }
                    case 2:
                        {
                            length = ArrLength();
                            array = new int[length];
                            for (int i = 0; i < length; i++)
                            {
                                Console.WriteLine($"Введите целочисленный элемент массива номер {i + 1}");
                                array[i] = GetNumber();
                            }
                            Console.Clear();
                            NrmCmpl();
                            Console.WriteLine($"Массив успешно сформирован из {length} элементов\n");
                            RstClr();
                            break;
                        }
                    case 3:
                        {
                            if (length == 0)
                            {
                                BdCmpl();
                                Console.WriteLine("\nМассив пуст. Попробуйте пункты 1 и 2 \n");
                                RstClr();
                            }
                            else
                            {
                                NrmCmpl();
                                Console.WriteLine("\nПолученный массив: [{0}] \n", string.Join(", ", array));
                                RstClr();
                            }
                            break;
                        }
                    case 4:
                        {
                            int count = 0;
                            if (length == 0)
                            {   
                                BdCmpl();
                                Console.WriteLine("Массив пуст. Попробуйте пункты 1 и 2 \n");
                                RstClr();
                            }
                            else if (length == 1)
                            {
                                BdCmpl();
                                Console.WriteLine( );
                                RstClr();
                            }
                            else
                            {
                                for (int i = 0; i < length; i++)
                                {
                                    if (i % 2 == 1)
                                    {
                                        count++;
                                    }
                                }
                                int[] arrayNew = new int[length - count];
                                int z = 0;
                                for (int k = 0; k < length; k++)
                                {
                                    if (k%2==0)
                                    {
                                        arrayNew[z] = array[k];
                                        z++;
                                    }
                                }
                                array = arrayNew;
                                length = array.Length;
                                NrmCmpl();
                                Console.WriteLine("Элементы с чётными индексами успешно удалены\n");
                                RstClr();
                            }
                            break;
                        }
                    case 5:
                        {
                            int nNumber = 0, kNumber = 0;
                            Console.WriteLine("Введите количество элементов, которые должны быть добавлены");
                            nNumber = GetNumber();
                            while (nNumber<1)
                            {
                                BdCmpl();
                                Console.WriteLine("Нельзя добавить неположительное количество элементов.\nПовторите ввод.");
                                RstClr();
                                nNumber = GetNumber();
                            }
                            if (nNumber == 0)
                            {
                                Console.Clear();
                                BdCmpl();
                                Console.WriteLine("Массив остаётся прежним. Ни один элемент не подлежит добавлению.\n");
                                RstClr();
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
                            if (kNumber > length + 1 || kNumber < 1)
                            {
                                do
                                {
                                    BdCmpl();
                                    Console.WriteLine("\nВведите индекс ещё раз. Индекс не соответствует размеру массива.");
                                    RstClr();
                                    kNumber = GetIndex();
                                } while (kNumber > length+1 || kNumber < 1);
                            }
                            int[] newArray = new int[length + nNumber];
                            for (int i = kNumber-1 ; i < nNumber + kNumber - 1; i++)
                            {
                                Console.WriteLine($"Введите целочисленный элемент массива номер {i+1}");
                                newArray[i] = GetNumber();
                            }
                            int j = 0;
                            for (int z = 0; z < kNumber-1; z++)
                            {
                                newArray[z] = array[j++];
                            }
                            for (int z = kNumber + nNumber -1; z < length + nNumber; z++)
                            {
                                newArray[z] = array[j++];
                            }
                            array = newArray;
                            length = array.Length;  
                            NrmCmpl();
                            Console.WriteLine("Массив успешно преобразован");
                            RstClr();
                            break;
                        }
                    case 6:
                        {
                            if (length == 0)
                            {
                                Console.WriteLine("Массив пуст. Попробуйте пункты 1 и 2\n");
                            }
                            else if (length % 2 == 0)
                            {
                                for (int i = 0, z = length - 1; i < length / 2 && z > length / 2 - 1; i++, z--)
                                {
                                    int tempo = array[i];
                                    array[i] = array[z];
                                    array[z] = tempo;
                                }
                                NrmCmpl();
                                Console.WriteLine("Массив успешно перевёрнут");
                                RstClr();       
                            }
                            else if (length % 2 == 1)
                            {
                                for (int i = 0, z = length - 1; i <= length / 2 && z > length / 2; i++, z--)
                                {
                                    int tempo;
                                    tempo = array[i];
                                    array[i] = array[z];
                                    array[z] = tempo;
                                }
                                NrmCmpl();
                                Console.WriteLine("Массив успешно перевёрнут");
                                RstClr();
                            }
                            break;
                        }
                    case 7:
                        {
                            Finder(array, length);
                            break;
                        }
                    case 8:
                        {
                            if (length == 0)
                            {
                                BdCmpl();
                                Console.WriteLine("Массив невозможно отсортировать, так как в нём нет элементов. Попробуйте пункты 1 и 2.\n");
                                RstClr();
                            }
                            else
                            {
                                ArraySort(array, length);
                                NrmCmpl();
                                Console.WriteLine("Массив успешно отсортирован\n");
                                RstClr();
                            }
                            break;
                        }
                    case 9:
                        {
                            ArraySort(array, length);
                            Console.WriteLine("Введите значение, которое будет искаться в масссиве");
                            int k = GetNumber();
                            if (BinaryFinder(array, k,0,length-1,0) == "0")
                            {
                                BdCmpl();
                                Console.WriteLine("Данное число не найдено в массиве\n");
                                RstClr();
                            }
                            else
                            {
                                NrmCmpl();
                                Console.WriteLine($"Для поиска потребовалось {BinaryFinder(array, k,0, length - 1,0)} сравнений\n");
                                RstClr();
                            }
                            break;
                        }
                    case 10:
                        {
                            Console.Clear();
                            NrmCmpl();
                            Console.WriteLine("Консоль очищена\n");
                            RstClr();
                            break;
                        }
                    case 11:
                        {
                            QuickSort(array, 0, length-1);
                            NrmCmpl();
                            Console.WriteLine("Массив успешно отсортирован\n");
                            RstClr();
                            break;
                        }
                    case 12:
                        {
                            Console.Clear();
                            Console.WriteLine("Вы уверены, что хотите завершить работу?");
                            Console.WriteLine("1.Да"); 
                            Console.WriteLine("2.Нет");
                            do
                            {
                                ans = answer();
                                switch (ans)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            NrmCmpl();
                                            Console.WriteLine("Программа завершена");
                                            RstClr();
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
                                            BdCmpl();
                                            Console.WriteLine("Нет такого пункта меню.\nПовторите попытку ввода.");
                                            RstClr();
                                            break;
                                        }
                                }
                            } while (ans != 2);
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            BdCmpl();
                            Console.WriteLine("Такого пункта меню не существует. Повторите попытку ввода.\n");
                            RstClr();
                            break;
                        }
                }
            } while (true);
        }
    }
}