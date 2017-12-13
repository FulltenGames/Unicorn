using System;
using UnityEngine;
using UnityEngine.UI;

public class CheckFunction : MonoBehaviour {

    [SerializeField]
    Status _status;

    [SerializeField]
    Status2 _status2;

    [SerializeField]
    private Button _button;

    [SerializeField]
    public int a = 3;


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

    //Statusの取得
    public int ｓParameter{get{return (int)_status;}}

    public int SParameter2{get{return (int)_status2;}}
    
	// Use this for initialization
	void Start () {

        //確認
        Debug.Log("CheckFunctionのスタートメソッドが呼ばれている!!!!");
        //Debug.Log(_a);

        //初期状態：全部閉じている
        this._status = Status.CLOSED;

        //4個爆弾、他セーフの予定
        this._status2 = Status2.BOMB;
        this._button.onClick.AddListener(Open);
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void Open()
    {
        //確認
        //Debug.Log("void Openが呼ばれた");

        if (this._status == Status.CLOSED)
        {
            this._status = Status.OPENED;
            Debug.Log(this._status);
        }
        else
        {
            Debug.Log("既にオープンです" + Enum.GetName(typeof(Status), Status.OPENED));
        }
        
        //CheckGame側で敗北テスト
        GameObject CG = GameObject.Find("/PlayingDirector");
        Debug.Log(CG.GetComponent<CheckGame>());
        CG.GetComponent<CheckGame>().Lose();
    }
}