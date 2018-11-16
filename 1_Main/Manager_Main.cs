using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Main : MonoBehaviour {

    public GameObject SetCardPanel;
    public List<Card> registerCard_rock = new List<Card>();
    public List<Card> registerCard_scissors = new List<Card>();
    public List<Card> registerCard_paper = new List<Card>();

    public void OpenSetCardPanel()
    {
        SetCardPanel.gameObject.SetActive(true);
    }
    public void CloseSetCardPanel()
    {
        SetCardPanel.gameObject.SetActive(false);        
    }
}
