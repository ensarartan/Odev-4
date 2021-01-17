using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Calculator
    {
        public Stack<double> result = new Stack<double>();
        double total;
        public void add(double a, double b)
        {
            total = a + b;
            Console.WriteLine("Toplam:{0}", total);
            result.Push(total);
        }
        public void sub(double a, double b)
        {
            total = a - b;
            Console.WriteLine("Fark:{0}", total);
            result.Push(total);
        }
        public void mul(double a, double b)
        {
            total = a * b;
            Console.WriteLine("Sonuç:{0} ", total);
            result.Push(total);
        }
        public void div(double a, double b)
        {
            if (b != 0)
            {
                total = a / b;
                Console.WriteLine("Miktar:{0}", total);
                result.Push(total);
            }
            else
            {
                Console.WriteLine("Hata: 0'a bölünemez");
            }
        }
        double getTotal()
        {
            return total;
        }
        void undo()
        {
            if (result.Count == 0)
            {
                Console.WriteLine("Geri alma işlemi yapılamaz");
            }
            result.Pop();
            total = result.Pop();
            Console.WriteLine("Running total:{0}", total);
        }
        void clear()
        {
            while (result.Count != 0)
                result.Pop();
            total = 0;
            Console.WriteLine("Running total:{0}", total);
        }
        static int Main()
        {
            Calculator cal = new Calculator();
            string line = "";
            while (true)
            {
                Console.WriteLine("Girin: (Temizle, Geri al, Çık, Hesapla):");
                line = Console.ReadLine();
                if (line.ToLower() == "Çık")
                    break;
                else if (line.ToLower() == "Geri Al")
                    cal.undo();
                else if (line.ToLower() == "Temizle")
                    cal.clear();
                else
                {
                    double a, b;
                    char c;

                    Console.WriteLine("İlk sayıyı giriniz:");
                    double.TryParse(Console.ReadLine(), out a);

                    Console.WriteLine("İkinci sayıyı giriniz:");
                    double.TryParse(Console.ReadLine(), out b);

                    Console.WriteLine("Operator seçiniz (+,-,/,*)");
                    char.TryParse(Console.ReadLine(), out c);


                    if (c == '+')
                        cal.add(a, b);
                    if (c == '-')
                        cal.sub(a, b);
                    if (c == '*')
                        cal.mul(a, b);
                    if (c == '/')
                        cal.div(a, b);
                }
            }

            return 0;
        }
    }


}
