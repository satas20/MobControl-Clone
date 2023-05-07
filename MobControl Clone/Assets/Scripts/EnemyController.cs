using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private ParticleSystem enemyParticular;


    [Header("Health Controller")]

    [SerializeField] int maxHealth;
    private int health;

    [SerializeField] int damage;

    [SerializeField] float fireCd;
    private float fireTimer;

    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    private Transform target;

    [SerializeField] bool isBig;
    private Vector3 startScale;
    void Start()
    {
        health = maxHealth;
        target = GameObject.FindGameObjectWithTag("PlayerCastle").transform;
        target.position -= new Vector3(0, target.position.y, 0);
        startScale = transform.localScale;
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
        EnemyHitEffect();

        if (isBig)
        {
            transform.localScale = startScale * health / maxHealth;
            EnemyHitEffect();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && fireTimer <= 0)
        {
            collision.gameObject.GetComponent<PlayerController>().getHit(damage);

            fireTimer = fireCd;
        }
        if (collision.gameObject.CompareTag("PlayerCastle") && fireTimer <= 0)
        {

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpeedReducePoint"))
        {

            moveSpeed = 6;
        }
    }
    private void EnemyHitEffect()
    {
        enemyParticular.Play();
    }

}
