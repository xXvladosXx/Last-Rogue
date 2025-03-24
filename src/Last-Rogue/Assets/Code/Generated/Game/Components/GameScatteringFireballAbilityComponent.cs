//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherScatteringFireballAbility;

    public static Entitas.IMatcher<GameEntity> ScatteringFireballAbility {
        get {
            if (_matcherScatteringFireballAbility == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ScatteringFireballAbility);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherScatteringFireballAbility = matcher;
            }

            return _matcherScatteringFireballAbility;
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

    static readonly Code.Gameplay.Features.Abilities.AbilityComponents.ScatteringFireballAbility scatteringFireballAbilityComponent = new Code.Gameplay.Features.Abilities.AbilityComponents.ScatteringFireballAbility();

    public bool isScatteringFireballAbility {
        get { return HasComponent(GameComponentsLookup.ScatteringFireballAbility); }
        set {
            if (value != isScatteringFireballAbility) {
                var index = GameComponentsLookup.ScatteringFireballAbility;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : scatteringFireballAbilityComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
