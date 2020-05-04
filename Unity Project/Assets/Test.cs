using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Reflection;
using MLAgents;

public class Test : MonoBehaviour
{
    void Start()
    {
        int value = 1;


        Debug.Log("Demo");

        //System.Threading.Thread.Sleep(5000);

        Type t = null;
        foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
        {
            t = a.GetType("UnityEditor.EditorApplication");
            if (t != null)
            {
                t.GetProperty("isPlaying").SetValue(null, true, null);
                break;
            }
        }
    }
}