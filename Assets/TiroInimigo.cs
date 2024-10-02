using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroInimigo : MonoBehaviour
{
    public float speed = 10f;  // Velocidade do projétil
    public float lifeTime = 5f;  // Tempo de vida do projétil antes de ser destruído

    void Start()
    {
        // Destrói o projétil após `lifeTime` segundos para evitar que fique indefinidamente na cena
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Faz o projétil se mover para frente constantemente
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    // Detecta colisões com outros objetos
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Lógica ao atingir o jogador
            Debug.Log("Player atingido pelo projétil!");
            Destroy(collision.gameObject);  // Destrói o jogador
            Destroy(gameObject);  // Destrói o projétil
        }
        else if (collision.CompareTag("Tiro"))
        {
            // Lógica para lidar com outros tiros (opcional)
            Destroy(gameObject);  // Destrói o projétil ao colidir com outro tiro, se necessário
        }
    }
}
