using System;

namespace fileorg
{
    class Program
    {
        static void Main()
        {
            
            computedchainingalg c = new computedchainingalg();
            c.computedchaining();
            beischalg b = new beischalg();

            Console.WriteLine("Bir secim yapiniz \n 1-Sayilari kendim gireceğim \n 2-Random sayi olustur");
            int secim = Convert.ToInt32(Console.ReadLine());
            Console.Write("Kac sayi gireceksiniz : ");
            int dizisayi = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[dizisayi];
            int hashKey = EnKucukAsalBul(dizisayi);
            int[] table = new int[hashKey];
            string[] refersTo = new string[hashKey];


            switch (secim)
            {
                case 1: //kullanıcı kendi girmek isterse

                    for (int i = 0; i < dizisayi; i++)
                    {
                        Console.Write("Sayilari girin : ");
                        array[i] = Convert.ToInt32(Console.ReadLine());

                    }
                    break;
                case 2: //random üretilsin isterse

                    Random rnd = new Random();
                    for (int i = 0; i < dizisayi; i++)
                    {
                        array[i] = rnd.Next(0, 1000);

                    }
                    break;
                default:
                    Console.WriteLine("Lutfen sunulan seceneklerden birini seciniz!");
                    break;
            }

            b.PlaceIntoBeischArray(array,hashKey);
            
            
             //burada hash tablosu için uygun hashKey bulunuyor yani girilen sayıların miktarından büyük en küçük asal sayı bulunuyor
            bool AsalMi(int sayi)
            {
                if (sayi < 2)
                    return false;

                for (int i = 2; i <= Math.Sqrt(sayi); i++)
                {
                    if (sayi % i == 0)
                        return false;
                }

                return true;
            }

            int EnKucukAsalBul(int altSinir)
            {
                int sayi = altSinir + 1;

                while (true)
                {
                    if (AsalMi(sayi))
                        return sayi;

                    sayi++;
                }
            }
        }
    }


}


