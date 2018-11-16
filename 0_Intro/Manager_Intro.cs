using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Intro : MonoBehaviour {

    public GameObject start;
    public GameObject login;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Btn_OpenStart()
    {
        start.SetActive(true);
        login.SetActive(false);
    }

    public void Btn_GoNextScene()
    {
        start.SetActive(true);
        login.SetActive(false);
    }

}
