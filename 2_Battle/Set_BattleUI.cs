using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_BattleUI : MonoBehaviour {

    private GameObject player1;
    private GameObject player2;
    private bool isP1Win;
    private bool isP2Win;

    public CARD_TYPE p1;
    public CARD_TYPE p2;

    //이기는쪽이 위로 올라와야 하기때문에 이런 수고를
    private GameObject LeftWin;
    private GameObject RightWin;

    Vector3 saveP1;
    Vector3 saveP2; 
        
    // Use this for initialization
    void Start () {
        LeftWin = transform.GetChild(1).gameObject;
        RightWin = transform.GetChild(2).gameObject;
    }
    private void SetPlayer()
    {
        isP1Win = false;
        isP2Win = false;
        if (p1 == CARD_TYPE.ROCK)
        {
            switch (p2)
            {
                case CARD_TYPE.ROCK:
                    {
                        //돌vs돌 비김                           L/R        R/C/P
                        player1 = LeftWin.transform.GetChild(1).GetChild(0).gameObject;
                        player2 = LeftWin.transform.GetChild(0).GetChild(0).gameObject;
                        break;
                    }
                case CARD_TYPE.SCISSORS:
                    {
                        //돌vs가위 이김
                        player1 = LeftWin.transform.GetChild(1).GetChild(0).gameObject;
                        player2 = LeftWin.transform.GetChild(0).GetChild(1).gameObject;
                        isP1Win = true;
                        break;
                    }
                case CARD_TYPE.PAPER:
                    {
                        //돌vs보 짐
                        player1 = RightWin.transform.GetChild(0).GetChild(0).gameObject;
                        player2 = RightWin.transform.GetChild(1).GetChild(2).gameObject;
                        isP2Win = true;
                        break;
                    }
            }
        }
        else if (p1 == CARD_TYPE.SCISSORS)
        {
            switch (p2)
            {
                case CARD_TYPE.ROCK:
                    {
                        //가위vs돌 짐
                        player1 = RightWin.transform.GetChild(0).GetChild(1).gameObject;
                        player2 = RightWin.transform.GetChild(1).GetChild(0).gameObject;
                        isP2Win = true;
                        break;
                    }
                case CARD_TYPE.SCISSORS:
                    {
                        //가위vs가위 비김
                        player1 = LeftWin.transform.GetChild(1).GetChild(1).gameObject;
                        player2 = LeftWin.transform.GetChild(0).GetChild(1).gameObject;
                        break;
                    }
                case CARD_TYPE.PAPER:
                    {
                        //가위vs보 이김
                        player1 = LeftWin.transform.GetChild(1).GetChild(1).gameObject;
                        player2 = LeftWin.transform.GetChild(0).GetChild(2).gameObject;
                        isP1Win = true;
                        break;
                    }
            }
        }
        else if (p1 == CARD_TYPE.PAPER)
        {
            switch (p2)
            {
                case CARD_TYPE.ROCK:
                    {
                        //보vs돌 이김
                        player1 = LeftWin.transform.GetChild(1).GetChild(2).gameObject;
                        player2 = LeftWin.transform.GetChild(0).GetChild(0).gameObject;

                        break;
                    }
                case CARD_TYPE.SCISSORS:
                    {
                        //보vs가위 짐
                        player1 = RightWin.transform.GetChild(0).GetChild(2).gameObject;
                        player2 = RightWin.transform.GetChild(1).GetChild(1).gameObject;
                        isP2Win = true;
                        break;
                    }
                case CARD_TYPE.PAPER:
                    {
                        //보vs보 비김
                        player1 = LeftWin.transform.GetChild(1).GetChild(2).gameObject;
                        player2 = LeftWin.transform.GetChild(0).GetChild(2).gameObject;
                        break;
                    }
            }
        }
    }
    public void BattleReStart(CARD_TYPE player1, CARD_TYPE player2)
    {
        p1 = player1;
        p2 = player2;
        BattleStart();
    }
    public void BattleStart()
    {
        SetPlayer();
        player1.gameObject.SetActive(true);
        player2.gameObject.SetActive(true);
        
        if (isP1Win && !isP2Win)
        {
            StartCoroutine(moveUI());
            player1.GetComponent<UI_RSPbody>().WinEvent();
            player2.GetComponent<UI_RSPbody>().DieEvent();
        }
        else if (!isP1Win && isP2Win)
        {
            StartCoroutine(moveUI());
            player1.GetComponent<UI_RSPbody>().DieEvent();
            player2.GetComponent<UI_RSPbody>().WinEvent();
        }
        else
        {
            StartCoroutine(moveUI());
            //비김 다시한번
            //  player1.GetComponent<UI_RSPbody>().DrawEvent();
            //  player2.GetComponent<UI_RSPbody>().DrawEvent();
            Debug.Log("비겼습니다 다시한번 입력");
        }        
    }
    
    IEnumerator moveUI()
    {
        float t = 0.1f;
        //예외처리를위하여 왼쪽플레이어의 정보를 가져오기위한 변수
        
        UI_RSPbody p1_infor = player1.GetComponent<UI_RSPbody>();
        //RectTransform RT = player1.GetComponent<RectTransform>();
        //saveP1 = new Vector3(RT.position.x, RT.position.y, RT.position.z);
        saveP1 = new Vector3(player1.transform.position.x, player1.transform.position.y, player1.transform.position.z);
        saveP2 = new Vector3(player2.transform.position.x, player2.transform.position.y, player2.transform.position.z);

        for (int i = 0; i < 55; i++)
        {            
            t += 0.1f;
            //왼쪽 가위 회전하였기에 예외처리
            if (p1_infor.IsLeft && p1_infor.mytype == CARD_TYPE.SCISSORS)
            {
                player1.transform.Translate(Vector3.left * t);
                player2.transform.Translate(Vector3.left * t);
            }                
            else
            {
                player1.transform.Translate(Vector3.right * t);
                player2.transform.Translate(Vector3.left * t);
            }                
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        player1.transform.position = saveP1;
        player2.transform.position = saveP2;

        player1.gameObject.SetActive(false);
        player2.gameObject.SetActive(false);
    }
}
