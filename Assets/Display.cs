using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Threading;

public class Display : MonoBehaviour
{
    public GUISkin layout;
    GameObject theBall;

    public AudioClip sfxVenceuJogo;
    public AudioController audioController;

    // Start is called before the first frame update
    void Start() {
        Debug.Log("Menu");
    }

    void OnGUI()
    {
        GUI.skin = layout;

        // Adiciona o texto acima do botão
        // GUI.Label(new Rect(Screen.width / 2 - 20, 215, 300, 30), "Play");
        // GUI.Label(new Rect(Screen.width / 2 - 55, 250, 350, 30), "Space Invaders");
        // GUI.Label(new Rect(Screen.width / 2 - 80, 280, 400, 30), "*Score advance table*");
        // GUI.Label(new Rect(Screen.width / 2 - 45, 320, 450, 30), "=? Mystery");
        // GUI.Label(new Rect(Screen.width / 2 - 45, 350, 500, 30), "=30 Points");
        // GUI.Label(new Rect(Screen.width / 2 - 45, 375, 550, 30), "=20 Points");
        // GUI.Label(new Rect(Screen.width / 2 - 45, 402, 600, 30), "=10 Points");

        // Cria o botão "Iniciar Jogo"
        if (GUI.Button(new Rect(Screen.width / 2 - 30, 350, 60, 30), "Start"))
        {
            SceneManager.LoadScene("fase1");
            GameManager.PlayerScore1 = 0;
        }

        
        // StartCoroutine(loadStartGame());
    }

    IEnumerator loadStartGame()
    {
        yield return new WaitForSeconds(7);
    
        SceneManager.LoadScene("fase1");
        GameManager.PlayerScore1 = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
