using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Battle : MonoBehaviour {

    public GameObject Wnd_SelectRSP;    

    public GameObject Wnd_Battle_Anim;
    private Set_BattleUI Script_BattleAnim;

    public int setStage_MaxCountOfCommand = 3; //stage 커맨드 한계 세팅
    private int setStage_NowCountOfCommand = 0;

    public List<GameObject> P2 = new List<GameObject>(); //적 객체 배열

    [HideInInspector]
    public Card p1_selectOne;
    [HideInInspector]
    public Card p2_selectOne;
    [HideInInspector]
    public List<Card> selectedCardList = new List<Card>();

    public void SetNowCard(Card c)
    {
        p1_selectOne = c;
    }
    public void Enqueue_CardToList()
    {
        selectedCardList.Add(p1_selectOne);
    }
    public Card Dequeue_CardAtList()
    {
        Card tmp = new Card();
        tmp = selectedCardList[0];
        selectedCardList.RemoveAt(0);
        return tmp;
    }

    public void Increase_CommandCount()
    {
        setStage_NowCountOfCommand++;
    }
    public void Reset_CommandCount()
    {
        setStage_NowCountOfCommand =0;
    }

    #region Player1
    //int p1_nowHP = 0 ;
    //int p1_nowAtk = 0;
    //int p1_nowDef = 0;
    //int p1_damage = 0;
    #endregion

    #region Player2
    //int p2_nowHP = 0;
    //int p2_nowAtk = 0;
    //int p2_nowDef = 0;
    //int p2_damage = 0;
    #endregion

    void Start()
    {
        StartCoroutine(InitScene());
        Script_BattleAnim = Wnd_Battle_Anim.GetComponent<Set_BattleUI>();
    }

    //출현 적의 숫자
    //적의 능력치 세팅
    // Use this for initialization

    public bool CheckFullOfCommand()
    {
        return setStage_MaxCountOfCommand <= setStage_NowCountOfCommand; 
    }

    IEnumerator InitScene()
    {
        //1초 지연 후 선택창 열기 
        yield return new WaitForSeconds(1.1f);
        Wnd_SelectRSP.GetComponent<Set_ChoiceCard_UI>().OpenSelectRSP();        
    }

    public void StartBattle()
    {
        StartCoroutine(Start_Scene());       
        //캐릭터 전투 데미지 갱신
        //캐릭터 애니메이션 처리
    }

    IEnumerator Start_Scene()
    {
        //1초 지연 후 선택창 열기       
        Wnd_Battle_Anim.gameObject.SetActive(true);
        for (int i = 0; i < setStage_MaxCountOfCommand; i++)
        {
            Script_BattleAnim.BattleReStart(selectedCardList[0].card_Type, Singletone_Player.MainPlayer.GetRandomCard());
            yield return new WaitForSeconds(3.1f);           
        }
        
    }
    public void EndBattle()
    {
        Wnd_Battle_Anim.gameObject.SetActive(false);
        //초기화
    }

    public void SetBattleRSPType(CARD_TYPE input_p1, CARD_TYPE input_p2)
    {
        Wnd_Battle_Anim.GetComponent<Set_BattleUI>().p1 = input_p1;
        Wnd_Battle_Anim.GetComponent<Set_BattleUI>().p2 = input_p2;
    }
}
