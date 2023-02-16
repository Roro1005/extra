using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class DelayExecute : MonoBehaviour
{
    [SerializeField]
    private Button ButtonA;
    [SerializeField]
    private Button ButtonB;
    [SerializeField]
    private Button ButtonC;

    void Start()
    {
        ButtonA.OnClickAsObservable().Subscribe(_ =>
        {
            //Invoke
            Invoke("Execute", 3f);
        });

        ButtonB.OnClickAsObservable().Subscribe(_ =>
        {
            //コルーチン
            StartCoroutine(WaitCoroutine(3f, () => Execute()));
        });

        ButtonC.OnClickAsObservable().Subscribe(_ =>
        {
            //Observable.Timer
            Observable.Timer(System.TimeSpan.FromSeconds(3)).Subscribe(_ => Execute());
        });
    }

    private IEnumerator WaitCoroutine(float waitSecond, System.Action action)
    {
        yield return new WaitForSeconds(waitSecond);
        action.Invoke();
    }
    private void Execute()
    {
        Debug.Log("実行されたよ");
    }

}
