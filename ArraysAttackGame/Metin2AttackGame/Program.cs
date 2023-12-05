using System;

namespace Metin2AttackGame;


class Program
{
    static void Main(string[] args)
    {
       
        string[] karakterler = { "Savaşcı", "Sura", "Şaman", "Ninja" };
        //int[,] ozellikler = new int[4,2];

        int[,] ozellikler =
        {
            {20,100,20},// savasci güç - savunma- ıskalama
            {19,110,20}, // sura güç - savunma -ıskalama
            {15,120,20},// şaman güç - savunma -ıskalama
            {30,80,25}// ninja güç - savunma -ıskalama
        };





        //Console.WriteLine(dusmanKarakter);

        Console.WriteLine("Metin2\n" +
            "Karakterler:\n" +
            "1- Savaşci\n" +
            "2- Sura\n" +
            "3- Şaman\n" +
            "4- Ninja\n" +
            "Bir karakter secimi yapiniz: ");
        Random x = new Random();
        int index = x.Next(0, 3);
        string dusmanKarakter = karakterler[index];
        int secim = int.Parse(Console.ReadLine());

        switch (secim)
        {
            case 1:
                Console.WriteLine($"Sectiginiz Karakter {karakterler[secim-1]} ve düsman karakter {dusmanKarakter}");
                Atak(ozellikler, secim, index, dusmanKarakter, karakterler);
              
                break;
            case 2:
                Console.WriteLine($"Sectiginiz Karakter {karakterler[secim - 1]} ve düsman karakter {dusmanKarakter}");
                Atak(ozellikler, secim, index, dusmanKarakter, karakterler);

                break;
            case 3:
                Console.WriteLine($"Sectiginiz Karakter {karakterler[secim - 1]} ve düsman karakter {dusmanKarakter}");
                Atak(ozellikler, secim, index, dusmanKarakter, karakterler);

                break;
            case 4:
                Console.WriteLine($"Sectiginiz Karakter {karakterler[secim - 1]} ve düsman karakter {dusmanKarakter}");
                Atak(ozellikler, secim, index, dusmanKarakter, karakterler);

                break;

            default:
                break;
        }

        Console.ReadKey();
        
        
    }

    static void Atak(int[,] ozellikler, int secim, int index, string dusmanKarakter, string[] karakterler)
    {
        
        int kullaniciSaldiri = ozellikler[secim - 1, 0];
        int kullaniciSaglik = ozellikler[secim - 1, 1];

        int pcSaldiri = ozellikler[index, 0];
        int pcSaglik = ozellikler[index, 1];
        bool kullaniciSirasi = true;

        Console.WriteLine($"Kullanici karakterin cani {kullaniciSaglik}");
        Console.WriteLine($"Dusman karakterin cani {pcSaglik}");


        while((kullaniciSaglik > 0) || (pcSaglik > 0))
        {
            Console.WriteLine("Atak icin 'saldir' yazin");
            string vurus = Console.ReadLine();

            if (vurus.Trim().ToLower() == "saldir")
            {
                Console.Clear();
                int kullaniciIskalama = ozellikler[secim - 1, 2];
                int pcIskalama = ozellikler[index, 2];
                Random random = new Random();
                int iska = random.Next(0, 100);
                Random random2 = new Random();
                int iska2 = random2.Next(0, 100);

                if (kullaniciSirasi)
                {
                    if (kullaniciIskalama > iska)
                    {
                        //Iskalama(ozellikler, secim, index);
                        Console.WriteLine($"ıskaladın. Pc saglik {pcSaglik}");
                        //Console.WriteLine(iska);

                    }
                    else
                    {
                        pcSaglik -= kullaniciSaldiri;
                        if (pcSaglik <= 0)
                        {
                            Console.WriteLine("Kazandınız");

                            return;
                        }
                        Console.WriteLine($"Kullanici yeni can {kullaniciSaglik}");
                        Console.WriteLine("Kullanici saldiriya geciyor..");
                        Console.WriteLine($"Bilgisayar yeni can {pcSaglik}");

                    }
                }
                else
                {
                    if (pcIskalama > iska2)
                    {
                        //Iskalama(ozellikler, secim, index);
                        Console.WriteLine($"Pc ıskaladı. canın: {kullaniciSaglik}");
                        //Console.WriteLine(iska);
                    }
                    else
                    {

                        kullaniciSaglik -= pcSaldiri;
                        if (kullaniciSaglik <= 0)
                        {
                            Console.WriteLine("Kaybettiniz");
                            return;
                        }
                        Console.WriteLine($"Bilgisayar yeni can {pcSaglik}");
                        Console.WriteLine("Pc saldiriya geciyor..");
                        Console.WriteLine($"Kullanici yeni can {kullaniciSaglik}");

                    }
                }
                kullaniciSirasi = !kullaniciSirasi;
            }
            else
            {
                Console.WriteLine("Gecersiz giris yaptiniz");
                
            }




        }


    }

   
}

