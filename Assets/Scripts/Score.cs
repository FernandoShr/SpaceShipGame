using UnityEngine;
using UnityEngine.UI; // Para trabalhar com UI

public class Score : MonoBehaviour
{
    private parallaxscroll parallax;
    public int score = 0; // Pontuação atual
    public Text scoreText; // Referência ao Text da UI

    void Start()
    {
        UpdateScoreUI(); // Atualiza a UI no início
    }

    public void AddScore(int points)
    {
        score += points; // Adiciona os pontos
        UpdateScoreUI(); // Atualiza a UI
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Pontos: " + score; // Atualiza o texto com a pontuação
        if (score % 50 == 0)
        {
            parallax.SlowTime();
        }
    }
}
