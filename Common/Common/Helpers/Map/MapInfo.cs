using System.Collections.Generic;
using System.Reflection;

namespace Common.Helpers.Map
{
    public class MapInfo
    {
        public Dictionary<string, MemberInfo> From { get; set; }
        public Dictionary<string, MemberInfo> To { get; set; }
        public Dictionary<string, string> FromTo { get; set; }
        public Dictionary<string, string> ToFrom { get; set; }

        public MapInfo()
        {
            From = new Dictionary<string, MemberInfo>();
            To = new Dictionary<string, MemberInfo>();
            FromTo = new Dictionary<string, string>();
            ToFrom = new Dictionary<string, string>();
        }

        public void AddMap(MemberInfo ma, MemberInfo mb)
        {
            From[ma.Name] = ma;
            To[mb.Name] = mb;
            FromTo[ma.Name] = mb.Name;
            ToFrom[mb.Name] = ma.Name;
        }
    }
}
