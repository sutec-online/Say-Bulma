using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _1._2sayıbulma
{
    class SkorYonetimi
    {
        public string dosyayolu { get; set; }
        public FileStream filestream;
        public StreamReader streamreader;

        public SkorYonetimi(string dosyayolu)
        {
            this.dosyayolu = dosyayolu;
        }

        public void SkorYaz(int skor)
        {
            filestream = new FileStream(dosyayolu, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            streamreader = new StreamReader(filestream, Encoding.GetEncoding("iso-8859-9"));

            List<string> skorlar = new List<string>();

            while (true)
            {
                string satir = streamreader.ReadLine();

                if (satir == null)
                    break;

                skorlar.Add(satir);
            }

            skorlar.Add(skor.ToString());

            streamreader.Close();
            filestream.Close();

            File.Delete(dosyayolu);
            FileStream fs = new FileStream(dosyayolu, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < skorlar.Count; i++)
            {
                sw.WriteLine(skorlar[i]);
            }

            sw.Close();
            fs.Close();
        }
    }
}
