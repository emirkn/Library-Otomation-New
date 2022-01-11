using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutuphaneoto
{
    class kitap
    {
        public int bookID;
        public int KitapID;
        public String KitapAdi;
        public int KitapFiyati;
        public int KitapSayisi;
        public int x;
    }
    class Kullanıcı:kitap
    {
        public string AdSoyad;
        private string parola;

       
        public string Parola
        {
            get {
                return parola;
            } 
            set {
                
                parola = value;
            }
        }
    }
    struct oduncAlınan
    {
        public int TC;
        public string isim;
        public int oduncalınanID;
        public int oduncAlmaSyisi;
        public DateTime OduncAlmaTarihi;

    }

    class program
    {
        

        static List<kitap> kitaplistesi = new List<kitap>();
        static List<oduncAlınan> oduncAlınans = new List<oduncAlınan>();
        static kitap kitap = new kitap();
        static oduncAlınan oduncAlınan = new oduncAlınan();

        static void Main(string[] args)
        {
            try
            {
                const string isim = "Arzu Hanım";
                Console.Write(isim +" Hoşgeldiniz...\n Şifrenizi Giriniz:");
                string parola = Console.ReadLine();

                Kullanıcı nesne = new Kullanıcı();
                nesne.Parola = "arzu";
                if (parola==nesne.Parola)
            {

               
                    for (; ; )
                    {
                        Console.WriteLine("\nMenu\n" +
                        "1)Kitap Ekle\n" +
                        "2)Kitap Sil\n" +
                        "3)Kitap Ara\n" +
                        "4)Kitap Ödünç Al\n" +
                        "5)Kitap İade Et\n" +
                        "6)Çıkış\n\n");
                        Console.Write("Menüden seçeneğinizi seçin :");
                        int menu =Convert.ToInt32( Console.ReadLine());
                        bool emir = true;
                        switch (menu)
                        {

                            case 1:
                                KitapEkle();
                                break;
                            case 2:
                                KitapSil();
                                break;
                            case 3:
                                KitapAra();
                                break;
                            case 4:
                                OduncAl();
                                break;
                            case 5:
                                IadeEt();
                                break;
                            case 6:
                                Console.WriteLine("Teşekkür Ederiz!");
                                emir = false;
                                break;
                            default:Console.WriteLine("Yanlış Menü Değeri");
                                break;
                        }


                    
                    }


            }
            else if (parola!="emir")
            {
                Console.WriteLine("Yanlış şifre");
            }
            }
             catch (Exception hata)
             {
                 Console.WriteLine("Yanlış Değer : " + hata);

             }

        }

        public static void KitapEkle()
        {
            kitap kitap = new kitap();
            Console.WriteLine("Kitap ID:{0}", kitap.KitapID = kitaplistesi.Count + 1);
            Console.Write("Kitap adı:");
            kitap.KitapAdi = Console.ReadLine();
            Console.Write("Kitap Fiyatı:");
            kitap.KitapFiyati = int.Parse(Console.ReadLine());
            Console.Write("Kitap Sayısı:");
            kitap.x = kitap.KitapSayisi = int.Parse(Console.ReadLine());
            kitaplistesi.Add(kitap);

            Console.ReadKey();

        }
        public static void KitapSil()
        {
            kitap kitap = new kitap();
            Console.Write("Silinecek Kitap ID sini giriniz:");

            int Sil = int.Parse(Console.ReadLine());

            if (kitaplistesi.Exists(x => x.KitapID == Sil))
            {
                kitaplistesi.RemoveAt(Sil - 1);
                Console.WriteLine("Kitap ID - {0} silindi", Sil);
            }
            else
            {
                Console.WriteLine("Geçersiz Kitap ID 'si...");
            }
            kitaplistesi.Add(kitap);

        }
        public static void KitapAra()
        {
            kitap kitap = new kitap();
            Console.WriteLine("Aramak İstediğiniz Kitabın ID 'sini giriniz:");
            int bul = int.Parse(Console.ReadLine());
            if (kitaplistesi.Exists(x => x.KitapID == bul))
            {
                foreach (kitap bulID in kitaplistesi)
                {
                    if (kitap.KitapID == bul)
                    {
                        Console.WriteLine("Kitap ID :{0}\n" +
                        "Kitap Adı :{1}\n" +
                        "Kitap Fiyatı :{2}\n" +
                        "Kitap Sayısı :{3}", bulID.KitapID, bulID.KitapAdi, bulID.KitapFiyati, bulID.KitapSayisi);
                    }
                }
            }
            else
            {
                Console.WriteLine("Kitap ID'si {0} bulunamadı.", bul);
            }
        }
        public static void OduncAl()
        {
            kitap kitap = new kitap();
            oduncAlınan oduncal = new oduncAlınan();
            Console.WriteLine("Kullanıcı ID 'si: {0}", (oduncal.TC = oduncAlınans.Count + 1));
            Console.WriteLine("İsim :");

            oduncal.isim = Console.ReadLine();

            Console.Write("Book id :");
            oduncal.oduncalınanID = int.Parse(Console.ReadLine());
            Console.Write("Number of Books : ");
            oduncal.oduncAlmaSyisi = int.Parse(Console.ReadLine());
            oduncal.OduncAlmaTarihi = DateTime.Now;
            Console.WriteLine("Date - {0} and Time - {1}", oduncal.OduncAlmaTarihi.ToShortDateString(), oduncal.OduncAlmaTarihi.ToShortTimeString());

            if (kitaplistesi.Exists(x => x.KitapID == oduncal.oduncalınanID))
            {
                foreach (kitap bulID in kitaplistesi)
                {
                    if (bulID.KitapSayisi >= bulID.KitapSayisi - oduncal.oduncAlmaSyisi && bulID.KitapSayisi - oduncal.oduncAlmaSyisi >= 0)
                    {
                        if (bulID.bookID == oduncal.oduncalınanID)
                        {
                            bulID.KitapSayisi = bulID.KitapSayisi - oduncal.oduncalınanID;

                            break;

                        }
                    }



                    else
                    {
                        Console.WriteLine("Sadece {0} kitap bulundu", bulID.KitapSayisi);
                        break;
                    }

                }

            }
            else
            {
                Console.WriteLine("Kitap ID si {0} bulunnamadı", oduncal.oduncalınanID);

            }
            oduncAlınans.Add(oduncal);
        }

        public static void IadeEt()
        {
            kitap kitap = new kitap();
            Console.WriteLine("Lütfen ayrıntıları girin: ");
            Console.WriteLine("Kitap ID si: ");
            int returnID = int.Parse(Console.ReadLine());

            Console.WriteLine("Kitap Sayısı: ");
            int returnCount = int.Parse(Console.ReadLine());

            if (kitaplistesi.Exists(y => y.KitapID == returnID))
            {
                foreach (kitap addReturnBookCount in kitaplistesi)
                {
                    if (addReturnBookCount.x >= returnCount + addReturnBookCount.KitapSayisi)
                    {
                        if (addReturnBookCount.KitapID == returnID)
                        {
                            addReturnBookCount.KitapSayisi = addReturnBookCount.KitapSayisi + returnCount;
                            break;

                        }
                    }
                    else
                    {
                        Console.WriteLine("Gerçek sayı belirtiniz!");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Kitap ID si {0} bulunamadı", returnID);
            }
        }
    }
}
