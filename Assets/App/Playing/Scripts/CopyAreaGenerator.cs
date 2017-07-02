using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyAreaGenerator : MonoBehaviour
{

	public GameObject AreaPrefab;

	//行数をインスペクタから指定
	[SerializeField]
	private int _row;

	//列数をインスペクタから指定
	[SerializeField]
	private int _column;

	[SerializeField]
	private Transform _masu;

	//エリアを増やすメソッドを書きたい
	// Use this for initialization
	void Start ()
	{
		GameObject[,] Areas = new GameObject[_column,_row];

		//行
		for (int i = 0; i < _row; i++)
		{
			//列
			for (int j = 0; j < _column; j++)
			{
				Areas[i,j] = Instantiate(AreaPrefab,_masu) as GameObject;
				Areas[i,j].transform.localPosition = new Vector2(i * 50,j * 50);
			}
		}
	}

}