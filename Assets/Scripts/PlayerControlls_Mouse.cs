using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls_Mouse : MonoBehaviour
{
  public KeyCode moveUp = KeyCode.W;
  public KeyCode moveDown = KeyCode.S;
  public float speed = 10.0f;
  public float boundY = 2.25f;
  private Rigidbody2D rb2d;

  // Defina os limites do campo
  float minX = 0.53f;  // Limite esquerdo
  float maxX = 5.0f;   // Limite direito
  float minY = -2.2f;  // Limite inferior
  float maxY = 2.2f;   // Limite superior

  // Start is called before the first frame update
  void Start()
  {
    rb2d = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    //no update
    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    var pos = transform.position;
    pos.x = mousePos.x;
    pos.y = mousePos.y;

    pos.x = Mathf.Clamp(pos.x, minX, maxX);
    pos.y = Mathf.Clamp(pos.y, minY, maxY);

    transform.position = pos;
  }
}
