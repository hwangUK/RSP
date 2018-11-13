using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Scissor : MonoBehaviour {

    private Transform uptranform;
    private Transform downtranform;
    // Use this for initialization
    void Start () {
        StartCoroutine(coru_Die());
        //StartCoroutine(coru_Win());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator coru_Die()
    {
        float z = 0.1f;
        for(int i=0; i< 50; i++)
        {
            z+=(1 * 0.1f);
            transform.GetChild(0).Rotate(new Vector3(0.0f, 0.0f, 0.0f - z));
            transform.GetChild(1).Rotate(new Vector3(0.0f, 0.0f, 0.0f + z));
            yield return null;
        }        
    }
    IEnumerator coru_Win()
    {
        float z = 0.1f;
        for (int i = 0; i < 31; i++)
        {
            z += (1 * 0.1f);
            transform.GetChild(0).Rotate(new Vector3(0.0f, 0.0f, 0.0f + z));
            transform.GetChild(1).Rotate(new Vector3(0.0f, 0.0f, 0.0f - z));
            yield return null;
        }
    }
    void DieEvent()
    {
        
        
    }
}
