using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement
{
    internal class Kompania
    {
        List<Punetori> punetoret = new List<Punetori>();
        List<Lideri> lideret = new List<Lideri>();
        Lideri l = null;
        List<Projekti> projektet = new List<Projekti>();
        List <Task> tasqet = new List<Task>();

        List<Task> TasqetSortuara = new List<Task>();
        public void RegjistroKompanine()
        {
            Console.Write("\nSheno emrin e menaxherit:  ");
            string emri = Console.ReadLine();

            Console.Write("\nSheno mbiemrin e menaxherit:  ");
            string mbiemri = Console.ReadLine();

            Console.Write("\nSheno numrin identifikues per menaxherin:  ");
            int idMenaxherit = int.Parse(Console.ReadLine());
            
            Menaxheri menaxheri = new Menaxheri(idMenaxherit, emri, mbiemri);


            Console.Write("\nSheno numrin e lidereve ne kompani:  ");
            int nrLidereve= int.Parse(Console.ReadLine());

            while (nrLidereve > 0)
            {
                Console.Write("\nSheno emrin e liderit:  ");
                string emriLiderit = Console.ReadLine();

                Console.Write("\nSheno mbiemrin e liderit:  ");
                string mbiemriLiderit = Console.ReadLine();

                Console.Write("\nSheno numrin identifikues per liderin:  ");
                int nrIdLiderit = int.Parse(Console.ReadLine());

                Lideri lideri = new Lideri(nrIdLiderit, emriLiderit, mbiemriLiderit);

                if (!lideret.Contains(lideri))
                {
                    lideret.Add(lideri);
                }

                nrLidereve--;
            }

            Console.Write("\nSheno numrin e punetoreve ne kompani:  ");
            int nrPunetoreve = int.Parse(Console.ReadLine());

            
            while (nrPunetoreve > 0)
            {
                Console.Write("\nSheno emrin e punetorit:  ");
                string emriPunetorit = Console.ReadLine();

                Console.Write("\nSheno mbiemrin e punetorit:  ");
                string mbiemriPunetorit = Console.ReadLine();

                Console.Write("\nSheno id-ne e punetorit:  ");
                int idPunetorit = int.Parse(Console.ReadLine());

                Console.Write($"\nSheno id-ne e liderit per punetorin {emriPunetorit} {mbiemriPunetorit}:  ");
                int idLideritPerPunetorin = int.Parse(Console.ReadLine());
               
                foreach (var lider in lideret)
                {
                    if (lider.ID == idLideritPerPunetorin)
                    {
                        l = lider;
                    }
                }

                Punetori punetori = new Punetori(idPunetorit, emriPunetorit, mbiemriPunetorit, l);

                if (!punetoret.Contains(punetori))
                {
                    punetoret.Add(punetori);
                }

                nrPunetoreve--;
            }
        }

        public void Kyqu()
        {
            Console.Write("\nCili eshte roli juaj ne kompani:  ");
            string roli = Console.ReadLine();

            if (roli == "menaxher".ToLower().Trim())
            {
                OpsionetPerMenaxherin();               
            }
            if (roli == "lider".ToLower().Trim())
            {
                OpsionetPerLiderin();
            }
            if (roli == "punetor".ToLower().Trim())
            {
                OpsionetPerPunetorin();
            }
        }

        public void OpsionetPerMenaxherin()
        {
            string opsionet="\n1 --> Shto projekt\n2 --> Fshij projekt\n3 --> Shiko te gjitha projektet\n4 --> Perfundo";
            Console.WriteLine(opsionet);
            int komanda = int.Parse(Console.ReadLine());

            if (komanda == 1)
            {
                Console.Write("\nSa projekte doni te shtoni:  ");
                int nrProjekteve = int.Parse(Console.ReadLine());

                while (nrProjekteve > 0)
                {
                    ShtoProjekt();
                    nrProjekteve--;
                }
                Console.WriteLine($"{opsionet}");
                komanda = int.Parse(Console.ReadLine());
            }
            if (komanda == 2)
            {
                string fshijProjekt="\nSheno emrin e projektit qe doni te fshini:  ";
                Console.WriteLine(fshijProjekt);
                string emriProjektitPerFshirje = Console.ReadLine();

                foreach (var projekt in projektet)
                {
                    if (projekt.name.ToLower().Trim() == emriProjektitPerFshirje.ToLower().Trim())
                    {
                        projektet.Remove(projekt);
                        Console.WriteLine($"Projekti {projekt.name} u fshi me sukses! ");
                        break;
                    }
                }
                Console.WriteLine($"{opsionet}");
                komanda = int.Parse(Console.ReadLine());

            }
            if (komanda == 3)
            {
                string shfaq="\nTe gjitha projektet: ";
                Console.WriteLine(shfaq);
                foreach (var projekt in projektet)
                {
                    Console.WriteLine($"{projekt}");
                }
                Console.WriteLine(opsionet);
                komanda=int.Parse(Console.ReadLine());
            }
            if (komanda == 4)
            {
                Kyqu();
            }
        }
        public void OpsionetPerLiderin()
        {
            string opsionet = "\n1 --> Shfaq projektete qe i ka caktuar menaxheri\n2 --> Shto tasqe dhe cakto punetoreve ato\n3 --> Perfundo";
            Console.WriteLine(opsionet);
            int komanda = int.Parse(Console.ReadLine());
            if (komanda == 1)
            {
                Console.Write("\nSheno id-ne tuaj:  ");
                int idLiderit=int.Parse(Console.ReadLine());
                foreach (var projekti in projektet)
                {
                    if (idLiderit == projekti.Lideri.ID)
                    {
                        Console.WriteLine(projekti);
                    }
                    else
                    {
                        Console.Write("\nNuk keni asnje projekt per te perfunduar! ");
                    }
                }
            }
            if (komanda == 2)
            {
                Console.Write("\nSa tasqe doni te shtoni:  ");
                int nrTasqeve = int.Parse(Console.ReadLine());

                Punetori p = null;
                while(nrTasqeve > 0)
                {
                    Console.Write("\nSheno id e taskut:  ");
                    int idTaskut = int.Parse(Console.ReadLine());

                    Console.Write("\nSheno pershrimin e taskut:  ");
                    string pershkrimi = Console.ReadLine();

                    Console.Write("Sheno daten e fillimit te taskut ne formatin \"dd-MM-yyyy\":  ");
                    string dataFillimitTaskut = Console.ReadLine();
                    DateTime dataFillimitTaskutConv = DateTime.ParseExact(dataFillimitTaskut, "dd-MM-yyyy", null);

                    Console.Write("Sheno daten e mbarimit te taskut ne formatin \"dd-MM-yyyy\":  ");
                    string dataMbarimitTaskut = Console.ReadLine();
                    DateTime dataMbarimitTaskutConv = DateTime.ParseExact(dataFillimitTaskut, "dd-MM-yyyy", null);

                    Console.WriteLine("Sheno id e punetorit per kete task:  ");
                    int idPuntoritPerTaskun = int.Parse(Console.ReadLine());
                    foreach (var punetor in punetoret)
                    {
                        if (punetor.ID == idPuntoritPerTaskun)
                        {
                            p = punetor;
                        }
                        else
                        {
                            Console.WriteLine("Punetori nuk ekziston!");
                        }
                    }
                    Task tasku = new Task(idTaskut,pershkrimi, dataFillimitTaskutConv, dataMbarimitTaskutConv,p);
                    if (!tasqet.Contains(tasku))
                    {
                        tasqet.Add(tasku);
                    }
                    nrTasqeve--;
                }
            }
            if (komanda == 3)
            {
                Kyqu();
            }
        }

        int idPunetorit;


        List<Task> tasqetPasortuara = new List<Task>();
        public void OpsionetPerPunetorin()
        {
            Task t = null;
            Punetori p = null;
            Console.Write("\nShenoni id tuaj:  ");
            idPunetorit= int.Parse(Console.ReadLine());
            foreach (var punetor in punetoret)
            {
                if (punetor.ID == idPunetorit)
                {
                    p = punetor;
                }
            }
            string opsionet = "\n1 --> Shiko te gjitha tasqet\n2 --> Shiko tasqet sipas prioritetit\n3 --> Raporto per bug\n4 --> Perfundo";
            Console.WriteLine("\n{opsionet}");
            int komanda = int.Parse(Console.ReadLine());

            if (komanda == 1)
            {
                ShikoTasqetPerPuntorin();
            }
            if(komanda == 2)
            {
                Console.WriteLine("Tasqet e parenditura me prioritet:  ");
                ShikoTasqetPerPuntorin();

                Console.WriteLine("Tasqet e renditura me prioritet:  ");
                CaktoPrioritetin(tasqetPasortuara);
                PrintoTasqetSortuara();
            }
            if (komanda == 3)
            {
                Console.WriteLine("Sheno id e taskut qe deshironi te raportoni:  ");
                int idTaskut = int.Parse(Console.ReadLine());               

                foreach (var task in tasqet)
                {
                    if (task.taskID == idTaskut)
                    {
                        t = task;
                        break;
                    }
                }
                Console.WriteLine("Sheno bug-in per taskun:  ");
                string bug = Console.ReadLine();

                t.bug = bug;

                Console.WriteLine("Bug u raportua! ");
            }
            if (komanda == 4)
            {
                Kyqu();
            }
        }

        public List<Task> ShikoTasqetPerPuntorin()
        {
            foreach (var task in tasqet)
            {
                if (task.punetori.ID == idPunetorit)
                {
                    if (!tasqetPasortuara.Contains(task))
                    {
                        tasqetPasortuara.Add(task);
                    }
                    else
                    {
                        continue;
                    }
                    
                    Console.WriteLine(task);
                }
                else
                {
                    Console.WriteLine("Nuk keni tasqe te paracaktuara! ");
                }
            }
            return tasqetPasortuara;
        }
        public void CaktoPrioritetin(List<Task> tasqet)
        {
            Task taskuMePrioritetMeTeLarte = null;
            TimeSpan time = TimeSpan.Zero;
            bool firsttime = true;

            foreach (var task in tasqet)
            {
                if (firsttime)
                {
                    taskuMePrioritetMeTeLarte = task;
                    time = task.endDate - task.startDate;
                    firsttime = false;
                }
                TimeSpan t1 = task.endDate - task.startDate;
                if (time > t1)
                {
                    time = task.endDate - task.startDate;
                    taskuMePrioritetMeTeLarte = task;
                }
            }
            TasqetSortuara.Add(taskuMePrioritetMeTeLarte);
            tasqet.Remove(taskuMePrioritetMeTeLarte);

            while (tasqet.Count != 0)
            {
                CaktoPrioritetin(tasqet);
            }
        }
        public void PrintoTasqetSortuara()
        {
            Console.WriteLine("Tasqet e renditura sipas prioritetit qe duhet te kryhen : ");
            for (int i = 0; i < TasqetSortuara.Count; i++)
            {
                Console.WriteLine($"{i + 1} --> {TasqetSortuara[i]}");
            }
        }
        public Projekti ShtoProjekt()
        {
            
            Console.Write("\nSheno id-ne e projektit:  ");
            int idProjektit = int.Parse(Console.ReadLine());

            Console.Write("\nSheno emrin e projektit:  ");
            string emriProjektit = Console.ReadLine();

            Console.Write("\nSheno daten e fillimit te projektit ne formatin \"dd-MM-yyyy\":  ");
            string dataFillimitProjektit = Console.ReadLine();
            DateTime dataFillimitProjektitConv = DateTime.ParseExact(dataFillimitProjektit, "dd-MM-yyyy", null);

            Console.Write("\nSheno daten e mbarimit te projektit ne formatin \"dd-MM-yyyy\":  ");
            string datatMbarimitProjekti = Console.ReadLine();
            DateTime dataMbarimitProjektitConv = DateTime.ParseExact(datatMbarimitProjekti, "dd-MM-yyyy", null);

            Console.Write("\nCakto liderin per projekt ne baze te id-se se tij:  ");
            int idLideritPerProjekt = int.Parse(Console.ReadLine());

            foreach (var lideri in lideret)
            {
                if (idLideritPerProjekt == lideri.ID)
                {
                    l = lideri;
                }
            }
            Projekti p = new Projekti(idProjektit, emriProjektit, dataFillimitProjektitConv, dataMbarimitProjektitConv, l);
            
            if (!projektet.Contains(p))
            {
                projektet.Add(p);
            }
            
            return p;
        }
    }
}
