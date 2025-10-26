using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreController : MonoBehaviour
{

    public PlayerStrikerController playerStrikerController;
    public enum ScoreType
    {
        AIScore,
        PlayerScore
    }

    public TextMeshProUGUI AIScoreText, PlayerScoreText;
    private int aiScore, playerScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (aiScore != 10)
        {
            if (playerScore == 10)
            {
                Debug.Log("Player Wins!");
                playerStrikerController.WinGame();
            }
        }
        else
        {
            Debug.Log("AI Wins!");
            playerStrikerController.EndGame();
            
        }
    }

    public void Inc(ScoreType whoScore)
    {
        if (whoScore == ScoreType.AIScore)
        {
            AIScoreText.text = (++aiScore).ToString();
        }
        else
        {
            PlayerScoreText.text = (++playerScore).ToString();
        }
    }
}
