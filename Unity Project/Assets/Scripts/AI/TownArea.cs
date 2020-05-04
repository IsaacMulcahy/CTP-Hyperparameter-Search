using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using TMPro;

public class TownArea : MonoBehaviour
{
    public bool complex;
    
    [Tooltip("The agent inside the area")]
    public NPCAgent agent;

    [Tooltip("The TextMeshPro text that shows the cumulative reward of the agent")]
    public TextMeshPro cumulative_reward_text;

    [Tooltip("Prefab of a live fish")]
    public Food food_prefab;

    [Tooltip("Prefab of a live fish")]
    public GameObject wood_pile;

    [Tooltip("Prefab of a live fish")]
    public GameObject firepit;

    [Tooltip("Prefab of a live fish")]
    public GameObject waterbucket;

    private List<GameObject> food_list;

    public void ResetArea()
    {
        RemoveAllFood();
        PlaceNPC();
        PlaceWoodPile();
        PlaceFirepit();
        SpawnFood(4);

        if(complex)
        {
            PlaceWater();
        }
    }

    public void RemoveSpecificFood(GameObject food)
    {
        food_list.Remove(food);
        Destroy(food);
    }

    public int FoodRemaining()
    {
        return food_list.Count;
    }

    private void RemoveAllFood()
    {
        if (food_list != null)
        {
            for (int i = 0; i < food_list.Count; i++)
            {
                if (food_list[i] != null)
                {
                    Destroy(food_list[i]);
                }
            }
        }

        food_list = new List<GameObject>();
    }

    private void PlaceNPC()
    {
        agent.GetComponent<BehaviorParameters>().behaviorName = AgentGlobal.behavior_name;
        //Debug.Log(AgentGlobal.behavior_name);
        Rigidbody rigidbody = agent.GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        agent.transform.position = ChooseRandomPostion(transform.position, 0f, 360f, 0f, 7f) + Vector3.up * .5f;
        agent.transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f);
    }

    private void PlaceWoodPile()
    {
        wood_pile.transform.position = ChooseRandomPostion(transform.position, 0f, 360f, 0f, 7f) + Vector3.up * .5f;
        wood_pile.transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f);
    }

    private void PlaceFirepit()
    {
        firepit.transform.position = ChooseRandomPostion(transform.position, 0f, 360f, 0f, 7f) + Vector3.up * .5f;
        firepit.transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f);
    }

    private void PlaceWater()
    {
        waterbucket.transform.position = ChooseRandomPostion(transform.position, 0f, 360f, 0f, 7f) + Vector3.up * .5f;
        waterbucket.transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f);
    }

    public void SpawnFood(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject food_object = Instantiate<GameObject>(food_prefab.gameObject);
            food_object.transform.position = ChooseRandomPostion(transform.position, 0f, 360f, 0f, 7f) + Vector3.up * .5f;
            food_object.transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f);

            food_object.transform.SetParent(transform);

            food_list.Add(food_object);
        }
    }

    public static Vector3 ChooseRandomPostion(Vector3 center, float min_angle, float max_angle, float min_radius, float max_radius)
    {
        float radius = min_radius;
        float angle = min_angle;

        if (max_radius > min_radius)
        {
            radius = UnityEngine.Random.Range(min_radius, max_radius);
        }

        if (max_angle > min_angle)
        {
            angle = UnityEngine.Random.Range(min_angle, max_angle);
        }

        return center + Quaternion.Euler(0f, angle, 0f) * Vector3.forward * radius;
    }

    private void Start()
    {
        ResetArea();
    }

    private void Update()
    {
        cumulative_reward_text.text = agent.GetCumulativeReward().ToString("0.00");
    }
}
