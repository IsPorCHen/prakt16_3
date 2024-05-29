using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prakt16_4
{
    public class Country
    {
        private string Name;
        private long Population;

        public string NameValue
        {
            get { return Name; }
            set { Name = value; }
        }

        public long PopulationValue
        {
            get { return Population; }
            set { Population = value; }
        }

    }
}
