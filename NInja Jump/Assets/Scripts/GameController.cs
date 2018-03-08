using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    const string BEST_SCORE = "Best Score";
    [SerializeField]
    Transform boltStaff;
    [SerializeField]
    Transform endPanel;
    [SerializeField]
    Transform pausePanel;
    [SerializeField]
    Transform groundLeft;
    [SerializeField]
    Transform groundRight;
    [SerializeField]
    Transform greenTree;
    [SerializeField]
    Transform pinkTree;
    [SerializeField]
    Transform stoneStatue;
    [SerializeField]
    Transform cherryBlossom;
    [SerializeField]
    Transform fire;
    [SerializeField]
    Transform vegeta;
    [SerializeField]
    Transform itachi;
    [SerializeField]
    Transform dragon;
    [SerializeField]
    Transform heart;
    [SerializeField]
    Transform explosion;
    [SerializeField]
    Transform bridge;
    [SerializeField]
    Transform grimReaper;
    HigariController ninja;
    [SerializeField]
    Text scoreText;
    public Text bestScore;
    [SerializeField]
    Text yourScore;
    [SerializeField]
    Text yourDragon;
    [SerializeField]
    Text dragonCollected;
    int score;
    float repeatRate;
    float maxY;
    float minX;
    float maxX;
    int vegetaMileStones;
    int itachiMileStones;
    int grimReaperMileStones;
    public bool inverse;
    public Button btnRestart;
    public Button btnHome;
    public Button btnHome2;
    public Button btnBack;
    public Button btnPause;
    public Button btnMusic;
    public Sprite btnRestartIdle;
    public Sprite btnRestartHover;
    public Sprite btnRestartClick;
    public Sprite btnHomeIdle;
    public Sprite btnHomeHover;
    public Sprite btnHomeClick;
    public Sprite btnPauseIdle;
    public Sprite btnPauseHover;
    public Sprite btnEnableMusic;
    public Sprite btnDisableMusic;
    public AudioSource backGroundMusic;
    // Use this for initialization
    void Start()
    {
        vegetaMileStones = 5000;
        itachiMileStones = 3000;
        grimReaperMileStones = 7000;
        Time.timeScale = 1;
        score = 0;
        MakeInstance();
        ninja = GameObject.FindGameObjectWithTag("Ninja").GetComponent<HigariController>();
        maxY = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).y;
        minX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        maxX = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x;
        GameObject.Instantiate(groundLeft, new Vector2(minX + 0.2f, 0), Quaternion.identity);
        GameObject.Instantiate(groundRight, new Vector2(maxX - 0.2f, 0), Quaternion.identity);
        InvokeRepeating("Spawm", 0.1f, 1.046f); //1.05
        InvokeRepeating("CreateObtacle", 1, 1f);
        endPanel.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(false);
        IsGameStartForTheFirstTime();
    }
    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }
    void IsGameStartForTheFirstTime()
    {
        if (PlayerPrefs.HasKey("IsGameStartForTheFirstTime") == true)
        {
            PlayerPrefs.SetInt(BEST_SCORE, 0);
            PlayerPrefs.SetInt("IsGameStartForTheFirstTime", 0); 
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!(gameObject.GetComponent<AudioSource>().isPlaying)&& MenuGameController.isEnableSound)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
        if (score > 1000)
            repeatRate = 0.3f;
        AddScore();
        AddDragonPoint();
        EndGame();
    }
    void AddDragonPoint()
    {
        yourDragon.text = "X " + ninja.numsOfDragon.ToString();
    }
    public void ActiveGamePanel()
    {
        Time.timeScale = 0;
        btnPause.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(true);
    }
    public void DeactiveGamePanel()
    {
        Time.timeScale = 1;
        btnPause.gameObject.SetActive(true);
        pausePanel.gameObject.SetActive(false);
    }
    void Spawm()
    {
        GameObject.Instantiate(groundLeft, new Vector2(minX + 0.2f, maxY), Quaternion.identity);
        GameObject.Instantiate(groundRight, new Vector2(maxX - 0.2f, maxY), Quaternion.identity);
    }
    void CreateObtacle()
    {
        inverse = false;
        int rand = Random.Range(0, 14);

        switch (rand)
        {
            case 0:
                if(Random.Range(0,2) == 0)
                    GameObject.Instantiate(greenTree, new Vector2(minX + 1.5f, maxY), Quaternion.Euler(180, 0, 270));
                else
                    GameObject.Instantiate(pinkTree, new Vector2(minX + 1.5f, maxY), Quaternion.Euler(180, 0, 270));
                break;
            case 1:
                if (Random.Range(0, 2) == 0)
                    GameObject.Instantiate(greenTree, new Vector2(maxX - 1.5f, maxY), Quaternion.Euler(0, 0, 90));
                else
                    GameObject.Instantiate(pinkTree, new Vector2(maxX - 1.5f, maxY), Quaternion.Euler(0, 0, 90));
                break;
            case 2:
                GameObject.Instantiate(cherryBlossom, new Vector2(minX + 1.7f, maxY), Quaternion.Euler(0, 0, -90));
                break;
            case 3:
                GameObject.Instantiate(cherryBlossom, new Vector2(maxX - 1.7f, maxY), Quaternion.Euler(180, 0, 90));
                break;
            case 4:
                GameObject.Instantiate(fire, new Vector2(maxX - 0.8f, maxY), Quaternion.Euler(0, 0, 90));
                break;
            case 5:
                if (Random.Range(0, 2) == 0)
                    GameObject.Instantiate(fire, new Vector2(minX + 0.8f, maxY), Quaternion.Euler(180, 0, 270));
                else
                    GameObject.Instantiate(stoneStatue, new Vector2(minX + 1.2f, maxY), Quaternion.Euler(180, 0, 270));
                break;
            case 6:
                if(score> vegetaMileStones)
                    GameObject.Instantiate(vegeta, new Vector2(minX + 1.2f, maxY + 1f), Quaternion.Euler(0, 0, 270));
                break;
            case 7:
                int randOb = Random.Range(0, 2);
                if (score > 8000)
                    randOb = 1;
                if (randOb == 0)
                    GameObject.Instantiate(stoneStatue, new Vector2(maxX - 1.2f, maxY), Quaternion.Euler(0, 0, 90));
                else
                    if (score > vegetaMileStones)
                {
                    GameObject.Instantiate(vegeta, new Vector2(maxX - 1.2f, maxY + 1f), Quaternion.Euler(180, 0, 90));
                    inverse = true;
                }
                break;
            case 8:
                if(score> itachiMileStones)
                    GameObject.Instantiate(itachi, new Vector2(minX + 1.3f, maxY + 1f), Quaternion.Euler(0, 0, 270));
                else
                    GameObject.Instantiate(stoneStatue, new Vector2(minX + 1.2f, maxY), Quaternion.Euler(180, 0, 270));
                break;
            case 9:
                if (score > itachiMileStones)
                {
                    GameObject.Instantiate(itachi, new Vector2(maxX - 1.3f, maxY + 1f), Quaternion.Euler(180, 0, 90));
                    inverse = true;
                }
                else
                    GameObject.Instantiate(bridge, new Vector2(0, maxY + 1f), Quaternion.Euler(0, 0, 0));
                break;
            case 10:
                if(Random.Range(0, 2) == 0)
                    GameObject.Instantiate(dragon, new Vector2(minX + 1.3f, maxY + 1f), Quaternion.Euler(0, 0, 0));
                else
                    GameObject.Instantiate(boltStaff, new Vector2(minX, maxY -2f ), Quaternion.Euler(180, 0, 180));
                break;
            case 11:
                if (Random.Range(0, 2) == 0)
                    GameObject.Instantiate(dragon, new Vector2(maxX - 1.3f, maxY + 1f), Quaternion.Euler(0, 180, 0));
                else
                    GameObject.Instantiate(boltStaff, new Vector2(maxX, maxY - 2f), Quaternion.Euler(0, 0, 0));
                inverse = true;
                break;
            case 12:
                int randO = Random.Range(0, 5);
                if (randO == 0)
                    GameObject.Instantiate(heart, new Vector2(0, maxY + 1f), Quaternion.Euler(0, 0, 0));
                else if(randO <= 2)
                    GameObject.Instantiate(bridge, new Vector2(0, maxY + 1f), Quaternion.Euler(0, 0, 0));
                else
                    GameObject.Instantiate(stoneStatue, new Vector2(minX + 1.2f, maxY), Quaternion.Euler(180, 0, 270));
                break;
            case 13:
                if(score > grimReaperMileStones)
                {
                   GameObject.Instantiate(bridge, new Vector2(0, maxY + 1f), Quaternion.Euler(0, 0, 0));
                   GameObject.Instantiate(grimReaper, new Vector2(0, maxY + 1f), Quaternion.Euler(0, 0, 0));
                }
                break;        
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void MenuGame()
    {
        MenuGameController.isRebackMainMenu = true;
        SceneManager.LoadScene(0);
    }
    void EndGame()
    {
        if (ninja.isAlive == false)
        {
            yourScore.text = "Your Score: " + score.ToString();
            if (score > GetBestScore())
            {
                SetBestScore(score);
            }
            MenuGameController.yourScore = GetBestScore();
            
            bestScore.text = "Best Score: " + GetBestScore();
            dragonCollected.text = ": " + ninja.countDragon.ToString();
            endPanel.gameObject.SetActive(true);
            Time.timeScale = 0.2f;
        }
    }
    public void MusicController()
    {
        if(!(gameObject.GetComponent<AudioSource>().isPlaying))
        {
            btnMusic.GetComponent<Image>().sprite = btnEnableMusic;
            MenuGameController.isEnableSound = true;
            gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            btnMusic.GetComponent<Image>().sprite = btnDisableMusic;
            MenuGameController.isEnableSound = false;
            gameObject.GetComponent<AudioSource>().Stop();
        }
    }
    void AddScore()
    {
        if (ninja.isAlive && Time.timeScale > 0)
        {
            score++;
            scoreText.text = score.ToString();
        }
    }
    public void SetBestScore(int score)
    {
        PlayerPrefs.SetInt(BEST_SCORE, score);
    }
    public int GetBestScore()
    {
        return PlayerPrefs.GetInt(BEST_SCORE);
    }
    public void ButtonRestartIdle()
{
    btnRestart.GetComponent<Image>().sprite = btnRestartIdle;
}
    public void ButtonRestartHover()
{
    btnRestart.GetComponent<Image>().sprite = btnRestartHover;
}
    public void ButtonRestartClick()
{
    btnRestart.GetComponent<Image>().sprite = btnRestartClick;
}
    public void ButtonHomeIdle()
    {
        btnHome.GetComponent<Image>().sprite = btnHomeIdle;
    }
    public void ButtonHomeHover()
    {
        btnHome.GetComponent<Image>().sprite = btnHomeHover;
    }
    public void ButtonHomeClick()
    {
        btnHome.GetComponent<Image>().sprite = btnHomeClick;
    }
    public void ButtonHome2Idle()
    {
        btnHome2.GetComponent<Image>().sprite = btnHomeIdle;
    }
    public void ButtonHome2Hover()
    {
        btnHome2.GetComponent<Image>().sprite = btnHomeHover;
    }
    public void ButtonPauseHover()
    {
        btnPause.GetComponent<Image>().sprite = btnPauseHover;
    }
    public void ButtonPauseClick()
    {
        btnPause.GetComponent<Image>().sprite = btnPauseIdle;
    }
    public void ButtonBackIdle()
    {
        btnBack.GetComponent<Image>().sprite = btnRestartIdle;
    }
    public void ButtonBackHover()
    {
        btnBack.GetComponent<Image>().sprite = btnRestartHover;
    }

}
