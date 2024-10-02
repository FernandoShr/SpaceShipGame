using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocha : MonoBehaviour
{
    private float movingSpeed = 5f;  // Velocidade de movimento da rocha
    public GameObject player;  // Referência ao jogador (Player)
    public float startPositionX = 10f;  // Posição inicial no eixo X (canto direito da tela)
    public float endPositionX = -10f;  // Posição final no eixo X (quando sair da tela)

    public float minY = -3f;  // Altura mínima para a posição aleatória da rocha
    public float maxY = 3f;   // Altura máxima para a posição aleatória da rocha

    public GameObject rockPrefab;  // Prefab da rocha (para clonar)
    public GameManager gameManager;  // Referência ao GameManager

    void Start()
    {
        // Define a posição inicial da rocha no canto direito da tela
        Respawn();
    }

    void Update()
    {
        // Mover a rocha para a esquerda
        transform.position += Vector3.left * Time.deltaTime * movingSpeed;

        // Verifica se a rocha chegou ao lado esquerdo da tela (além do limite)
        // if (transform.position.x < endPositionX)
        // {
        //     Respawn();  // Reaparece no lado direito com uma nova posição Y aleatória
        // }
    }

    void Respawn()
    {
        // Reposiciona a rocha no lado direito da tela e define uma nova posição Y aleatória
        float randomY = Random.Range(minY, maxY);  // Gera uma posição Y aleatória dentro dos limites
        transform.position = new Vector3(startPositionX, randomY, transform.position.z);
    }

    // Detecta colisões com o player ou projétil
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            // Lógica para matar o player
            Debug.Log("Player morreu!");
            Destroy(player);  // Destrói o player ao encostar na rocha
            SceneManager.LoadScene("Loser");
        }
        else if (collision.CompareTag("Tiro"))  // Verifica se o objeto é o projétil do jogador
        {
            // Dá 10 pontos ao jogador
            Debug.Log("Entrou 1");
            gameManager.AddScore(10);

            // Instancia uma nova rocha antes de destruir a atual
            CreateNewRock();

            // Destroi a rocha e o projétil
            Destroy(collision.gameObject);  // Destrói o projétil
            Destroy(gameObject);  // Destrói a rocha atual
        }
    }

    // Método para criar um novo clone da rocha
    void CreateNewRock()
    {
        // Instancia uma nova rocha a partir do prefab
        Instantiate(rockPrefab, new Vector3(startPositionX, Random.Range(minY, maxY), transform.position.z), Quaternion.identity);
    }
}
