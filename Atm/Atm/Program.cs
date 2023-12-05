/*namespace Atm;

class Program
{
    
    static void Main(string[] args)
    {
        int bakiye = 1000;
        while (true)
        {
            

            // Kullanıcıya ana menüyü göster
            Console.WriteLine("1. Bakiye Görüntüle");
            Console.WriteLine("2. Para Yatır");
            Console.WriteLine("3. Para Çek");
            Console.WriteLine("4. Çıkış");

            // Kullanıcının seçimini al
            Console.Write("Seçiminizi yapın (1-4): ");
            string secim = Console.ReadLine();

            // Kullanıcının seçimine göre işlemi gerçekleştir
            switch (secim)
            {
                case "1":
                    BakiyeGoruntule(ref bakiye);
                    break;
                case "2":
                    ParaYatir(ref bakiye);
                    break;
                case "3":
                    ParaCek(ref bakiye);
                    break;

                default:
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                    break;
            }
        }
        Console.ReadKey();
    }
    static void BakiyeGoruntule(ref int bakiye)
    {
        Console.Clear();
        Console.WriteLine($"bakiyeniz: {bakiye}");
    }
    static void ParaYatir(ref int bakiye)
    {
        Console.Clear();
        Console.Write("Yatirmak istediginiz tutar: ");
        int yatirilacakPara = int.Parse(Console.ReadLine());
        bakiye = bakiye + yatirilacakPara;
        Console.WriteLine($"Guncel Toplam Bakiye: {bakiye}");
        


    }
    static void ParaCek(ref int bakiye)
    {
        Console.Clear();

        Console.Write("Cekmek istediginiz tutar: ");
        int cekilecekPara = int.Parse(Console.ReadLine());
        bakiye = bakiye - cekilecekPara;

        if (bakiye > 0)
        {
            Console.WriteLine($"Guncel Toplam Bakiye: {bakiye}");
        }
        else
        {
            Console.WriteLine("Bakiyeniz yetersiz");

        }



    }
}


*/

namespace Atm
{
    class Program
    {
        static void Main(string[] args)
        {
            int bakiye = 1000;
            while (true)
            {
                // Kullanıcıya ana menüyü göster
                Console.WriteLine("1. Bakiye Görüntüle");
                Console.WriteLine("2. Para Yatır");
                Console.WriteLine("3. Para Çek");
                Console.WriteLine("4. Çıkış");

                // Kullanıcının seçimini al
                Console.Write("Seçiminizi yapın (1-4): ");
                string secim = Console.ReadLine();

                // Kullanıcının seçimine göre işlemi gerçekleştir
                switch (secim)
                {
                    case "1":
                        BakiyeGoruntule(bakiye);
                        break;
                    case "2":
                        bakiye = ParaYatir(bakiye);
                        break;
                    case "3":
                        bakiye = ParaCek(bakiye);
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                        break;
                }
            }
            Console.ReadKey();
        }

        static void BakiyeGoruntule(int bakiye)
        {
            Console.Clear();
            Console.WriteLine($"Bakiyeniz: {bakiye}");
        }

        static int ParaYatir(int bakiye)
        {
            Console.Clear();
            Console.Write("Yatırmak istediğiniz tutar: ");
            int yatirilacakPara = int.Parse(Console.ReadLine());
            bakiye = bakiye + yatirilacakPara;
            Console.WriteLine($"Güncel Toplam Bakiye: {bakiye}");
            return bakiye;
        }

        static int ParaCek(int bakiye)
        {
            Console.Clear();
            Console.Write("Çekmek istediğiniz tutar: ");
            int cekilecekPara = int.Parse(Console.ReadLine());
            bakiye = bakiye - cekilecekPara;

            if (bakiye >= 0)
            {
                Console.WriteLine($"Güncel Toplam Bakiye: {bakiye}");
            }
            else
            {
                Console.WriteLine("Bakiyeniz yetersiz");
                bakiye = bakiye + cekilecekPara; // İşlemi geri al
            }

            return bakiye;
        }
    }
}