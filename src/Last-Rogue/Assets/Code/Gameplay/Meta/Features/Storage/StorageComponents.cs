using Code.Infrastructure.Progress;
using Entitas;

namespace Code.Gameplay.Meta.Features.Storage
{
     [Meta] public class Storage : ISavedComponent { }
     [Meta] public class Gold : ISavedComponent { public float Value; }
     [Meta] public class GoldPerSecond : ISavedComponent { public float Value; }
}