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

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Endgame()
    {
        Debug.Log($"END! Player: {playerScore}, AI: {aiScore}");
        menuController.EndGame(playerScore > aiScore, playerScore == aiScore);
    }

    public void Inc(ScoreType whoScore)
    {
        Debug.Log($"Player: {playerScore}, AI: {aiScore}");

        if (whoScore == ScoreType.AIScore)
        {
            aiScore++;
            AIScoreText.text = (aiScore < 10) ? $"0{aiScore}" : (aiScore).ToString();
        }
        else
        {
            playerScore++;
            PlayerScoreText.text = (aiScore < 10) ? $"0{playerScore}" : (playerScore).ToString();

        }
    }
}
