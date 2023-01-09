namespace PvKviz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "text.txt";
            StreamWriter streamWriter = new StreamWriter(filePath, true);
            string line;
            int body = 0;
            int otazky = 0;

            bool zadavaniOtazek = true;
            bool mazaniOtazek = true;
            while (zadavaniOtazek)
            {
                Console.WriteLine("Chcete pridat otazku do souboru? ano/ne");
                string odpoved = Console.ReadLine();
                if (odpoved != "ne" && odpoved != "ano")
                {
                    Console.WriteLine("Nenapsal si ano nebo ne\n");
                }
                if (odpoved == "ne")
                {
                    zadavaniOtazek = false;
                    Console.WriteLine();
                }
                if (odpoved == "ano")
                {
                    Console.WriteLine("Napis otazku");
                    string veta = Console.ReadLine();
                    streamWriter.WriteLine(veta);
                    Console.WriteLine("Napis spravnou odpoved");
                    string veta2 = Console.ReadLine();
                    streamWriter.WriteLine(veta2);
                    Console.WriteLine();
                }
            }

            streamWriter.Close();
            StreamReader reader = new StreamReader(filePath);
            List<string> vsechnyOtazky = new List<string>();
            while ((line = reader.ReadLine()) != null)
            {
                vsechnyOtazky.Add(line);
            }

            int pocetOtazek = 0;
            while (mazaniOtazek)
            {
                Console.WriteLine("Chcete smazat nejakou z otazek z momentalniho kvizu? ano/ne");
                string odpoved = Console.ReadLine();
                if (odpoved != "ne" && odpoved != "ano")
                {
                    Console.WriteLine("Nenapsal si ano nebo ne\n");
                }
                if (odpoved == "ne")
                {
                    mazaniOtazek = false;
                    Console.WriteLine();
                }
                if (odpoved == "ano")
                {
                    Console.WriteLine();
                    for(int i = 0; i<vsechnyOtazky.Count;i++)
                    {
                        if (i % 2 == 1) continue;
                        pocetOtazek++;
                        Console.WriteLine(vsechnyOtazky.ElementAt(i) + " | " + pocetOtazek);
                        string skip = reader.ReadLine();

                    }
                    Console.WriteLine("\nNapis cislo otazky, kterou chces smazat");
                    string answer = Console.ReadLine();
                    int nAnswer = Convert.ToInt32(answer) *2;
                    vsechnyOtazky.RemoveAt(nAnswer-1);
                    vsechnyOtazky.RemoveAt(nAnswer-2);

                }
            }

            Console.WriteLine("---------------------------------\n           Kviz zacina");

            for (int i = 0; i < vsechnyOtazky.Count;i +=2)
            {
                string odpoved = "";

                Console.WriteLine("---------------------------------\n" + vsechnyOtazky.ElementAt(i));
                odpoved = Console.ReadLine();
                
                if (odpoved.Equals(vsechnyOtazky.ElementAt(i+1)))
                {
                    Console.WriteLine("\nSpravna odpoved");
                    body++;
                    otazky++;
                }
                else
                {
                    Console.WriteLine("\nSpatna odpoved");
                    otazky++;
                }
            }
            Console.WriteLine("\n-------------------------------------\nMas bodu: " + body + "\n" +
                "Celkem moznych dosazitelnych bodu: " + otazky + "\n-------------------------------------\n\n");
            reader.Close();
        }
    }
}