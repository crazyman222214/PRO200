using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class AdController : MonoBehaviour
{
    [SerializeField] private GoalController goalController;

    [SerializeField] private GameObject adCanvas;
    [SerializeField] List<GameObject> adsToPlay = new List<GameObject>();
    private GameObject ad;
    private VideoPlayer adPlayer;

   [SerializeField] Button CloseButton;

    void Start()
    {
        
        foreach (GameObject go in adsToPlay)
        {
            go.SetActive(false);
        }
        
        adCanvas.SetActive(false);

        CloseButton.GetComponent<Button>().onClick.AddListener(OnCloseAd);
       // Button btn = yourButton.GetComponent<Button>();
       // btn.onClick.AddListener(TaskOnClick);

    }



    public void playAd()
    {
        if (UnityEngine.Random.value < 0.2f)
        {
        
        print("play ad");
        if (adsToPlay.Count > 0)
        {
            ad = GetRandomAd();
            ad.SetActive(true);
            adCanvas.SetActive(true);

        }

        if (ad.TryGetComponent<VideoPlayer>(out VideoPlayer Found))
        {
            adPlayer = Found;
        }
        else
        {
            print($"Object {ad.name} has no Video Player");
        }

        adPlayer.Play();
    }
    }

    

    public GameObject GetRandomAd()
    {
        int randomNum = Random.Range(0, adsToPlay.Count);
        return adsToPlay[randomNum];
    }



    public void OnCloseAd()
    {
        if (adPlayer.isPlaying)
        {
            adPlayer.Stop();
            adCanvas.SetActive(false);
        }
        
        
    }

    private void OnEnable()
    {
        goalController.OnPuckScored += playAd;
    }

    private void OnDisable()
    {
        goalController.OnPuckScored -= playAd;
    }


    // Update is called once per frame
    void Update()
    {

        
    }

    
}
