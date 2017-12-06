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
    //uGUI上の_columnの値
	private int _column;
	public int Column{get{return _column;}}

	[SerializeField]
    //uGUI上の_rowの値
	private int _row;
	public int Row{get{return _row;}}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}

    //インスペクタ上のGameManagerがもつRowとColumnの値を引数に変更する
	public void Parameter(int column,int row){
		_column = column;
		_row = row;
	}
}