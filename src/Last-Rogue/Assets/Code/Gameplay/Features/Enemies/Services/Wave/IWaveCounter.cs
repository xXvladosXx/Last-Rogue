namespace Code.Gameplay.Features.Enemies.Services.Wave
{
    public interface IWaveCounter
    {
        float EnemySpawnInterval { get; }
        int WavesCompleted { get; }
        EnemyTypeId PickUpRandomEnemy();
        void Cleanup();
    }
}