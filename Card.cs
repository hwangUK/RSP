using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CARD_TYPE { ROCK, SCISSORS, PAPER, DEFAULT };

public class Card : MonoBehaviour {
    //card type
    public CARD_TYPE card_Type = CARD_TYPE.DEFAULT;
    [Space(10)]
    public Sprite card_Img;
    public Sprite card_Img_small;
    public Sprite card_Img_illust;

    [Space(20)]
    [Header("Information")]
    [SerializeField]
    int atk_Up;
    [SerializeField]
    int def_Up;
    [SerializeField]
    int hp_Up;
    
    // Use this for initialization
    void Start () {
        atk_Up = 0;
        def_Up = 0;
        hp_Up = 0;
        DrawCardImage();
    }
 
    public int Atk_Up { get { return atk_Up; } set { atk_Up = value; } }   
    public int Def_Up { get { return def_Up; } set { def_Up = value; } }   
    public int Hp_Up { get { return hp_Up; } set { hp_Up = value; } }

    void DrawCardImage()
    {
        if(card_Type != CARD_TYPE.DEFAULT)
        {            
            transform.GetComponent<Image>().sprite = card_Img;
        }
            
    }
    public void ShowCardDescription()
    {
        //현재 카드를 큰 화면 설명창에 출력
        GameObject.FindGameObjectWithTag("Card_Description").GetComponent<Image>().sprite = card_Img;
        //우측 선택화면에 출력
        if (card_Type == CARD_TYPE.ROCK)
            GameObject.FindGameObjectWithTag("Card_ShowSelected_R").GetComponent<Image>().sprite = card_Img;
        if(card_Type == CARD_TYPE.SCISSORS)
            GameObject.FindGameObjectWithTag("Card_ShowSelected_S").GetComponent<Image>().sprite = card_Img;
        if (card_Type == CARD_TYPE.PAPER)
            GameObject.FindGameObjectWithTag("Card_ShowSelected_P").GetComponent<Image>().sprite = card_Img;
    }
    public void EquipCardToPlayer()//현재 카드를 캐릭터에 추가*********************
    {        
        Singletone_Player.MainPlayer.addCard(card_Type, this);
    } 
}
