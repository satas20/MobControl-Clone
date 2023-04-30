using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private float angle;
    [SerializeField] private float radius;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlaceRunners();


    }
    private void PlaceRunners()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Vector3 childLocalPosition = GetRunnerLocalPosition(i);
            transform.GetChild(i).localPosition = childLocalPosition;

        }

    }
    private Vector3 GetRunnerLocalPosition(int index) // golden ratio and golden angle
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);

        return new Vector3(x, 0, z);

    }
}
