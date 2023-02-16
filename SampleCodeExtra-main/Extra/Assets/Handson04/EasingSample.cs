using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EasingSample
{

    public static IEnumerator Move(float time, Vector3 move, Transform target)
    {
        //最初の位置
        Vector3 initialPosition = target.position;

        float elapsedTime = 0f;
        while(elapsedTime < time)
        {
            //ここに移動処理を書く
            float t = elapsedTime / time;
            target.position = initialPosition + move * t;

            yield return null;
            elapsedTime += Time.deltaTime;
        }

        target.position = initialPosition + move;
    }
}
