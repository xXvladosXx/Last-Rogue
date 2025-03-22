//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Code.Gameplay.Meta.Features.Simulation;

public static class MetaComponentsLookup {

    public const int Destructed = 0;
    public const int Gold = 1;
    public const int GoldPerSecond = 2;
    public const int Storage = 3;
    public const int Duration = 4;
    public const int GoldGainBoost = 5;
    public const int Tick = 6;

    public const int TotalComponents = 7;

    public static readonly string[] componentNames = {
        "Destructed",
        "Gold",
        "GoldPerSecond",
        "Storage",
        "Duration",
        "GoldGainBoost",
        "Tick"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Code.Common.CommonComponents.Destructed),
        typeof(Code.Gameplay.Meta.Features.Storage.Gold),
        typeof(Code.Gameplay.Meta.Features.Storage.GoldPerSecond),
        typeof(Code.Gameplay.Meta.Features.Storage.Storage),
        typeof(Duration),
        typeof(GoldGainBoost),
        typeof(Tick)
    };
}
