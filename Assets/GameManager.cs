using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public GUISkin layout;
    public AudioClip sfxVenceuJogo;
    public AudioController audioController;

    public float enemySpeedMultiplier = 1.0f;

    void Start()
    {
        // Inicialização pode ser adicionada aqui, se necessário
    }

    public void AddScore(int points)
    {
        PlayerScore1 += points;

        // Verifica se a pontuação atingiu 600
        if (PlayerScore1 >= 600)
        {
            // Carrega a cena de vitória
            LoadVictoryScene();
        }
    }

    void LoadVictoryScene()
    {
        // Carrega a cena de vitória (substitua "VictoryScene" pelo nome da sua cena de vitória)
        SceneManager.LoadScene("Victoria");
    }

    void IncreaseEnemySpeed()
    {
        enemySpeedMultiplier += 0.5f;
    }

    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 200 - 12, 40, 100, 100), "Score: " + PlayerScore1);
    }
}
