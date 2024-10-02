using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float velocidade = 7f; // Velocidade da bola
    private bool podeMoverParaCima = true; // Controle para mover a bola para cima apenas uma vez

    /* void GoBall()
    {
        // Inicializa a velocidade da bola
        rb2d.velocity = new Vector2(4, 4);

        // Aplica uma força inicial aleatória
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(20, -15));
        }
        else
        {
            rb2d.AddForce(new Vector2(-20, 15));
        }
    } */

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y) + (coll.collider.attachedRigidbody.velocity.y);
            rb2d.velocity = vel;
        }
        else if (coll.collider.CompareTag("Ball"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = rb2d.velocity.y;
            rb2d.velocity = vel;
        }
    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        // Define a nova posição para um pouco mais abaixo no eixo Y
        transform.position = new Vector2(transform.position.x, -4.0f); // Ajuste o valor de -4.0f conforme necessário
        podeMoverParaCima = true; // Permite mover a bola para cima novamente
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && podeMoverParaCima)
        {
            MoverBolaParaCimaAleatoriamente();
            podeMoverParaCima = false; // Desativa a possibilidade de mover a bola para cima até o próximo reset
        }
        if (Input.GetKeyDown(KeyCode.P) && podeMoverParaCima)
        {
            MoverBolaParaCimaAleatoriamente();
        }
    }

    void MoverBolaParaCimaAleatoriamente()
    {
        // Gera uma nova direção aleatória para cima
        Vector2 novaDirecao = new Vector2(Random.Range(-1f, 1f), 1).normalized; 
        rb2d.velocity = novaDirecao * velocidade;
        Debug.Log("Direção da bola alterada: " + novaDirecao); 
    }
}
