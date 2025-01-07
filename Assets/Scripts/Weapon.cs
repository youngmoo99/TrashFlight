using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{   
    [SerializeField]
    private float moveSpeed = 10f;
    public float damage = 1f;

    //Start객체 게임시작하고 처음 호출되는 객체 혹은 비활성화 했다가 다시 활성화하는 경우에도 호출
    void Start() 
    {   
        //미사일 쏘고나서 1초뒤 사라짐
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}
