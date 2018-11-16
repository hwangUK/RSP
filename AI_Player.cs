using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Player : MonoBehaviour {

    public int P2_MaxHP;

    Stack<Card>[] CardList = new Stack<Card>[3];
    Stack<Card> AttackCardList = new Stack<Card>();  

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
