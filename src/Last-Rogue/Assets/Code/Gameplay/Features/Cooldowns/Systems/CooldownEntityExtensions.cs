namespace Code.Gameplay.Features.Cooldowns.Systems
{
    public static class CooldownEntityExtensions 
    {
        public static GameEntity PutOnCooldown(this GameEntity entity)
        {
            if (!entity.hasCooldown)
                return entity;

            entity.isCooldownUp = false;
            entity.ReplaceCooldownLeft(entity.Cooldown);

            return entity;
        }
        
        public static GameEntity PutOnCooldown(this GameEntity entity, float cooldown)
        {
            entity.isCooldownUp = false;
            entity.ReplaceCooldown(entity.Cooldown);
            entity.ReplaceCooldownLeft(entity.Cooldown);

            return entity;
        }

    }
}