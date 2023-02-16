using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Handson01Editor
{
    [MenuItem("Sample/ハンズオン01/ボタン生成")]
    public static void GenerateButtons()
    {
        //ボタンのプロトタイプ
        //エディタコードなのでGameObject.Find使っていい
        GameObject prototype = GameObject.Find("GUI/Canvas/ButtonPrototype");

        //Debug.Log(prototype);
        //エディタコードなのでFindObjectOfType使っていい
        ButtonManager manager = Object.FindObjectOfType<ButtonManager>();
        List<ButtonElement> buttons = new List<ButtonElement>();

        //事前にButtonManagerの下位オブジェクトを全て削除しておく
        //インデックスを逆順に回すと削除がスムーズ
        for (int i = manager.transform.childCount-1; i >= 0; i--)
        {
            Object.DestroyImmediate(manager.transform.GetChild(i).gameObject);
        }

        //ButtonManagerの下にボタンを10x10で100個生成する
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GameObject btnObject = Object.Instantiate(prototype, manager.transform);
                btnObject.name = "Button";
                btnObject.transform.localPosition = new Vector3(-150 + 30 * j, -150 + 30 * i, 0);
                btnObject.SetActive(true);

                ButtonElement btn = btnObject.GetComponent<ButtonElement>();
                buttons.Add(btn);
            }
        }

        manager.SetButtons(buttons.ToArray());
        //保存するためにこれが必要
        EditorUtility.SetDirty(manager);

    }

}
