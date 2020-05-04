using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AgentGlobal : MonoBehaviour
{
    public static AgentGlobal instance;

    [SerializeField]float hunger_rate, thrist_rate;

    [SerializeField] public static string behavior_name;

    void Awake()
    {

        behavior_name = EditorPrefs.GetString("NN_Setting");
        Debug.Log("Run time = " + behavior_name);
        instance = gameObject.GetComponent<AgentGlobal>();
    }

    public float hungerRate()
    {
        return hunger_rate;
    }

    public float thirstRate()
    {
        return thrist_rate;
    }

    public static void updateBehaviour(string value)
    {
        Debug.Log("updated to " + value);
        behavior_name = value;
    }

}

public enum AGENT_GOALS
{
    GOAL = 0,
    FOOD = 1,
    WATER = 2
}
