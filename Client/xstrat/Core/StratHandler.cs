using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xstrat.Json;

namespace xstrat.Core
{
    public static class StratHandler
    {
        public static List<XMap> Maps = new List<XMap>();
        public static void Initialize()
        {
            Maps.Add(new XMap());
        }

        public static List<string> GetMapNames()
        {
            var list = new List<string>();
            foreach (var item in Maps)
            {
                list.Add(item.Name);
            }
            return list;
        }

        public static List<(string, string)> getFloorsByListPos(int position)
        {
            return Maps[position].getFloors();
        }
    }
}
