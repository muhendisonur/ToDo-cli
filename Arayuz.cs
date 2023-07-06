public struct Arayuz
{
    public void Bosluk(int boslukAdedi = 1)
    {
        for(int i = 0; i < boslukAdedi; i++)
        {
            System.Console.WriteLine("");
        }
    }

    public void Navigasyon(out int cevap)
    {
        Bosluk();
        System.Console.Write(
            "(1) Board Listelemek   \n" +
            "(2) Kart Ekleme        \n" +
            "(3) Kart Silmek        \n" +
            "(4) Kart Güncelle      \n" +
            "(5) Kart Taşı          \n" + 
            "Lütfen yapmak istediğiniz işlemi giriniz: "
        );

        try
        {
            cevap = int.Parse(Console.ReadLine());
        }
        catch(FormatException)
        {
            throw new FormatException("Geçerli değer girilmeli!");
        }
        catch(Exception)
        {
            throw new Exception("Hata!");
        }
    }

    public void KartAlanlari(int bilgiIndeksi)
    {
        string[] kartBilgileri = new string[6];
        kartBilgileri[0] = "Başlık\t: ";
        kartBilgileri[1] = "İçerik\t: ";      
        kartBilgileri[2] = "Kişi\t: ";
        kartBilgileri[3] = "Büyüklük: ";
        kartBilgileri[4] = "ID\t: ";
        kartBilgileri[5] = "Büyüklük Seçiniz -> XS(1), S(2), M(3), L(4), XL(5): ";

        System.Console.Write(kartBilgileri[bilgiIndeksi]);
    }

    public void Baslik(string kartTuru) //genel kullanım için bir başlık
    {
        Bosluk();
        System.Console.WriteLine("****************** {0} ******************", kartTuru);
    }

    public void KartBilgisiIste(string islemBilgisi, string kartBilgisi, out string cevap)
    {
        Bosluk();
        System.Console.Write(
            "Öncelikle {0} istediğiniz kartı seçmeniz gerekiyor.\n" +
            "Lütfen kart {1} yazınız: "
            ,islemBilgisi, kartBilgisi
            );
        cevap = Console.ReadLine();
    }

    public void KartBulunamadi(out int cevap)
    {
        Bosluk();
        System.Console.WriteLine(
            "Aradığınız kritelere uygun kart bulunamadı.\n" +
            "(1) İşlemi sonlandır\n" +
            "(2) Yeniden Dene\n" +
            "Lütfen bir seçim yapınız: "
        );

        try
        {
            cevap = int.Parse(Console.ReadLine());
        }
        catch(FormatException)
        {
            throw new FormatException("Geçerli değer girilmeli!");
        }
        catch(Exception)
        {
            throw new Exception("Hata!");
        }
    }

    public void Tasinacak(out int cevap)
    {
        Bosluk();
        System.Console.WriteLine(
            "(1) TODO\n" +
            "(2) IN PROGRESS\n" +
            "(3) DONE\n" +
            "Lütfen taşımak istediğiniz yeri seçin: "
        );
        
        try
        {
            cevap = int.Parse(Console.ReadLine());
        }
        catch(FormatException)
        {
            throw new FormatException("Geçerli değer girilmeli!");
        }
        catch(Exception)
        {
            throw new Exception("Hata!");
        }
    }

    public void Degerİste(string degerBasligi, out string cevap) //guncelleme isleminde yeni değer istenirken kullanılır
    {
        Bosluk();
        System.Console.Write("Lütfen {0} değerini giriniz: ", degerBasligi);
        cevap = Console.ReadLine();
    }
}