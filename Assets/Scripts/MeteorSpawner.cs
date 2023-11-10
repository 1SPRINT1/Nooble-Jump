using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
public class MeteorSpawner : MonoBehaviour
{
    public GameObject spawnPlat;
    private Vector3 _spawnerPosition = new Vector3();
    public float _time = 15f;
   // public GameObject messageMeteor;
    public float spawnRate = 15f; // раз в какое время спавнить
    [SerializeField] public float nextSpawn = 0.0f;
    private bool _isGameStarted = false;

    private void Start()
    {
      //  messageMeteor.SetActive(true);
        StartCoroutine(WaitTimer());
    }

    private void Update()
   {
       _time -= 1f * Time.deltaTime;
       {   if (Time.time > nextSpawn && _isGameStarted == true)
        {
            nextSpawn = Time.time + spawnRate;
            SpawnPlatforms();
            _time = 15f;
         // messageMeteor.SetActive(false);
        }
         
     }
    }
    public void SpawnPlatforms()
    {    
             _spawnerPosition.x = Random.Range(-10, 10f);
            _spawnerPosition.y = transform.position.y; 
            Instantiate(spawnPlat, _spawnerPosition, Quaternion.identity);
    }

    IEnumerator WaitTimer()
    {
        yield return new WaitForSecondsRealtime(15f);
        _isGameStarted = true;
    }
}
