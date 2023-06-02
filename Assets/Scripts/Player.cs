using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Player : MonoBehaviour
{
  private Rigidbody2D _rb;
  public GameObject deadPanel;
  private float speed = 350f, HP = 100f, h;
  public Text HPText;
  private bool isGrounded;

  private void Awake()
  {
    Time.timeScale = 1f;
    _rb = GetComponent<Rigidbody2D>();
    HP = 100f;
    Time.timeScale = 1f;
    HPText.text = "HP: " + HP;
  }

  private void FixedUpdate()
  {
    float h = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime; // передвижение 
    _rb.velocity = transform.TransformDirection(new Vector2(h, _rb.velocity.y)); // скорость rigidbody
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "Enemy")
    {
      Destroy(other.gameObject);
      Random rnd = new Random();
      HP = HP - rnd.Next(5, 16);
      HPText.text = "HP: " + HP;
      if (HP <= 0)
      {
        deadPanel.gameObject.SetActive(true);
        Time.timeScale = 0f;
      }
    }
  }
}