using System.Collections;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int startingTime = 60 * 7;
    public int currentTime;

    public TMP_Text timerText;
    public ScoreController scoreController;

    void Start()
    {
        scoreController = FindAnyObjectByType<ScoreController>();
        currentTime = startingTime;
        StartCoroutine(UpdateTime());
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime <= 0)
        {
            
            TimerEnd();
        }
    }

    public void TimerEnd()
    {
        Debug.Log("END");
        scoreController.Endgame();
        StopCoroutine(UpdateTime());
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
