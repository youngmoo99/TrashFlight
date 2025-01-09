using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //싱글톤 패턴 
    public static GameManager instance = null;
    [SerializeField]
    private TextMeshProUGUI text;
    private int coin = 0;

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
}
