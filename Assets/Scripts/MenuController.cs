using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject endPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseGame()
    {
        Debug.Log("You Lose!");
        //endPanel.SetActive(true);
        //endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You Lose!";
    }

    public void WinGame()
    {
        Debug.Log("You Win!");
        //endPanel.SetActive(true);
        //endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You Win!";
    }
}
