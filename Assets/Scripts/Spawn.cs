using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject blood;
    public float ememyNumber;
    public float createTime;
    public float timeBetween;
    public GameObject playerTemp;
    
    // Start is called before the first frame update
    
    private void Update()
    {
        timeBetween += Time.deltaTime;
        if (createTime < timeBetween)
        {
            SpawnObject(blood);
            SpawnObject(enemy).GetComponent<Enemy>().playerObj = playerTemp;
            // 场景中必须有实体，要不然无法将实体拖到Ememy中，这个是为了将player传递给ememy脚本当中。
            timeBetween = 0;
        }
    }

    private GameObject SpawnObject(GameObject obj)
    {
        return Instantiate(obj, new Vector3(Random.Range(-15,15), Random.Range(-15,15),0 ), Quaternion.identity);
    }
}
