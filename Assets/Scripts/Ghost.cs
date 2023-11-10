using UnityEngine;

public class Ghost : MonoBehaviour
{
    private float _speed = 10f;
   
    void Update()
    {
        transform.Translate(0f,_speed * Time.deltaTime,0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyDeadZone"))
        {
            Destroy(gameObject);
        }
    }
}
