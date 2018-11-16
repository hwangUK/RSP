using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class self_DrawCardList : MonoBehaviour {

    [HideInInspector]
    public List<Card> card = new List<Card>();
    public CARD_TYPE rsp;
    // Use this for initialization   

    private void Start()
    {
        card = Singletone_Player.MainPlayer.GetCard(rsp);
        DrawCardList();
    }

    void DrawCardList()
    {        
        for (int i = 0; i < card.Count; i++)
        {
            transform.GetChild(i).GetComponent<Image>().sprite = card[i].card_Img;
        }
    }
}
