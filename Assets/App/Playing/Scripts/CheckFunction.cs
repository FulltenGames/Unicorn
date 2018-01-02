using System;
using UnityEngine;
using UnityEngine.UI;

public class CheckFunction : MonoBehaviour {

	[SerializeField]
	private enum Status
	{

		//ブロックのステータス(open・close)
		CLOSED = 1,
		OPENED = 2

	}

	[SerializeField]
	private enum Status2
	{
		//ブロックのステータス(bomb・safe)
		SAFE = 3,
		BOMB = 4

	}

	//ブロックのステータス(open・close)
	public int _status_CF;

	//ブロックのステータス2(safe・bomb)
	public int _status2_CF;

	[SerializeField]
	private Button _button;

	//各ブロックに対して呼ばれる
	void Start() {

		//確認
		Debug.Log("CheckFunctionのスタートメソッドが呼ばれている");

		//PlayingDirectorの初期化
		GameObject PD = GameObject.Find("/PlayingDirector");

		//CheckGame側でCLOSED状態へ
		_status_CF = (int)Status.CLOSED;

		//safe(enum)を入力
		this._status2_CF = (int)Status2.SAFE;

		//bomb(enum)を入力
		foreach (int j in PD.GetComponent<CheckGame>().attachBomb)
		{
			Debug.Log("bombが入るのは" + j);

			if (this.gameObject.name == ("AreaPrefab" + j))
			{
				//bomb設定
				this._status2_CF = (int)Status2.BOMB;

				//bombが付加されているブロックに赤色を設定
				this.GetComponent<Image>().color = new Color(1, 0, 0, 1);
			}

			Debug.Log("ステータス" + this.gameObject.name + "は" + this._status2_CF);
		}

		//ブロックを開ける処理
		this._button.onClick.AddListener(Open);
	}

	// Update is called once per frame
	void Update() {

	}

	//ブロックのオープン処理
	private void Open()
	{
		//確認
		Debug.Log(this.gameObject);

		//PlayingDirectorの初期化
		GameObject PD = GameObject.Find("/PlayingDirector");

		//クリックしたブロックの名前をCheckGameに渡す
		PD.GetComponent<CheckGame>().blockObject = this.gameObject.name;

		//ブロックのオープン処理分岐
		if (_status_CF != (int)Status.OPENED) {

			//ブロックのステータスをオープンに変更
			_status_CF = (int)Status.OPENED;

			//オープンした際にブロックの色を変更する(open)
			this.GetComponent<Image>().color = new Color(0, 1, 1, 1);

			//ブロックのナンバーだけ取得
			Debug.Log(this.gameObject.name.Substring(10));

			//勝敗確認
			PD.GetComponent<CheckGame>().Win_Lose();

			//クリックしたブロック周りの処理
			causeOpend(this.gameObject.name);

		} else if (_status_CF == (int)Status.OPENED) {

			//オープンブロックをオープンしようとしたときの処理
			Debug.Log("このブロックは既にオープンになっています");

		}

	}

	//クリックしたブロック周辺の処理
	public void causeOpend(string pointedNumber)
	{
		//オープンにしたブロックの番号
		int centerNumber_int = int.Parse(pointedNumber.Substring(10));

		int[] causedBlocks;

		causedBlocks = moreOpen(centerNumber_int);

		//確認
		Debug.Log("centerNumber:" + centerNumber_int);

		

		foreach (int isChanged in causedBlocks)
		{
			//空以外
			if (isChanged != 0)
			{
				Debug.Log("isChangedの影響範囲:" + isChanged);
			}
		}

		foreach (int isChanged in causedBlocks)
		{
			//配列内の実値のみ
			if (isChanged != 0)
			{
				//インスタンス初期化
				GameObject CF = GameObject.Find("/BlockCanvas/AreaGenerator/Masu/" + "AreaPrefab" + isChanged.ToString());

				//開いてないものかつ、爆弾ではないもの
				if (CF.GetComponent<CheckFunction>()._status_CF != (int)Status.OPENED && CF.GetComponent<CheckFunction>()._status2_CF != 4)
				{

					CF.GetComponent<CheckFunction>()._status_CF = (int)Status.OPENED;
					CF.GetComponent<Image>().color = new Color(0, 1, 1, 1);
				}
			}
		}

	}

