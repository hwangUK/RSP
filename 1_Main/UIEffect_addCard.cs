using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEffect_addCard : MonoBehaviour
{
    int idx_r = 1; // 넘기며 밑장 보기 인덱스
    int idx_s = 1;
    int idx_p = 1;

    public void update_addCardEffect() //가드 밑장 추가되는 효과
    {
        for (int i = 1; i <= Singletone_Player.MainPlayer.BehindCardCount[0]; i++) transform.GetChild(0).GetChild(i-1).gameObject.SetActive(true);
        for (int i = 1; i <= Singletone_Player.MainPlayer.BehindCardCount[1]; i++) transform.GetChild(2).GetChild(i-1).gameObject.SetActive(true);
        for (int i = 1; i <= Singletone_Player.MainPlayer.BehindCardCount[2]; i++) transform.GetChild(4).GetChild(i-1).gameObject.SetActive(true);
    }

    public void change_nextCard_R()
    {
        //싱글톤에 저장된 나의 카드 이미지를 순차 순환 호출        
        transform.GetChild(1).GetComponent<Image>().sprite = 
            Singletone_Player.MainPlayer.GetCard(CARD_TYPE.ROCK)[++idx_r % Singletone_Player.MainPlayer.BehindCardCount[0]].card_Img;
    } //내 카드 넘기며 보여주기
    public void change_nextCard_S()
    {
        //싱글톤에 저장된 나의 카드 이미지를 순차 순환 호출        
        transform.GetChild(3).GetComponent<Image>().sprite = 
            Singletone_Player.MainPlayer.GetCard(CARD_TYPE.SCISSORS)[++idx_s % Singletone_Player.MainPlayer.BehindCardCount[1]].card_Img;
    }
    public void change_nextCard_P()
    {
        //싱글톤에 저장된 나의 카드 이미지를 순차 순환 호출        
        transform.GetChild(5).GetComponent<Image>().sprite = 
            Singletone_Player.MainPlayer.GetCard(CARD_TYPE.PAPER)[++idx_p % Singletone_Player.MainPlayer.BehindCardCount[2]].card_Img;
    }
}
