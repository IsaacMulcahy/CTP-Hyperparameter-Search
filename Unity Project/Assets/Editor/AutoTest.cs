using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using MLAgents;


namespace AutoTestingSystem
{

    public class AutoTest : MonoBehaviour
    {
        static int value;

        public static void Perform()
        {
            GameObject root = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefab/AI/Peasent.prefab", typeof(GameObject));

            root.GetComponent<BehaviorParameters>().behaviorName = "Auto" + value;

            PrefabUtility.RecordPrefabInstancePropertyModifications(root);

            EditorSceneManager.OpenScene("Assets/Main2.unity");

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

            EditorPrefs.SetString("NN_Setting", "Auto" + value);
           // EditorUtility.SetDirty(GameObject.Find("AgentGlobal"));
            AgentGlobal.updateBehaviour("Auto" + value);

            //AgentGlobal.updateBehaviour("Auto" + value);
        }


        public static void Test0()
        {
            value = 0;
            Perform();
        }

        public static void Test1()
        {
            value = 1;
            Perform();
        }
        public static void Test2()
        {
            value = 2;
            Perform();
        }
        public static void Test3()
        {
            value = 3;
            Perform();
        }
        public static void Test4()
        {
            value = 4;
            Perform();
        }

        public static void Test5()
        {
            value = 5;
            Perform();
        }

        public static void Test6()
        {
            value = 6;
            Perform();
        }
        public static void Test7()
        {
            value = 7;
            Perform();
        }
        public static void Test8()
        {
            value = 8;
            Perform();
        }
        public static void Test9()
        {
            value = 9;
            Perform();
        }

        public static void Test10()
        {
            value = 10;
            Perform();
        }

        public static void Test11()
        {
            value = 11;
            Perform();
        }

        public static void Test12()
        {
            value = 12;
            Perform();
        }
        public static void Test13()
        {
            value = 13;
            Perform();
        }
        public static void Test14()
        {
            value = 14;
            Perform();
        }
        public static void Test15()
        {
            value = 15;
            Perform();
        }

        public static void Test16()
        {
            value = 16;
            Perform();
        }

        public static void Test17()
        {
            value = 17;
            Perform();
        }
        public static void Test18()
        {
            value = 18;
            Perform();
        }
        public static void Test19()
        {
            value = 19;
            Perform();
        }
        public static void Test20()
        {
            value = 20;
            Perform();
        }

        public static void Test21()
        {
            value = 21;
            Perform();
        }

        public static void Test22()
        {
            value = 22;
            Perform();
        }
        public static void Test23()
        {
            value = 23;
            Perform();
        }
        public static void Test24()
        {
            value = 24;
            Perform();
        }
        public static void Test25()
        {
            value = 25;
            Perform();
        }

        public static void Test26()
        {
            value = 26;
            Perform();
        }
    }
}
