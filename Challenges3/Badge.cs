using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges3
{
   public class Badge
    {

        public Badge () { }

        public int BadgeID { get; set; }

        public List<string> Doors = new List<string>();



        public Badge(int badgeID, List<string> doors)
        {
            BadgeID = badgeID;
            Doors = doors;
        }

        


    }

    
}
