using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectEasy : MonoBehaviour
{
	public CopyAreaGenerator _copyAreaGenerator;

	//行数をインスペクタから指定
	[SerializeField]
	private int _row;

	//列数をインスペクタから指定
	[SerializeField]
	private int _column;

	[SerializeField]
	private Transform _masu;

	// Use this for initialization
	void Start ()
	{
		_copyAreaGenerator = GetComponent<CopyAreaGenerator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
