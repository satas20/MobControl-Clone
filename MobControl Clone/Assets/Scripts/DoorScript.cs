using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int amount;
    [SerializeField] GameObject player;
    [SerializeField] float time;
    [SerializeField] Vector2 xMove;
    [SerializeField] bool isMoving;

    void Start()
    {
        if (isMoving) 
        {
            DoMoveRight();
        }
            
    }
    private void DoMoveLeft()
    {
        transform.DOMoveX(xMove.x, time).OnComplete((DoMoveRight));
    }
    private void DoMoveRight()
    {
        transform.DOMoveX(xMove.y, time).OnComplete((DoMoveLeft));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject player = other.gameObject;

            if (player.GetComponent<PlayerController>().cloneSource != gameObject)
            {
                for(int i = 0; i < amount-1; i++)
                {
                    Vector3 newSpawnPoint = player.transform.position;
                    float spawnX = Random.Range(-4, 4);
                    float spawnZ = Random.Range(-2, 2);
                    newSpawnPoint.x += spawnX;
                    newSpawnPoint.z += spawnZ;

                    player.GetComponent<PlayerController>().cloneSource = gameObject;
                    Instantiate(player, newSpawnPoint, Quaternion.identity);
                }
            }
        }
    }
}
