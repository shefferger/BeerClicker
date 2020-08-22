using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using System;


public class _game : MonoBehaviour
{
    Hashtable langT = new Hashtable();
    //adVideo normal - ca-app-pub-7406680285571154/2564574421
    //adBanner normal - ca-app-pub-7406680285571154/8826730445
    private const string appID = "ca-app-pub-7406680285571154~4482773017";
    private const string adVideo = "ca-app-pub-7406680285571154/2564574421";
    private const string simpleBanner = "ca-app-pub-7406680285571154/8826730445";
    private RewardBasedVideoAd rewardVideo;
    private BannerView bannerView;
    public static ulong litresSt, litresPerClickSt, litresPerSecondSt;
    public ulong litres, litresPerClick;

    public GameObject mainCam;

    public static bool menust = false, shopst = false, optionst = false, teleSt = false;
    public Button shopBtn, menuBtn;
    public GameObject adPanel;
    public GameObject backg, shopList, mainMenuList, optionMenu, tail, hand1, hand2, startLangSet, dayNightCircle, teleMenu;
    public Text allLitresText, lpsText, cpsText, fps, donatValue;
    public Text _continue, _options, _exit, _music, _sounds, _about, _lang, _resetsaves; 
    public AudioClip canOpening, mainTheme1;
    AudioSource _sound, _mainTheme;
    public static double _circleSpeed = 0.54f;
    double rotZ = 0;
    public static int donvalSt;
    public int donval;
    public Toggle tog;
    public GameObject btnLng;
    public Text watchAdTab, btnBack, btnWatch;
    private RewardedAd mRewardedVideoAd;

    void Awake()
    {  
        langT.Add("ru_Continue", "Продолжить");
        langT.Add("ru_Options", "Опции");
        langT.Add("ru_Exit", "Выход");

        langT.Add("ru_Music", "Музыка");
        langT.Add("ru_Sounds", "Звуки");
        langT.Add("ru_About", "О нас");
        langT.Add("ru_Lang", "Язык");
        langT.Add("ru_Resetsaves", "Сбросить\nсохранение");

        langT.Add("ru_WatchAndGet", "Посмотрите рекламу и\n получите 3 кренделя!");
        langT.Add("ru_Back", "Назад");
        langT.Add("ru_Watch", "Посмотреть");

        langT.Add("en_WatchAndGet", "Watch ad and\n get 3 pretzels!");
        langT.Add("en_Back", "Back");
        langT.Add("en_Watch", "Watch");

        langT.Add("en_Continue", "Continue");
        langT.Add("en_Options", "Options");
        langT.Add("en_Exit", "Exit");

        langT.Add("en_Music", "Music");
        langT.Add("en_Sounds", "Sounds");
        langT.Add("en_About", "About");
        langT.Add("en_Lang", "Language");
        langT.Add("en_Resetsaves", "Reset\nsaves");
      
        if (PlayerPrefs.HasKey("lang"))
        {
            _setLang();
        }
        else
        {
            startLangSet.SetActive(!startLangSet.activeSelf);
        }

        donval = 0;
        if (PlayerPrefs.HasKey("blitres"))
            litres = Convert.ToUInt64(PlayerPrefs.GetString("blitres"));
        else
            litres = 0;
        if (PlayerPrefs.HasKey("bkrendels"))
            donval = PlayerPrefs.GetInt("bkrendels");
        litresSt = litres;
        litresPerClick = 1;
        litresPerClickSt = litresPerClick;
        litresPerSecondSt = 0;
        donvalSt = donval;    
    }

    public void _changeLang()
    {
        if (PlayerPrefs.GetString("lang") == "ru")
            PlayerPrefs.SetString("lang", "en");
        else
            PlayerPrefs.SetString("lang", "ru");
        btnLng.SetActive(!btnLng.activeSelf);
        _setLang();
    }

    public void ru()
    {
        PlayerPrefs.SetString("lang", "ru");
        _setLang();
        startLangSet.SetActive(!startLangSet.activeSelf);    
    }

