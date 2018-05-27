using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

	// carPrefabを入れる
	public GameObject carPrefab;

	// coinPrefabを入れる
	public GameObject coinPrefab;

	// cornPrefabを入れる
	public GameObject conePrefab;

	// スタート地点
	private int startPos = -160;

	// ゴール地点
	private int goalPos = 120;

	// アイテムを出すx方向の範囲
	private float posRange = 3.4f;

	// UnityChanのオブジェクトを格納
	private GameObject unityChan;

	// UnityChanのZ軸座標を格納
	private int unityChanZ;

	// アイテムを置く間隔
	private int itemInterval = 15;

	// Use this for initialization
	void Start () {

		Debug.Log ("aaa");
		unityChan = GameObject.Find ("unitychan");

	}

	// Update is called once per frame
	void Update () {

		// UnityChanのZ軸
		unityChanZ = (int)unityChan.transform.position.z;


		// UnityChanの位置から+40の位置まで、かつゴールまでの位置にオブジェクトを生成

		if (unityChanZ >= startPos - 40) {
			// どのアイテムを出すのかをランダムに設定
			int num = Random.Range (0, 10);

			// 0,1の場合、横一列にコーンを並べる
			if (num <= 1) {

				// コーンをx軸方向に一直線に生成
				for (float j = -1; j <= 1; j += 0.4f){

					GameObject cone = Instantiate (conePrefab) as GameObject;
					cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, startPos);

				}
			} else {

				// アイテムを生成するレーン
				for (int j = -1; j < 2; j++) {

					// アイテムの種類を決める(1-10)
					int item = Random.Range (1, 11);

					// アイテムを置くZ座標のオフセットをランダムに設定
					int offsetZ = Random.Range (-5, 6);

					// 60%コイン配置, 30%車配置, 10%何もなし
					if (1 <= item && item <= 6){

						// コインを生成
						// X軸は横の位置、Y軸はそのままのコインの位置。
						// Z軸(奥行)は、スタートのZ座標＋ゴールまで15間隔。
						GameObject coin = Instantiate (coinPrefab) as GameObject;
						coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, startPos + offsetZ);

					} else if (7 <= item && item <= 9){

						// 車を生成
						GameObject car = Instantiate (carPrefab) as GameObject;
						car.transform.position = new Vector3(posRange * j, car.transform.position.y, startPos + offsetZ);
					}
				}
			}

			startPos += 15;

		}
	}
}
