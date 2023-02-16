using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private ButtonElement[] Buttons;
    CompositeDisposable Disposables = new CompositeDisposable();

    public void SetButtons(ButtonElement[] buttons)
    {
        Buttons = buttons;
    }

    void Start()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            var button = Buttons[i];

            button.MyButton.OnClickAsObservable().Subscribe(_ => 
            {
                button.Active = !button.Active;
            }).AddTo(Disposables);
        }
    }

    private void OnDestroy()
    {
        Disposables.Dispose();
    }

}
