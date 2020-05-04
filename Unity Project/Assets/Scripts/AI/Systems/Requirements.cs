using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Requirements
{
    public Requirements()
    {
        hunger = 100;
        thirst = 100;
        aggression = 50;
    }

    [SerializeField][Range(0, 100)] float hunger;
    [SerializeField][Range(0, 100)] float thirst;
    [SerializeField][Range(0, 100)] float aggression;

    public void reset()
    {
        hunger = 100;
        thirst = 100;
        aggression = 50;
    }

    public bool UpdateNeeds()
    {
        if (hunger > 0)
        {
            hunger -= (Time.deltaTime * AgentGlobal.instance.hungerRate());
        }
        else
        {
            return false;
        }

        if (thirst > 0)
        {
            thirst -= (Time.deltaTime * AgentGlobal.instance.thirstRate());
        }
        else
        {
            return false;
        }

        return true;
    }

    public void Thirst(float value)
    {
        thirst += value;

        if (thirst > 100)
            thirst = 100;
    }

    public float Hunger()
    {
        return hunger;
    }

    public void Hunger(float value)
    {
        hunger += value;

        if (hunger > 100)
            hunger = 100;
    }

    public float Thirst()
    {
        return thirst;
    }
}
