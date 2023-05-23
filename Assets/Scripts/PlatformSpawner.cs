using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _platformPrefab1;
    [SerializeField] private GameObject _platformPrefab2;
    [SerializeField] private GameObject _platformPrefab3;
    [SerializeField] private GameObject _platformPrefab4;
    [SerializeField] private GameObject _platformPrefab5;
    private GameObject[] _platformPrefabs;
    
    [SerializeField] private BoxCollider2D _boxCollider2D;
    [SerializeField] private float _gap = 3;

    private void Start()
    {
        _platformPrefabs = new GameObject[] { _platformPrefab1, _platformPrefab2, _platformPrefab3, _platformPrefab4, _platformPrefab5 };
    }

    private void Update()
    {
        if (transform.position.x < 0)
        {
            Vector3 spawnPosition = new Vector3(
                transform.position.x + _boxCollider2D.bounds.size.x + _gap, 
                0, 
                0);
            
            int randomPlatform = Random.Range(0, _platformPrefabs.Length);

            GameObject clone = Instantiate(_platformPrefabs[randomPlatform]);
            clone.transform.position = spawnPosition;
            clone.transform.name = "Platform";
            enabled = false;
        }
    }
}
