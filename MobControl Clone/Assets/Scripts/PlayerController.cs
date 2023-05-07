using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    [Header("Health Controller")]
    [SerializeField] int maxHealth;
    private int health;
    private bool isReachedCheckPoint;
    [SerializeField] int damage;

    [SerializeField] float fireCd;
    private float fireTimer;

    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    private Vector3 target;
    private GameObject[] allTargets;
    public GameObject cloneSource = null;

    [SerializeField] bool isBig;
    private Vector3 startScale;
    void Start()
    {

        health = maxHealth;
        startScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        allTargets = GameObject.FindGameObjectsWithTag("EnemyCastle");
        target = closestTarget().transform.position;
        target.y = 0;
        fireTimer -= Time.deltaTime;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        MoveForward();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void MoveForward()
    {
        if (isReachedCheckPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * moveSpeed);
        }
        else
        {
            target.x = transform.position.x;
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * moveSpeed);
        }
    }
    public void getHit(int damage)
    {
        health -= damage;
        if (isBig)
        {

            transform.localScale = startScale * health / maxHealth;
        }
    }

    private GameObject closestTarget()
    {

        GameObject closestHere = gameObject;
        float leastDistance = Mathf.Infinity;

        foreach (var target in allTargets)
        {

            float distanceHere = Vector3.Distance(transform.position, target.transform.position);

            if (distanceHere < leastDistance)
            {
                leastDistance = distanceHere;
                closestHere = target;
            }

        }
        return closestHere;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && fireTimer <= 0)
        {
            ScoreScript.scoreValue += 2;
            collision.gameObject.GetComponent<EnemyController>().getHit(damage);
            fireTimer = fireCd;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpeedReducePoint"))
        {

            moveSpeed = 6;
        }
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            isReachedCheckPoint = true;
        }
        if (other.gameObject.CompareTag("EnemyCastle") && fireTimer <= 0)
        {
            other.gameObject.GetComponent<EnemyCastleScript>().getHit(damage);
            fireTimer = fireCd;
        }

    }


}
