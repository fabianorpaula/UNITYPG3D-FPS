﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle : MonoBehaviour {

    //Eixos
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    //Sensibilidade
    public float sensibilidadeX = 5F;
    public float sensibilidadeY = 5F;
    //Minimo
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationY = 0F;


    private GameObject Bala2;

    public float rotacao = 150;
    public float velocidade = 3;
    public float forcabala = 5000.0f;
    public GameObject Bala;
    public GameObject Saida;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;

        Bala = Resources.Load("caramelo") as GameObject;

    }
	
	// Update is called once per frame
	void Update () {
        //float x = Input.GetAxis("Horizontal") * Time.deltaTime * rotacao;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * velocidade;
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * velocidade;
        //transform.Rotate(0, x, 0);
        transform.Translate(x, 0, z);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject Disparo = Instantiate(Bala, Saida.transform.position, Quaternion.identity);
            Disparo.GetComponent<Rigidbody>().AddForce(transform.forward * forcabala);
            Destroy(Disparo, 2f);
        }
        Mouse();

    }


    void Mouse()
    {

        if (axes == RotationAxes.MouseXAndY)
        {
            //partex
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensibilidadeX;

            //partey
            rotationY += Input.GetAxis("Mouse Y") * sensibilidadeY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensibilidadeX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensibilidadeY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
    }

    /*
    void OnCollisionEnter(Collision colisor)
    {
        Debug.Log(colisor.gameObject.name);
    }*/

}
