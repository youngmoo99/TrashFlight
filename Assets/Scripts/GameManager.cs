using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //싱글톤 패턴 
    public static GameManager instance = null;
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private GameObject gameOverPanel;

    private int coin = 0;

    [HideInInspector]
    public bool isGameOver = false;

    //start메서드보다 더 빨리 불러지는 메서드
    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void IncreaseCoin() {
        coin++;
        //코인을 문자열로 변경
        text.SetText(coin.ToString());

        if(coin % 30 == 0) {
            Player player = FindObjectOfType<Player>();
            if (player != null) {
                player.Upgrade();
            }
        }
    }

    public void SetGameOver() {
        isGameOver = true;
        
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner != null) {
            enemySpawner.StopEnemyRoutine();
        }

        //시간을 기다린뒤에 메소드실행  1초뒤에   
        Invoke("ShowGameOverPanel",1f);
    }

    void ShowGameOverPanel() {
        //게임오버 패널 활성화
        gameOverPanel.SetActive(true);
    }
    
    //재시작 메서드 onclick
    public void PlayAgain() {
        SceneManager.LoadScene("SampleScene");
    }
}
