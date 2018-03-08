using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameController : MonoBehaviour
{
    public static int yourScore;
    public static bool isEnableSound;
    public static bool isRebackMainMenu;
    const string YOUR_SCORE = "Your Score";
    public Button btnStart;
    public Sprite btnStartIdle;
    public Sprite btnStartHover;
    public Sprite btnStartClick;
    public Button btnInfo;
    public Sprite btnInfoIdle;
    public Sprite btnInfoHover;
    public Sprite btnInfoClick;
    public Button btnBack;
    public Sprite btnBackIdle;
    public Sprite btnBackHover;
    public Sprite btnBackClick;
    public Button btnBack1;
    public Button btnBack2;
    public Button btnBack3;
    public Button btnBack4;
    public Button btnAbout;
    public Transform insPanel;
    public Transform aboutPanel;
    public Transform bestScorePanel;
    public Transform soundPanel;
    public Transform settingPanel;
    public Transform resetPanel;
    public Transform exitGamePanel;
    public Transform tutorialGamePanel;
    public Button btnBestScore;
    public Sprite btnAboutIdle;
    public Sprite btnAboutHover;
    public Sprite btnAboutClick;
    public Text viewBestScore;
    public AudioSource backGroundMusic;
    public Button btnEnable;
    public Sprite btnEnableIdle;
    public Sprite btnEnableHover;
    public Button btnDisable;
    public Sprite btnDisableIdle;
    public Sprite btnDisableHover;
    public Button btnSetting;
    public Sprite btnSettingIdle;
    public Sprite btnSettingHover;
    public Sprite btnSettingClick;
    public Button btnSound;
    public Sprite btnSoundIdle;
    public Sprite btnSoundHover;
    public Sprite btnSoundClick;
    public Button btnYes;
    public Button btnNo;
    public Button btnYes1;
    public Button btnNo1;
    public Button btnReset;
    public Button btnExit;
    public Sprite btnExitIdle;
    public Sprite btnExitHover;
    public Sprite btnExitClick;
    public Button btnTutorial;
    public Sprite btnTutorialIdle;
    public Sprite btnTutorialHover;
    // Use this for initialization
    void Start ()
    {
        if (!isRebackMainMenu)
            ActiveSoundPanel();
        else
        {
            StartCoroutine(LoadSceneWhenUsingBtnHome());
        }
        settingPanel.gameObject.SetActive(false);
        insPanel.gameObject.SetActive(false);
        aboutPanel.gameObject.SetActive(false);
        bestScorePanel.gameObject.SetActive(false);
        tutorialGamePanel.gameObject.SetActive(false);
        IsGameStartForTheFirstTime();
    }
	void IsGameStartForTheFirstTime()
    {
        if (PlayerPrefs.HasKey("IsGameStartForTheFirstTime") == true)
        {
            yourScore = 0;
        }
    }
	// Update is called once per frame
	void Update ()
    {
        if (!(gameObject.GetComponent<AudioSource>().isPlaying) && isEnableSound)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
    IEnumerator LoadSceneWhenUsingBtnHome()
    {
        gameObject.GetComponent<Fading>().enabled = false;
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<Fading>().enabled = true;
        //SceneManager.LoadScene(0);

    }
    public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void InstructionGame()
    {
        insPanel.gameObject.SetActive(true);
    }
    public void BackPanel()
    {
        insPanel.gameObject.SetActive(false);
    }
    public void aboutPanelActive()
    {
        aboutPanel.gameObject.SetActive(true);
    }
    public void BackInsPanel()
    {
        insPanel.gameObject.SetActive(true);
        aboutPanel.gameObject.SetActive(false);
    }
    #region ScorePanel
    public void BestScorePanel()
    {
        SetBestScore(yourScore);
        bestScorePanel.gameObject.SetActive(true);
        viewBestScore.text = "                        Your Score: " + GetBestScore().ToString();
        
    }
    void SetBestScore(int score)
    {
        PlayerPrefs.SetInt(YOUR_SCORE, score);
    }
    int GetBestScore()
    {
        return PlayerPrefs.GetInt(YOUR_SCORE);
    }
    public void CloseBestScorePanel()
    {
        bestScorePanel.gameObject.SetActive(false);
    }
    #endregion
    public void ActiveSoundPanel()
    {
        soundPanel.gameObject.SetActive(true);
        btnExit.gameObject.SetActive(false);
    }
    public void ActiveSettingPanel()
    {
        settingPanel.gameObject.SetActive(true);
    }
    public void DeactiveSettingPanel()
    {
        settingPanel.gameObject.SetActive(false);
    }
    public void DeactiveSoundPanel()
    {
        soundPanel.gameObject.SetActive(false);
        btnExit.gameObject.SetActive(true);
    }
    public void ActiveResetPanel()
    {
        resetPanel.gameObject.SetActive(true);
        btnExit.gameObject.SetActive(false);
    }
    public void DeactiveResetPanel()
    {
        resetPanel.gameObject.SetActive(false);
        btnExit.gameObject.SetActive(true);
    }
    public void ActiveExitPanel()
    {
        exitGamePanel.gameObject.SetActive(true);
        btnExit.gameObject.SetActive(false);
    }
    public void DeactiveExitPanel()
    {
        exitGamePanel.gameObject.SetActive(false);
        btnExit.gameObject.SetActive(true);
    }
    public void ActiveTutorialPanel()
    {
        tutorialGamePanel.gameObject.SetActive(true);
        insPanel.gameObject.SetActive(false);
    }
    public void DeactiveTutorialPanel()
    {
        tutorialGamePanel.gameObject.SetActive(false);
        insPanel.gameObject.SetActive(true);

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ChooseYes()
    {
        GameController.instance.SetBestScore(0);
        yourScore = 0;
        DeactiveResetPanel();
    }
    public void ChooseNo()
    {
        DeactiveResetPanel();
    }
    public void EnableSound()
    {
        isEnableSound = true;
        DeactiveSoundPanel();
    }
    public void DisableSound()
    {
        DeactiveSoundPanel();
        isEnableSound = false;
        if ((gameObject.GetComponent<AudioSource>().isPlaying))
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }
    }
    //Function to select button
    //change sprite everytime user click these buttons
    #region Button 
    public void ButtonStartIdle()
    {
        btnStart.GetComponent<Image>().sprite = btnStartIdle;
    }
    public void ButtonStartHover()
    {
        btnStart.GetComponent<Image>().sprite = btnStartHover;
    }
    public void ButtonStartClick()
    {
        btnStart.GetComponent<Image>().sprite = btnStartClick;
    }
    public void ButtonInfoIdle()
    {
        btnInfo.GetComponent<Image>().sprite = btnInfoIdle;
    }
    public void ButtonInfoHover()
    {
        btnInfo.GetComponent<Image>().sprite = btnInfoHover;
    }
    public void ButtonInfoClick()
    {
        btnInfo.GetComponent<Image>().sprite = btnInfoClick;
    }
    public void ButtonSettingIdle()
    {
        btnSetting.GetComponent<Image>().sprite = btnSettingIdle;
    }
    public void ButtonSettingHover()
    {
        btnSetting.GetComponent<Image>().sprite = btnSettingHover;
    }
    public void ButtonSettingClick()
    {
        btnSetting.GetComponent<Image>().sprite = btnSettingClick;
    }
    public void ButtonExitIdle()
    {
        btnExit.GetComponent<Image>().sprite = btnExitIdle;
    }
    public void ButtonExitHover()
    {
        btnExit.GetComponent<Image>().sprite = btnExitHover;
    }
    public void ButtonExitClick()
    {
        btnExit.GetComponent<Image>().sprite = btnExitClick;
    }
    public void ButtonSoundIdle()
    {
        btnSound.GetComponent<Image>().sprite = btnSoundIdle;
    }
    public void ButtonSoundHover()
    {
        btnSound.GetComponent<Image>().sprite = btnSoundHover;
    }
    public void ButtonSoundClick()
    {
        btnSound.GetComponent<Image>().sprite = btnSoundClick;
    }
    #region BestScoreButton
    public void ButtonBestScoreIdle()
    {
        btnBestScore.GetComponent<Image>().sprite = btnInfoIdle;
    }
    public void ButtonBestScoreHover()
    {
        btnBestScore.GetComponent<Image>().sprite = btnInfoHover;
    }
    public void ButtonBestScoreClick()
    {
        btnBestScore.GetComponent<Image>().sprite = btnInfoClick;
    }
    #endregion
    public void ButtonBackIdle()
    {
        btnBack.GetComponent<Image>().sprite = btnBackIdle;
    }
    public void ButtonBackHover()
    {
        btnBack.GetComponent<Image>().sprite = btnBackHover;
    }
    public void ButtonBackClick()
    {
        btnBack.GetComponent<Image>().sprite = btnBackClick;
    }
    public void ButtonEnableIdle()
    {
        btnEnable.GetComponent<Image>().sprite = btnEnableIdle;
    }
    public void ButtonEnableHover()
    {
        btnEnable.GetComponent<Image>().sprite = btnEnableHover;
    }
    public void ButtonDisableIdle()
    {
        btnDisable.GetComponent<Image>().sprite = btnDisableIdle;
    }
    public void ButtonDisableHover()
    {
        btnDisable.GetComponent<Image>().sprite = btnDisableHover;
    }
    public void ButtonYesIdle()
    {
        btnYes.GetComponent<Image>().sprite = btnEnableIdle;
    }
    public void ButtonYesHover()
    {
        btnYes.GetComponent<Image>().sprite = btnEnableHover;
    }
    public void ButtonYes1Idle()
    {
        btnYes1.GetComponent<Image>().sprite = btnEnableIdle;
    }
    public void ButtonYes1Hover()
    {
        btnYes1.GetComponent<Image>().sprite = btnEnableHover;
    }
    public void ButtonNoIdle()
    {
        btnNo.GetComponent<Image>().sprite = btnDisableIdle;
    }
    public void ButtonNoHover()
    {
        btnNo.GetComponent<Image>().sprite = btnDisableHover;
    }
    public void ButtonNo1Idle()
    {
        btnNo1.GetComponent<Image>().sprite = btnDisableIdle;
    }
    public void ButtonNo1Hover()
    {
        btnNo1.GetComponent<Image>().sprite = btnDisableHover;
    }
    public void ButtonResetIdle()
    {
        btnReset.GetComponent<Image>().sprite = btnDisableIdle;
    }
    public void ButtonResetHover()
    {
        btnReset.GetComponent<Image>().sprite = btnDisableHover;
    }
    public void ButtonBack1Idle()
    {
        btnBack1.GetComponent<Image>().sprite = btnBackIdle;
    }
    public void ButtonBack1Hover()
    {
        btnBack1.GetComponent<Image>().sprite = btnBackHover;
    }
    public void ButtonBack1Click()
    {
        btnBack1.GetComponent<Image>().sprite = btnBackClick;
    }
    // back button in scoreBoard
    public void ButtonBack2Idle()
    {
        btnBack2.GetComponent<Image>().sprite = btnBackIdle;
    }
    public void ButtonBack2Hover()
    {
        btnBack2.GetComponent<Image>().sprite = btnBackHover;
    }
    public void ButtonBack2Click()
    {
        btnBack2.GetComponent<Image>().sprite = btnBackClick;
    }
    public void ButtonBack3Idle()
    {
        btnBack3.GetComponent<Image>().sprite = btnBackIdle;
    }
    public void ButtonBack3Hover()
    {
        btnBack3.GetComponent<Image>().sprite = btnBackHover;
    }
    public void ButtonBack3Click()
    {
        btnBack3.GetComponent<Image>().sprite = btnBackClick;
    }
    //turn off tutorial panel
    public void ButtonBack4Idle()
    {
        btnBack4.GetComponent<Image>().sprite = btnBackIdle;
    }
    public void ButtonBack4Hover()
    {
        btnBack4.GetComponent<Image>().sprite = btnBackHover;
    }
    #region About
    public void ButtonAboutIdle()
    {
        btnAbout.GetComponent<Image>().sprite = btnAboutIdle;
    }
    public void ButtonAboutHover()
    {
        btnAbout.GetComponent<Image>().sprite = btnAboutHover;
    }
    public void ButtonAboutClick()
    {
        btnAbout.GetComponent<Image>().sprite = btnAboutClick;
    }
    #endregion
    public void ButtonTutorialIdle()
    {
        btnTutorial.GetComponent<Image>().sprite = btnTutorialIdle;
    }
    public void ButtonTutorialHover()
    {
        btnTutorial.GetComponent<Image>().sprite = btnTutorialHover;
    }
    #endregion
}
