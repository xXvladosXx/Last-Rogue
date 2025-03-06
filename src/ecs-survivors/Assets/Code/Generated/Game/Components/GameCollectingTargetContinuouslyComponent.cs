//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCollectingTargetContinuously;

    public static Entitas.IMatcher<GameEntity> CollectingTargetContinuously {
        get {
            if (_matcherCollectingTargetContinuously == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CollectingTargetContinuously);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCollectingTargetContinuously = matcher;
            }

            return _matcherCollectingTargetContinuously;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Code.Gameplay.Features.TargetCollection.CollectingTargetContinuously collectingTargetContinuouslyComponent = new Code.Gameplay.Features.TargetCollection.CollectingTargetContinuously();

    public bool isCollectingTargetContinuously {
        get { return HasComponent(GameComponentsLookup.CollectingTargetContinuously); }
        set {
            if (value != isCollectingTargetContinuously) {
                var index = GameComponentsLookup.CollectingTargetContinuously;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : collectingTargetContinuouslyComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
