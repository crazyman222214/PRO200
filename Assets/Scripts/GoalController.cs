using System.Collections;
using Unity.MLAgents.Sensors;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GoalController : MonoBehaviour
{

    public ScoreController scoreControllerInst;
    public static bool WasGoal { get; private set; }
    public Rigidbody puckRB;

    public static ScoreController.ScoreType scoreType;


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
            scoreType = (gameObject.tag == "AiGoal") ? ScoreController.ScoreType.PlayerScore : ScoreController.ScoreType.AIScore;
            scoreControllerInst.Inc(scoreType);
            WasGoal = true;
            StartCoroutine(ResetPuck());
            Debug.Log("Goal Scored!");

        }
    }
    private IEnumerator ResetPuck()
    {
        yield return new WaitForSeconds(2);
        puckRB.linearVelocity = Vector3.zero;
        puckRB.angularVelocity = Vector3.zero;
        //this postion is specific to the current table setup where its in favor of the player


        puckRB.transform.position = new Vector3(-0.400000006f, 0.8762459f, 0f);
        Physics.SyncTransforms();
        WasGoal = false;
    }
}
