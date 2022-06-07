using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageStart : MonoBehaviour
{
    [Header("UI")]
    public GameObject startUI;
    public GameObject stageUI;

    [Header("Stage")]
    public GameObject[] stagelock;
    public GameObject[] stageOpen;
    public GameObject[] stage1star;
    public GameObject[] stage2star;
    public GameObject[] stage3star;

    private int isStaged; // 나중에 스테이지에서 화면으로 돌아올 때 
    private int levelat;
    //private List<int> stageStar = new List<int>();
    private int[] stageStar = new int[9];

    private int stageStar1;
    private int stageStar2;
    private int stageStar3;
    private int stageStar4;
    private int stageStar5;
    private int stageStar6;
    private int stageStar7;
    private int stageStar8;
    private int stageStar9;

    //private List<int> stageList = new List<int>();

    //stageStar[0] = 2;

    // Start is called before the first frame update
    void Start()
    {
        // 스테이지 별개수 불러오기
        stageStar1 = 2;
        stageStar[0] = stageStar1;
        stageStar2 = 2;
        stageStar[1] = stageStar2;
        stageStar3 = 1;
        stageStar[2] = stageStar3;
        stageStar4 = 0;
        stageStar[3] = stageStar4;
        //isStaged = 1;
        stageStar5 = 0;
        stageStar[4] = stageStar5;
        stageStar6 = 0;
        stageStar[5] = stageStar6;
        stageStar7 = 0;
        stageStar[6] = stageStar7;
        stageStar8 = 0;
        stageStar[7] = stageStar8;
        stageStar9 = 0;
        stageStar[8] = stageStar9;

        levelat = 6;

        int a = 1;

        // 레벨에 따른 스테이지 언락
        for(int i = 0; i < levelat; i++)
        {
            stageOpen[i].SetActive(true);
            stagelock[i].SetActive(false);
        }

        for(int i = levelat; i < stageOpen.Length; i++)
        {
            stageOpen[i].SetActive(false);
            stagelock[i].SetActive(true);
        }

        
        if(isStaged == 1 ) // 나중에 스테이지에서 돌아올때
        {
            SetstageUIOn();
        }

        
        for (int i = 0; i < stageStar.Length; i++)
        {
            if (stageStar[i] == 0)
            {
                stage1star[i].SetActive(true);
            }

            if (stageStar[i] == 1)
            {
                stage2star[i].SetActive(true);
            }

            if (stageStar[i] == 2)
            {
                stage3star[i].SetActive(true);
            }
        }

        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetstageUIOn()
    {
        startUI.SetActive(false);
        stageUI.SetActive(true);
    }

    public void SetlobbyUIOn()
    {
        startUI.SetActive(true);
        stageUI.SetActive(false);
    }
}