	//どのブロックを処理するかの決定
	public int[] moreOpen(int centerNumber){

		int[] otherBlock = new int[8];

		//左下
		if (centerNumber == 1)
		{
			otherBlock[0] = centerNumber + 1;
			otherBlock[1] = centerNumber + GameManager.Instance.Column;
			otherBlock[2] = centerNumber + 1 + GameManager.Instance.Column;

		}//左上
		else if (centerNumber == GameManager.Instance.Column)
		{
			otherBlock[0] = centerNumber - 1;
			otherBlock[1] = centerNumber + GameManager.Instance.Column - 1;
			otherBlock[2] = centerNumber + GameManager.Instance.Column;



		}//右下
		else if (centerNumber == (1 + (GameManager.Instance.Row - 1) * GameManager.Instance.Column))
		{
			otherBlock[0] = (1 + (GameManager.Instance.Row - 2) * GameManager.Instance.Column);
			otherBlock[1] = (2 + (GameManager.Instance.Row - 2) * GameManager.Instance.Column);
			otherBlock[2] = (2 + (GameManager.Instance.Row - 1) * GameManager.Instance.Column);




		}//右上
		else if (centerNumber == (GameManager.Instance.Column + (GameManager.Instance.Row - 1) * GameManager.Instance.Column))
		{
			otherBlock[0] = (GameManager.Instance.Column - 1 + (GameManager.Instance.Row - 2) * GameManager.Instance.Column);
			otherBlock[1] = (GameManager.Instance.Column + (GameManager.Instance.Row - 2) * GameManager.Instance.Column);
			otherBlock[2] = (GameManager.Instance.Column + (GameManager.Instance.Row - 1) * GameManager.Instance.Column);



		}//左端沿い
		else if (1 < centerNumber && centerNumber < GameManager.Instance.Column)
		{
			otherBlock[0] = centerNumber - 1;
			otherBlock[1] = centerNumber + 1;
			otherBlock[2] = centerNumber + GameManager.Instance.Column - 1;
			otherBlock[3] = centerNumber + GameManager.Instance.Column;
			otherBlock[4] = centerNumber + GameManager.Instance.Column + 1;



		}//右端沿い
		else if ((1 + (GameManager.Instance.Row - 1) * GameManager.Instance.Column) < centerNumber && centerNumber < (GameManager.Instance.Column + (GameManager.Instance.Row - 1) * GameManager.Instance.Column))
		{
			otherBlock[0] = centerNumber - GameManager.Instance.Column - 1;
			otherBlock[1] = centerNumber - GameManager.Instance.Column;
			otherBlock[2] = centerNumber - GameManager.Instance.Column + 1;
			otherBlock[3] = centerNumber - 1;
			otherBlock[4] = centerNumber + 1;



		}//下端
		else if (1 < centerNumber && centerNumber % GameManager.Instance.Column == 1 && centerNumber < (1 + (GameManager.Instance.Row - 1) * GameManager.Instance.Column))
		{
			otherBlock[0] = centerNumber - GameManager.Instance.Column;
			otherBlock[1] = centerNumber - GameManager.Instance.Column + 1;
			otherBlock[2] = centerNumber + 1;
			otherBlock[3] = centerNumber + GameManager.Instance.Column;
			otherBlock[4] = centerNumber + GameManager.Instance.Column + 1;



		}//上端
		else if (GameManager.Instance.Column < centerNumber && centerNumber % GameManager.Instance.Column == 0 && centerNumber < (GameManager.Instance.Column + (GameManager.Instance.Row - 1) * GameManager.Instance.Column))
		{
			otherBlock[0] = centerNumber - GameManager.Instance.Column - 1;
			otherBlock[1] = centerNumber - GameManager.Instance.Column;
			otherBlock[2] = centerNumber - 1;
			otherBlock[3] = centerNumber + GameManager.Instance.Column - 1;
			otherBlock[4] = centerNumber + GameManager.Instance.Column;



		}//中央
		else
		{
			otherBlock[0] = centerNumber - GameManager.Instance.Column - 1;
			otherBlock[1] = centerNumber - GameManager.Instance.Column;
			otherBlock[2] = centerNumber - GameManager.Instance.Column + 1;
			otherBlock[3] = centerNumber - 1;
			otherBlock[4] = centerNumber + 1;
			otherBlock[5] = centerNumber + GameManager.Instance.Column - 1;
			otherBlock[6] = centerNumber + GameManager.Instance.Column;
			otherBlock[7] = centerNumber + GameManager.Instance.Column + 1;

		}

		return otherBlock;
	}
}