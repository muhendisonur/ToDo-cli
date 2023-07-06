public class Kart
{
    public Dictionary<int, string> uyeler = new(); //Program ortamında ki üyelerin üzerinde işlem yapabilmek için tanımlandı
    public string baslik {get; set;}
    public string icerik {get; set;}
    private int _kisiID;
    public int kisiID //kullanıcıdan girilen değer ön-tanımlı kullanıcılar arasında bulunuyorsa atama gerçekleşir bulunmuyorsa ön-tanımlı listede "none" karşılığı olan 0 indeksi atanır
    {
        get => _kisiID;
        set
        {
            if(uyeler.Keys.Contains(value))
            {   
                _kisiID = value;
            }
            else 
            {
                _kisiID = 0;
                System.Console.WriteLine("Hata: Girdiğiniz ID'ye Ait Üye Bulunamadı!");
            }

        }
    }
    private int _buyuklukID;
    public int buyuklukID
    {
        get => _buyuklukID;
        set
        {
            if(value > 5)
            {
                _buyuklukID = 0;
                System.Console.WriteLine("Hata: Büyüklük Değeri Bulunamadı!");
            }
            else
                _buyuklukID = value;
        }
    }
    public Buyuklukler buyuklukIsim;
    public string kisiIsim;
    public Kart(Dictionary<int, string> uyelerPara ,string baslikPara, string icerikPara, int kisiIDPara, int buyuklukIDPara) //kurucu metot
    {
        baslik = baslikPara;
        icerik = icerikPara;
        uyeler = uyelerPara;
        kisiID = kisiIDPara;
        kisiIsim = uyeler[_kisiID]; //_kisiID enkapsüle edilip kontrol altına alındı dolayısıyla hata alınmayacak
        buyuklukID = buyuklukIDPara;
        buyuklukIsim = (Buyuklukler)_buyuklukID; //_buyuklukID enkapsüle edilip kontrol altına alındı dolayısıyla casting hatası alınmayacak
    }
}

public static class KartIslemleri
{
    public static void Ekle(this List<Kart> listePara, Dictionary<int, string> uyeler)
    {
        Arayuz arayuz;

        arayuz.KartAlanlari(0);
        string baslik = Console.ReadLine();
        arayuz.KartAlanlari(1);
        string icerik = Console.ReadLine();
        
        int kisiID, buyuklukID;
        try
        {
            arayuz.KartAlanlari(4);
            kisiID = Convert.ToInt16(Console.ReadLine());
            arayuz.KartAlanlari(5);
            buyuklukID  = Convert.ToInt16(Console.ReadLine());
        }
        catch(FormatException)
        {
            throw new Exception("Geçerli değer girilmeli!");
        }
        catch(Exception)
        {
            throw new Exception("Hata!");
        }

        listePara.Add(new Kart(uyeler, baslik, icerik, kisiID, buyuklukID));
    }

    public static void Goster(this Kart eleman)
    {
        Arayuz arayuz;
        arayuz.KartAlanlari(0);
        System.Console.WriteLine(eleman.baslik);
        arayuz.KartAlanlari(1);
        System.Console.WriteLine(eleman.icerik);
        arayuz.KartAlanlari(2);
        System.Console.WriteLine(eleman.kisiIsim);
        arayuz.KartAlanlari(3);
        System.Console.WriteLine(eleman.buyuklukIsim);
        System.Console.WriteLine("******************************"); //ayıraç
    }

    public static void TumunuGoster(this List<Kart> listePara)
    {
        foreach(Kart item in listePara)
        {
            item.Goster();
        }
    }

    public static void Guncelle(this string guncellenecekKartBasligi, string degisecekOzellik, object yeniDeger, params List<Kart>[] elemaninAranacagiListeler) //başlığı verilen ifade kart olarak belirtilen tüm listelerde aranır ve seçilir. Yeni atanacak değer object türünde olduğu için duruma göre cast uygulandı
    {
        for(int i = 0; i < elemaninAranacagiListeler.Length; i++)
        {
            foreach(Kart item in elemaninAranacagiListeler[i])
            {
                if(item.baslik == guncellenecekKartBasligi)
                {
                    switch(degisecekOzellik)
                    {
                        case "baslik":
                            item.baslik = (string)yeniDeger;
                            // elemaninAranacagiListeler[i][elemaninAranacagiListeler[i].IndexOf(item)].baslik = (string)yeniDeger;
                            break;

                        case "icerik":
                            item.icerik = (string)yeniDeger;
                            break;
                    }
                    break; // aranan eleman bulunup işlem yapıldı, işlem yükünün artmasını engellemek için döngü kırılır
                }
            }
        }
    }

    public static void Sil(this string silinecekKartBasligi, out bool silmeGerceklesti, params List<Kart>[] liste) //sınırsız adette liste parametresi alarak her birinden ilgili kart başlığı kontrolüne göre listeden elemanı silmek
    {
        silmeGerceklesti = false;
        for(int i = 0; i< liste.Length; i++)
        {
            foreach(Kart item in liste[i])
            {
                if(item.baslik == silinecekKartBasligi)
                {
                    silmeGerceklesti = true;
                    liste[i].Remove(item);
                    break; // liste üzerinde değişiklik oluşacak dolayısıyla run-time erorr alınmaması için söz konusu listede silinme gerçekleşirse diğer listeler kontrol edilecek sırayla
                }
            }
        }
    }

    public static void Tasi(this string tasinacakKartBasligi, List<Kart> tasinilacakListe, params List<Kart>[] elemaninAranacagiListeler) //alınan başlık değerine sahip elemanı listelerde arayıp, bulup gerekli taşıma işlemini yapar
    {
        for(int i = 0; i < elemaninAranacagiListeler.Length; i++)
        {
            foreach(Kart item in elemaninAranacagiListeler[i])
            {
                if(item.baslik == tasinacakKartBasligi)
                {
                    elemaninAranacagiListeler[i].Remove(item);
                    tasinilacakListe.Add(item);
                    break; // aranan eleman bulunup işlem yapıldı, işlem yükünün artmasını engellemek için döngü kırılır
                }
            }
        }
    }
}