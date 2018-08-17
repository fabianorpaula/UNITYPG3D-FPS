using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zumbi : MonoBehaviour {

    public GameObject Jogador;
    private int contador = 0;
    private bool vivo = true;


    //Controla a Animação
    Animator anim;

    // Use this for initialization
    void Start () {
        Jogador = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
	void Update () {

        //so pode executar ações se estiver vivo
        if (vivo)
        {
            Debug.Log(Vector3.Distance(transform.position, Jogador.transform.position));
            float distanciazumbi = Vector3.Distance(transform.position, Jogador.transform.position);
            if(distanciazumbi < 1)
            {
                anim.SetInteger("Atacar", 2);
            }
            else if (distanciazumbi < 10)
            {
                anim.SetInteger("Andar", 2);
                anim.SetInteger("Atacar", 1);
                transform.LookAt(Jogador.transform.position);
                transform.position = Vector3.MoveTowards(transform.position, Jogador.transform.position, 0.005f);

            }
            else
            {
                anim.SetInteger("Andar", 0);
                anim.SetInteger("Atacar", 1);
            }

            /*
            if (zumbd < 2f) 
            {
                anim.SetInteger("Atacar", 2);

            }
            else if(zumbd < 10)
            {
                anim.SetInteger("Andar", 2);
                anim.SetInteger("Atacar", 1);
                transform.LookAt(Jogador.transform.position);
                transform.position = Vector3.MoveTowards(transform.position, Jogador.transform.position, 0.01f);
            }else
            {
                anim.SetInteger("Atacar", 0);
                anim.SetInteger("Andar", 1);
            }
            */
        }

    }

    //Morre-> chamado pela bala
    public void Morrer()
    {
        anim.SetBool("Morrer", true);
        vivo = false;
    }

    void Perseguir()
    {

    }
}
