using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] ParticleSystem enemyParticle;



    [Header("Health Controller")]
    [SerializeField] int health = 4;
    [SerializeField] int damage = 2;

    [SerializeField] float fireCd;
    private float fireTimer;

    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform target;

    public GameObject cloneSource = null;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("EnemyCastle").transform;
        target.position -= new Vector3(0, target.position.y, 0);

    }

    // Update is called once per frame
    void Update()
    {
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
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * moveSpeed);
    }
    public void getHit(int damage)
    {
        health -= damage;
        EnemyHitParticular();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && fireTimer <= 0)
        {

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
        if (other.gameObject.CompareTag("EnemyCastle") && fireTimer <= 0)
        {
            other.gameObject.GetComponent<EnemyCastleScript>().getHit(damage);

            fireTimer = fireCd;
        }

    }
    private void EnemyHitParticular()
    {
        enemyParticle.Play();
    }



}
