using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class self_SelectCardListOfOne : MonoBehaviour
{
    Manager_Battle mng_battle = new Manager_Battle();

    private void Start()
    {
        mng_battle = GameObject.FindGameObjectWithTag("Manager_Battle").GetComponent<Manager_Battle>();
    }

    public void SelectListOfOne()
    {        
        //선택시 현재 카드를 싱글톤 정보에 추가 *******************
        if(transform.parent.GetComponent<self_DrawCardList>().card.Count > transform.GetSiblingIndex() && !mng_battle.CheckFullOfCommand())
        {
            //형제4번 이미지를 -> 현재 자기자신 인덱스의 카드 이미지로 교체
            transform.parent.GetChild(4).GetComponent<Image>().sprite = transform.parent.GetComponent<self_DrawCardList>().card[transform.GetSiblingIndex()].card_Img;
            // 현재 자신을 대기열 후보값으로 갱신
            mng_battle.SetNowCard(transform.parent.GetComponent<self_DrawCardList>().card[transform.GetSiblingIndex()]);
        }        
    }
	// Update is called once per frame
	void Update () {
		
	}
}
