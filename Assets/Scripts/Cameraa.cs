using UnityEngine;

public class Cameraa : MonoBehaviour
{
  public Transform player;
  private Vector3 playerVector;
  public int speed; // скорость передвежения камеры
  [SerializeField] public float leftLimit, rightLimit, floatLimit, bottomLimit; // границы за которые камера не должна выходить 

  public Vector2 DefaultResolution = new Vector2(1920, 960); // разрешение по умолчанию
  [Range(0f, 1f)] public float WidthOrHeight = 0.5f; // изменения в ширину или высоту (переключатель в диапазоне от 0 до 1)
  private Camera Camera; // объект камеры 
  private float initialCameraSize; // исходный размер камеры
  private float needAspect; // нужный аспект

  private void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player").transform;

    Camera = GetComponent<Camera>(); // получаем объект камеры 
    initialCameraSize = Camera.orthographicSize; // получаем исходный размер камеры
    needAspect = DefaultResolution.x / DefaultResolution.y; // задаем (уснаем) нужный аспект
  }
  private void FixedUpdate()
  {
    playerVector = player.position;
    playerVector.z = -10;
    // transform.position = Vector3.Lerp(transform.position, playerVector, speed * Time.deltaTime);
    transform.position = Vector3.Lerp(transform.position, playerVector, 1);

    // работа камеры возле границ 
    if (leftLimit > transform.position.x && bottomLimit > transform.position.y)
    {
      transform.position = new Vector3(leftLimit, bottomLimit, transform.position.z);
    }
    else if (leftLimit > transform.position.x && floatLimit < transform.position.y)
    {
      transform.position = new Vector3(leftLimit, floatLimit, transform.position.z);
    }
    else if (rightLimit < transform.position.x && bottomLimit > transform.position.y)
    {
      transform.position = new Vector3(rightLimit, bottomLimit, transform.position.z);
    }
    else if (rightLimit < transform.position.x && floatLimit < transform.position.y)
    {
      transform.position = new Vector3(rightLimit, floatLimit, transform.position.z);
    }
    else if (leftLimit > transform.position.x)
    {
      transform.position = new Vector3(leftLimit, playerVector.y, transform.position.z);
    }
    else if (rightLimit < transform.position.x)
    {
      transform.position = new Vector3(rightLimit, playerVector.y, transform.position.z);
    }
    else if (bottomLimit > transform.position.y)
    {
      transform.position = new Vector3(playerVector.x, bottomLimit, transform.position.z);
    }
    else if (floatLimit < transform.position.y)
    {
      transform.position = new Vector3(playerVector.x, floatLimit, transform.position.z);
    }
    
    float constWidthSize = initialCameraSize * (needAspect / Camera.aspect); // узнаем постоянный размер ширины
    Camera.orthographicSize = Mathf.Lerp(constWidthSize, initialCameraSize, WidthOrHeight); // задаем параметры камеры
  }
}