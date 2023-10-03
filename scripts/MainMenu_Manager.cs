using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//using Facebook.Unity;

public class MainMenu_Manager : MonoBehaviour 
{
    // ----------- Static Ref. of Main Menu Handler Start------------//
    public static MainMenu_Manager mmsh;
    // ----------- Static Ref. of Main Menu Handler End------------//

    [Header("Loading Screen")]
    public bool isLoading;
    public Image LoadingBar;
    public Text loading_Text;
    public GameObject loadingPanel;
    public float loadingDelayTime;

    [Header("Main Menu Stuff")]
    public GameObject mainMenu;
    public GameObject settingsDialoug;
    public GameObject[] RemoveAdsBtns, unlockAllButton, unlockAllChars;
    public GameObject UnlockEveryThing, Shop;
    public Image soundButton;
    public Sprite soundOn, SoundOff;
    bool soundState = true;

    [Header("Text Fields to Display User Coins")]
    public Text UserCoinsText;
    public int coinstoadd;
    

    void Start()
    {
        if (mmsh == null)
        {
            mmsh = this;
        }

        
        OnStart();
       
    }
  
    private void LateUpdate()
    {
        if (isLoading)
        {
            LoadingBar.fillAmount += 0.006f;
            if (LoadingBar.fillAmount == 1)
            {
                isLoading = false;
            }
        }
    }
   

    public void OnStart()
    {

        Time.timeScale = 1f;
       
        SoundManager._SoundManager.playMainMenuSounds(1f);
       
        if (PlayerPrefs.GetInt("ComingFromGP", 0) == 1)
        {
            PlayerPrefs.SetInt("ComingFromGP", 0);
        }
        StoreScriptHandler.storeScript.firstTimeComing(100);
        updateCoins();
    }


   
    public void updateCoins()
    {
        UserCoinsText.text = StoreScriptHandler.storeScript.getTotalEarnedCoins().ToString();
       
    }
   

   

    public void PlayButtonClickSound()
    {
        SoundManager._SoundManager.playButtonClickSound();
    }

    public void settingsDialougStatus(bool temp)
    {
        if (temp) {
            settingsDialoug.SetActive(true);
            //			AdsManager.adsManager.showAd ();
        }
        else if (!temp) {
            settingsDialoug.SetActive(false);
        }
    }


    public void Play()
    {
        StartCoroutine(LoadScene());
        //Call Interstitial Ads Here
    }
  
   
    
    IEnumerator LoadScene()
    {
      
        loadingPanel.SetActive(true);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(2);

        while (!asyncOperation.isDone)
        {

            loading_Text.text = (int)(asyncOperation.progress * 100) + "%";
            if (LoadingBar) LoadingBar.fillAmount = asyncOperation.progress;

            yield return null;
        }
      
    }

    public void SoundToggle()
    {
        soundState = !soundState;
        if (soundState) {
            soundButton.sprite = soundOn;
            AudioListener.volume = 1;
        }
        else if (!soundState) {
            soundButton.sprite = SoundOff;
            AudioListener.volume = 0;
        }
    }


    public void Exitbtn()
    {
        Application.Quit();
    }

   
    
  
   
    public void GotoShop()
    {
        Shop.SetActive(true);
    }

    public void OpenPrivacyLink()
    {
        Application.OpenURL("https://maxgames001.blogspot.com/p/privacy-policy.html");
    }
    public void OpenMoreapps()
    {
        Application.OpenURL("https://play.google.com/store/apps/developer?id=Max+Gamer+Studio");
    }

    public void rateUsApp()
    {
        Application.OpenURL("#");
    }

}
