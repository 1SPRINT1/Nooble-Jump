using UnityEngine;
using UnityEngine.SceneManagement;
public class PikePlatform : MonoBehaviour
{
    public float jumpForce;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0 && NubJump.Instace._isHelmet == false)
        {
           NubJump.Instace.GameOvv(); 
        }
        else if(collision.relativeVelocity.y < 0)
        {
            NubJump.Instace.NoobleRG.velocity = Vector2.up * 20f;
        }
    }
}
