using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnerCapsule : MonoBehaviour
{
    private PlayerStatus _playerStatus;
    private GameObject _enemyPrefab;
    //private Spawner _spawner;

    public SpawnerCapsule(PlayerStatus playerStatus, GameObject enemyPrefab)
    {
        _playerStatus = playerStatus;
        _enemyPrefab = enemyPrefab;
        //_spawner = spawner;
    }

    public IEnumerator SpawnLoop()
    {
        while (true)
        {
            var distanceVector = new Vector3(10f, 0f);
            var spawnPositionFromPlayer = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f) * distanceVector;
            var spawnPosition = _playerStatus.transform.position + spawnPositionFromPlayer;

            NavMeshHit navMeshHit;
            if (NavMesh.SamplePosition(spawnPosition, out navMeshHit, 10f, NavMesh.AllAreas))
            {
                Instantiate(_enemyPrefab, navMeshHit.position, Quaternion.identity);
            }

            yield return new WaitForSeconds(10f);

            if (_playerStatus.Life <= 0f)
            {
                break;
            }
        }
    }
}
