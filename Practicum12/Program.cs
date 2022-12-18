using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nomination, value, sum, price;
            while (true)
            {
                try
                {
                    Console.Write("Введите номинал купюры: ");
                    nomination = int.Parse(Console.ReadLine());
                    Console.Write("Введите количество купюр: ");
                    value = int.Parse(Console.ReadLine());
                    Console.Write("Введите сумму закупки товара: ");
                    sum = int.Parse(Console.ReadLine());
                    Console.Write("Введите стоимость 1 штуки товара: ");
                    price = int.Parse(Console.ReadLine());
                    if (nomination <= 0 || value <= 0 || sum <= 0 || price <= 0) throw new Exception("Значение не может быть меньше или равно нулю!");
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите корректное значение");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("------------------------------------------------------------");
            Money money = new Money(nomination, value);

            money.outInfo();
            Console.WriteLine("------------------------------------------------------------");
            money.isEnoughMoney(sum);
            Console.WriteLine("------------------------------------------------------------");
            money.quantityOfGoods(price, sum);
            Console.WriteLine("------------------------------------------------------------");
            while (true)
            {
                try
                {
                    Console.Write("Введите значение номинала: ");
                    money.First = int.Parse(Console.ReadLine());
                    Console.Write("Введите значение количества купюр: ");
                    money.Second = int.Parse(Console.ReadLine());
                    if (money.First <= 0 || money.Second <= 0) throw new Exception("Значение не может быть меньше или равно нулю!");
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите корректное значение");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine($"Значение номинала равно {money.First}, значение кол-ва купюр равно {money.Second}\n" +
                $"Сумма денег равна {money.Sum}");

            Console.WriteLine("------------------------------------------------------------");
            int indx;
            while (true)
            {
                try
                {
                    Console.Write("Введите индекс (0 - поле first, 1 - поле second): ");
                    indx = int.Parse(Console.ReadLine());
                    Console.Write("Введите новое значение: ");
                    money[indx] = int.Parse(Console.ReadLine());
                    if (money[indx] < 0) throw new Exception("Значение не может быть меньше нуля!");
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите корректное значение");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Индекс должен быть равен 0 или 1");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine($"Значение изменено. Теперь оно равно {money[indx]}");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Перегрузки\n");
            //перегрузка ++
            Console.WriteLine("Применение перегрузки инкремента");
            Console.WriteLine("______________________________________________");
            money.outInfo();
            money++;
            Console.WriteLine($"Операция произведена!");
            money.outInfo();
            //перегрузка --
            Console.WriteLine("\nПрименение перегрузки декремента");
            Console.WriteLine("______________________________________________");
            money.outInfo();
            money--;
            Console.WriteLine($"Операция произведена!");
            money.outInfo();
            //перегрузка операции !
            Console.WriteLine("\nПрименение перегрузки !");
            Console.WriteLine("______________________________________________");
            if (!money) Console.WriteLine("Поле second не нулевое");
            else Console.WriteLine("Значение поля second равно нулю");
            //перегрузка +
            Console.WriteLine("\nПрименение перегрузки +");
            Console.WriteLine("______________________________________________");
            int scal;
            while (true)
            {
                try
                {
                    Console.Write("Введите значение скаляра: ");
                    scal = int.Parse(Console.ReadLine());
                    if (scal < 0) throw new Exception("Значение не может быть меньше нуля!");
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите корректное значение");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            money += scal;
            Console.WriteLine($"Новое значение поля second - {money.Second}");
            //преобразование типа Money в String
            Console.WriteLine("\nПрименение преобразования типа");
            Console.WriteLine("______________________________________________");
            string mny = (string)money;
            Console.WriteLine("Преобразование в строковый тип");
            Console.WriteLine(mny);
            //и наоборот
            Console.WriteLine("\nПреобразование в тип Money");
            Console.Write("Введите в строку два значения для преобразования ее в класс Money: ");
            string str = Console.ReadLine();
            try
            {
                Money mny1 = (Money)str;
                if (mny1 is Money) Console.WriteLine("Преобразование в класс Money успешно");
                else Console.WriteLine("Преобразование неудачно");
                mny1.outInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}