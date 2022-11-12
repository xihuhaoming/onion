using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public float enemyDeadTime;
    public GameObject enemyDied;
    public float emenySpeed;
    public GameObject playerObj;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<PlayMoveMent>().playerHealth -= 10;
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Instantiate(enemyDied, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerObj.transform.position, emenySpeed * Time.deltaTime);
        emenySpeed += Random.Range(0.002f, 0.003f);
    }
}
