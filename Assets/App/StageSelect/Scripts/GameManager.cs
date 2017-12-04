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
	[SerializeField]
	private int _column;
	public int Column{get{return _column;}}

	[SerializeField]
	private int _row;
	public int Row{get{return _row;}}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}

	public void Parameter(int column,int row){
		_column = column;
		_row = row;
	}
}