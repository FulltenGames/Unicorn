using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckGame : MonoBehaviour{

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

    //ブロックのステータス監視オブジェクト
    [SerializeField]
    private Status _status;

    [SerializeField]
    private Status2 _status2;

    //参照用のSetter・Getter(sp1・sp2)
    public int sp{get{return (int) _status;} set{this._status = (Status) Enum.ToObject(typeof(Status),this.sp);}}

    public int sp2{get{return (int) _status2;}set{this._status2 = (Status2) Enum.ToObject(typeof(Status2),this.sp2);}}

    // Use this for initialization
    void Start () {
        //確認
        Debug.Log("CheckGameが呼ばれている");

    }

    // Update is called once per frame
    void Update () {
        
    }

    //勝敗確認
    public void Win_Lose()
    {
        //確認
        Debug.Log("Win_Loseが呼ばれている");

        //sp2の値を更新
         this._status2 = (Status2) Enum.ToObject(typeof(Status2),sp2);
         
       if(this._status2 == Status2.BOMB){

           Debug.Log("負けです");

       }
    }
}
