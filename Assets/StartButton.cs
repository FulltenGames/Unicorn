using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton: MonoBehaviour {

    public void SceneLoad()
    {
        Debug.Log("出力");
        //StageSelect画面に遷移
        SceneManager.LoadScene("StageSelect");
    }

}
