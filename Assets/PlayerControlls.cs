using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    public KeyCode moveRight = KeyCode.D;  // Movimento para a direita
    public KeyCode moveLeft = KeyCode.A;   // Movimento para a esquerda
    public KeyCode moveUp = KeyCode.W;     // Movimento para cima
    public KeyCode moveDown = KeyCode.S;   // Movimento para baixo
    public float speed = 10.0f;

    // Limites de movimento (se necessário)
    public float boundX = 5.0f;
    public float boundY = 3.0f;  // Novo limite vertical
    private Rigidbody2D rb2d;

    // Parâmetros para o tiro
    public GameObject projectilePrefab;    // Prefab do projétil
    public Transform firePoint;            // Ponto de origem do tiro
    public float projectileSpeed = 10.0f;  // Velocidade do projétil

    // Som do tiro
    public AudioClip shootSound;           // Arquivo de som do tiro
    private AudioSource audioSource;       // Componente para reproduzir o som

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();  // Obtém o componente de áudio
    }

    void Update()
    {
        // Movimento do player
        var vel = rb2d.velocity;

        // Movimentação horizontal
        if (Input.GetKey(moveRight))
        {
            vel.x = speed;
        }
        else if (Input.GetKey(moveLeft))
        {
            vel.x = -speed;
        }
        else
        {
            vel.x = 0;
        }

        // Movimentação vertical
        if (Input.GetKey(moveUp))
        {
            vel.y = speed;
        }
        else if (Input.GetKey(moveDown))
        {
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;
        }

        rb2d.velocity = vel;

        // Limites de movimento na tela
        var pos = transform.position;

        if (pos.x > boundX)
        {
            pos.x = boundX;
        }
        else if (pos.x < -boundX)
        {
            pos.x = -boundX;
        }

        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }

        transform.position = pos;

        // Atirar quando a tecla Espaço for pressionada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instanciar o projétil no firePoint e adicionar força para ele se mover para a direita
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rbProjectile = projectile.GetComponent<Rigidbody2D>();
        rbProjectile.velocity = Vector2.right * projectileSpeed;  // Movimenta o projétil para a direita

        // Tocar som de tiro
        if (shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);  // Reproduz o som do tiro
        }
    }
}
