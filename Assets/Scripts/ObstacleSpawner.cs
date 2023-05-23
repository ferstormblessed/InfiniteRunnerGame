using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _obstaclePrefab;
    // [SerializeField] private float _xPosition = 10;
    // [SerializeField] private float _yPosition = 10;
    [SerializeField] private float _timeBetweenSpawn = 3f;
    [SerializeField] private bool _spawnObstacle = true;

    private void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnObstacle()
    {
        while (_spawnObstacle)
        {
            GameObject clone = Instantiate(_obstaclePrefab);
            //clone.transform.position = new Vector3(_xPosition, _yPosition, 0);
            clone.transform.position = gameObject.transform.position;

            yield return new WaitForSeconds(_timeBetweenSpawn);
        }
    }

}
