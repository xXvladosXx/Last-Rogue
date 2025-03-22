//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class MetaMatcher {

    static Entitas.IMatcher<MetaEntity> _matcherStorage;

    public static Entitas.IMatcher<MetaEntity> Storage {
        get {
            if (_matcherStorage == null) {
                var matcher = (Entitas.Matcher<MetaEntity>)Entitas.Matcher<MetaEntity>.AllOf(MetaComponentsLookup.Storage);
                matcher.componentNames = MetaComponentsLookup.componentNames;
                _matcherStorage = matcher;
            }

            return _matcherStorage;
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
public partial class MetaEntity {

    static readonly Code.Gameplay.Meta.Features.Storage.Storage storageComponent = new Code.Gameplay.Meta.Features.Storage.Storage();

    public bool isStorage {
        get { return HasComponent(MetaComponentsLookup.Storage); }
        set {
            if (value != isStorage) {
                var index = MetaComponentsLookup.Storage;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : storageComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
