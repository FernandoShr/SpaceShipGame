using System.Collections;
using UnityEngine;

public class mae : MonoBehaviour
{
    public float speed = 5.0f; // Velocidade de movimento da nave-mãe
    private float offScreenX = -10f; // Posição onde a nave sai da tela
    private float waitTimeMin = 30f; // Tempo mínimo entre aparições
    private float waitTimeMax = 50f; // Tempo máximo entre aparições
    public int pontos = 50; // Pontos a serem adicionados ao destruir a nave-mãe

    private void Start()
    {
        StartCoroutine(SpawnMotherShip());
    }

    private IEnumerator SpawnMotherShip()
    {
        while (true)
        {
            // Espera por um tempo aleatório
            float waitTime = Random.Range(waitTimeMin, waitTimeMax);
            yield return new WaitForSeconds(waitTime);

            // Posiciona a nave-mãe no lado direito da tela
            transform.position = new Vector3(10f, Random.Range(12f, 14f), 0f);
            gameObject.SetActive(true); // Ativa a nave-mãe

            // Move a nave-mãe da direita para a esquerda
            while (transform.position.x > offScreenX)
            {
                // Move a nave
                transform.position += Vector3.left * speed * Time.deltaTime;
                yield return null; // Espera até o próximo quadro
            }

            // Desativa a nave-mãe ao sair da tela
            gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            Debug.Log("Entrou 5");
            gameManager.AddScore(pontos);
        }
        else
        {
            Debug.LogWarning("GameManager não encontrado!");
        }
    }
}
