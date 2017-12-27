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

	//ブロックのステータス(開閉)
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

		//CheckGame側で各ブロックのパラメータ設定（全ブロックClosed）
		_status_CF = (int)Status.CLOSED;

		//safe(enum)を入力
		this._status2_CF = (int)Status2.SAFE;

		//bomb(enum)を入力
		foreach (int j in PD.GetComponent<CheckGame>().attachBomb)
		{
			Debug.Log("bombが入るのは" + j);

			if(this.gameObject.name == ("AreaPrefab" + j))
			{
				//bomb設定
				this._status2_CF = (int)Status2.BOMB;

				//bombが付加されているブロックに赤色を設定
				this.GetComponent<Image>().color = new Color(1,0,0,1);
			}

			Debug.Log("ステータス" + this.gameObject.name + "は" + this._status2_CF);
		}
		
        //ブロックを開ける処理
        this._button.onClick.AddListener(Open);
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void Open()
    {
        //確認
        Debug.Log(this.gameObject);

        //PlayingDirectorの初期化
        GameObject PD = GameObject.Find("/PlayingDirector");

		//クリックしたブロックの名前をCheckGameに渡す
		PD.GetComponent<CheckGame>().blockObject = this.gameObject.name;
        
        //ブロックのオープン処理分岐
        if(_status_CF != (int)Status.OPENED){
            
            //ブロックのオープン処理
            _status_CF = (int)Status.OPENED;

			//オープンした際にブロックの色を変更する
			this.GetComponent<Image>().color = new Color(0, 1, 1, 1);

			//ブロックのナンバーだけ取得
			Debug.Log(this.gameObject.name.Substring(10));
            
            //勝敗確認
            PD.GetComponent<CheckGame>().Win_Lose();
            
            }else if(_status_CF == (int) Status.OPENED){

            //オープンブロックをオープンしようとしたときの処理
            Debug.Log("このブロックは既にオープンになっています");

		}

    }
}