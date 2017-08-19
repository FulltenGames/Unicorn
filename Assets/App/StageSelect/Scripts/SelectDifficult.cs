using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//public class SelectDifficult : MonoBehaviour
public class SelectDifficult:MonoBehaviour
{
	[SerializeField]
	public static int column;

	[SerializeField]
	public static int row;

	[SerializeField]
	private Button _button;

	//難易度選択
	void Start () {
		GameManager.Instance.Parameter();
		//StageSelect画面に遷移
		_button.onClick.AddListener(OnClick);
	}

	private void OnClick()
	{	
		SceneManager.LoadScene("Playing");
	}
}
