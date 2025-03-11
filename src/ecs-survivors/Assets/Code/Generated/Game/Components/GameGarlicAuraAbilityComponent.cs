//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherGarlicAuraAbility;

    public static Entitas.IMatcher<GameEntity> GarlicAuraAbility {
        get {
            if (_matcherGarlicAuraAbility == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GarlicAuraAbility);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGarlicAuraAbility = matcher;
            }

            return _matcherGarlicAuraAbility;
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

    static readonly Code.Gameplay.Features.Abilities.AbilityComponents.GarlicAuraAbility garlicAuraAbilityComponent = new Code.Gameplay.Features.Abilities.AbilityComponents.GarlicAuraAbility();

    public bool isGarlicAuraAbility {
        get { return HasComponent(GameComponentsLookup.GarlicAuraAbility); }
        set {
            if (value != isGarlicAuraAbility) {
                var index = GameComponentsLookup.GarlicAuraAbility;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : garlicAuraAbilityComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
