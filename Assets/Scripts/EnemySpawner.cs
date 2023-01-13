using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _enemySpawner;

    private Transform[] _spawnPointPosition;

    private void Start()
    {
        _spawnPointPosition = new Transform[_enemySpawner.childCount];

        for (int i = 0; i < _spawnPointPosition.Length; i++)
        {
            _spawnPointPosition[i] = _enemySpawner.GetChild(i);
        }

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        var timeStepSpawn = new WaitForSeconds(2);

        for (int i = 0; i < _spawnPointPosition.Length; i++)
        {
            Instantiate(_enemy, _spawnPointPosition[i]);

            yield return timeStepSpawn;
        }
    }
}
