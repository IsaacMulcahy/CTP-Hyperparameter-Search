using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class NPCAgentComplex : Agent
{
    [Tooltip("How fast the agent moves forward")]
    public float move_speed = 5f;

    [Tooltip("How fast the agent turns")]
    public float turn_speed = 180f;

    public TownArea town_area;
    new private Rigidbody rigidbody;
    [SerializeField] Requirements requirements;
    [SerializeField] bool alive;

    int uncooked_food;
    int fuel;
    int cooked_food;
    int eatten_food;

    public override void InitializeAgent()
    {
        base.InitializeAgent();
        rigidbody = GetComponent<Rigidbody>();
        requirements.reset();
        alive = true;
        uncooked_food = 0;
        fuel = 0;
        cooked_food = 0;
        eatten_food = 0;
    }

    public override void AgentAction(float[] vectorAction)
    {
        // Forward movement
        float forward_amount = vectorAction[0];

        float turn_amount = 0f;

        // Left or right (In order)
        if (vectorAction[1] == 1f)
        {
            turn_amount = -1f;
        }
        else if (vectorAction[1] == 2f)
        {
            turn_amount = 1f;
        }

        // Apply Movement
        rigidbody.MovePosition(transform.position + transform.forward * forward_amount * move_speed * Time.fixedDeltaTime);
        transform.Rotate(transform.up * turn_amount * turn_speed * Time.fixedDeltaTime);

        if (maxStep > 0) AddReward(-1f / maxStep);
    }

    public override float[] Heuristic()
    {
        float forward_action = 0f;
        float turn_action = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            forward_action = 1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            turn_action = 1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            turn_action = 2f;
        }

        return new float[] { forward_action, turn_action };
    }

    public override void CollectObservations()
    {
        AddVectorObs(requirements.Hunger());
        AddVectorObs(requirements.Thirst());

        AddVectorObs(transform.forward);

        AddVectorObs(uncooked_food);
        AddVectorObs(fuel);
        AddVectorObs(cooked_food);

        // 7 Values
    }

    private void FixedUpdate()
    {
        if (eatten_food == 5)
        {
            Done();
        }

        // Every 5 steps request decision 
        if (GetStepCount() % 5 == 0)
        {
            RequestDecision();
        }
        else
        {
            RequestAction();
        }

        alive = requirements.UpdateNeeds();

        if (requirements.Hunger() > 40)
        {
            AddReward(0.001f * Time.deltaTime);
        }
        else if (requirements.Hunger() < 40)
        {
            if (cooked_food > 0)
            {
                EatFood();
            }

            AddReward(-0.002f * Time.deltaTime);
        }
        else if (requirements.Hunger() < 20)
        {
            AddReward(-0.004f * Time.deltaTime);
        }

        if (requirements.Thirst() > 40)
        {
            AddReward(0.001f * Time.deltaTime);
        }
        else if (requirements.Thirst() < 40)
        {
            if (cooked_food > 0)
            {
                EatFood();
            }

            AddReward(-0.002f * Time.deltaTime);
        }
        else if (requirements.Thirst() < 20)
        {
            AddReward(-0.004f * Time.deltaTime);
        }

        if (!alive)
        {
            AddReward(-1f);
            Done();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.transform.tag)
        {
            case "food":
                CollectFood(collision.gameObject);
                break;
            case "fuel":
                CollectFuel(collision.gameObject);
                break;
            case "heat":
                CookFood();
                break;
        }
    }

    private void CollectFood(GameObject gameObject)
    {
        town_area.RemoveSpecificFood(gameObject);

        uncooked_food++;

        AddReward(0.5f);

    }

    private void CollectFuel(GameObject gameObject)
    {
        fuel++;

        AddReward(0.5f);

    }

    private void CookFood()
    {
        if (fuel > 0 && uncooked_food > 0)
        {
            cooked_food++;
            fuel--;
            uncooked_food--;

            AddReward(1f);
        }

    }

    private void EatFood()
    {
        requirements.Hunger(20f);
        cooked_food--;
        eatten_food++;
        AddReward(1f);
    }

    public override void AgentReset()
    {
        alive = true;
        town_area.ResetArea();
    }
}
