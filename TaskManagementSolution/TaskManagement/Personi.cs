using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement
{
    public abstract class Personi
    {

        public int ID { get; set; }
        public string emri { get; set; }
        public string mbiemri { get; set; }
        public string email { get; set; }

        public Personi(int id,string emri,string mbiemri) 
        {

            if (id<0)
            {
                throw new KompaniaException("id nuk mund te jete <0");

            }
            else if (emri.Trim().Equals("") || emri==null)
            {
                throw new KompaniaException("emri nuk mund te jete null ose i zbrazet");

            }
            else if (mbiemri.Trim().Equals("") || mbiemri == null)
            {

                throw new KompaniaException("mbiemri nuk mund te jete null ose i zbrazet");
            }
            else { 
            this.ID = id;   
            this.emri = emri;
            this.mbiemri = mbiemri;
            }
        }
        public abstract string pozita();



    }
}
