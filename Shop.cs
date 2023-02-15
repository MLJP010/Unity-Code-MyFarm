using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public int hay;
    public CollectorScript firstScript;

    private void Start()
    {
        hay = firstScript.hay;
    }

    void OnMouseDown()
    {
        if (hay > 0)
        {
            hay--;
        }
    }
}