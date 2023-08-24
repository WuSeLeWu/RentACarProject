using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Model
{
    public static class Enums
    {
        public static class Roller
        {
            public static int WebYonetici = 1;
            public static int Musteri = 2;
            public static int Admin = 3;
            public static int MusteriTemsilcisi = 4;
            public static int SubeSorumlusu = 5;
        }

        public static class YakitTip
        {
            public static int Benzin = 1;
            public static int Dizel = 2;
            public static int Elektrik = 3;
            public static int LPG = 4;
        }

        public static class KartTip
        {
            public static int Visa = 1;
            public static int MasterCard = 2;
            public static int IsBankasi = 3;
            public static int Akbank = 4;
            public static int YapiKredi = 5;
            public static int PTT = 6;
        }


    }
}
