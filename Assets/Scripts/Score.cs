using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
  public float myTime, record;
  public Text timeText, recordText;

  private void Update()
  {
    record = PlayerPrefs.GetFloat("record");
    recordText.text = "Record: " + Mathf.Floor(record);

    myTime = myTime + Time.deltaTime;
    timeText.text = "Score:" + Mathf.Floor(myTime);
    if (Mathf.Floor(myTime) > record)
    {
      record = myTime;
      PlayerPrefs.SetFloat("record", record);
      recordText.text = "Record: " + Mathf.Floor(record);
    }
  }
}