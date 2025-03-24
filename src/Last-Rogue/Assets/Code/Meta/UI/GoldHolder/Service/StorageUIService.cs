using System;

namespace Code.Meta.UI.GoldHolder.Service
{
    public class StorageUIService : IStorageUIService
    {
        public float CurrentGold { get; private set; }
        public float GoldGainBoost { get; private set; }

        public event Action OnGoldChanged;
        public event Action OnGoldBoostChanged;

        public void UpdateCurrentGold(float gold)
        {
            if (Math.Abs(gold - CurrentGold) > float.Epsilon)
            {
                CurrentGold = gold;
                OnGoldChanged?.Invoke();
            }
        }

        public void UpdateGoldGainBoost(float boost)
        {
            GoldGainBoost = boost;
            OnGoldBoostChanged?.Invoke();
        }

        public void Cleanup()
        {
            CurrentGold = 0;
            GoldGainBoost = 0;

            OnGoldChanged = null;
            OnGoldBoostChanged = null;
        }
    }
}