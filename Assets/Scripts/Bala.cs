using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision colisor)
    {
        //Debug.Log(colisor.gameObject.name);
        if(colisor.gameObject.tag== "Inimigo")
        {
            Destroy(colisor.gameObject, 3f);
            colisor.gameObject.GetComponent<Zumbi>().Morrer();
            Destroy(this.gameObject);
        }
    }
}
