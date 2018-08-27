using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameControl : MonoBehaviour {
    
    public bool pause_game = false;



    public GameObject CanvasJogo;
    public GameObject CanvasPause;




    public AudioMixer ControladordeAudio;

    // Use this for initialization
    void Start () {

        ControleCanvas();

    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.P))
        {

            if(pause_game == false)
            {
                Time.timeScale = 0;
                pause_game = true;
            }else
            {
                Time.timeScale = 1;
                pause_game = false;
            }
            
        }







        
        /*
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(pause_game == true)
            {
                pause_game = false;
                Time.timeScale = 1;
                
            }else
            {
                pause_game = true;
                Time.timeScale = 0;
            }
            ControleCanvas();
        }*/

	}

    public bool JogoPausado()
    {
        return pause_game;
    }







    void ControleCanvas()
    {

        if (pause_game == true)
        {
            CanvasPause.SetActive(true);
            CanvasJogo.SetActive(false);
            ControladordeAudio.SetFloat("VolumeAmbiente", -80f);

        }
        else
        {
            CanvasPause.SetActive(false);
            CanvasJogo.SetActive(true);
            ControladordeAudio.SetFloat("VolumeAmbiente", 0f);
        }
    }

}
