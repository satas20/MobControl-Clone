using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adam : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("EnemyCastle").transform;
        target.position -= new Vector3(0, target.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * moveSpeed);
    }
}
