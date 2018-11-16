using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singletone_Player : MonoBehaviour {

    //싱클톤
    public static Singletone_Player MainPlayer = null;
    private void Awake()
    {
        if(MainPlayer == null)
        {
            MainPlayer = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    #region SetPlayerInformation
    [Header("Player Status")]
    [SerializeField]
    int playerLevel;
    [SerializeField]
    int maxhp;
    [SerializeField]
    int curhp;
    [SerializeField]
    int atk;
    [SerializeField]
    int def;
    [SerializeField]
    int dmg;
    [SerializeField]
    int slotCount;    
    public int PlayerLevel { get { return playerLevel; } set { playerLevel = value; } }
    public int MaxHp { get { return maxhp; } set { maxhp = value; } }
    public int CurHp { get { return curhp; } set { curhp = value; } }
    public int Atk { get { return atk; } set { atk = value; } }
    public int Def { get { return def; } set { def = value; } }
    public int Dmg { get { return dmg; } set { dmg = value; } }
    public int SlotCount { get { return slotCount; } set { slotCount = value; } }
    #endregion

    [HideInInspector]
    //카드 밑장 추가 개수 r s p 3가지
    public int[] BehindCardCount = new int[3];

    //카드를 담을 리스트 생성 r s p 3가지
    private List<Card>[] myCardList = new List<Card>[3];
    //선택한 카드
    private List<Card> AttackCardList = new List<Card>();

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            BehindCardCount[i] = 0;
            myCardList[i] = new List<Card>();
        }
        //indexOfNowSelectCard_r = 1;
        //indexOfNowSelectCard_s = 1;
        //indexOfNowSelectCard_p = 1;        
        playerLevel = 1;
        maxhp = 50;
        curhp = maxhp;
        atk = 0;
        def = 0;
        dmg = 0;
        slotCount = 4;               
    }

    public void addCard(CARD_TYPE cType, Card addCard) //타입에 맞게 카드 추가
    {        
        if (cType == CARD_TYPE.ROCK)
        {            
            if(myCardList[0].Count >= slotCount) myCardList[0].RemoveAt(slotCount-1); //슬롯 갯수를 넘어서면 delete
            myCardList[0].Add(addCard);
            BehindCardCount[0] = myCardList[0].Count;
        }            
        else if (cType == CARD_TYPE.SCISSORS)
        {
            if (myCardList[1].Count >= slotCount) myCardList[1].RemoveAt(slotCount-1);
            myCardList[1].Add(addCard);
            BehindCardCount[1] = myCardList[1].Count;

        }            
        else if (cType == CARD_TYPE.PAPER)
        {
            if (myCardList[2].Count >= slotCount) myCardList[2].RemoveAt(slotCount-1);
            myCardList[2].Add(addCard);
            BehindCardCount[2] = myCardList[2].Count;
        } 
    }
    public List<Card> GetCard(CARD_TYPE cType)
    {
        if (cType == CARD_TYPE.ROCK){
            return myCardList[0]; // 
        }
        else if (cType == CARD_TYPE.SCISSORS) {
            return myCardList[1];
        }
        else if (cType == CARD_TYPE.PAPER){
            return myCardList[2];
        }
        else return null;
    }

    public void SetAttackCardList(Card input) // 커맨드 개수에 따라 입력한 카드들 입력 [ 공격 대기열 ]
    {
        AttackCardList.Add(input);
    }

    public List<Card> GetAttackCardList() // 커맨드 개수에 따라 입력한 카드들 하나씩 빼기 [ 공격 ]
    {
        return AttackCardList;
    }

    //------------------------------------------------기타 자주 사용하는 함수-----------------------------------------------------------------------------

    public void Btn_GoNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    } //씬 전환 함수
    public void Btn_GoPrevScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public IEnumerator Delay(float val)
    {
        yield return new WaitForSeconds(val);
    }
    public CARD_TYPE GetRandomCard()
    {
        CARD_TYPE ctype = new CARD_TYPE();
        int ran = Random.Range(0, 2);
        if (ran == 0) ctype = CARD_TYPE.ROCK;
        else if (ran == 1) ctype = CARD_TYPE.SCISSORS;
        else if (ran == 2) ctype = CARD_TYPE.PAPER;

        return ctype;
    }
}
