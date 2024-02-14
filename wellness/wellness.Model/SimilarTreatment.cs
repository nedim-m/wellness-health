using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace wellness.Model
{
    public class SimilarTreatment
    {
        public Treatment.Treatment Treatment { get; set; }
        public double Similarity { get; set; }
    }
}
