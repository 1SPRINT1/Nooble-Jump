using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] spawnPlat;
    private Vector3 lastPlatformPosition;
    private Vector3 spawnerPosition = new Vector3();
    private float _time = 1f;

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            spawnerPosition.x = Random.Range(-10f, 10);
            spawnerPosition.y += Random.Range(5f, 10f);
            Instantiate(spawnPlat[Random.Range(0, spawnPlat.Length)], spawnerPosition, Quaternion.identity);
        }
    }

    private void Update()
    {
        _time -= 1f * Time.deltaTime;
        if (_time <= 0)
        {
            SpawnPlatforms();
            _time = 1f;
        }
    }

    public void SpawnPlatforms()
    {
        for (int i = 0; i < 10; i++)
        {
            spawnerPosition.x = Random.Range(-10f, 10);
            spawnerPosition.y += Random.Range(4f, 8f);
            Instantiate(spawnPlat[Random.Range(0, spawnPlat.Length)], spawnerPosition, Quaternion.identity);
        }

    }
   
}
