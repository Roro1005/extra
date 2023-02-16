using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Move : MonoBehaviour
{
    [SerializeField]
    private Transform Target;

    [SerializeField]
    private UnityEngine.UI.Button MyButton;

    void Start()
    {
        MyButton.OnClickAsObservable().Subscribe(_ =>
        {
            //Target‚ð“®‚©‚·
            StartCoroutine(EasingSample.Move(0.5f, new Vector3(5f, 0, 0), Target));
        });
    }
}
