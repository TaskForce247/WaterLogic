using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Party
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Person> People { get; set; }

        public int AvailableSpots { get; set; }


        public override string ToString()
        {
            return string.Format("{0} Max:{1}", Title, AvailableSpots);
        }
    }
}
