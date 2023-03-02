using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWawe : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _nextWaweButton;

    private void OnEnable()
    {
        _spawner.OnAllEnemySpawned += SpawnerOnAllEnemySpawned;
        _nextWaweButton.onClick.AddListener(OnNextWaweButtonClick);
    }

    private void OnDisable()
    {
        _spawner.OnAllEnemySpawned -= SpawnerOnAllEnemySpawned;
        _nextWaweButton.onClick.RemoveListener(OnNextWaweButtonClick);
    }

    public void OnNextWaweButtonClick()
    {
        _spawner.NextWawe();
        _nextWaweButton.gameObject.SetActive(false);
    }

    private void SpawnerOnAllEnemySpawned()
    {
        _nextWaweButton.gameObject.SetActive(true);
    }
}
