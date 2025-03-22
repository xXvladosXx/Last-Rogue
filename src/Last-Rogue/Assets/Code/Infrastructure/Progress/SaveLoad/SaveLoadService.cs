using System.Linq;
using Code.Gameplay.Common.Time;
using Code.Infrastructure.Progress.Data;
using Code.Infrastructure.Progress.Provider;
using Code.Infrastructure.Serialization;
using UnityEngine;

namespace Code.Infrastructure.Progress.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly MetaContext _metaContext;
        private readonly IProgressProvider _progressProvider;
        private readonly ITimeService _timeService;

        private const string PLAYER_PROGRESS = "PlayerProgress";

        public SaveLoadService(MetaContext metaContext,
            IProgressProvider progressProvider,
            ITimeService timeService)
        {
            _metaContext = metaContext;
            _progressProvider = progressProvider;
            _timeService = timeService;
        }

        public void SaveProgress()
        {
            PreserveMetaEntities();
            PlayerPrefs.SetString(PLAYER_PROGRESS, _progressProvider.ProgressData.ToJson());
            PlayerPrefs.Save();
        }

        public void LoadProgress()
        {
            var serializedProgress = PlayerPrefs.GetString(PLAYER_PROGRESS);
            _progressProvider.SetProgressData(serializedProgress.FromJson<ProgressData>());
            
            var snapshots = _progressProvider.ProgressData.EntityData.MetaEntitySnapshots;
            foreach (var snapshot in snapshots)
            {
                _metaContext
                    .CreateEntity()
                    .HydrateWith(snapshot);
            }
        }

        public void CreateProgress()
        {
            _progressProvider.SetProgressData(new ProgressData
            {
                LastSimulationTickTime = _timeService.UtcNow
            });
        }

        public bool HasSavedProgress() => PlayerPrefs.HasKey(PLAYER_PROGRESS);

        private void PreserveMetaEntities()
        {
            _progressProvider.ProgressData.EntityData.MetaEntitySnapshots = _metaContext.GetEntities()
                .Where(e => e.GetComponents().Any(c => c is ISavedComponent))
                .Select(e => e.AsSavedEntity())
                .ToList();
        }
    }
}