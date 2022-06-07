using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<soundManager>();


            }

            return m_instance;
        }
    }

    private static soundManager m_instance;

    [HideInInspector]
    public bool isServed;
    [HideInInspector]
    public bool isCoffee;
    [HideInInspector]
    public bool isMocha;
    [HideInInspector]
    public bool isDeleted;
    [HideInInspector]
    public bool isPlated;
    [HideInInspector]
    public bool isAchieved;
    [HideInInspector]
    public bool isFailed;
    [HideInInspector]
    public bool isGameover;
    [HideInInspector]
    public bool isStar_1;
    [HideInInspector]
    public bool isStar_2;
    [HideInInspector]
    public bool isStar_3;
    [HideInInspector]
    public bool isClick;
    [HideInInspector]
    public bool isCoffeeloop;
    [HideInInspector]
    public bool isMochaloop;
    [HideInInspector]
    public bool isPanloop;
    [HideInInspector]
    public bool isRefill;
    [HideInInspector]
    public bool isOverCooked;
    [HideInInspector]
    public bool isWash;
    [HideInInspector]
    public bool isDestroyed;
    [HideInInspector]
    public bool isSmoke;
    [HideInInspector]
    public bool isOrder;
    [HideInInspector]
    public bool isSpecialOrder;

    public bool isOver;

    private AudioSource soundSfx;
    public AudioSource backgroundMusic;
    public AudioSource HurryUpMusic;
    public AudioClip ServeAudio;
    public AudioClip DeleteItem;
    public AudioClip Plate;
    public AudioClip AchiveSound;
    public AudioClip FailSound;
    public AudioClip GameoverSound;
    public AudioClip destroySound;
    public AudioClip Star_1Sound;
    public AudioClip Star_2Sound;
    public AudioClip Star_3Sound;
    public AudioClip Click;
    public AudioClip reFill;
    public AudioClip Orderbell;
    public AudioClip Specialorderbell;
    public AudioClip GameOverBell;

    private bool isTrue;
    private bool isLoop;
    private bool isOverloop;
    


    // Start is called before the first frame update
    void Start()
    {
        soundSfx = GetComponent<AudioSource>();

        isTrue = true;

        isLoop = true;

        isOverloop = true;


    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isPaused)
        {  
            backgroundMusic.Pause();
            //soundSfx.Pause();
            
        }

        if (!GameManager.instance.isPaused)
        {
            backgroundMusic.UnPause();
            //soundSfx.UnPause();
            
        }

        if(isOver)
        {
            if(isOverloop)
            {
                soundSfx.PlayOneShot(GameOverBell);
                isOverloop = false;
            }
        }


        if (GameManager.instance.isHurryup)
        {
            HurryUpMusic.UnPause();
            if (GameManager.instance.isPaused)
            {
                HurryUpMusic.Pause();
               
            }
        }

        if (!GameManager.instance.isHurryup)
        {
            HurryUpMusic.Pause();
        }

        if (isServed == true)
        {
            soundSfx.PlayOneShot(ServeAudio);
            isServed = false;
        }

        if (isClick == true)
        {
            soundSfx.PlayOneShot(Click);
            isClick = false;
        }

        if(isDestroyed == true)
        {
            soundSfx.PlayOneShot(destroySound);
            isDestroyed = false;
        }

       if(isOrder == true)
        {
            soundSfx.PlayOneShot(Orderbell);
            isOrder = false;
        }

        if (isSpecialOrder == true)
        {
            soundSfx.PlayOneShot(Specialorderbell);
            isSpecialOrder = false;
        }

        if (isDeleted == true)
        {
            soundSfx.PlayOneShot(DeleteItem);
            isDeleted = false;
        }

        if (isPlated == true)
        {
            soundSfx.PlayOneShot(Plate);
            isPlated = false;
        }
        if (isAchieved == true)
        {
            soundSfx.PlayOneShot(AchiveSound);
            isAchieved = false;
        }

        if (isFailed == true)
        {
            soundSfx.PlayOneShot(FailSound);
            isFailed = false;
        }

        if (isGameover == true)
        {
            soundSfx.PlayOneShot(GameoverSound);
            isGameover = false;
        }

        if(isStar_1 == true)
        {
            soundSfx.PlayOneShot(Star_1Sound);
            
            isStar_1 = false;
        }

        if (isStar_2 == true)
        {
            soundSfx.PlayOneShot(Star_2Sound);
            
            isStar_2 = false;
        }

        if (isStar_3 == true)
        {
            soundSfx.PlayOneShot(Star_3Sound);
            
            isStar_3 = false;
        }

        if (isRefill == true)
        {
            soundSfx.PlayOneShot(reFill);
            print("REFILL!!");
            isRefill = false;
        }
        
    }
}
