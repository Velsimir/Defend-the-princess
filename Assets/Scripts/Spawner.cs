using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wawe> _wawes;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    private Wawe _currentWawe;
    private int _currentWaweNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;

    public event UnityAction<int,int> OnEnemyCountChanged;
    public event UnityAction OnAllEnemySpawned;

    private void Start()
    {
        SetWawe(_currentWaweNumber);
    }

    private void Update()
    {
        if (_currentWawe == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWawe.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0f;
            OnEnemyCountChanged?.Invoke(_spawned,_currentWawe.Count);
        }

        if (_currentWawe.Count <= _spawned)
        {
            if (_wawes.Count > _currentWaweNumber + 1)
                OnAllEnemySpawned?.Invoke();

            _currentWawe = null;
        }
    }

    public void NextWawe()
    {
        SetWawe(++_currentWaweNumber);
        _spawned = 0;
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWawe.Tamplate, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_player);
        enemy.Died += OnEnemyDied;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;

        _player.AddMoney(enemy.Reward);
    }

    private void SetWawe(int index)
    {
        _currentWawe = _wawes[index];
        OnEnemyCountChanged?.Invoke(0,1);
    }
}

[System.Serializable]
public class Wawe
{
    public GameObject Tamplate;
    public float Delay;
    public int Count;
}
