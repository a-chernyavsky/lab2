//#define TYPES
//#define STRING1
//#define ARRAY
//#define TUPLE
#define FIVELOCAL

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace lab22
{
    class Program
    {
        static void Main(string[] args)
        {
#if TYPES
            //1)типы
            //а)
            bool t = true;
            byte b = 4;
            sbyte sb = -103;//-128  -- 127;
            short n1 = 1;//Int16
            ushort n2 = 3;//UInt16
            int i1 = 228;//System.Int32
            uint ui1 = 88005553;//System.UInt32
            long l1 = 88005553535; //System.Int64
            ulong ul1 = 12342312;
            float f1 = 8483.444f;//System.Single
            double skibidipapa = 45354234.333;//System.Double;
            decimal d1212 = 5434234;//хранит десятичное дробное число
            char a = 'A';// in Unicode 2 bytes
            string hello = "Hello";
            object ob1 = 7788;
            object ob2 = 3.14;
            object ob3 = "hello world";
            //----------------------------------------------//

            //б)5 операций явного и 5 неявного преобразований
            int iA = 5;
            double dB = iA;//неявное

            short sA = 12;
            iA = sA;

            byte bA = 55;
            float fA = bA;

            //-------------------явное
            ulong ulA = 8800555;
            float f2 = (float)ulA;

            short s3 = 5;
            byte b3 = Convert.ToByte(s3);

            long l3 = 3344;
            int i4 = Convert.ToInt32(l3);

            string str3 = "32323";
            int i5 = int.Parse(str3);//32323
            int i6;
            bool b5 = int.TryParse(str3, out i6);

            //c) упаковка и распаковка значимых типов

            int aa = 10;//a - значимый тип
            object bb = aa;//неявная упаковка

            int cc = (int)bb;//распаковка
            /*В процессе упаковки в куче создается объект
             * класса-оболочки и ему присваивается значение 
             * переменной, взятое из программного стека. 
             * При распаковке осуществляются обратные
             * действия:*/
            /*Как видим, для распаковки нужно перед экземпляром
             * класса-оболочки в круглых скобках указать
             * значащий тип, который из него извлекается.
             * Среда исполнения CLR проверяет соответствие 
             * значащего типа и данных в куче на принадлежность 
             * к совместимым типам. Если совместимость нарушена,
             * возникает исключение InvaldCastException.*/

            //--------------------------------------------
            //d)Работа с неявно типизированной переменной

            var bla = 5;//int
            int mmm = bla + 1;//6
            var myString = "hello world it is string ...";//string

            //--------------------
            //Ссылочные типы могут иметь значение null, 
            //если ссылка не ссылается ни на какой объект. 
            //В противоположность им значимые типы не могут иметь значение null.
            string newstr1 = null;//string -- ссылочный тип
            //int i7 = null =>ошибка
            int? i7 = null;
            System.Nullable<int> enable = 5;
            if (i7.HasValue)
            {
                Console.WriteLine("i7 = " + i7.Value);
            }
            else { Console.WriteLine("i7 has not value"); }
            if(enable.HasValue)
            {
                Console.WriteLine("enable = " + enable.Value);
            }

#endif
#if STRING1
            //==========================================
            //2) Строки
            string strOne = "Hello";
            string strTwo = "big";
            string strThree = "brother";
            //сравнение
            Console.WriteLine("Сравнение двух строк: 1 - 1-я больше 2-й, -1 - 1-я меньше 2-й, 0 - равны\n" + String.Compare(strOne, strTwo));
            Console.WriteLine(String.Compare(strOne, "Hello"));
            //compareordinal, equels, ==, !=; <, >, <=, >= -- для ссылок

            string[] strArr = new string[] { strOne, strTwo, strThree };//массив строк

            string strNew1 = strOne + " " + strTwo + " " + strThree + ".";//конкатенация
            Console.WriteLine(strNew1 + "\n");

            strNew1 = String.Concat(strNew1, "Это Конкатенация");//конкатенация
            Console.WriteLine(strNew1 + "\n");

            string strNew2 = null;
            strNew2 = String.Join(" ", strArr);//соединение метод Join()
            Console.WriteLine(strNew2 + "\n");


            string[] strArray = strNew1.Split(' ');//разделение строки на слова
            foreach (string i in strArray)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine('\n');

            Console.WriteLine(strNew1.Substring(3, 9));//подстрока в строке

            Console.WriteLine(strNew1.Insert(3, "! INSERT STRING !"));//Вставка

            Console.WriteLine(strNew1.Remove(3,5));//удаление

            strNew1 = String.Copy(strOne); Console.WriteLine(strNew1);//копирование

            string empty1 = "";
            Console.WriteLine(empty1 == "");
            Console.WriteLine(empty1.Length);

            string nullstring = null;
            Console.WriteLine(nullstring == "");
            //Console.WriteLine(nullstring.Length == 0);
            Console.WriteLine("строка nullstring является:      " + string.IsNullOrEmpty(nullstring));


            StringBuilder sb1 = new StringBuilder("Hello world");
            Console.WriteLine(sb1.Length);      //11
            Console.WriteLine(sb1.Capacity + "\n");    //16
            sb1.Append(" blablabla");//добавление в конец
            Console.WriteLine(sb1);
            sb1.Insert(2, "sucksucksuck");//добавление в любое место(2 симв.)
            Console.WriteLine(sb1);
            sb1.Insert(0, "AAAAAAAAAA");//добавл. в начало
            Console.WriteLine(sb1);
#endif
#if ARRAY
            //============================
            //ARRAYS
            Console.WriteLine();
            //a)
            int[,] ArrInt = new int[,] { { 1, 2, 3 }, { 6, 7, 8 }, { 9, 9, 9 } };//двумерный массив
            int rows = ArrInt.GetUpperBound(0) + 1;//кол-во строк в массиве
            int columns = ArrInt.Length / rows;//кол-во столбцов = (длина массива)/(кол-во строк)
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    Console.Write(ArrInt[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();

            //b)
            string[] ArrString = new string[] { "vasia", "petya", "masha" };
            Console.WriteLine("\n\nmy array length is " + ArrString.Length + ", con. of:");
            foreach(string i in ArrString)  //цикл foreach
            {
                Console.WriteLine(i);//print all
            }
            ArrString[2] = "vladimir";

            foreach (string i in ArrString)
            {
                Console.WriteLine(i);//print all
            }


            //c)

            double[][] Arrstep = new double[3][];//ступенчастый невыровненный массив массив
            Arrstep[0] = new double[2];
            Arrstep[1] = new double[3];
            Arrstep[2] = new double[4];
            //input
            for (int i = 0; i < 2;i++)
            {
                Console.WriteLine("Enter " + i + " element of first string");
                Arrstep[0][i] = Convert.ToDouble(Console.ReadLine());
            }
            
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter " + i + " element of second string");
                Arrstep[1][i] = Convert.ToDouble(Console.ReadLine());
            }

            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine("Enter " + i + " element of third string");
                Arrstep[2][i] = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine("\nВывод ступенчатого массива:\n\n");
            
            //output
            foreach(double[]rows1 in Arrstep)
            {
                foreach(double columns1 in rows1)
                {
                    Console.Write(columns1 + " ");
                }
                Console.WriteLine();
            }

            //d)

            var str228 = "Неявнотипизированная переменная для хранения строки";
            var arr228 = new int[] { 24, 12, 1999 };//для хранения массива
            //output type
            Console.WriteLine("str228 type -  " + str228.GetType());//system.string
            Console.WriteLine("arr228 type -  " + arr228.GetType());//system.int32
#endif
#if TUPLE
            //====================================
            //КОРТЕЖИ
            //Кортежи предоставляют удобный способ для работы с набором значений

            (int, string, char, string, ulong) myfunction = (1,"Alex",'b',"Charniauski",88005553535);
            //print
            Console.WriteLine(myfunction);
            

            (int num, string name, char group, string sur, ulong phone) myfunc2 = (2, "Stasik", 'a', "Pyrkin", 7788);
            Console.WriteLine(myfunc2);
            Console.WriteLine($"{myfunc2.num}  {myfunc2.group}  {myfunc2.phone}");

            int num1 = (int)myfunc2.num;
            string name1 = myfunc2.name;

            int ans = myfunction.CompareTo(myfunc2);
            Console.WriteLine(ans);


#endif

#if FIVELOCAL
            (int max, int min, int sum, char c) NewFunction (int[] array, string str)
            {
                int min = array[0];
                int max = array[0];
                int sum = 0;
                foreach(int i in array)
                {
                    if (min > i)
                        min = i;
                    if (max < i)
                        max = i;
                    sum += i;
                }
                char firstchar = str[0];
                (int max, int min, int sum, char c) result = (max, min, sum, firstchar);
                return result;
            }
            int[] myarray222 = {3,4,5,2,333,2,4};
            string str228 = "Alexey Charniauski";
            Console.WriteLine("my answer is " + NewFunction(myarray222, str228));

#endif


            Console.ReadKey();
        }
    }
}
