using System.Collections.Generic;

namespace Code.Gameplay.Features.CharacterStats.Indexing
{
    public class StatKeyComparer : IEqualityComparer<StatKey>
    {
        public bool Equals(StatKey x, StatKey y)
        {
            return x.TargetId == y.TargetId && x.Stat == y.Stat;
        }

        public int GetHashCode(StatKey obj)
        {
            return obj.TargetId.GetHashCode() ^ obj.Stat.GetHashCode();
        }
    }
}