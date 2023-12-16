using System;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab6._1
{
    internal class Program
    {
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
                    BdCmplt("Ошибка! Такого пункта меню не существует.\n \a");
                }
            } while (!isConvert);
            return number;
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
        static void Title(string str = "MENU")
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(str);
            Console.ResetColor();
        }
        static void MainMenu()
        {
            Title("╔╦╗╔═╗╦╔╗╔  ╔╦╗╔═╗╔╗╔╦ ╦\r\n║║║╠═╣║║║║  ║║║║╣ ║║║║ ║\r\n╩ ╩╩ ╩╩╝╚╝  ╩ ╩╚═╝╝╚╝╚═╝");
            Console.WriteLine("1.Работа со строками");
            Console.WriteLine("2.Выход\n");
        }
        static void StringMenu()
        {
            Title("╔═╗╔╦╗╦═╗╦╔╗╔╔═╗  ╔╦╗╔═╗╔╗╔╦ ╦\r\n╚═╗ ║ ╠╦╝║║║║║ ╦  ║║║║╣ ║║║║ ║\r\n╚═╝ ╩ ╩╚═╩╝╚╝╚═╝  ╩ ╩╚═╝╝╚╝╚═╝");
            Console.WriteLine("1.Удаление всех слов, начинающихся и оканчивающихся на одну и ту же букву (Демо-режим)");
            Console.WriteLine("2.Ввести строку и удалить из неё все слова, начинающиеся и оканчивающихся на одну и ту же букву");
            Console.WriteLine("3.Очистить консоль");
            Console.WriteLine("4.Выйти из подменю\n");
        }
        static void ExitMenu()
        {
            Console.WriteLine("Вы уверены, что хотите завершить работу?");
            Console.WriteLine("1.Да");
            Console.WriteLine("2.Нет");
        }
        static void InputSelectMenu()
        {
            Title("╦╔╗╔╔═╗╦ ╦╔╦╗  ╔═╗╔═╗╦  ╔═╗╔═╗╔╦╗╦╔═╗╔╗╔\r\n║║║║╠═╝║ ║ ║   ╚═╗║╣ ║  ║╣ ║   ║ ║║ ║║║║\r\n╩╝╚╝╩  ╚═╝ ╩   ╚═╝╚═╝╩═╝╚═╝╚═╝ ╩ ╩╚═╝╝╚╝");
            Console.WriteLine("1.Ввести предложение вручную");
            Console.WriteLine("2.Выбрать файл для обработки");
            Console.WriteLine("3.Выйти из подменю");
        }
        static bool SampleCorrect(ref string inputStr)
        {
            inputStr = inputStr.Replace(".", ".+").Replace("!", "!+").Replace("?", "?+");
            bool ok = true;
            StringBuilder sb = new StringBuilder();
            Regex sample = new Regex(@"^[А-Я][^.!?]*[.!?]$");
            string[] sentences = inputStr.Split("+");
            if (sentences[^1] == " " || sentences[^1] == "")
                Array.Resize(ref sentences, sentences.Length - 1);
            for (int i = 0; i < sentences.Length; i++)
            {
                string sentence = sentences[i].Trim();
                if (sample.IsMatch(sentence) != true)
                {
                    ok = false;
                }
            }
            if (ok)
                return true;
            else
                return false;
        }
        static bool IsEmptyStr(ref string inputStr)
        {
            bool normal = true;
            int count = 0;
            string test = inputStr.Replace(" ", "+");
            foreach (char ch in test)
            {
                if (ch == '+')
                    count++;
            }
            if (inputStr.Length == 0 || inputStr == null || inputStr.Contains("\t") || (count == inputStr.Length))
                normal = false;
            if (normal)
                return true;
            else
                return false;
        }
        static void RemoveWord(string text = "В траве сидел кузнечик! Кузнечик не трогал козявок и дружил с мухом.")
        {
            string textNew = text.Replace(",", " , ").Replace(";", " ; ").Replace(":", " : ").Replace(".", " . ").Replace("?", " ? ").Replace("!", " ! ").Trim();
            textNew = Regex.Replace(textNew, "\\s+", "+");
            string[] a = textNew.Split('+');
            int k = 0;
            int countDeletedWords = 0;
            string[] deletedWords = new string[0];
            foreach (string word in a)
            {
                if (word == "")
                    k++;
            }
            string[] tmp = new string[a.Length - k];
            for (int i = 0, j = 0; i < a.Length; i++)
            {
                if (a[i] != "")
                {
                    tmp[j] = a[i];
                    j++;
                }
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < tmp.Length; i++)
            {
                string low = tmp[i].ToLower();
                if (low[0] == low[^1] && tmp[i].Length != 1)
                {
                    string[] b = new string[tmp.Length - 1];
                    Array.Copy(tmp, 0, b, 0, i);
                    Array.Copy(tmp, i + 1, b, i, tmp.Length - i - 1);
                    countDeletedWords++;
                    Array.Resize(ref deletedWords, countDeletedWords);
                    deletedWords[countDeletedWords - 1] = tmp[i];
                }
                else
                    sb.Append(tmp[i] + " ");
            }
            string sbNew = sb.ToString().Replace(" ,", ",").Replace(" ;", ";").Replace(" :", ":").Replace(" .", ".").Replace(" ?", "?").Replace(" !", "!").Trim();
            text = text.Replace("+", "");
            GdCmplt($"Изначальная строка: {text}");
            GdCmplt($"Полученная строка: {sbNew}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Всего было удалено {countDeletedWords} слов: ");
            Console.WriteLine("{0} \n", string.Join(", ", deletedWords));
            Console.ResetColor();
        }
        static void RemoveWord(string[] strings)
        {
            bool isCorrect;
            bool isEmpty;
            foreach (string s in strings) 
            {
                string inputStr = s;
                isCorrect = (SampleCorrect(ref inputStr));
                isEmpty = IsEmptyStr(ref inputStr);
                if (isEmpty && isCorrect)
                {
                    string text = s;
                    string textNew = text.Replace(",", " , ").Replace(";", " ; ").Replace(":", " : ").Replace(".", " . ").Replace("?", " ? ").Replace("!", " ! ").Trim();
                    textNew = Regex.Replace(textNew, "\\s+", "+");
                    string[] a = textNew.Split('+');
                    int k = 0;
                    int countDeletedWords = 0;
                    string[] deletedWords = new string[0];
                    foreach (string word in a)
                    {
                        if (word == "")
                            k++;
                    }
                    string[] tmp = new string[a.Length - k];
                    for (int i = 0, j = 0; i < a.Length; i++)
                    {
                        if (a[i] != "")
                        {
                            tmp[j] = a[i];
                            j++;
                        }
                    }
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        string low = tmp[i].ToLower();
                        if (low[0] == low[^1] && tmp[i].Length != 1)
                        {
                            string[] b = new string[tmp.Length - 1];
                            Array.Copy(tmp, 0, b, 0, i);
                            Array.Copy(tmp, i + 1, b, i, tmp.Length - i - 1);
                            countDeletedWords++;
                            Array.Resize(ref deletedWords, countDeletedWords);
                            deletedWords[countDeletedWords - 1] = tmp[i];
                        }
                        else
                            sb.Append(tmp[i] + " ");
                    }
                    string sbNew = sb.ToString().Replace(" ,", ",").Replace(" ;", ";").Replace(" :", ":").Replace(" .", ".").Replace(" ?", "?").Replace(" !", "!").Replace("+","").Trim();
                    text = text.Replace("+", "");
                    if (deletedWords.Length > 0)
                    {
                        GdCmplt($"Изначальная строка: {text}");
                        GdCmplt($"Полученная строка: {sbNew}");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"Всего было удалено {countDeletedWords} слов: ");
                        Console.WriteLine("{0} \n", string.Join(", ", deletedWords));
                        Console.ResetColor();
                    }
                    else if (deletedWords.Length == 0)
                    {
                        GdCmplt($"В предложении \"{text}\" не найдено ни одного слова для удаления.\n");
                    }
                }
                else if (!isCorrect) 
                {
                    inputStr = inputStr.Replace("+", "");
                    BdCmplt($"Предложение \"{inputStr}\" введено некорректно\n \a");
                }
            }
        }
        static string GetStringFromConsole()
        {
            string inputStr;
            bool isCorrect, isEmpty;
            do
            {
                Console.WriteLine("Введите предложение:");
                inputStr = Console.ReadLine();
                isCorrect = SampleCorrect(ref inputStr);
                isEmpty = IsEmptyStr(ref inputStr);
                if (!isEmpty)
                {
                    BdCmplt("Нельзя ввести пустую строку. Повторите ввод.\n \a");
                }
                else if (!isCorrect)
                {
                    BdCmplt("Предложение должно начинаться с заглавной буквы и оканчиваться знаком окончания предложения. Повторите ввод.\n \a");
                }
            } while (isCorrect == false);
            return inputStr;
        }
        static string GetFileLocation(string location = "../../../test.txt")
        {
            string inputStr;
            Console.WriteLine("Введите расположение файла без кавычек (для использования файла по умолчанию нажмите ENTER):");
            inputStr = Console.ReadLine();
            Console.WriteLine();
            if (inputStr != null && inputStr.Length != 0 && inputStr != "")
                return inputStr;
            else
                return location;  
        }
        static string[] StringReader()
        {
            string[] finalStrings = new string[0];
            string[] strings = new string[0];
            string line;
            int count = 0;
            try
            {
                StreamReader sr = new StreamReader(GetFileLocation());
                line = "";
                while (line != null)
                {
                    line = sr.ReadLine();
                    Array.Resize(ref strings, count + 1);
                    strings[count++] = line;
                }
                line = sr.ReadLine();
                sr.Close();
                count = 0;
            }
            catch { BdCmplt("Файл не найден\n\a"); }
            finally { }
            foreach (string str in strings)
            { 
                if (str != null)
                {
                    Array.Resize(ref finalStrings, count + 1);
                    finalStrings[count++] = str;
                }
            }
            return finalStrings;
        }
        static void Main(string[] args)
        {
            int ans;
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
                                StringMenu();
                                ans = Answer();
                                switch (ans)
                                {
                                    case 1:
                                        {
                                            RemoveWord(StringReader());
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Clear();
                                            do
                                            {
                                                InputSelectMenu();
                                                ans = Answer();
                                                switch (ans)
                                                {
                                                    case 1:
                                                        {
                                                            Console.Clear();
                                                            RemoveWord(GetStringFromConsole());
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            Console.Clear();
                                                            RemoveWord(StringReader());
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
                                                            BdCmplt("Нет такого пункта меню.\nПовторите попытку ввода.\n \a");
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
                                            BdCmplt("Нет такого пункта меню.\nПовторите попытку ввода.\n \a");
                                            break;
                                        }
                                }
                            } while (ans != 2);
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            BdCmplt("Нет такого пункта меню.\nПовторите попытку ввода.");
                            break;
                        }
                }
            } while (true);
        }
    }
}