using System.Collections.Generic;

namespace BadgeRepo
{

    public class BadRepository
    {
        //Create
        //Object were working with
        public Badge badge = new Badge();
        //Doors that badge can open
        public List<string> _doors = new List<string>();
        //Dictionary in badge to open door according to id
        private Dictionary<int, List<string>> _badges = new Dictionary<int, List<string>>();
        //List of all badges.
        private List<Badge> _listOfBadges = new List<Badge>();
        public Dictionary<int, List<string>> ReturnDictionary() { return _badges; }


        public bool AddToDictionary(Badge badge)
        {
            _badges.Add(badge.BadgeID, badge.Doors);
            _listOfBadges.Add(badge);
            return true;
        }

        //update
        public void AddDoorsByID(int badgeId, List<string> newDoorList)
        {
            //update badge in repo
            foreach(var badge in _listOfBadges)
            {
                if(badge.BadgeID == badgeId)
                {
                    badge.Doors = newDoorList;
                }
            }
            //update badge in dictionary
            _badges[badgeId] = newDoorList;
        }



        // Read
        public List<Badge> GetBadges()
        {
            return _listOfBadges;
        }

        // Delete
        //public bool RemovBadgesFromList(int badgeID)
        //{
        //    Badge badge = GetBadges(Badge);

        //    if (badge.BadgeID != badgeID)
        //    {
        //        return false;
        //    }

        //    int initialCount = _badges.Count;
        //    _badges.Remove(badgeID);

        //    if (initialCount > _badges.Count)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
            //Helper
            public Badge GetbadgebyNumber(int badgeNum)
            {
                foreach (Badge badge in _listOfBadges)
                {
                    if (badge.BadgeID == badgeNum)
                    {
                        return badge;
                    }
                }
                return null;
            }
        
    }
}