using System;
using System.Collections.Generic;

namespace Proje
{
    class Program
    {
        static void Main(string[] args)
        {
            string TCno;
            string ad, soyad, doktor, hastalık, ilaç;
            Hasta.Liste hastaListesi = new Hasta.Liste();


            hastaListesi.sonaEkle(TCno = "46573806740", ad = "Hiranur", soyad = "Sazak",
                doktor = "Dr. Ömer Kaplan", hastalık = "Nezle", ilaç = "Theraflu Forte");
            hastaListesi.sonaEkle(TCno = "23746982347", ad = "Nisa Nur", soyad = "Özdal",
                doktor = "Dr. Ali Nazmican Güröz", hastalık = "Menisküs Yırtığı", ilaç = "Paraflex 20 Komprime");
            hastaListesi.sonaEkle(TCno = "89374938243", ad = "Nisa Gül", soyad = "Ünal",
                doktor = "Dr. Bekir Borazan", hastalık = "Gastroenteroloji", ilaç = "Laksafenol");
            hastaListesi.sonaEkle(TCno = "98723424674", ad = "Berfin", soyad = "Geleş",
                doktor = "Dr. Pınar İnan", hastalık = "Göz Enfeksiyonu", ilaç = "BlefariTTO Göz Jeli 20 ml");
            Console.WriteLine("\n...Kimlikle Sorgulama...");

            Console.Write("TCno: ");
            string tc = Console.ReadLine();
            Hasta hasta = hastaListesi.hastaBul(tc);

            if (hasta != null)
            {
                Console.WriteLine($"Hasta Bilgileri:\nAd: {hasta.ad} {hasta.soyad}\n" +
                                  $"Doktor: {hasta.doktor}\n" +
                                  $"Hastalık: {hasta.hastalık}\n" +
                                  $"Alması Gereken İlaçlar: {hasta.ilaç}");
            }
            else
            {
                Console.WriteLine("Hasta bulunamadı.");
            }
            Console.ReadKey();
        }
    }
}
class Hasta   // Node 
{
    public string TCno;
    public string ad, soyad, doktor, hastalık, ilaç;
    public Hasta next;
    public Hasta prev;
    public Hasta head;

    public Hasta(string tc, string a, string s, string d, string h, string i)
    {
        this.TCno = tc;
        this.ad = a;
        this.soyad = s;
        this.doktor = d;
        this.hastalık = h;
        this.ilaç = i;
    }
    public class Liste //Çift bağlı dairesel liste sınıfı
    {
        private int Count;
        public Hasta head;
        public Hasta tail;

        public Liste()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public void sonaEkle(string tc, string a, string s, string d, string h, string i)
        {
            Hasta yeniHasta = new Hasta(tc, a, s, d, h, i);

            yeniHasta.TCno = tc;
            yeniHasta.ad = a;
            yeniHasta.soyad = s;
            yeniHasta.doktor = d;
            yeniHasta.hastalık = h;
            yeniHasta.ilaç = i;

            if (head == null)
            {
                head = yeniHasta;
                tail = yeniHasta;
                head.next = tail;
                head.prev = tail;
                tail.next = head;
                tail.prev = head;
            }
            else
            {
                tail.next = yeniHasta;
                yeniHasta.prev = tail;
                yeniHasta.next = head;
                head.prev = yeniHasta;
                tail = yeniHasta;
            }

            Count++;


        }
        public Hasta hastaBul(string tc)
        {
            if (head == null)
            {
                Console.WriteLine("Listede kayıtlı hasta yok !");
                return null;
            }
            else
            {
                Hasta temp = head;
                do
                {
                    if (temp.TCno == tc)
                    {
                        return temp;
                    }
                    temp = temp.next;
                } while (temp != head);

                return null; // Hasta bulunamadı
            }
        }
    }
}