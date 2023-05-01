using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliders : MonoBehaviour
{
    public Vector3 pos1;
    public Vector3 pos2;
    public float moveSpeed;

    private void FixedUpdate()
    {
        gameObject.GetComponent<Transform>().localPosition = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * moveSpeed, 1.0f));
    }
}
