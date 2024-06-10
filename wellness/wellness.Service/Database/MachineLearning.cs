using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Service.Database
{
    public class MachineLearning
    {
        public int Id { get; set; }
        public byte[] ModelData { get; set; }
        public DateTime TrainingTimestamp { get; set; }
    }

}
