using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject endPanel;
    public GameObject endButton;
    public GameObject replayButton;
    public PlayerStrikerController playerStrikerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endPanel.SetActive(false);
        replayButton.SetActive(false);
        endButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseGame()
    {
        Debug.Log("You Lose!");
        endPanel.SetActive(true);
        replayButton.SetActive(true);
        endButton.SetActive(true);
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You Lose!";
    }

    public void WinGame()
    {
        Debug.Log("You Win!");
        endPanel.SetActive(true);
        replayButton.SetActive(true);
        endButton.SetActive(true);
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You Win!";
    }

    public void OnClickReplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

    public void OnClickEnd()
    {
        Application.Quit(); // end game
    }
}
