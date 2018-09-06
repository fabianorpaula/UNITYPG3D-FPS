using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
    
    public bool pause_game = true;
    private Controle Jogador;

    //Vairaiveis de Tela
    public GameObject CanvasJogo;
    public GameObject CanvasPause;
    public Text TextoTiro;
    public Text TextoVida;
    public Text TextoPonto;
    public Text TextoInimigo;

    //Variavel do Sistema
    public int pontos;

    //Criação de Inimigos
    public List<GameObject> Spawnpoints;
    public GameObject Inimigo1;
    public int qtd_inimigo = 0;
    public int ronda = 0;




    public AudioMixer ControladordeAudio;

    // Use this for initialization
    void Start () {

        //ControleCanvas();
        Jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Controle>();

        Time.timeScale = 0;
        pause_game = true;
        CanvasPause.SetActive(true);
        ControladordeAudio.SetFloat("VolumeMaster", -80f);
        ronda = 1;
        ChamarRonda();

    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.P))
        {

            if(pause_game == false)
            {
                Time.timeScale = 0;
                pause_game = true;
                CanvasPause.SetActive(true);
                ControladordeAudio.SetFloat("VolumeMaster", -80f);
            }else
            {
                Time.timeScale = 1;
                pause_game = false;
                CanvasPause.SetActive(false);
                ControladordeAudio.SetFloat("VolumeMaster", 0);
            }
            
        }

        if(pause_game != true)
        {
            if(qtd_inimigo==0)
            {
                ronda++;
                ChamarRonda();
            }
        }

        //Contagem de Tiro
        TextoTiro.text = Jogador.qtd_balas.ToString()+"/50";
        TextoVida.text = Jogador.life.ToString()+"/100";
        TextoPonto.text = "SCORE: " + pontos.ToString();
        TextoInimigo.text = qtd_inimigo.ToString();




      
	}

    public bool JogoPausado()
    {
        return pause_game;
    }


    public void INICIAR()
    {
        Time.timeScale = 1;
        pause_game = false;
        CanvasPause.SetActive(false);
        ControladordeAudio.SetFloat("VolumeMaster", 0);
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




    void ChamarRonda()
    {
        for (int i = 0; i < (5*ronda); i++)
        {
            int indrandom = Random.Range(0, 4);
            Vector3 PosInimigo = Spawnpoints[indrandom].transform.position;
            Instantiate(Inimigo1, PosInimigo, Quaternion.identity);
        }
        qtd_inimigo = ronda * 5;
    }

}
