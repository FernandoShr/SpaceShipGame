using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Threading;

public class GameOver : MonoBehaviour
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
        GUI.Label(new Rect(Screen.width / 2 - 20, 215, 300, 30), "Game Over");

        //mostra a pontuação do jogador
        Debug.Log("Score: " + GameManager.PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 - 20, 250, 300, 30), "Score: " + GameManager.PlayerScore1);
        StartCoroutine(loadStartGame());

    }

    IEnumerator loadStartGame()
    {
        yield return new WaitForSeconds(5);
        
        SceneManager.LoadScene("SampleScene");
        GameManager.PlayerScore1 = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
