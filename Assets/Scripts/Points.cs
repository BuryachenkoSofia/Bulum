using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Points : MonoBehaviour
{
  public GameObject enemyObj;
  private float ttt;
  private bool stawnOrNo;
  private void Start()
  {
    StartCoroutine(SpawnCoroutine());
  }

  IEnumerator SpawnCoroutine()
  {
    while (true)
    {
      Random rnd = new Random();
      ttt = rnd.Next(1, 6);
      if (rnd.Next(0, 2) == 0)
      {
        stawnOrNo = true;
      }
      else
      {
        stawnOrNo = false;
      }
      if (stawnOrNo)
      {
        yield return new WaitForSeconds(ttt);
        Instantiate(enemyObj, transform.position, Quaternion.identity);
      }
    }
  }
}
