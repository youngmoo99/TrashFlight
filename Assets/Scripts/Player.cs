using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{   
    //캐릭터 움직임 속도
    [SerializeField]
    private float moveSpeed;

    //무기
    [SerializeField]
    private GameObject[] weapons;
    private int weaponIndex = 0;

    //미사일 발사
    [SerializeField]
    private Transform shootTransform;

    //미사일 간격
    [SerializeField]
    private float shootInterval = 0.05f;
    private float lastShotTime = 0f;

    // Update is called once per frame
    void Update()
    {   
        //키보드 제어
        //float horizontalInput = Input.GetAxisRaw("Horizontal");
        //float verticalInput = Input.GetAxisRaw("Vertical");
        // Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f);
        // transform.position += moveTo * moveSpeed * Time.deltaTime;

        // Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        // if (Input.GetKey(KeyCode.LeftArrow)) {  //왼쪽 방향키일때
        //     transform.position -= moveTo;
        // } else if(Input.GetKey(KeyCode.RightArrow)) { //오른쪽 방향키일때
        //     transform.position += moveTo;
        // }


        //마우스 제어 
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(mousePos); 로그남기기 
        
        //mathf.clamp(값, 최소값, 최대값) --> 최소,최대값을 벗어난경우 해당수치로 변경, 그 사이값일 경우 값 그대로 
        float toX = Mathf.Clamp(mousePos.x,-2.35f,2.35f);
        //x값만 변경된 포지션 y z 값은 원래값 그대로 
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);


        //탄막 공격
        Shoot();
    }

    //공격 메서드
    void Shoot() {
        if (Time.time - lastShotTime > shootInterval) { // Time.time : 게임이 시작된 이후로 현재까지 흐른시간
            //Instantiate(어떤객체를, 어떤위치에, 회전을 어떻게해서);
            Instantiate(weapons[weaponIndex],shootTransform.position, quaternion.identity);
            lastShotTime = Time.time;
        }
        
    }
    //충돌 메서드 OnTriggerEnter2D 충돌감지  isTirgger 체크 o
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag =="Boss") {
            Debug.Log("Game Over");
            Destroy(gameObject);
        } else if(other.gameObject.tag == "Coin") {
            GameManager.instance.IncreaseCoin();
            Destroy(other.gameObject);
        }
    }

    public void Upgrade() {
        weaponIndex++;
        if (weaponIndex >= weapons.Length) {
            weaponIndex = weapons.Length -1;
        }
    }
}
