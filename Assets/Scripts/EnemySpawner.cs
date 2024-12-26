using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   
    [SerializeField]
    private GameObject[] enemies;

    private float[] arrPosX = { -2.2f, -1.1f, 0, 1.1f, 2.2f };
    // Start is called before the first frame update
    void Start()
    {   
        foreach (float posX in arrPosX) {
            //적 개수 랜덤 0~6
            int index = Random.Range(0,enemies.Length);
            SpawnEnemy(posX, index);
        }
    }

    //적 5개 생성 
    void SpawnEnemy(float posX, int index) {
        Vector3 spawnPos = new Vector3(posX,transform.position.y,transform.position.z);
        Instantiate(enemies[index], spawnPos, Quaternion.identity);
    }
}
