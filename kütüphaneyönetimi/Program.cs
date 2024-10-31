using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static kütüphaneyönetimi.Kitaplar;

namespace kütüphaneyönetimi
{
    public class Kitaplar
    {
        public string kitapid;
        public string kitapadi;
        public string yazaradi;
        public string durumu;
        public Uye uye;

        public Kitaplar (string kitapadi, string yazaradi, string kitapid, string durumu)
        {
            this.kitapid = kitapid;
            this.kitapadi = kitapadi;
            this.yazaradi = yazaradi;
            this.durumu = durumu;
        }
        public class Uye
        {
            public string ad;
            public string soyad;
            public string tckimlik;
            public Uye(string ad, string soyad,string tckimlik)
            {
                this.ad = ad;
                this.soyad = soyad;
                this.tckimlik = tckimlik;
            }
            public void KitapAl()
            {

            }
        }
    }

    public class Program
    {
        static Kitaplar[] kitap_listesi;
        static Uye[] uye_listesi;
        static int kitap_sayisi = 0;
        static int uye_sayisi = 0;
        static void Main(string[] args)
        {
            kitap_listesi = new Kitaplar[100];
            uye_listesi = new Uye[100];

            while (true)
            {
                Console.WriteLine(".:: Kütüphane ::.");
                Console.WriteLine("1 - Kitap Ekleme");
                Console.WriteLine("2 - Kitapları Listeleme");
                Console.WriteLine("3 - Üye Ekleme");
                Console.WriteLine("4 - Üye Listeleme");
                Console.WriteLine("5 - Kitap Alma");
                Console.WriteLine("6 - Kitap İade");
                Console.WriteLine("7 - Çıkış");
                string girilen_değer = Console.ReadLine();

                int secim = Convert.ToInt32(girilen_değer);

                switch (secim)
                {
                    case 1:
                        Console.WriteLine("Kitap Ekleme İşlemi");
                        Kitaplar kitap = KitapEkle();
                        kitap_listesi[kitap_sayisi] = kitap;
                        kitap_sayisi = kitap_sayisi + 1;
                        break;
                    case 2:
                        Console.WriteLine("Kitap Listeleme İşlemi");
                        KitapListele();
                        break;
                    case 3:
                        Console.WriteLine("Üye Ekleme İşlemi");
                        Uye uye = UyeEkle();
                        uye_listesi[uye_sayisi] = uye;
                        uye_sayisi = uye_sayisi + 1;
                        break;
                    case 4:
                        Console.WriteLine("Üye Listeleme İşlemi");
                        UyeListele();
                        break;
                    case 5:
                        Console.WriteLine("Kitap Alma İşlemi");
                        KitapAl();
                        break;
                    case 6:
                        Console.WriteLine("Kitap İade İşlemi");
                        KitapIade();
                        break;
                    case 7:
                        Cikis();
                        break;
                    default:
                        break;
                }
            }
        }
        public static Kitaplar KitapEkle()
        {
            Console.WriteLine("Kitabın adını giriniz: ");
            string kitapadi = Console.ReadLine();
            Console.WriteLine("Yazarın adını giriniz: ");
            string yazaradi = Console.ReadLine();
            Console.WriteLine("Kitap numarasını giriniz ");
            string kitapid = Console.ReadLine();

            Kitaplar kitap = new Kitaplar(kitapadi, yazaradi, kitapid, "Okunabilir");

            Console.WriteLine($"{kitapid} numaralı {kitapadi} {yazaradi} kitap listeye eklendi ");
            Console.WriteLine($"==============================\n");
            return kitap;
        }
        public static void KitapListele()
        {
            for (int i = 0; i < kitap_sayisi; i++)
            {
                Console.WriteLine($"{i + 1}. Kitap: ");
                Console.WriteLine($"Kitap Adı: {kitap_listesi[i].kitapadi}");
                Console.WriteLine($"Yazar Adı: {kitap_listesi[i].yazaradi}");
                Console.WriteLine($"Kitap Numarası: {kitap_listesi[i].kitapid}");

                if (kitap_listesi[i].durumu != "Başka üyemizde")
                {
                    Console.WriteLine($"Durumu: {kitap_listesi[i].durumu}");
                }
                else
                {
                    Console.WriteLine($"Durumu: {kitap_listesi[i].durumu} ({kitap_listesi[i].uye.ad} {kitap_listesi[i].uye.soyad}");
                }
            }
            Console.WriteLine($"==============================\n");
        }
        public static Uye UyeEkle()
        {
            Console.WriteLine("Üye olacak kişini adını giriniz: ");
            string uyeadi = Console.ReadLine();
            Console.WriteLine("Üye olacak kişinin soyadını giriniz: ");
            string uyesoyadi = Console.ReadLine();
            Console.WriteLine("Üye Kimlik No gir: ");
            string kimlik = Console.ReadLine();
            Uye uye = new Uye(uyeadi, uyesoyadi, kimlik);
            Console.WriteLine($"{uyeadi} {uyesoyadi}, üye listesine eklendi.");
            Console.WriteLine($"==============================\n");

            return uye;
        }
        public static void UyeListele()
        {
            for (int i = 0; i < uye_sayisi; i++)
            {
                Console.WriteLine($"{i + 1}. Üye: ");
                Console.WriteLine($"Ad: {uye_listesi[i].ad}");
                Console.WriteLine($"Soyad: {uye_listesi[i].soyad}");
                Console.WriteLine($"Kimlik No: {uye_listesi[i].tckimlik}");
            }
            Console.WriteLine($"==============================\n");
        }
        public static void KitapAl()
        {
            Console.WriteLine("Okumak istediğiniz kitabın numarası");
            string okunacakKitap = Console.ReadLine();

            bool mevcut = false;
            int bulunan_kitap_indisi = 0;

            for (int i = 0; i < kitap_sayisi; i++)
            {
                if (kitap_listesi[i].kitapid == okunacakKitap)
                {
                    mevcut = true;
                    bulunan_kitap_indisi = i;
                    break;
                }
            }
            if (mevcut == false)
            {
                Console.WriteLine($"{okunacakKitap} kitap listede yok!");
            }
            else
            {
                Console.WriteLine("Üye kimlik numarasını gir: ");
                string odunc_alacak_kisinin_kimlik_no = Console.ReadLine();

                bool uye_bulundu = false;
                int bulunan_uyenin_indisi = 0;

                for (int i = 0; i < uye_sayisi; i++)
                {
                    if (uye_listesi[i].tckimlik == odunc_alacak_kisinin_kimlik_no)
                    {
                        uye_bulundu = true;
                        bulunan_uyenin_indisi = i;
                        break;
                    }
                }
                if (uye_bulundu == false)
                {
                    Console.WriteLine($"{odunc_alacak_kisinin_kimlik_no} kimlikli üye bulunamadı. Yeni üye ekleyin!");
                }
                else
                {
                    kitap_listesi[bulunan_kitap_indisi].durumu = "Üyede";
                    kitap_listesi[bulunan_kitap_indisi].uye = uye_listesi[bulunan_uyenin_indisi];
                    Console.WriteLine($"{kitap_listesi[bulunan_uyenin_indisi].kitapid}'li kitap, {uye_listesi[bulunan_uyenin_indisi].ad} {uye_listesi[bulunan_uyenin_indisi].soyad} tarafından alınmıştır.");
                }
            }
            Console.WriteLine($"==============================\n");
        }
        public static void KitapIade()
        {
            Console.WriteLine("İade etmek istediğin kitabın numarasını giriniz ");
            string iade_edilmek_istenen_kitapid = Console.ReadLine();

            bool kitap_bulundu = false;
            int bulunan_kitap_indisi = 0;

            for (int i = 0; i < kitap_sayisi; i++)
            {
                if (kitap_listesi[i].kitapid == iade_edilmek_istenen_kitapid)
                {
                    kitap_bulundu = true;
                    bulunan_kitap_indisi = i;
                    break;
                }
            }

            if (kitap_bulundu == false)
            {
                Console.WriteLine($"{iade_edilmek_istenen_kitapid} kitap listede yok!");
            }
            else
            {
                if (kitap_listesi[bulunan_kitap_indisi].durumu == "Üyede")
                {
                    kitap_listesi[bulunan_kitap_indisi].durumu = "Okunmaya hazır";
                    kitap_listesi[bulunan_kitap_indisi].uye = null;

                    Console.WriteLine($"{iade_edilmek_istenen_kitapid} numaralı kitap iade edilmiştir!");
                }
                else
                {
                    Console.WriteLine($"{iade_edilmek_istenen_kitapid} numaralı kitap zaten üyede değil!");
                }
            }
            Console.WriteLine($"==============================\n");
        }
        public static void Cikis()
        {
            System.Environment.Exit(0);
        }
    }
}
