using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
     public Text BestScoreTXT;
    public float bestScore;
     public GameObject Panel;
     public AudioSource AU;
    private SoundSystem SS;
     private void Update()
     {
        BestScoreTXT.text = PlayerPrefs.GetFloat("BestScore", bestScore).ToString("#");
        SS = FindObjectOfType<SoundSystem>();
     }
     public void StarGame()
     {
          SceneManager.LoadScene(1);
     } 

     public void StartPanel()
     {
          Panel.SetActive(true);
          AU.Play();
     }
    public void Off()
    {
        SS.ToggleOff();
    }
    public void On()
    {
        SS.ToggleON();
    }
}
