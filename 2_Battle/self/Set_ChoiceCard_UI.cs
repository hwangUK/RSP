using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_ChoiceCard_UI : Manager_Battle {

    //
    Stack<CARD_TYPE> saveCommand = new Stack<CARD_TYPE>();
    Manager_Battle mng_battle = new Manager_Battle();

    public GameObject Command_Bar;

    [Space(10)]
    public GameObject UI_Icon_commandBar_Rock;
    public GameObject UI_Icon_commandBar_Scissors;
    public GameObject UI_Icon_commandBar_Paper;

    int MaxCommandCount;
    int NowCommandCount;

    private void Start()
    {
        mng_battle = transform.parent.GetComponent<Manager_Battle>();
        NowCommandCount = 0;
        MaxCommandCount = mng_battle.setStage_MaxCountOfCommand;
    }
 

    public void OpenSelectRSP() // UI묵찌빠 선택창 열기
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void CloseSelectRSP() // UI묵찌빠 선택창 닫기
    {
        transform.GetChild(0).gameObject.SetActive(false);        
        //Singletone_Player.MainPlayer.AttackCardList = saveCard; //현재 선택한 카드정보를 싱글톤플레이어에게 전달
    }

    //버튼에연결됨 
    public void OpenSelectedCardList(int index) // UI카드선택창 열기 0 = rock, 1= scissors, 2 = paper
    {
        if (index == 0) transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        else if (index == 1) transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
        else if (index == 2) transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
    }

    public void CloseSelectedCardListAll() // UI카드선택창 닫기
    {
        for (int i = 0; i < 3; i++)
            transform.GetChild(1).GetChild(i).gameObject.SetActive(false);

        mng_battle.Enqueue_CardToList(); //대기열에 추가
        Debug.Log(mng_battle.selectedCardList.Count);
        mng_battle.Increase_CommandCount();
        if (mng_battle.CheckFullOfCommand()) // 입력이 끝났다면
        {
            CloseSelectRSP(); // 현재 창 닫기
            mng_battle.StartBattle();        
        }
    }

    public void Anim_InsertIconToBar(int index)  // IU_Effect : index에 따른 커맨드 바 종류 선택 후 아이콘 삽입
    {
        if (NowCommandCount < MaxCommandCount)
        {
            if (index == 0)
            {
                saveCommand.Push(CARD_TYPE.ROCK);
                Instantiate(UI_Icon_commandBar_Rock, Command_Bar.transform);
            }
            else if (index == 1)
            {
                saveCommand.Push(CARD_TYPE.SCISSORS);
                Instantiate(UI_Icon_commandBar_Scissors, Command_Bar.transform);
            }
            else if (index == 2)
            {
                saveCommand.Push(CARD_TYPE.PAPER);
                Instantiate(UI_Icon_commandBar_Paper, Command_Bar.transform);
            }
            NowCommandCount++;
        }
    }

    //--------------------------------------------
    IEnumerator debug_timer(float inn)
    {
        yield return new WaitForSeconds(inn);
    }
}