    public void en()
    {
        PlayerPrefs.SetString("lang", "en");
        _setLang();
        startLangSet.SetActive(!startLangSet.activeSelf);   
    }

    void _setLang()
    {
        string lng;
        ICollection keys = langT.Keys;
        if (PlayerPrefs.HasKey("lang"))
        {
            lng = PlayerPrefs.GetString("lang");

            _continue.text = langT[lng + "_Continue"].ToString();
            _options.text = langT[lng + "_Options"].ToString();
            _exit.text = langT[lng + "_Exit"].ToString();

            _music.text = langT[lng + "_Music"].ToString();
            _sounds.text = langT[lng + "_Sounds"].ToString();
            _about.text = langT[lng + "_About"].ToString();
            _lang.text = langT[lng + "_Lang"].ToString();
            _resetsaves.text = langT[lng + "_Resetsaves"].ToString();

            btnWatch.text = langT[lng + "_Watch"].ToString();
            btnBack.text = langT[lng + "_Back"].ToString();
            watchAdTab.text = langT[lng + "_WatchAndGet"].ToString();
        }
    }

    void Start()
    {
        InvokeRepeating("onSecGone", 1.0f, 1.0f);
        InvokeRepeating("_saveLitres", 8.0f, 3.0f);

        if (menust)
            menuSwitch();
        if (shopst)
            shopSwitch();
        //if ()
        //_mainTheme = GetComponent<AudioSource>();
        //AudioSource.PlayClipAtPoint(mainTheme1, admotransform.position);
        //_mainTheme.PlayOneShot(mainTheme1);
        MobileAds.Initialize(appID);
        if (PlayerPrefs.HasKey("music"))
        {
            //mainCam.GetComponent<AudioSource>().mute = Convert.ToBoolean(PlayerPrefs.GetString("music"));
            tog.isOn = !Convert.ToBoolean(PlayerPrefs.GetString("music"));
        }
        _sound = GetComponent<AudioSource>();
        _sound.PlayOneShot(canOpening);

        

        this.rewardVideo = RewardBasedVideoAd.Instance;

        // Called when an ad request has successfully loaded.
        rewardVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        // Called when an ad is shown.
        rewardVideo.OnAdOpening += HandleRewardBasedVideoOpened;
        // Called when the ad starts to play.
        rewardVideo.OnAdStarted += HandleRewardBasedVideoStarted;
        // Called when the user should be rewarded for watching a video.
        rewardVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        rewardVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

        this.RequestRewardBasedVideo();

        loadVideo();


        this.RequestBanner();
    }

