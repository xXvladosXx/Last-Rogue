using Code.Infrastructure.Progress.Data;

namespace Code.Infrastructure.Progress.Provider
{
    public class ProgressProvider : IProgressProvider
    {
        public ProgressData ProgressData { get; private set; }

        public void SetProgressData(ProgressData data)
        {
            ProgressData = data;
        }
    }
}