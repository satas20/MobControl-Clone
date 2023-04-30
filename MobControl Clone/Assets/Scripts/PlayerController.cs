using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("EnemyCastle").transform;
        target.position -= new Vector3(0, target.position.y, 0);

    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();


    }
    private void MoveForward()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * moveSpeed);
    }
}
