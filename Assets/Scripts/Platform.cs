using UnityEngine;
public class Platform : MonoBehaviour
{
    public float jumpForce;
    public GameObject Plat;
    public AudioSource AUD;

    private void Start()
    {
      //  AUD.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {
            NubJump.Instace.NoobleRG.velocity = Vector2.up * jumpForce;
            AUD.Play();
        }
    }
    
    private void Update()
    {
        //if (transform.position.y < cum.transform.position.y)
        // {
        //    Plat.SetActive(false);
        // }
        // else
        // {
        //     Plat.SetActive(true);
        // }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            // float RandX = Random.Range(-10f,10f);
            //  float RandY = Random.Range(transform.position.y + 20f, transform.position.y + 22f);

            // transform.position = new Vector3(RandX,RandY,0);
            Destroy(gameObject);
        }
        
    }
}
