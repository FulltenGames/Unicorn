using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyAreaGenerator : MonoBehaviour
{

	public GameObject AreaPrefab;

    [SerializeField]
    private Transform _masu;

    //[SerializeField]
    //private Button _button;

	public void Start ()
	{   //確認
        Debug.Log("CopyAreaGeneratorが呼ばれた");
		Debug.Log("Column" + GameManager.Instance.Column);
		Debug.Log("Row" + GameManager.Instance.Row);
        
        
		GameObject[,] Areas = new GameObject[GameManager.Instance.Column,GameManager.Instance.Row];        

		//生成開始する座標中心
		gameObject.transform.localPosition = new Vector2(0,0);

		//行
		for (int i = 0; i < GameManager.Instance.Row; i++)
		{
			//列
			for (int j = 0; j < GameManager.Instance.Column; j++)
			{
				Areas[i, j] = Instantiate(AreaPrefab, _masu) as GameObject;
                Areas[i, j].name = AreaPrefab.name;
				Areas[i, j].transform.localPosition = new Vector2((i * 50) - (GameManager.Instance.Row * 25) + 25, (j * 50) -(GameManager.Instance.Column * 25) + 25);
			}
		}

    //動かない
    //_button.onClick.AddListener(OnClick);
	}

    private void OnClick()
    {
        Debug.Log(this.gameObject.name + "がCopyAreaGeneratorから押されている");
    }

}