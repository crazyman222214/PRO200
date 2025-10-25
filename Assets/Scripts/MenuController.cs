using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject endPanel;
    public PlayerStrikerController playerStrikerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseGame()
    {
        Debug.Log("You Lose!");
        endPanel.SetActive(true);
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You Lose!";
    }

    public void WinGame()
    {
        Debug.Log("You Win!");
        endPanel.SetActive(true);
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You Win!";
    }
}
