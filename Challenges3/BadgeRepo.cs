using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges3
{
    public class BadgeRepo
    {
        public Dictionary<int, List<string>> _badgeAndDoor = new Dictionary<int, List<string>>();


        public Dictionary<int, List<string>> SeeBadgeList()
        {
            return _badgeAndDoor;
        }





        public Badge GetBadgeByID(int badgeID)
        {
            foreach (var badge in _badgeAndDoor)
            {
                if (badge.Key == badgeID)
                {
                    Badge newBadge = new Badge(badge.Key, badge.Value);
                    return newBadge;
                }
            }
            return null;
        }



        public void AddDoor(int badgeID, string doorID)
        {
            _badgeAndDoor[badgeID].Add(doorID);
        }

        public void EraseAllDoors(int badgeID)
        {
            _badgeAndDoor[badgeID].Clear();
        }


        public void NewBadge(int badgeID)
        {
            List<string> doors = new List<string>();
            Badge newBadge = new Badge(badgeID, doors);

            _badgeAndDoor.Add(newBadge.BadgeID, newBadge.Doors);


        }

        public void RemoveDoor(int badgeID, string door)
        {
            _badgeAndDoor[badgeID].Remove(door);
        }


        public bool HasKey(int key)
        {
            bool validKey = _badgeAndDoor.ContainsKey(key);
            if (validKey)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
