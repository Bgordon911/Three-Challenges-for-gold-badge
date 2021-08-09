using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeRepo
{
   public class Badge
    {
        public int BadgeID { get; set; }

        public List<string> Doors { get; set; } = new List<string>();

        public string AnameForthebadge { get; set; }

        public Badge() { }

        public Badge(int badgeID, List<string> doors, string anameForthebadge)
        {
            BadgeID = badgeID;
            Doors = doors;
            AnameForthebadge = anameForthebadge;
        }
    }
}
         
       
  
