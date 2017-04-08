using System;
using System.Collections.Generic;

namespace _1._2sayıbulma
{
    class RandomSayi
    {
        bool tekrardurum;
        int basamak;
        List<int> uretilen;
        Random random = new Random();
        private static RandomSayi nesne;

        public RandomSayi()
        {

        }

        public void DegiskenAyarla(int basamak, bool tekrardurum)
        {
            this.basamak = basamak;
            this.tekrardurum = tekrardurum;
        }

        public static RandomSayi NesneAl()
        {
            if (nesne == null)
                nesne = new RandomSayi();

            return nesne;
        }

        public List<int> Uret()
        {
            if (tekrardurum)
                TekrarliUret();
            else
                TekrarsizUret();

            return uretilen;
        }

        private void TekrarliUret()
        {
            uretilen = new List<int>();

            for (int i = 0; i < basamak; i++)
            {
                uretilen.Add(random.Next(0, 10));
            }
        }

        private void TekrarsizUret()
        {
            uretilen = new List<int>();

            for (int i = 0; i < basamak; i++)
            {
                int randomuretilen = random.Next(0, 10);

                if (uretilen.IndexOf(randomuretilen) == -1)
                    uretilen.Add(randomuretilen);
                else
                    i--;
            }
        }
    }
}
