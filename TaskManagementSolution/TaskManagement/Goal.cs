using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement
{
    public class Goal
    {


        public int id { get; set; }

        public String emri { get; set; }
        public string pershkrimi { get; set; }

        public Goal(int id, string emri,string pershkrimi)
        {

            if (id<0 || emri.Trim().Equals("") || emri==null || pershkrimi.Trim().Equals("") || pershkrimi == null)
            {
                throw new KompaniaException("Te dhenat e goals nuk u plotesuan mire !");

            }

            this.id = id;  
            this.emri = emri;
            this.pershkrimi = pershkrimi;   
        }




        public override string ToString()
        {
            return "Goal me id: " + id + " me emer, " + emri + ". \nPershkrimi: " + pershkrimi;
        }



    }
}
