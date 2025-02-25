//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherSelfDestructTime;

    public static Entitas.IMatcher<GameEntity> SelfDestructTime {
        get {
            if (_matcherSelfDestructTime == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SelfDestructTime);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSelfDestructTime = matcher;
            }

            return _matcherSelfDestructTime;
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

    public Code.Common.CommonComponents.SelfDestructTime selfDestructTime { get { return (Code.Common.CommonComponents.SelfDestructTime)GetComponent(GameComponentsLookup.SelfDestructTime); } }
    public float SelfDestructTime { get { return selfDestructTime.Value; } }
    public bool hasSelfDestructTime { get { return HasComponent(GameComponentsLookup.SelfDestructTime); } }

    public GameEntity AddSelfDestructTime(float newValue) {
        var index = GameComponentsLookup.SelfDestructTime;
        var component = (Code.Common.CommonComponents.SelfDestructTime)CreateComponent(index, typeof(Code.Common.CommonComponents.SelfDestructTime));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceSelfDestructTime(float newValue) {
        var index = GameComponentsLookup.SelfDestructTime;
        var component = (Code.Common.CommonComponents.SelfDestructTime)CreateComponent(index, typeof(Code.Common.CommonComponents.SelfDestructTime));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveSelfDestructTime() {
        RemoveComponent(GameComponentsLookup.SelfDestructTime);
        return this;
    }
}
