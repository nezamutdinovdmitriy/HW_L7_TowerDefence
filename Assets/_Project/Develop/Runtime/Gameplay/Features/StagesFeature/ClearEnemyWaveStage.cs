using Assets._Project.Develop.Runtime.Gameplay.Configs.Stages;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.EnemiesFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class ClearEnemyWaveStage : IStage
{
    private readonly ReactiveEvent _completed = new();
    private readonly ClearEnemyWaveStageConfig _stageConfig;
    private readonly EnemiesEntityFactory _enemiesEntityFactory;
    private readonly EntitiesLifeContext _entitiesLifeContext;

    private readonly Dictionary<Entity, IDisposable> _spawnedEntitiesToRemoveReason = new();

    private bool _isRunning;

    public ClearEnemyWaveStage(
        ClearEnemyWaveStageConfig stageConfig,
        EnemiesEntityFactory enemiesEntityFactory,
        EntitiesLifeContext entitiesLifeContext)
    {
        _stageConfig = stageConfig;
        _enemiesEntityFactory = enemiesEntityFactory;
        _entitiesLifeContext = entitiesLifeContext;
    }

    public IReadOnlyEvent Completed => _completed;

    public void Start()
    {
        if (_isRunning)
            throw new InvalidOperationException("Game stage alread started!");

        SpawnEnemies();

        _isRunning = true;
    }

    public void Update(float deltaTime)
    {
        if (_isRunning == false)
            return;

        if (_spawnedEntitiesToRemoveReason.Count == 0)
            ProcessEnd();
    }

    private void ProcessEnd()
    {
        _isRunning = false;
        _completed?.Invoke();
    }

    public void Cleanup()
    {
        foreach (KeyValuePair<Entity, IDisposable> item in _spawnedEntitiesToRemoveReason)
        {
            item.Value.Dispose();
            _entitiesLifeContext.Remove(item.Key);
        }

        _spawnedEntitiesToRemoveReason.Clear();

        _isRunning = false;
    }

    public void Dispose()
    {
        foreach (KeyValuePair<Entity, IDisposable> item in _spawnedEntitiesToRemoveReason)
        {
            item.Value.Dispose();
        }

        _spawnedEntitiesToRemoveReason.Clear();

        _isRunning = false;
    }

    private void SpawnEnemies()
    {
        foreach (EnemyWaveConfig enemyWaveConfig in _stageConfig.WaveConfigs)
        {
            for (int i = 0; i < enemyWaveConfig.Count; i++)
            {
                Entity spawnedEnemy = _enemiesEntityFactory.Create(enemyWaveConfig.EntityConfig, GetRandomPosition());

                IDisposable removeReason = spawnedEnemy.IsDead.Subscribe((oldValue, isDead) =>
                {
                    if (isDead)
                    {
                        IDisposable disposable = _spawnedEntitiesToRemoveReason[spawnedEnemy];
                        disposable.Dispose();
                        _spawnedEntitiesToRemoveReason.Remove(spawnedEnemy);
                    }
                });

                _spawnedEntitiesToRemoveReason.Add(spawnedEnemy, removeReason);
            }
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector2 randomPosition = Random.insideUnitCircle.normalized * 35f;

        return new(randomPosition.x, 0, randomPosition.y);
    }
}
