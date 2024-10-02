using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    public Sprite intactShield;        // Sprite do escudo intacto
    public Sprite damagedShield;       // Sprite do escudo danificado após 2 hits
    private int hitCount = 0;          // Contador de hits
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = intactShield;  // Inicialmente com o escudo intacto
    }

    // Detecção de colisões
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TiroEnemy")) // Se o tiro inimigo acertar o escudo
        {
            hitCount++;
            Destroy(collision.gameObject); // Destrói o tiro inimigo após a colisão

            if (hitCount == 2)
            {
                spriteRenderer.sprite = damagedShield;  // Troca o sprite para o escudo danificado
            }
            else if (hitCount >= 4)
            {
                Destroy(gameObject);  // Destrói o escudo após 4 hits
            }
        }
        else if (collision.CompareTag("TiroPlayer")) // Se o tiro do jogador acertar o escudo
        {
            Destroy(collision.gameObject); // Apenas destrói o tiro do jogador
        }
    }
}
