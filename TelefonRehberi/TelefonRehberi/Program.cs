using System;

namespace TelefonRehberi;

class RehberKisi
{
    public int ID { get; set; }
    public string Ad { get; set; }
    public string Soyad { get; set; }
    public string Numara { get; set; }
}

class Program

{
    static RehberKisi[] rehber = new RehberKisi[100];
    

    static void Main(string[] args)
    {
        while (true)
        {
            // Kullanıcıya ana menüyü göster
            Console.WriteLine("1. Rehberi Görüntüle");
            Console.WriteLine("2. Kişi Ekle");
            Console.WriteLine("3. Kişi Güncelle");
            Console.WriteLine("4. Kişi Sil");
            Console.WriteLine("5. Çıkış");

            // Kullanıcının seçimini al
            Console.Write("Seçiminizi yapın (1-5): ");
            string secim = Console.ReadLine();

            // Kullanıcının seçimine göre işlemi gerçekleştir
            switch (secim)
            {
                case "1":
                    RehberiGoruntule();
                    break;
                case "2":
                    KisiEkle();
                    break;
                case "3":
                    KisiGuncelle();
                    break;
                case "4":
                    KisiSil();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                    break;
            }
        }
        Console.ReadKey();
    }
    static void RehberiGoruntule()
    {
        Console.WriteLine("Rehberim:");
        Console.WriteLine("******************");

        foreach (var kisi in rehber)
        {
            if (kisi != null)
            {
                Console.WriteLine($"ID:{kisi.ID} Ad: {kisi.Ad}, Soyad: {kisi.Soyad}, Numara: {kisi.Numara}");

            }
        }
    }

    static void KisiEkle()
    {
        Console.Clear();
        Console.WriteLine("Yeni Kisinin Adini giriniz: ");
        string ad = Console.ReadLine();

        Console.WriteLine("Yeni Kisinin Soyadini giriniz: ");
        string soyad = Console.ReadLine();

        Console.WriteLine("Yeni Kisinin Numarasini giriniz: ");
        string numara = Console.ReadLine();

        int index = Array.IndexOf(rehber, null);

        RehberKisi yeniKisi = new RehberKisi
        {
            ID = index+1,
            Ad = ad,
            Soyad = soyad,
            Numara = numara
        };

        rehber[index] = yeniKisi;
        Console.WriteLine("Kisi Basariyla Eklendi");

    }

    static void KisiGuncelle()
    {
        Console.Clear();
        RehberiGoruntule();
        Console.WriteLine("Guncelleme yapilacak kisinin id'sini girin: ");
        int secimID = int.Parse(Console.ReadLine());

        RehberKisi GuncelKisi = rehber.FirstOrDefault(kisi => kisi != null && kisi.ID == secimID);

        if (GuncelKisi != null) 
        {

            Console.WriteLine("Guncellenecek Adi giriniz: ");
            GuncelKisi.Ad = Console.ReadLine();

            Console.WriteLine("Guncellenecek Soyadi giriniz: ");
            GuncelKisi.Soyad = Console.ReadLine();

            Console.WriteLine("Guncellencek Numarayi giriniz: ");
            GuncelKisi.Numara = Console.ReadLine();


            Console.WriteLine("Kisi Basariyla Guncellendi");
        }
        else
        {
            Console.WriteLine("Belirtilen kisi bulunamadi.");
        }

    }

    static void KisiSil()
    {

        Console.Clear();
        RehberiGoruntule();
        Console.WriteLine("Silinecek kisinin id'sini girin:");
        int secimID = int.Parse(Console.ReadLine());

        RehberKisi siliecekKisi = rehber.FirstOrDefault(kisi => kisi != null && kisi.ID == secimID);

        if (siliecekKisi != null)
        {
            Array.Clear(rehber, Array.IndexOf(rehber, siliecekKisi),1);
        }
        else
        {
            Console.WriteLine("Belirtilen ID ile eşleşen kişi bulunamadı.");
        }

    }
}

