using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo : MonoBehaviour
{
    public float movingSpeed = 1f;  // Velocidade de movimento do inimigo
    public GameObject player;  // Referência ao jogador
    public GameObject enemyPrefab;  // Prefab do inimigo (para clonar)
    public GameObject projectilePrefab;  // Prefab do projétil

    public Transform firePoint;  // Ponto de disparo para os projéteis

    public float startPositionX = 10f;  // Posição inicial no eixo X
    public float endPositionX = -10f;  // Limite da posição X (quando sair da tela)

    public float minY = -3f;  // Altura mínima para a posição aleatória
    public float maxY = 3f;   // Altura máxima para a posição aleatória
    public float minX = -10f; // Limite mínimo no eixo X (para movimento aleatório, ajuste conforme necessário)

    private Vector3 direction;  // Direção do movimento

    public GameManager gameManager;  // Referência ao GameManager para controle de pontuação
    public float fireRate = 2f;  // Taxa de tiro em segundos
    private float nextFireTime = 0f;  // Tempo até o próximo tiro

    void Start()
    {
        Respawn();
        direction = GetRandomDirection();  // Definindo a direção inicial aleatória
    }

    void Update()
    {
        MoveEnemy();
        CheckFiring();
    }

    // Método responsável por mover o inimigo
    void MoveEnemy()
    {
        // Atualiza a posição do inimigo
        transform.position += direction * Time.deltaTime * movingSpeed;

        Vector3 currentPosition = transform.position;

        // Verifica se o inimigo atingiu os limites da área do jogo e inverte a direção
        if (currentPosition.x < endPositionX || currentPosition.x > startPositionX)
        {
            direction.x = -direction.x;  // Inverte a direção no eixo X
        }

        if (currentPosition.y < minY || currentPosition.y > maxY)
        {
            direction.y = -direction.y;  // Inverte a direção no eixo Y
        }

        // Atualiza a posição do inimigo
        transform.position = currentPosition;
    }

    // Método que verifica se o inimigo pode atirar
    void CheckFiring()
    {
        // Verifica se o jogador ainda existe antes de disparar
        if (player != null && Time.time > nextFireTime)
        {
            //Shoot();  // Chama o método de tiro
            nextFireTime = Time.time + fireRate;  // Atualiza o tempo do próximo tiro
        }
    }

    void Respawn()
    {
        float randomX = Random.Range(minX, startPositionX);
        float randomY = Random.Range(minY, maxY);
        transform.position = new Vector3(randomX, randomY, transform.position.z);

    }

    Vector3 GetRandomDirection()
    {
        float randomX = Random.Range(-1f, 1f);  // Aleatório entre -1 e 1 no eixo X
        float randomY = Random.Range(-1f, 1f);  // Aleatório entre -1 e 1 no eixo Y
        return new Vector3(randomX, randomY, 0).normalized;  // Normaliza o vetor para obter a direção
    }

    //void Shoot()
    //{
    //    GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
    //    Vector3 directionToPlayer = (player.transform.position - firePoint.position).normalized;
    //    projectile.GetComponent<Rigidbody2D>().velocity = directionToPlayer * 10f;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player morreu!");
            Destroy(collision.gameObject);
            SceneManager.LoadScene("Loser");
        }
        else if (collision.CompareTag("Tiro"))
        {
            Debug.Log("Entrou 2");
            gameManager.AddScore(10);
            CreateNewEnemy();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    void CreateNewEnemy()
    {
        Instantiate(enemyPrefab, new Vector3(startPositionX, Random.Range(minY, maxY), transform.position.z), Quaternion.identity);
    }
}
