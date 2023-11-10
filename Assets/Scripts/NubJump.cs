using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class NubJump : MonoBehaviour
{
    public static NubJump Instace;

    private float _horizontal;
    private float _jhorizontal;
    public Rigidbody2D NoobleRG;
    public float playerHeight;
    public Text HeighText;
    public Camera cum;
    public GameObject MobileMove;
    private Vector2 MoveVector;
    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _spriteRenderer1;
    private SpriteRenderer _spriteRenderer2;
    private SpriteRenderer _spriteRenderer3;
    public Joystick joystick;

    public GameObject gameOverPanel;
    public bool isGameOver;

    public Text HighScore;

    [Header("Апгрейд")]
    public GameObject helmet;
    public GameObject pickAxe;
    public bool _isHelmet = false;
    public bool _isPickAxe = false;
    public GameObject objPix;

    public AudioSource AU;

    [Header("Сохранения")]
    public float SavesBestScore;
    private void Start()
    {
        MobileMove.SetActive(true);
        _spriteRenderer3 = gameObject.GetComponent<SpriteRenderer>();
        _spriteRenderer2 = gameObject.GetComponent<SpriteRenderer>();
        _spriteRenderer1 = gameObject.GetComponent<SpriteRenderer>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (Instace == null)
        {
            Instace = this;
        }
        NoobleRG = GetComponent<Rigidbody2D>();
        AU = GetComponent<AudioSource>();
    }
    private void Update()
    {
        playerHeight = Mathf.Max(playerHeight,cum.transform.position.y);
       // if (playerHeight > YandexGame.savesData.bestScore)
      //  {
     //       YandexGame.savesData.bestScore = playerHeight;
     //   }
        UpdateUI();
        _horizontal = Input.GetAxis("Horizontal");
        _jhorizontal = joystick.Horizontal;
        if (_isPickAxe == true)
        {
            pickAxe.SetActive(true);
        }
        else
        {
            pickAxe.SetActive(false);
        }

        if (_isHelmet == true)
        {
            helmet.SetActive(true);
        }
        else
        {
            helmet.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
            Vector2 movementMob = new Vector2(_jhorizontal,0f);
            MoveVector = movementMob.normalized * 3f;
            NoobleRG.velocity = new Vector2(MoveVector.x * 3f,NoobleRG.velocity.y); 
            
        if (MoveVector.x < 0)
        {
            _spriteRenderer3.flipX = false;
        }
        if (MoveVector.x > 0)
        {
            _spriteRenderer2.flipX = true;
        }

        //  if (playerHeight > YandexGame.savesData.bestScore)
       // {
       //     YandexGame.savesData.bestScore = playerHeight;
      //  }

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            gameOverPanel.SetActive(true);
            isGameOver = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameOverPanel.SetActive(true);
            isGameOver = true;
        }

        if (collision.gameObject.CompareTag("Meteorite"))
        {
            gameOverPanel.SetActive(true);
            isGameOver = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && _isHelmet == false)
        {
            gameOverPanel.SetActive(true); 
            Destroy(other.gameObject);
            isGameOver = true;
        }
        else
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Helmet"))
        {
            StartCoroutine(Helm());
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Pixake"))
        {
            StartCoroutine(Pix());
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("JetPack"))
        {
            NoobleRG.velocity = Vector2.up * 120f; 
            Destroy(other.gameObject);
            AU.Play();
        }
    }

    private void UpdateUI()
    {
        float height = Mathf.Round(playerHeight);
        if (height > PlayerPrefs.GetFloat("BestScore"))
        {
            SavesBestScore = height;
            PlayerPrefs.SetFloat("BestScore", SavesBestScore);
        }
        HeighText.text = "Score: " + height.ToString("#"); 
    }
    IEnumerator Pix()
    {
        _isPickAxe = true;
        objPix.SetActive(true);
        pickAxe.SetActive(true);
        yield return new WaitForSecondsRealtime(5f);
        _isPickAxe = false;
        objPix.SetActive(false);
        pickAxe.SetActive(false);
    }

    IEnumerator Helm()
    {
        _isHelmet = true;
        helmet.SetActive(true);
        yield return new WaitForSecondsRealtime(15f);
        _isHelmet = false;
        helmet.SetActive(false);
    }

    public void GameOvv()
    {
        gameOverPanel.SetActive(true);
    }
}
