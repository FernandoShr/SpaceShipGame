using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireInvader : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto colidido é um inimigo
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroi o inimigo
            // Destroy(collision.gameObject);

            // Destroi o projetil
            Destroy(gameObject);
        }
    }
}
