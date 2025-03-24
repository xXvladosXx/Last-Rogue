namespace Code.Gameplay.Features.Enemies.Services.Wave
{
    public interface IWaveCounter
    {
        float EnemySpawnInterval { get; }
        EnemyTypeId PickUpRandomEnemy();
    }
}