//ön-tanımlı kullanıcıların bildirilmesi
Dictionary<int, string> takimUyeleri = new(); //kullanıcıların tutulacağı listenin tanımlanması
takimUyeleri.Add(0, "NONE");
takimUyeleri.Add(1, "Mehmet");
takimUyeleri.Add(61, "Onur");

//uygulama katagorilerinin tanımlanması
List<Kart> toDo = new();
List<Kart> inProgress = new();
List<Kart> done = new();

Arayuz arayuz; // ön-tanımlı ifadelerin kullanılması için genel bir arayüz değişkeni

while(true)
{
    arayuz.Navigasyon(out int navCevap);
    switch(navCevap)
    {
        case 1:
            arayuz.Baslik("TODO");
            toDo.TumunuGoster();
            arayuz.Baslik("IN PROGRESS");
            inProgress.TumunuGoster();
            arayuz.Baslik("DONE");
            done.TumunuGoster();
            break;

        case 2: //alınan bilgiler doğrultusunda oluşturulan Kart elemanı belirtilen(varsayılan todo) listeye eleman olarak eklenmesi            
            arayuz.Degerİste("katagori(todo/inprogress/done)", out string eklenecekKartinKatagorisi);
            switch(eklenecekKartinKatagorisi)
            {
                case "todo":
                    toDo.Ekle(takimUyeleri);
                    break;
                
                case "inprogress":
                    inProgress.Ekle(takimUyeleri);
                    break;
                
                case "done":
                    done.Ekle(takimUyeleri);
                    break;
            }
            break;

        case 3:
            arayuz.KartBilgisiIste("silmek", "başlık", out string silinecekKart);
            silinecekKart.Sil(out bool kartSilindi, toDo, inProgress, done);
            while(kartSilindi == false)
            {
                arayuz.KartBulunamadi(out int silmeGerceklesmediCevap);
                if(silmeGerceklesmediCevap == 2)
                {
                    arayuz.KartBilgisiIste("silmek", "başlık", out string silinecekKartTekrar);
                    silinecekKartTekrar.Sil(out bool silmeDurumuTekrar, toDo, inProgress, done);
                    kartSilindi = silmeDurumuTekrar; //eğer bir silme başarıyla gerçekleşirse tekrardan silme işlemi sorulmamaması için gerekli atama
                }
                else
                    break; //2 haricinde ki girdiler tekrardan silme işleminin istenmediği manasında algılanır
            }
            break;

        case 4:
            arayuz.KartBilgisiIste("güncellemek", "başlık", out string guncellencekKartBasligi);
            arayuz.Degerİste("güncellemek istediğiniz özelliğin(baslik, icerik)", out string degisecekOzellik);
            arayuz.Degerİste("yeni", out string yeniDeger);
            guncellencekKartBasligi.Guncelle(degisecekOzellik, yeniDeger, toDo, inProgress, done);
            
            break;

        case 5:
            arayuz.KartBilgisiIste("taşımak", "başlık", out string tasinacakKart);
            arayuz.Degerİste("taşınacak katagori(todo/inprogress/done)", out string KartinYeniKatagorisi);
            switch(KartinYeniKatagorisi)
            {
                case "todo":
                    tasinacakKart.Tasi(toDo, toDo, inProgress, done);
                    break;
                
                case "inprogress":
                    tasinacakKart.Tasi(inProgress, toDo, inProgress, done);
                    break;
                    
                case "done":
                    tasinacakKart.Tasi(done, toDo, inProgress, done);
                    break;
            }
            break;
    }
}