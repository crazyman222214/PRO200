using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class AIStrikerController : Agent
{

    public PuckController puckController;
    [SerializeField] float speed = 10;
    //Vector3 puckPosition;
    Rigidbody rb;
    bool hasCollided = false;

    public GoalController selfGoal;
    public GoalController enemyGoal;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        puckController = FindAnyObjectByType<PuckController>();
    }

  

    public override void OnActionReceived(ActionBuffers actions)
    {
        Debug.Log($"Action received: X={actions.ContinuousActions[0]}, Z={actions.ContinuousActions[1]}");

        Vector3 direction = Vector3.zero;
        direction.x = actions.ContinuousActions[0];
        direction.z = actions.ContinuousActions[1];
        rb.AddForce(direction * speed);

        EnergyReward();
        VelocityReward();

        Rigidbody puckRB = puckController.GetComponent<Rigidbody>();
        TouchPuckReward(puckRB.linearVelocity);

        if (GoalController.WasGoal)
        {
            int score = (GoalController.scoreType == ScoreController.ScoreType.AIScore) ? 1 : -1;

            SetReward(score);
            EndEpisode();
        }

        
    }


    private void PuckVelocityToGoalReward()
    {
        Rigidbody puckRB = puckController.GetComponent<Rigidbody>();
        Vector3 toEnemyGoal = (enemyGoal.transform.position - puckController.transform.position).normalized;
        float velocityTowardsGoal = Vector3.Dot(puckRB.linearVelocity.normalized, toEnemyGoal);
        SetReward(velocityTowardsGoal * (puckRB.linearVelocity.magnitude / rb.maxLinearVelocity));
    }
    private void EnergyReward()
    {
        // Create a reward for maximizing total Mechanical Energy (Kinetic Energy + Potential Energy)
        // Kinetic Energy = 0.5 * m * v^2 (mass is irrelevant for this since it's constant)

        SetReward(0.5f * rb.linearVelocity.magnitude / rb.maxLinearVelocity);
    }


    private void VelocityReward()
    {
        float normalizedVelocity = rb.linearVelocity.normalized.magnitude;

        SetReward(normalizedVelocity);
    }

    private void TouchPuckReward(Vector3 puckVel)
    {
        // Reward the agent for touching the puck
        if (hasCollided)
        {
            SetReward(puckVel.magnitude / rb.maxLinearVelocity);
            hasCollided = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        hasCollided = collision.gameObject.CompareTag("Puck");

    }


    public override void CollectObservations(VectorSensor sensor)
    {
        // observations are the current states what the agent is observing
        // collect the current observation states:

        // agent position
        // target position
        // target rb velocity x / z
        // agent rb velocity x / z

        
        sensor.AddObservation(transform.localPosition);

        if (rb != null)
        {
            sensor.AddObservation(rb.linearVelocity.x);
            sensor.AddObservation(rb.linearVelocity.z);
        }
        
        if (puckController != null)
        {
            Rigidbody puckRB = puckController.GetComponent<Rigidbody>();

            sensor.AddObservation(puckController.transform.localPosition);
            sensor.AddObservation(puckRB.linearVelocity.x);
            sensor.AddObservation(puckRB.linearVelocity.z);
        }
        

        if (selfGoal != null && enemyGoal != null)
        {
            sensor.AddObservation(selfGoal.transform.localPosition);
            sensor.AddObservation(enemyGoal.transform.localPosition);
        }

    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        // allow input control of the agent
        var continuousActionsOut = actionsOut.ContinuousActions;

        continuousActionsOut[0] = Input.GetAxis("Horizontal");
        continuousActionsOut[1] = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
