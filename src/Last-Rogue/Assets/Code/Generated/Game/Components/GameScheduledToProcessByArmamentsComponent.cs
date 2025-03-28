//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherScheduledToProcessByArmaments;

    public static Entitas.IMatcher<GameEntity> ScheduledToProcessByArmaments {
        get {
            if (_matcherScheduledToProcessByArmaments == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ScheduledToProcessByArmaments);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherScheduledToProcessByArmaments = matcher;
            }

            return _matcherScheduledToProcessByArmaments;
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

    public Code.Gameplay.Features.Abilities.AbilityComponents.ScheduledToProcessByArmaments scheduledToProcessByArmaments { get { return (Code.Gameplay.Features.Abilities.AbilityComponents.ScheduledToProcessByArmaments)GetComponent(GameComponentsLookup.ScheduledToProcessByArmaments); } }
    public System.Collections.Generic.List<int> ScheduledToProcessByArmaments { get { return scheduledToProcessByArmaments.Value; } }
    public bool hasScheduledToProcessByArmaments { get { return HasComponent(GameComponentsLookup.ScheduledToProcessByArmaments); } }

    public GameEntity AddScheduledToProcessByArmaments(System.Collections.Generic.List<int> newValue) {
        var index = GameComponentsLookup.ScheduledToProcessByArmaments;
        var component = (Code.Gameplay.Features.Abilities.AbilityComponents.ScheduledToProcessByArmaments)CreateComponent(index, typeof(Code.Gameplay.Features.Abilities.AbilityComponents.ScheduledToProcessByArmaments));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceScheduledToProcessByArmaments(System.Collections.Generic.List<int> newValue) {
        var index = GameComponentsLookup.ScheduledToProcessByArmaments;
        var component = (Code.Gameplay.Features.Abilities.AbilityComponents.ScheduledToProcessByArmaments)CreateComponent(index, typeof(Code.Gameplay.Features.Abilities.AbilityComponents.ScheduledToProcessByArmaments));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveScheduledToProcessByArmaments() {
        RemoveComponent(GameComponentsLookup.ScheduledToProcessByArmaments);
        return this;
    }
}
