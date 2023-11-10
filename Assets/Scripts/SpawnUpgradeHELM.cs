using UnityEngine;
using Random = UnityEngine.Random;
public class SpawnUpgradeHELM : MonoBehaviour
{
    private int randNum;
    public GameObject upgradeble;
    private NubJump NJ;

    private void Start()
    {
        NJ = FindObjectOfType<NubJump>();
        randNum = Random.Range(0, 10);
       if (randNum > 7 && NJ._isHelmet == false)
        {
            upgradeble.SetActive(true);
        }
       else
       {
           upgradeble.SetActive(false);
       }
    }
}
