using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement
{
    public class Menaxheri : Personi
    {
        public List<Task> TasqetSortuara = new List<Task>();
        public List<Lideri> lideret { get; set; }
       
        List<Goal> qellimet=new List<Goal>();

        public Menaxheri(int id, string emri, string mbiemri) : base(id, emri, mbiemri)
        {






        }
        public override string pozita()
        {
            return "Menaxher";
        }       

        public void shtoQellimet(Goal g)
        {

            if (qellimet.Contains(g))
            {
                Console.WriteLine("Egziston qellimi ---> "+g.ToString());
            }

            else if (g==null)
            {
                Console.WriteLine("Vlerat null nuk lejohen");
            }

            else
            {
                qellimet.Add(g);    
            }

        }

        public void shtypQellimet()
        {
            foreach (var item in qellimet)
            {
                Console.WriteLine(item);
            }
        }
       
    }
}
