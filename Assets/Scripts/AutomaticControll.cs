using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticControll : MonoBehaviour
{
    public Transform ball; // Referência à primeira bola
    public Transform ball2; // Referência à segunda bola
    public float speed = 10f; // Velocidade de movimento da raquete
    public float boundaryY = 0f; // Limite de movimento da raquete no eixo Y

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (ball != null && ball2 != null)
        {
            // Calcula a posição média das duas bolas
            float averageY = (ball.position.y + ball2.position.y);
            Vector3 targetPosition = new Vector3(transform.position.x, averageY, transform.position.z);
            targetPosition.y = Mathf.Clamp(targetPosition.y, -boundaryY, boundaryY);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
