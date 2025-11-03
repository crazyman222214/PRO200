using System;
using Unity.Mathematics;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    

    public event Action OnPuckScored;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Puck"))
        {
            Debug.Log("Goal Scored!");


                OnPuckScored?.Invoke();

            

        }
    }
}
