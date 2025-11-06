using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public PlayerStrikerController playerStrikerController;
    public MenuController menuController;
    public GoalController goalController;

    public enum ScoreType
    {
        AIScore,
        PlayerScore
    }

    public TextMeshProUGUI AIScoreText, PlayerScoreText;
    private int aiScore, playerScore;

    void Start()
    {
        menuController = FindAnyObjectByType<MenuController>();
        goalController = FindAnyObjectByType<GoalController>();

        //goalController.OnPuckScored += () => { };
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Endgame()
    {
        menuController.EndGame(playerScore > aiScore, playerScore == aiScore);
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
