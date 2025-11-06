using System;
using Unity.Mathematics;
using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour
{
    public ScoreController scoreControllerInst;
    public static bool WasGoal { get; private set; }
    public Rigidbody rb;

    public event Action OnPuckScored;

    void Start()
    {
        WasGoal = false;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!WasGoal && other.tag == "Puck")
        {
            Debug.Log("Goal Scored!");
            WasGoal = true;
            OnPuckScored?.Invoke();
            StartCoroutine(ResetPuck());

            ScoreController.ScoreType scoreType = (name.Equals("AIGOAL")) ? ScoreController.ScoreType.PlayerScore 
                : ScoreController.ScoreType.AIScore;

            scoreControllerInst.Inc(scoreType);

        }
    }
    private IEnumerator ResetPuck()
    {
        yield return new WaitForSeconds(2);
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        //this postion is specific to the current table setup where its in favor of the player
        rb.transform.position = new Vector3(-0.400000006f, 0.8762459f, 0f);
        Physics.SyncTransforms();
        WasGoal = false;
    }
}
