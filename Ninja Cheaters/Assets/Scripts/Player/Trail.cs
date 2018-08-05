using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour {


    public float LifeTime = 3f;
	// Use this for initialization
	void Start () {
        StartCoroutine(selfDestruct());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(LifeTime);
        Destroy(gameObject);
    }
}
