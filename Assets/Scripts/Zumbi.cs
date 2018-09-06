﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zumbi : MonoBehaviour {

    public GameObject Jogador;
    private int contador = 0;
    private bool vivo = true;
    private AudioSource Som;

    private GameControl GameControlador;
    private float vel;

    //Controla a Animação
    Animator anim;

    // Use this for initialization
    void Start () {
        Jogador = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        Som = GetComponent<AudioSource>();
        Som.mute = true;
        GameControlador = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>();
        vel = Random.Range(0.005f, 0.05f);
    }
	
	// Update is called once per frame
	void Update () {
        if (GameControlador.JogoPausado() == false)
        {
            //so pode executar ações se estiver vivo
            if (vivo)
            {
                // Debug.Log(Vector3.Distance(transform.position, Jogador.transform.position));
                float distanciazumbi = Vector3.Distance(transform.position, Jogador.transform.position);
                if (distanciazumbi < 1)
                {
                    anim.SetInteger("Atacar", 2);
                    transform.LookAt(Jogador.transform.position);
                    transform.position = Vector3.MoveTowards(transform.position, Jogador.transform.position, vel);
                }
                else if (distanciazumbi < 10)
                {
                    Som.mute = false;
                    anim.SetInteger("Andar", 2);
                    anim.SetInteger("Atacar", 1);
                    transform.LookAt(Jogador.transform.position);
                    transform.position = Vector3.MoveTowards(transform.position, Jogador.transform.position, vel);

                }
                else
                {
                    Som.mute = true;
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

    }

    //Morre-> chamado pela bala
    public void Morrer()
    {
        anim.SetBool("Morrer", true);
        vivo = false;
        GameControlador.pontos += 10;
        GameControlador.qtd_inimigo--;
    }

    void Perseguir()
    {

    }
}
