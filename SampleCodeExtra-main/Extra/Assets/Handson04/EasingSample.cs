using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public static class EasingSample
{
    public static void MoveRx(float time,Vector3 move,Transform target,
         Func<float, float> easing)
    {
        MainThreadDispatcher.StartUpdateMicroCoroutine(Move(time, move, target,
             easing));
    }

    public static IEnumerator Move(float time, Vector3 move, Transform target,
        Func<float,float> easing)
    {
        //最初の位置
        Vector3 initialPosition = target.position;

        float elapsedTime = 0f;
        while(elapsedTime < time)
        {
            //ここに移動処理を書く
            float t = elapsedTime / time;

            //イージング
            //float x = t;//Linear
            //float x = 1 - (1 - t) * (1 - t);//EaseOutQuad
            //float x = t * t;//EaseInQuad

            //EaseOutBack
            //float c1 = 1.70158f;
            //float c3 = c1 + 1f;
            //float x = 1 + c3 * Mathf.Pow(t - 1, 3) + c1 * Mathf.Pow(t - 1, 2);

            float n1 = 7.5625f;
            float d1 = 2.75f;
            float x;

            if (t < 1 / d1)
            {
                 x= n1 * t * t;
            }
            else if (t < 2 / d1)
            {
                 x= n1 * (t -= 1.5f / d1) * t + 0.75f;
            }
            else if (t < 2.5 / d1)
            {
                 x = n1 * (t -= 2.25f / d1) * t + 0.9375f;
            }
            else
            {
                 x = n1 * (t -= 2.625f / d1) * t + 0.984375f;
            }


            target.position = initialPosition + move * x;

            yield return null;
            elapsedTime += Time.deltaTime;
        }

        target.position = initialPosition + move;
    }
    public static readonly Func<float, float> EaseLinear = t => t;
    public static readonly Func<float, float> EaseInQuad = t => t * t;
    public static readonly Func<float, float> EaseOutQuad = t => 1 - (1 - t) * (1 - t);
    public static readonly Func<float, float> EaseInOutQuad = t =>
    {
        if (t < 0.5f)
            return 2 * t * t;
        else
            return 1 - Mathf.Pow(-2 * t + 2, 2) / 2;
    };
    
}
