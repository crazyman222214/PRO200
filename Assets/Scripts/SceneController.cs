using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject TitleScreenPanel;
    [SerializeField] GameObject OptionScreenPanel;




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPressPlay()
    {
        SceneManager.LoadScene("GameplayScene"); // loads current scene
    }


    public void OnPressQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void OnPressOptions()
    {
        TitleScreenPanel.SetActive(false);
        OptionScreenPanel.SetActive(true);
    }

    public void OnPressBack()
    {
        TitleScreenPanel.SetActive(true);
        OptionScreenPanel.SetActive(false);
    }
}
