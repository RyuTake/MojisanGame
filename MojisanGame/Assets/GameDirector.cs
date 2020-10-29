using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    // オブジェクトさんたち
    GameObject mojisan;
    GameObject peach;
    GameObject peachStackText;
    GameObject beamYellow;
    GameObject countDownText;
    GameObject timerText;

    // 変数さんたち
    float peachStack;   // 闘気スタック数
    float rotateSpeed;  // モンク回転スピード
    float time;         // 時間
    bool gameStatus;   // ゲーム動作状態(on:動作、off:停止)
    string countDownTextString; //カウントダウン用テキスト
    float attackTime;   //攻撃したときの時間
    string timerTextString; // タイマー表示用テキスト

    // Start is called before the first frame update
    void Start()
    {
        // ゲームオブジェクト取得
        this.mojisan = GameObject.Find("mojisan");
        this.peach = GameObject.Find("fruit_peach");
        this.peachStackText = GameObject.Find("PeachStackText");
        this.beamYellow = GameObject.Find("beam_yellow");
        this.countDownText = GameObject.Find("CountDownText");
        this.timerText = GameObject.Find("TimerText");
        
        // 変数初期化
        this.peachStack = 0f;
        this.rotateSpeed = 0f;
        this.countDownTextString = "Click to Start";
        this.timerTextString = Time.time.ToString();


        // 表示関係初期化
        // カウントダウン初期化
        this.countDownText.GetComponent<Text>().text = this.countDownTextString;
        // 画面上部タイマー初期化
         this.timerText.GetComponent<Text>().text = Time.time.ToString();
        // 闘気数字初期化
        this.peachStackText.GetComponent<Text>().text = this.peachStack.ToString();
        
        // エフェクト表示初期化
        this.beamYellow.SetActive(false);

        // タイマー関連初期化
        this.time = 0f;
        this.gameStatus = false;


    }

    // Update is called once per frame
    void Update()
    {
        // ゲームが動いていないとき
        if(gameStatus == false)
        {
            // マウスクリックでゲームスタート
            if(Input.GetMouseButtonDown(0))
            {
                StartGame();
            }
            return;
        }
        else
        {
            // todo 関数切り分ける
            // ゲーム処理 
            if (Input.GetMouseButtonDown(0))
            {
                // 闘気が5の時は万象闘気圏を撃ってリセット
                if (peachStack == 5f)
                {
                    peachStack = 0f;
                    rotateSpeed = 0f;
                    this.mojisan.transform.rotation.Set(0, 0, 0, 0);
                    this.beamYellow.SetActive(true);
                    this.attackTime = Time.time;
                }
                // 闘気をスタックする
                else
                {
                    this.peachStack++;
                }
            }
            if (peachStack == 5f)
            {
                rotateSpeed = 10f;
            }
            this.peachStackText.GetComponent<Text>().text = this.peachStack.ToString();
            this.mojisan.transform.Rotate(0, 0, rotateSpeed);
            // 攻撃エフェクト消去判定
            EffectOffMethod();
            // タイマーテキスト更新
             this.timerText.GetComponent<Text>().text = Time.time.ToString();

        }
    }

    // ゲーム処理本体 ---------------------------
    // ゲーム開始処理
    void StartGame()
    {

        // カウントダウン処理
        this.countDownTextString = "3";
        this.countDownText.GetComponent<Text>().text = this.countDownTextString;
        // todo waitをはさむ

        this.countDownTextString = "2";
        this.countDownText.GetComponent<Text>().text = this.countDownTextString;

        this.countDownTextString = "1";
        this.countDownText.GetComponent<Text>().text = this.countDownTextString;

        this.countDownTextString = "0";
        this.countDownText.GetComponent<Text>().text = this.countDownTextString;


        // 0になったらカウントダウン非表示
        this.countDownText.SetActive(false);
        // タイマーのフラグをon
        gameStatus = true;
    }

    // 万象闘気圏非表示処理
    void EffectOffMethod()
    {
        // 陰陽闘気斬

        // 万象闘気圏
        if(this.beamYellow.activeSelf)
        {
            // Time.timeで取れる時間はfloatのsec msでないので注意
            if(Time.time - attackTime > 2)
            {
                this.beamYellow.SetActive(false);
            }
        }
    }



    // Timer関連--------------------------
    // タイマー初期化
    // Time関数で開始からの時間はずっと保持している
    // じゃあ、Time使って何とかする？
    // Updateのたびになんかさせる？or
    // Time関数を適宜呼び出せば問題なし？
    void StartTimer()
    {

    }

    // タイマーさん
    float Timer(float time)
    {


        return time;
    }
}
