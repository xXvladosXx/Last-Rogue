using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Cameras.Systems;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class HeroFeature : Feature
    {
        public HeroFeature(GameContext gameContext, ICameraProvider cameraProvider)
        {
            Add(new SetHeroDirectionByInputSystem(gameContext));
            Add(new AnimateHeroMovementSystem(gameContext));
            Add(new CameraFollowHeroSystem(gameContext, cameraProvider));
        }
    }
}