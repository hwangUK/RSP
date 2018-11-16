using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_RSPbody : MonoBehaviour {

    public CARD_TYPE mytype;
    public bool IsLeft;    
    // Use this for initialization
    
    IEnumerator coru_Win_Scissors()
    {
        float z = 0.1f;
        for (int i = 0; i < 1; i++)
            yield return new WaitForSeconds(0.8f);

        for (int i = 0; i < 31; i++)
        {
            z += (1 * 0.1f);
            //오므리는 상단 가위날
            transform.GetChild(0).Rotate(new Vector3(0.0f, 0.0f, 0.0f + z));
            //오므리는 하단 가위날
            transform.GetChild(1).Rotate(new Vector3(0.0f, 0.0f, 0.0f - z));
            yield return null;
        }
    }

    IEnumerator coru_Die_Scissors()
    {
        float z = 1.1f;
        for (int i = 0; i < 1; i++)
            yield return new WaitForSeconds(0.85f);

        for (int i = 0; i < 34; i++)
        {
            z += (1 * 0.2f);
            //벌어지는 상단 가위날
            transform.GetChild(0).Rotate(new Vector3(0.0f, 0.0f, 0.0f - z));
            //벌어지는 하단 가위날
            transform.GetChild(1).Rotate(new Vector3(0.0f, 0.0f, 0.0f + z));
            yield return null;
        }
    }

    public void DieEvent()
    {
        if (mytype == CARD_TYPE.SCISSORS)
            StartCoroutine(coru_Die_Scissors());
    }

    public void WinEvent()
    {
        if (mytype == CARD_TYPE.SCISSORS)
            StartCoroutine(coru_Win_Scissors());
    }

    public void DrawEvent()
    {
    }
}
