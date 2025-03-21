using Code.Infrastructure.Progress.Data;

namespace Code.Infrastructure.Progress.Provider
{
    public interface IProgressProvider
    {
        ProgressData ProgressData { get; }
        void SetProgressData(ProgressData data);
    }
}