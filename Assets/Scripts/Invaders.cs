using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Adicione esta linha

public class Invaders : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float waitTime = 1.0f; 
    private float timer = 0.0f;
    private float state = 0;
    private float x;
    public float moveSpeedHorizontal = 0.5f; 
    private float moveSpeedVertical = 0.5f;

    public GameObject enemyProjectilePrefab;
    public Transform tiroInimigo;
    private float shotTimer = 0.0f;
    public float minShotTime = 3.0f;
    public float maxShotTime = 7.0f;
    public float projectileSpeed = 5.0f;
    private float timeUntilNextShot;

    public int coluna; 
    public List<GameObject> inimigosAcima; 

    public int pontos = 10;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        x = transform.position.x;
        timeUntilNextShot = Random.Range(minShotTime, maxShotTime);

        // Ajusta as variáveis quando a fase é iniciada
        AdjustVariables();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            ChangeState();
            timer = 0.0f;
        }

        MoveInvader();

        shotTimer += Time.deltaTime;
        if (shotTimer >= timeUntilNextShot && PodeAtirar())
        {
            Shoot();
            shotTimer = 0.0f;
            timeUntilNextShot = Random.Range(minShotTime, maxShotTime);
        }
    }

    void MoveInvader()
    {
        var pos = transform.position;

        if (state >= -5 && state < 0)
        {
            pos.x -= moveSpeedHorizontal * Time.deltaTime;
        }
        else if (state > 0 && state <= 3)
        {
            pos.x += moveSpeedHorizontal * Time.deltaTime;
        }
        else if (state == 0)
        {
            pos.y -= moveSpeedVertical;
            ChangeState();
            pos.x = x;
        }

        transform.position = pos;
    }

    void ChangeState()
    {
        state++;
        if (state > 5)
        {
            state = -5;
        }
    }

    bool PodeAtirar()
    {
        foreach (GameObject inimigo in inimigosAcima)
        {
            if (inimigo != null)
            {
                return false; 
            }
        }
        return true; 
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(enemyProjectilePrefab, tiroInimigo.position, Quaternion.identity);
        Rigidbody2D rbProjectile = projectile.GetComponent<Rigidbody2D>();
        rbProjectile.velocity = Vector2.down * projectileSpeed;
    }

    private void OnDestroy()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            Debug.Log("Entrou 3");
            gameManager.AddScore(pontos);
        }
    }

    private void AdjustVariables()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            if (SceneManager.GetActiveScene().name == "Fase2")
            {
                waitTime = 0.3f;
                moveSpeedHorizontal = 1.5f;
                Debug.Log("Variáveis ajustadas: waitTime = " + waitTime + ", moveSpeedHorizontal = " + moveSpeedHorizontal);
            }
        }
    }
}
