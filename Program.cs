using System;
using System.IO;

namespace Lab_1_2
{/// <summary>
/// Class that works with the data
/// </summary>
    public class Program
    {/// <summary>
     /// Gives the answer 
     /// </summary>
     /// <param name="args"></param>
        static void Main(string[] args)
        {
            string result = DReader.Start();
            DWriter.Print(Logic(ParseResult(result)));
        }/// <summary>
         /// makes an array, consisting of 3 values (Dominant homozigotes, Heterozigotes and Recesive homozigotes)
         /// </summary>
         /// <param name="result">
         /// the string we need to parse
         /// </param>
         /// <returns>
         /// an array with 3 numbers
         /// </returns>
        public static int[] ParseResult(string result)
        {
            string[] ans = new string[3];
            int k = 0;
            int count = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == '/' || result[i] == ',' || result[i] == ' ' || i + 1 == result.Length)
                {
                    if (count == 3)
                    {
                        Console.WriteLine("Неверные параметры ввода. Обработанны только первые 3 числа");
                        break;
                    }
                    ans[count] = result.Substring(k, i - k + 1);
                    k = i;
                    count++;
                }
            }
            return getInts(ans);
        }
        /// <summary>
        /// Converts array of strings to array of ints
        /// </summary>
        /// <param name="ans">
        /// array of string
        /// </param>
        /// <returns>
        /// array of ints
        /// </returns>
        private static int[] getInts(string[] ans)
        {
            int[] answer = new int[3];
            for (int i = 0; i < 3; i++)
            {
                answer[i] = Convert.ToInt32(ans[i]);
            }
            return answer;
        }
        /// <summary>
        /// the nmain logic in the program, which counts the probability
        /// </summary>
        /// <param name="allele">
        /// gets the array of alleles to count 
        /// </param>
        public static string Logic(int[] allele)
        {
            double Dom_hom = allele[0];
            double Rec_hom = allele[1];
            double Heter = allele[2];
            double sum = Dom_hom + Heter + Rec_hom;
            double Dprob = (Dom_hom / sum);
            double Hprob = (Heter / sum) * (4 * Dom_hom + 3 * (Heter - 1) + 2 * Rec_hom) / (4 * (sum - 1));
            double Rprob = (Rec_hom / sum) * (2 * Dom_hom + Heter) / (2 * (sum - 1));
            string ans = (Dprob + Hprob + Rprob).ToString();
            return ans.Substring(0, 7);
        }
    }
    /// <summary>
    /// Class that helps us get the data from console or file 
    /// </summary>
    class DReader
    {
        /// <summary>
        /// Method that asks what is needed from user 
        /// </summary>
        /// <returns>
        /// The string where all the values are
        /// </returns>
        public static string Start()
        {
            Console.WriteLine("Приветсвтуем вас в программе, демонстрирующей 1 закон Менделя. Напишите данные в порядке: Количество доминантных гомозигот, количество гетерозигот, количество рецесивных гомозигот.");
            Console.WriteLine("Разделяйте данные пробелами, запятыми или слешами");
            Console.WriteLine("Выберите откуда считывать данные [File/Console]");
            string answer = Console.ReadLine().ToLower().ToString();
            while (!answer.Equals("file") && !answer.Equals("console"))
            {
                Console.WriteLine("Ошибка введенно неверное значение. Введите команду File или Console");
                Console.WriteLine("Вы ввели " + answer);
                answer = Console.ReadLine().ToLower().ToString();
            }
            if (answer.Equals("file"))
            {
                return FileData();
            }
            return ConsoleData();
        }

        /// <summary>
        /// If user would like to type the string to the console 
        /// </summary>
        /// <returns>
        /// the string of values
        /// </returns>
        private static string ConsoleData()
        {
            Console.WriteLine("Введите данные в указанном порядке в одну строку");
            return Console.ReadLine();
        }
        /// <summary>
        /// Gets the information from which file should we take data 
        /// </summary>
        /// <returns>
        /// the string of values
        /// </returns>
        private static string FileData()
        {
            Console.WriteLine("Файл лежит в папке C:\\Users\\Tim\\source\\repos\\Lab_1_2\\Lab_1_2\\Resourses?[y/n]");
            string answer = Console.ReadLine().ToString();
            while (!answer.Equals("y") && !answer.Equals("n"))
            {
                Console.WriteLine("Введен неправильный ответ. Вы должны написать 'y' или 'n'");
                answer = Console.ReadLine().ToString();
            }
            if (answer.Equals("y"))
            {
                return getDataFromFileFolder();
            }
            return getDataFromDifFolder();
        }
        /// <summary>
        /// gets the data from file which lies in the Resourses directory
        /// </summary>
        /// <returns>
        /// string of values
        /// </returns>
        private static string getDataFromFileFolder()
        {
            string path = "C:\\Users\\Tim\\source\\repos\\Lab_1_2\\Lab_1_2\\Resourses\\";
            Console.WriteLine("Напишите название файла");
            string folder = Console.ReadLine().ToString();
            path += folder;
            while (!File.Exists(path))
            {
                Console.WriteLine("Введен некорректный адреc файла");
                Console.WriteLine("Введенный адрес: " + path);
                path = "C:\\Users\\Tim\\source\\repos\\Lab_1_2\\Lab_1_2\\Resourses\\";
                Console.WriteLine("Напишите название файла");
                folder = Console.ReadLine().ToString();
                path += folder;
            }
            string[] fileText = File.ReadAllLines(path);
            return fileText[0];
        }
        /// <summary>
        /// If user gives his own folder to grab data
        /// </summary>
        /// <returns>
        /// values in string</returns>
        private static string getDataFromDifFolder()
        {
            Console.WriteLine("Напишите полный путь к файлу");
            string path = Console.ReadLine().ToString();
            if (!File.Exists(path))
            {
                Console.WriteLine("Введен некорректный адреc файла");
                path = Console.ReadLine().ToString();
            }
            string[] fileText = File.ReadAllLines(path);
            return fileText[0];
        }
    }



    /// <summary>
    /// Class that helps us to write the answer
    /// </summary>
    class DWriter
    {/// <summary>
     /// prints the results on the console and to the special file
     /// </summary>
     /// <param name="result">
     /// gets the string with result
     /// </param>
     /// по коням
        public static void Print(string result)
        {
            string path = "C:\\Users\\Tim\\source\\repos\\Lab_1_2\\Lab_1_2\\Dominant_Probability.txt";
            Console.WriteLine("Вероятность появления организма, проявляющего доминантные признаки составляет:\n" + result);
            Console.WriteLine("Этот результат будет так же записан в текстовый файл\n" + path);
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(result);
            }
        }
    }
    //some comments below 
}