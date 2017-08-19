using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
	/* 
	[SerializeField]
	private int _column;

	[SerializeField]
	private int _row;
	*/
	public int _column;

	public int _row;


	// Use this for initialization
	void Start () {
		_column = SelectDifficult.column;
		_row = SelectDifficult.row;
		DontDestroyOnLoad(this.gameObject);
	}

	public void Parameter(){
		_column = SelectDifficult.column;
		_row = SelectDifficult.row;
	}
}