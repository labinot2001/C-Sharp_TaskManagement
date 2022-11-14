using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement
{
    public class Lideri: Personi
    {
        public Menaxheri menaxheri { get; set; }
        public List<Punetori> punetoret { get; set; }
        public List<Task> tasqet { get; set; }

        public void ShtoTask(Task tasku)
        {
            if (tasku != null && !tasqet.Contains(tasku))
            {
                tasqet.Add(tasku);
            }
        }

        public void RemoveTask(Task tasku)
        {
            if (tasqet.Contains(tasku))
            {
                tasqet.Remove(tasku);
            }
        }

        public override string pozita()
        {
            return "Lider";
        }

        public Lideri(int id, string emri, string mbiemri) : base(id, emri, mbiemri)
        {
         
        }

       
    }
}
