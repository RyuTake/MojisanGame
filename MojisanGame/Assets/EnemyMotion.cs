
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotion : MonoBehaviour
{
    GameObject player;
    GameObject toukiEffect;

    // Start is called before the first frame update
    void Start()
    {
        // 初期位置のx座標を-7に設定
        // this.transform.position.x = -7;
        this.player = GameObject.Find("mojisan");
        this.toukiEffect = GameObject.Find("beamYellow");
    }

    // Update is called once per frame
    void Update()
    {
    }



}
