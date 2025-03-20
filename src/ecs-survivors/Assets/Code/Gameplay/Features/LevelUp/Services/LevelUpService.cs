using Code.Common.Entity;
using Code.Gameplay.StaticData;

namespace Code.Gameplay.Features.LevelUp.Services
{
    public class LevelUpService : ILevelUpService
    {
        private readonly IStaticDataService _staticDataService;

        public float CurrentExperience { get; private set; }
        public int CurrentLevel { get; private set; }

        public LevelUpService(IStaticDataService staticDataService) => 
            _staticDataService = staticDataService;

        public float ExperienceForLevelUp() => 
            _staticDataService.ExperienceForLevel(CurrentLevel + 1);

        public void AddExperience(float value)
        {
            CurrentExperience += value;
            UpdateLevel();
        }

        private void UpdateLevel()
        {
            while (true)
            {
                if (CurrentLevel > _staticDataService.MaxLevel) 
                    return;

                var experienceForLevelUp = _staticDataService.ExperienceForLevel(CurrentLevel + 1);
                if (CurrentExperience >= experienceForLevelUp)
                {
                    CurrentExperience -= experienceForLevelUp;
                    CurrentLevel++;

                    CreateEntity.Empty()
                        .isLevelUp = true;
                }
            }
        }
    }
}