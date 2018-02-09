﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Target_location : MonoBehaviour
{
    public GameObject target;
    public static List<float> px = new List<float>(); //各座標のリスト
    public static List<float> py = new List<float>();
    public static List<float> pz = new List<float>();
    public int max = 5; //的の最大数


    float temp_x, temp_y,temp_z;  //座標のバッファ

    public static int num = 0; //的の生成された数
    Vector3 pos;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (num < max)
        {
            while (true)
            {
                //的の座標をランダムに作成
				int wall=Random.Range(1,5);
				if(wall==1)
				{
					temp_x = Random.Range(-24,25);
					temp_y = Random.Range(1,50);
					temp_z = 24.4f;
				}
				else if(wall==2)
				{
					temp_x = Random.Range(-24,25);
					temp_y = Random.Range(1,50);
					temp_z = -24.4f;
				}
				else if(wall==3)
				{
					temp_x = -24.4f;
					temp_y = Random.Range(1,50);
					temp_z = Random.Range(-24,25);
				}
				else if(wall==4)
				{
					temp_x = 24.4f;
					temp_y = Random.Range(1,50);
					temp_z = Random.Range(-24,25);
				}
                if (px.Contains(temp_x)&& py.Contains(temp_y) && pz.Contains(temp_z))
                {
                    continue; // ランダムで出てきた数字がすでに1度出てきてたら、もう一度
                }

                pos.x = temp_x;  //座標を代入
                pos.y = temp_y;
                pos.z = temp_z;

                GameObject targets = GameObject.Instantiate(target) as GameObject;
                targets.transform.position = pos;
				if(wall>2)
					targets.transform.Rotate(0f, 90f, 0f);
                num++;
                px.Add(temp_x);  // ランダムで出てきた数字を保持
                py.Add(temp_y);
                pz.Add(temp_z);


                if (num == max)
                {
                    break;  //指定数の的のインスタンスを作ったらループを抜ける
                }
            }
        }
    }
}