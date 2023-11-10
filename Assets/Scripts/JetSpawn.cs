using UnityEngine;
public class JetSpawn : MonoBehaviour
{
    public GameObject[] spawnPlat;
    private Vector3 lastPlatformPosition;
    private Vector3 spawnerPosition = new Vector3();
    private float _time = 10f;

    private void Update()
    {
        _time -= 1f * Time.deltaTime;
        if (_time <= 0 && NubJump.Instace.playerHeight > 500)
        {
            SpawnPlatforms();
            _time = 10f;
        }
    }

    public void SpawnPlatforms()
    {
        for (int i = 0; i < 10; i++)
        {
            spawnerPosition.x = Random.Range(-10f, 10);
            spawnerPosition.y += transform.position.y; 
            Instantiate(spawnPlat[Random.Range(0, spawnPlat.Length)], spawnerPosition, Quaternion.identity);
        }

    }

}