    private void RequestBanner()
    {
        bannerView = new BannerView(simpleBanner, AdSize.Banner, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
    }
    

void loadVideo()
    {
        AdRequest request2 = new AdRequest.Builder().Build();
        this.rewardVideo.LoadAd(request2, adVideo);
    }

    private void RequestRewardBasedVideo()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        this.rewardVideo.LoadAd(request, adVideo);
    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardBasedVideoFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        donvalSt += 3;
    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }

void Update()
    {
        //if (!ad.IsLoaded() && !ldd)
        //{
            //ldd = true;
            //ad.LoadAd(request2);
        //}
        donval = donvalSt;
        litres = litresSt;
        allLitresText.text = shortener(litresSt) + " l.";
        lpsText.text = string.Format("{0:0}", litresPerSecondSt) + " l/s";
        cpsText.text = string.Format("{0:0}", litresPerClickSt) + " l/cl";
        fps.text = string.Format("FPS: " + "{0:0.00}", 1 / Time.deltaTime);
        donatValue.text = donval.ToString();

        litresPerClick = litresPerClickSt;
        litresPerClickSt = litresPerClick;

        Transform t1 = dayNightCircle.transform;
        rotZ = _circleSpeed;
        t1.rotation = Quaternion.Euler(0, 0, (float)rotZ);


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menust)
                menuSwitch();
            else if (shopst)
                shopSwitch();
            else
            {
                _saveLitres();
                appClose();
            }
        }
    }

    public void adToPretzels()
    {
        if (rewardVideo.IsLoaded())
        {
            rewardVideo.Show();
            loadVideo();
        }
        
    }

    public void musicChanged()
    {
        mainCam.GetComponent<AudioSource>().mute = !mainCam.GetComponent<AudioSource>().mute;
        PlayerPrefs.SetString("music", mainCam.GetComponent<AudioSource>().mute.ToString());
    }

    private string shortener(ulong a)
    {
        string res = a.ToString();
        string multiplier = "";
        if (a >= 10000 && a < 1000000)
        {
            a = a / 1000;
            multiplier = "K.";
        }
        else if (a >= 1000000 && a < 1000000000)
        {
            a = a / 1000000;
            multiplier = "M.";
        }
        else if (a >= 1000000000 && a < 1000000000000)
        {
            a = a / 1000000000;
            multiplier = "B.";
        }
        else if (a >= 1000000000000 && a < 1000000000000000)
        {
            a = a / 1000000000000;
            multiplier = "Q.";
        }
        res = a.ToString() + multiplier;
        return res;
    }

    public void setDefaultVals()
    {
        litres = 0;
        litresSt = 0;
        litresPerClickSt = 1;
        litresPerSecondSt = 0;
    }

    private void _saveLitres()
    {
        PlayerPrefs.SetString("blitres", litresSt.ToString());
        // SAVING
        PlayerPrefs.SetInt("bkrendels", donvalSt);
    }

    public void _delAllSaves()
    {
        PlayerPrefs.DeleteAll();
        setDefaultVals();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void onTailClick()
    {
        //bigLitres.plus((int)litresPerClickSt);
        litresSt += litresPerClickSt;
    }

    public static void onFriendClick()
    {
        Debug.Log("friend clicked when not sleep");
        litresSt += (litresPerClickSt * (Convert.ToUInt64(PlayerPrefs.GetInt("sosed")) + 1));
    }

    private void onSecGone()
    {
        litresSt += litresPerSecondSt;
    }

    public void appClose() // КНОПКА ЗАРКЫТЬ ПРИЛОЖЕНИЕ
    {
        _saveLitres();
        Application.Quit();
    }

    public void menuSwitch() // ВКЛ ВЫКЛ МЕНЮ
    {
        if (adPanel.activeSelf)
            adPanel.SetActive(!adPanel.activeSelf);
        if (shopst)
            shopSwitch();
        if (optionst)
            optionsSwitch();
        if (teleSt)
            telephoneSwitch();
        menust = !menust;
        mainMenuList.SetActive(!mainMenuList.activeSelf);
        backg.SetActive(!backg.activeSelf);
    }

    public void shopSwitch() //ВКЛ ВЫКЛ МАГАЗИН
    {
        if (adPanel.activeSelf)
            adPanel.SetActive(!adPanel.activeSelf);
        if (menust)
            menuSwitch();
        if (optionst)
            optionsSwitch();
        if (teleSt)
            telephoneSwitch();
        shopst = !shopst;
        backg.SetActive(!backg.activeSelf);
        shopList.SetActive(!shopList.activeSelf);
    }
    //asdasd
    public void optionsSwitch()
    {
        if (menust)
            menuSwitch();
        backg.SetActive(!backg.activeSelf);
        optionMenu.SetActive(!optionMenu.activeSelf);
        optionst = !optionst;
    }

    public void telephoneSwitch()
    {
        if (adPanel.activeSelf)
            adPanel.SetActive(!adPanel.activeSelf);
        if (shopst)
            shopSwitch();
        if (menust)
            menuSwitch();
        if (optionst)
            optionsSwitch();
        backg.SetActive(!backg.activeSelf);
        teleMenu.SetActive(!teleMenu.activeSelf);
        teleSt = !teleSt;
    }

    public void outlineSwitch(UnityEngine.GameObject sender)
    {
        sender.GetComponent<Outline>().enabled = !sender.GetComponent<Outline>().enabled;
    }
}