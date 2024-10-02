using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Display2 : MonoBehaviour
{
    public GUISkin layout;
    GameObject theBall;

    public AudioClip sfxVenceuJogo;
    public AudioController audioController;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnGUI()
    {
        GUI.skin = layout;

        // Cria o botão "Iniciar Jogo"
        if (GUI.Button(new Rect(Screen.width / 2 - 60, 145, 120, 53), "Voltar ao Menu"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
