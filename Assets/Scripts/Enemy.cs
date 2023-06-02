using UnityEngine;

public class Enemy : MonoBehaviour
{
  private Rigidbody2D _rb;

  private void Awake()
  {
    _rb = GetComponent<Rigidbody2D>();
  }
  private void OnCollisionEnter2D(Collision2D other) {
    if(other.gameObject.tag == "Ground"){
        Destroy(gameObject);
    }
  }
}
