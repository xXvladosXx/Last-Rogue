using Code.Infrastructure.View;
using Entitas;

namespace Code.Common
{
    public class CommonComponents
    {
        [Game] public class Destructed : IComponent { }
        [Game] public class View : IComponent { public IEntityView Value; }
        [Game] public class SelfDestructTime : IComponent { public float Value; }
    }
}