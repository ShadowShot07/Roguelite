using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Resources : MonoBehaviour
{
    [SerializeField] private static Dictionary<Resources, int> resources = new Dictionary<Resources, int>();
    void Start()
    {
        DisplayDictionary();
    }

    private void DisplayDictionary()
    {
        if (resources.Count <= 0)
        {
            Debug.Log("No hay recursos");
        }
        else
        {
            foreach (KeyValuePair<Resources, int> item in resources)
            {
                Debug.Log(item.Key + ": " + item.Value);
            }
        }
    }
    public static void AddResource(Resources resource)
    {
        if (resources.ContainsKey(resource))
        {
            resources[resource]++;
        }
        else
        {
            resources.Add(resource, 1);
        }
    }
    public static void RemoveResource(Resources resource)
    {
        if (resources.ContainsKey(resource))
        {
            resources[resource]--;
        }
        if (resources[resource] <= 0)
        {
            resources.Remove(resource);
        }
    }
}
