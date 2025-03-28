**Last Rogue** is a survivors-like game built in Unity using:

- **Entitas (ECS)** for efficient, scalable game logic.
- **Zenject (DI)** for modular, testable code.
- A **clean architecture** style for rapid iteration.
  
Experience dynamic survival gameplay in a uniquely challenging world.

https://github.com/user-attachments/assets/94ba71d4-d5a2-4e3b-a6d7-b5d9705c28e2

# Game Features

- **Enemies**
- **Waves**
- **Shop System**
- **Abilities and Upgrade**
- **Enchants**
- **Loot**
- **Leveling Up**
- **Statuses and Effects**

# Project Structure

The game code is divided into several folders:

- **Common**  
  Includes extensions, common components, and systems for entities.

- **Gameplay**  
  Contains the main gameplay features, and is further organized into:
  - Factories
  - Configs
  - Systems
  - Features

- **Generated**  
  Contains source-generated code from Jenny.

- **Infrastructure**  
  Manages game state flow, save/load functionality, and asset management.

- **Meta**  
  Contains home screen features.

---

## Bootstrap Installer

All services are installed via the bootstrap installer: 
```csharp 
public class BootstrapInstaller : MonoInstaller, ICoroutineRunner, IInitializable
{
    public override void InstallBindings()
    {
        BindStateMachine();
        BindStateFactory();
        BindGameStates();
        BindInputService();
        BindInfrastructureServices();
        BindAssetManagementServices();
        BindCommonServices();
        BindSystemFactory();
        BindUIFactories();
        BindUIServices();
        BindContexts();
        BindGameplayServices();
        BindCameraProvider();
        BindGameplayFactories();
        BindEntityIndices();
        BindProgressServices();
    }
}
``` 

---

## System Creation with Zenject

To automatically create systems, Zenject is used to inject dependencies. For example, to create an input feature system:

```csharp 
Add(systemFactory.Create<InputFeature>());
```
### SystemFactory Implementation

The `SystemFactory` class leverages Zenject's `DiContainer` to instantiate systems, ensuring a clean and modular design:

```csharp 
public class SystemFactory : ISystemFactory
{
    private readonly DiContainer _container;

    public SystemFactory(DiContainer container) => 
        _container = container;

    public T Create<T>() where T : ISystem => 
        _container.Instantiate<T>();

    public T Create<T>(params object[] args) where T : ISystem => 
        _container.Instantiate<T>(args);
}
```

This approach promotes a clean architecture style by decoupling system creation from their usage, allowing for easier testing, maintenance, and extension.
