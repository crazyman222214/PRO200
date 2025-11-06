using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject endPanel;
    public PlayerStrikerController playerStrikerController;
    public TMP_Text endMessageText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void EndGame(bool playerWin, bool tie)
    {
        Debug.Log("Game Over!");
       
        endPanel.SetActive(true);
       
        string message = tie ? "You Tied!" : playerWin ? "You Win!" : "You Lose!";
        Debug.Log(message);
        endMessageText.text = message;
    }


    public void OnClickReplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

    public void OnClickEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
