using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement
{
    public class Task
    {
        public int taskID { get; set; }
        public  string pershkrimi{ get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public Punetori punetori { get; set; }
        public string bug { get; set; } = "nuk ka bug";


        public Task(int id,string pershkrimi,DateTime startDate,DateTime endDate,Punetori p)
        {

            if (id<0 || pershkrimi.Trim().Equals("") || pershkrimi == null || p==null || startDate==null || endDate ==null)
            {

                throw new KompaniaException("Te dhenat e Task nuk u plotesuan mire!");
            }
            

            this.taskID = id; 
            this.pershkrimi = pershkrimi; 
            this.startDate = startDate;
            this.endDate = endDate;
            this.punetori = p;


        }

        public override string ToString()
        {
            return $"Tasku {taskID} -> {pershkrimi} kohezgjatja {startDate} - {endDate}, {bug}";
        }

        public override bool Equals(object obj)
        {

            if (obj is Task)
            {

                Task t= (Task)obj;

                if (taskID==t.taskID)
                {
                    return true;

                }
            }

            return false;
        }

    }
}
