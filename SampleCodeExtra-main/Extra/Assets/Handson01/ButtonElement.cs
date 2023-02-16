using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ButtonElement : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Button m_MyButton;
    public UnityEngine.UI.Button MyButton { get { return m_MyButton; } }

    [SerializeField]
    private UnityEngine.UI.Image m_MyImage;
    public UnityEngine.UI.Image MyImage { get { return m_MyImage; } }

    public bool m_Active = false;
    public bool Active
    {
        get { return m_Active; }
        set 
        {
            m_Active = value;
            if (m_Active)
            {
                MyImage.color = Color.red;
            }
            else
            {
                MyImage.color= Color.white;
            }
        }
    }
}
