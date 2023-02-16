using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Handson01Editor
{
    [MenuItem("Sample/�n���Y�I��01/�{�^������")]
    public static void GenerateButtons()
    {
        //�{�^���̃v���g�^�C�v
        //�G�f�B�^�R�[�h�Ȃ̂�GameObject.Find�g���Ă���
        GameObject prototype = GameObject.Find("GUI/Canvas/ButtonPrototype");

        //Debug.Log(prototype);
        //�G�f�B�^�R�[�h�Ȃ̂�FindObjectOfType�g���Ă���
        ButtonManager manager = Object.FindObjectOfType<ButtonManager>();
        List<ButtonElement> buttons = new List<ButtonElement>();

        //���O��ButtonManager�̉��ʃI�u�W�F�N�g��S�č폜���Ă���
        //�C���f�b�N�X���t���ɉ񂷂ƍ폜���X���[�Y
        for (int i = manager.transform.childCount-1; i >= 0; i--)
        {
            Object.DestroyImmediate(manager.transform.GetChild(i).gameObject);
        }

        //ButtonManager�̉��Ƀ{�^����10x10��100��������
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
        //�ۑ����邽�߂ɂ��ꂪ�K�v
        EditorUtility.SetDirty(manager);

    }

}
