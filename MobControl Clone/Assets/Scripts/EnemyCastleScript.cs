using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyCastleScript : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject enemy;
    [SerializeField] TextMeshProUGUI health_text;
    public class EnemySpawnEvents 
    {
        public int enemyAmount;
        public int bigEnemyAmount;
        public float spawnTime;
    }
    public EnemySpawnEvents[] spawnEvents;
    void Start()
    {
        spawn(10);
    }
    void Update()
    {
        health_text.text = health.ToString();
    }
    private void spawn(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            Vector3 newSpawnPoint = spawnPoint.position;
            int spawnX = Random.Range(-2, 2);
            int spawnZ = Random.Range(-3, 3);

            newSpawnPoint.z += spawnZ;
            newSpawnPoint.x += spawnX;
            Instantiate(enemy,newSpawnPoint, Quaternion.identity);
        }
    }
    public void getHit(int damage)
    {
        health -= damage;
    }
}
