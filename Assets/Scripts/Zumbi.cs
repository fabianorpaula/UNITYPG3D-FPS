using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zumbi : MonoBehaviour {

    public GameObject Jogador;
    private int contador = 0;

	// Use this for initialization
	void Start () {
        Jogador = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P))
        {
          // SceneManager 
        }

        transform.LookAt(Jogador.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, Jogador.transform.position, 0.01f);
       
	}


    void Perseguir()
    {

    }
}
