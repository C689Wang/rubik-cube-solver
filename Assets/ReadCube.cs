using System.Collections.Generic;
using UnityEngine;

public class ReadCube : MonoBehaviour
{
    public Transform tUp;
    public Transform tDown;
    public Transform tLeft;
    public Transform tRight;
    public Transform tFront;
    public Transform tBack;

    private int layerMask = 1 << 6;
    CubeState cubeState;
    CubeMap cubeMap;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cubeState = FindFirstObjectByType<CubeState>();
        cubeMap = FindFirstObjectByType<CubeMap>();
        List<GameObject> facesHit = new List<GameObject>();
        Vector3 ray = tFront.transform.position;
        RaycastHit hit;

        if (Physics.Raycast(ray, tFront.right, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(ray, tFront.right * hit.distance, Color.yellow);
            facesHit.Add(hit.collider.gameObject);
            print(hit.collider.gameObject.name);
        }
        else
        {
            Debug.DrawRay(ray, tFront.right * 1000, Color.green);
        }
        cubeState.front = facesHit;
        cubeMap.Set();
    }

    // Update is called once per frame
    void Update()
    {
        // List<GameObject> facesHit = new List<GameObject>();
        // Vector3 ray = tFront.transform.position;
        // RaycastHit hit;

        // if (Physics.Raycast(ray, tFront.right, out hit, Mathf.Infinity, layerMask))
        // {
        //     Debug.DrawRay(ray, tFront.right * hit.distance, Color.yellow);
        //     facesHit.Add(hit.collider.gameObject);
        //     print(hit.collider.gameObject.name);
        // }
        // else
        // {
        //     Debug.DrawRay(ray, tFront.right * 1000, Color.green);
        // }
        // cubeState.front = facesHit;
        // cubeMap.Set();
    }
}
