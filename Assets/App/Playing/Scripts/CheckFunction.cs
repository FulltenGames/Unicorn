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

	//ランダムシード
	public int seed;

	//座標系
	public int position;

    [SerializeField]
    private Button _button;

	//各ブロックに対して呼ばれる
	void Start() {

		//確認
		Debug.Log("CheckFunctionのスタートメソッドが呼ばれている");

		//乱数生成(機能してない)
		//UnityEngine.Random.InitState(256);
		//seed = (int) UnityEngine.Random.value;
		//Debug.Log(seed);

		//PlayingDirectorの初期化
		GameObject CG = GameObject.Find("/PlayingDirector");

		//CheckGame側で各ブロックのパラメータ設定（全ブロックClosed）
		_status_CF = 1;

		//safe(enum)を入力
		_status2_CF = 3;

		//bomb(enum)を入力
		if(CG.GetComponent<CheckGame>().bombCount < 4)
		{
			_status2_CF = 4;
			CG.GetComponent<CheckGame>().bombCount++;
		}

        //ブロックを開ける
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
        GameObject CG = GameObject.Find("/PlayingDirector");

		//クリックしたブロックの名前をCheckGameに渡す
		CG.GetComponent<CheckGame>().blockObject = this.gameObject.name;
                
        //ブロックのオープン処理分岐
        if(_status_CF != 2){
            
            //ブロックのオープン処理
            _status_CF = 2;
            
            //勝敗確認
            CG.GetComponent<CheckGame>().Win_Lose();
            
            }else if(_status_CF == 2){

            //オープンブロックをオープンしようとしたときの処理
            Debug.Log("このブロックは既にオープンになっています");

		}        
    }
}