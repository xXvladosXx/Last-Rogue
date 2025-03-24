using System;

namespace Code.Meta.UI.GoldHolder.Service
{
    public interface IStorageUIService
    {
        float CurrentGold { get; }
        float GoldGainBoost { get; }
        event Action OnGoldChanged;
        void UpdateCurrentGold(float gold);
        void Cleanup();
        event Action OnGoldBoostChanged;
        void UpdateGoldGainBoost(float boost);
    }
}