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
            //StartCoroutine(EasingSample.Move(0.2f, new Vector3(2f, 0, 0), Target));

            EasingSample.MoveRx(0.5f,new Vector3(3f,0,0),Target,EasingSample.EaseLinear);
        });
    }
}
