using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Camera1 : MonoBehaviour
{
    public Transform NooblePos;
    private Camera mainCamera;
    public NubJump NJ;
    public GameObject GameOverPanel;
    private Vector3 camik = new Vector3(0, 0f, 10f);
    public GameObject YesReward;
    public GameObject NoReward;
    public Text HighScore;
    private float _empty;
    private void Start()
    {
        mainCamera = Camera.main;
        NJ = FindObjectOfType<NubJump>();
    }

    private void Update()
    {
            HighScore.text = "Best Score: " + PlayerPrefs.GetFloat("BestScore").ToString("#");

        if (NooblePos.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x,NooblePos.position.y,transform.position.z);
        }
       /* if (NooblePos.position.x > transform.position.x)
        {
            transform.position = new Vector3(NooblePos.position.x, NooblePos.position.y, transform.position.z);
        }
        if (NooblePos.position.x < transform.position.x)
        {
            transform.position = new Vector3(NooblePos.position.x, NooblePos.position.y, transform.position.z);
    }*/
     //  if (NJ.isGameOver == true)
      // {
     //      Collider2D[] collider2Ds = Physics2D.OverlapAreaAll(
    //           mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane)),
     //          mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.nearClipPlane)));

      //     foreach (Collider2D collider in collider2Ds)
      //     {
    ///           Destroy(collider.gameObject);
    //       } 
       //}

       if (GameOverPanel.activeSelf == true)
       {
          transform.position = new Vector3(0,0,10f); 
       }
       
    }

    public void Restar()
    {
        SceneManager.LoadScene(1);
        
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
