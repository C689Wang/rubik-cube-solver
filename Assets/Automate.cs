using System.Collections.Generic;
using UnityEngine;

public class Automate : MonoBehaviour
{
    public static List<string> moveList = new List<string>() {};
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveList.Count > 0)
        {
            // remove the move at first index
            moveList.Remove(moveList[0]);
        }
    }

    void RotateSide(List<GameObject> side, float angle)
    {
        
    }
}
