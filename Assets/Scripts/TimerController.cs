using System.Collections;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int startingTime = 60 * 7;
    public int currentTime;

    public TMP_Text timerText;

    void Start()
    {
        currentTime = startingTime;
        StartCoroutine(UpdateTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator UpdateTime()
    {
        while (currentTime > 0)
        {
            currentTime--;
            int minutes = currentTime / 60;
            int seconds = currentTime % 60;

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            yield return new WaitForSeconds(1);
        }
    }
}
