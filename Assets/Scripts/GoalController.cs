using System.Collections;
using UnityEngine;

public class GoalController : MonoBehaviour
{

    public ScoreController scoreControllerInst;
    public static bool WasGoal { get; private set; }
    public Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            if (gameObject.tag == ("AiGoal"))
            {
                scoreControllerInst.Inc(ScoreController.ScoreType.PlayerScore);
                WasGoal = true;
                StartCoroutine(ResetPuck());
                Debug.Log("Goal Scored!");
            }
            else if (gameObject.tag == ("PlayerGoal"))
            {
                scoreControllerInst.Inc(ScoreController.ScoreType.AIScore);
                WasGoal = true;
                StartCoroutine(ResetPuck());
                Debug.Log("Goal Scored!");
            }
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
