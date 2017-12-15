using System;
using UnityEngine;
using UnityEngine.UI;

public class CheckFunction : MonoBehaviour {

    [SerializeField]
    int _status;

    [SerializeField]
    int _status2;

    [SerializeField]
    private Button _button;

    
    
	// Use this for initialization
	void Start () {

        //確認
        Debug.Log("CheckFunctionのスタートメソッドが呼ばれている");

        //PlayingDirectorの初期化
        GameObject CG = GameObject.Find("/PlayingDirector");
        
        //CheckGame側で各ブロックのパラメータ設定（全ブロックClosed）
        _status = CG.GetComponent<CheckGame>().sp;

        //CheckGame側で各ブロックのパラメータ設定(全ブロックの内、一部Bombにしたい)
        _status2 =CG.GetComponent<CheckGame>().sp2;
        
        //ブロックを開ける
        this._button.onClick.AddListener(Open);
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void Open()
    {
        //確認
        Debug.Log("オープンメソッドが呼ばれている");

        //PlayingDirectorの初期化
        GameObject CG = GameObject.Find("/PlayingDirector");
                
        //ブロックのオープン処理分岐
        if(this._status != 2){
            
            //ブロックのオープン処理
            this._status = 2;

            //オープンしたブロックのSafe・Bomb情報をCheckGameに送る
            CG.GetComponent<CheckGame>().sp2 = this._status2;

            //勝敗確認
            CG.GetComponent<CheckGame>().Win_Lose();
            
            }else if(this._status == 2){

            //オープンブロックをオープンしようとしたときの処理
            Debug.Log("このブロックは既にオープンになっています");

        }        
    }
}