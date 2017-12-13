using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGame : MonoBehaviour{

    public enum Check
    {

        SAFE = 3,
        BOMB = 4

    }

    public Check _status;

    [SerializeField]
    private int b;

    // Use this for initialization
    void Start () {
        //確認
        Debug.Log("CheckGameが呼ばれている");

        //生成されるまで存在しないから無理
        //GameObject checkStatus = GameObject.Find("/BlockCanvas/AreaGenerator/Masu/AreaPrefab");
        //Debug.Log(checkStatus.GetComponent<RectTransform>());

        Debug.Log(b);
    }

    // Update is called once per frame
    void Update () {
        
    }

    public void Lose()
    {
        this._status = Check.BOMB;
       if(this._status == Check.BOMB){

           Debug.Log("負けです");

       }
    }
}
