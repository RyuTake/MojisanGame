using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    // オブジェクトさんたち
    GameObject mojisan;
    GameObject beamYellow;
    GameObject countDownText;
    GameObject timerText;
    GameObject peachButton;
    GameObject peachButtonText;
    GameObject enemyText;

    // 変数さんたち
    private float peachStack;   // 闘気スタック数
    private float rotateSpeed;  // モンク回転スピード
    private bool gameStatus;   // ゲーム動作状態(on:動作、off:停止)
    private string countDownTextString; //カウントダウン用テキスト
    private float attackTime;   //攻撃したときの時間
    private float attackCount;  // 攻撃回数
    private float timeLimit;    //ゲーム時間
    private float gameStartTime;    // ゲーム開始時間
    private float usedTime;         // ゲーム経過時間


    // public関数-------------------------------------------------------------
    public void PeachTap()
    {
        // 闘気が5の時は万象闘気圏を撃ってリセット
        if (peachStack == 5f)
        {
            peachStack = 0f;
            rotateSpeed = 0f;
            this.mojisan.transform.rotation.Set(0, 0, 0, 0);
            this.beamYellow.SetActive(true);
            this.attackTime = Time.time;
            this.attackCount++;
            this.enemyText.GetComponent<Text>().text= this.attackCount.ToString();
        }
        // 闘気をスタックする
        else
        {
            this.peachStack++;
        }

    }

    // private関数-------------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        // ゲームオブジェクト取得
        this.mojisan = GameObject.Find("mojisan");
        this.beamYellow = GameObject.Find("beamYellow");
        this.countDownText = GameObject.Find("CountDownText");
        this.timerText = GameObject.Find("TimerText");
        this.peachButton = GameObject.Find("PeachButton");
        this.peachButtonText = GameObject.Find("PeachButtonText");
        this.enemyText = GameObject.Find("enemyText");

        // 変数初期化
        this.peachStack = 0f;
        this.rotateSpeed = 0f;
        this.countDownTextString = "Click to Start";
        this.attackCount = 0f;
        this.enemyText.GetComponent<Text>().text = "0";
        this.timeLimit = 10f;
        this.gameStartTime = 0f;
        this.usedTime = this.timeLimit;

        // 表示関係初期化
        // カウントダウン初期化
        this.countDownText.GetComponent<Text>().text = this.countDownTextString;
        // 画面上部タイマー初期化
         this.timerText.GetComponent<Text>().text = this.timeLimit.ToString();
        // 闘気数字初期化
        this.peachButtonText.GetComponent<Text>().text = this.peachStack.ToString();
        
        // エフェクト表示初期化
        this.beamYellow.SetActive(false);

        // ゲーム状態初期化
        this.gameStatus = false;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // ゲームが動いていないとき
        if (gameStatus == false)
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
            // ゲーム実行
            RunGame();

        }
    }

    // ゲーム処理本体 ---------------------------
    // ゲーム開始処理
    private void StartGame()
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
        // ゲーム開始時間記憶
        this.gameStartTime = Time.time;
    }

    // ゲーム実行処理
    private void RunGame()
    {
        // 残り時間計算
        usedTime = this.timeLimit - Time.time + this.gameStartTime;
        // 闘気5の時
        if (peachStack == 5f)
        {
            // 回る
            rotateSpeed = 100f;
        }
        // 闘気テキスト更新
        this.peachButtonText.GetComponent<Text>().text = this.peachStack.ToString();
        // モじさん回転
        this.mojisan.transform.Rotate(0, 0, rotateSpeed);
        // 攻撃エフェクト消去判定
        EffectOffMethod();

        // タイマーがゼロ未満の場合の処理
        if(usedTime < 0)
        {
            // ボタンを無効化
            this.peachButton.SetActive(false);
        }
        // タイマー時間が正の場合
        else
        {
            // タイマーテキスト更新
            this.timerText.GetComponent<Text>().text = (usedTime).ToString();

        }

    }

    // 万象闘気圏非表示処理
    private void EffectOffMethod()
    {
        // 陰陽闘気斬

        // 万象闘気圏
        if(this.beamYellow.activeSelf)
        {
            // Time.timeで取れる時間はfloatのsec msでないので注意
            if(Time.time - attackTime > 0.5)
            {
                this.beamYellow.SetActive(false);
            }
        }
    }


 
}
