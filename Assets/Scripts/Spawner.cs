using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private GameObject enemyPrefab;
    SpawnerCapsule ctrl;

    void Start()
    {
        ctrl = new SpawnerCapsule(playerStatus, enemyPrefab);
        StartCoroutine(ctrl.SpawnLoop());
    }
}
