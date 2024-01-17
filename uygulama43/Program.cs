using System.Diagnostics.SymbolStore;

namespace uygulama43
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaslangicMesajiYaz();
            #region Calisan sinif bilgisi isteyip temel maaş hesabı
            string calisanSinifiGirisi;
            double ekMesaiUcreti;
            double temelMaas;
            double totalMaas;
            do {
                
                Console.Write("Çalışan Sınıfını Giriniz (Cirak,Kalfa,Usta) : ");
                calisanSinifiGirisi = Console.ReadLine();
                if(calisanSinifiGirisi == "Cirak"|| calisanSinifiGirisi == "Kalfa"|| calisanSinifiGirisi == "Usta") break;
            } while (true);
            temelMaas=CalisanSinifMaasiBelirle(calisanSinifiGirisi);
            #endregion

            #region Ek mesai Var mı? Yok mu?
            char calisanMesaisiVarMi;
            do
            {
                Console.WriteLine("Ek Mesai Girişi olacak mı? Y/N");
                try
                {
                    calisanMesaisiVarMi = Convert.ToChar(Console.ReadLine());
                    if (calisanMesaisiVarMi == 'Y' || calisanMesaisiVarMi == 'N') break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Lütfen Tek Harf Giriniz!!!");
                   
                }
            } while (true);
           
            if (calisanMesaisiVarMi == 'N')
            {
                Console.WriteLine("Mesai yoktur.");
                Console.WriteLine("Maaş : " + temelMaas);
            }
            else if (calisanMesaisiVarMi == 'Y') 
            { 
                EkMesaiBilgiriIste(out string haftaBilgisi, out double ekMesaiSaati);
                ekMesaiUcreti = CalisanEkMesaisiHesapla(temelMaas, haftaBilgisi, ekMesaiSaati);
                totalMaas =temelMaas+ekMesaiUcreti;
                Console.WriteLine($"Temel Maaş : {temelMaas} Ek Mesai Ücreti : {ekMesaiUcreti} ve Total Ücret : {totalMaas}" );
            }
            #endregion


        }
        static void BaslangicMesajiYaz()
        {
            Console.WriteLine("---------------------------------------------------------------\n");
            Console.WriteLine("         AYLIK MAAŞ HESAPLAMA UYGULAMASINA HOŞGELDİNİZ\n");
            Console.WriteLine("---------------------------------------------------------------\n");
        }

        /// <summary>
        /// this Method calculate montly Slary
        /// </summary>
        /// <param name="calisanIsci">string type employee clasification</param>
        /// <returns>return double type</returns>
        /// <exception cref="Exception"></exception>
        static double CalisanSinifMaasiBelirle(string calisanIsci)
        {
            double maas = 3000;
            if (calisanIsci == "Cirak") return maas;
            else if (calisanIsci == "Kalfa") return maas * 1.5;
            else if (calisanIsci == "Usta") return maas * 3;
            else { throw new Exception("Bu işçi sınıfı işletmede bulunmamaktadır!!!!!");
            }
        }
        /// <summary>
        /// This Method takes overtime knowledge
        /// </summary>
        /// <param name="mesaiZaman">return weekday or weekend</param>
        /// <param name="mesaiSaati">return overtime in terms of hour</param>
        static void EkMesaiBilgiriIste(out string mesaiZaman, out double mesaiSaati)
        {



            //Haftaiçi-Haftasonu parametre girişi
            do
            {
                Console.WriteLine("Mesai Haftaici/Haftasonu mu?");
                mesaiZaman = Console.ReadLine();
                if (mesaiZaman == "Haftaici" || mesaiZaman == "Haftasonu") break;

            } while (true);

            //Mesai Saat Girişi ve Kontrolü
            do
            {
                mesaiSaati = 1;
                try
                {
                    Console.WriteLine("Kaç Saat Mesai olduğunu Girininiz.[1-20]");
                    mesaiSaati = Int32.Parse(Console.ReadLine());
                    if (mesaiSaati > 0 && mesaiSaati < 21) break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Lütfen Reel Sayi Giriniz!!!");

                }

            } while (true);




        }
        /// <summary>
        /// This Method calculate overtime
        /// </summary>
        /// <param name="temelMaas">double type base salary</param>
        /// <param name="calisilanGun">string type weekday or weekend</param>
        /// <param name="ekMesaiSaati">overtime in terms of hour</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        static double CalisanEkMesaisiHesapla(double temelMaas,string calisilanGun,double ekMesaiSaati)
        {
            double saatlikUcret;
            double ekMesaiUcreti;
            saatlikUcret = temelMaas / 200;//Günlük 10 saat normal mesaiden haftalık 50 aylık 200 saat çalışıldığı hesaplanmıştır.
            if (calisilanGun == "Haftaici")
            {
                ekMesaiUcreti = saatlikUcret * 1.5 * ekMesaiSaati;
            }
            else if(calisilanGun == "Haftasonu")
            {
                ekMesaiUcreti = saatlikUcret * 2.0 * ekMesaiSaati;
            }
            else
            {
                throw new Exception("Mesai ucreti Hesaplanamadi");
            }
            return ekMesaiUcreti;
        }

      
    }
}