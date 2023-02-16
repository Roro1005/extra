using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TextureCreator
{
  [MenuItem("test/テクスチャ生成")]
  public static void MakeTexture()
    {
        Texture2D texture = new Texture2D(8192, 8192);
        Color[] colors = texture.GetPixels();

        //colorsの値を変更する
        /*for (int i=0;i<colors.Length;i++)
        {
            colors[i] = new Color(0f, 1f, 0f, 1f);
        }*/

        //シングルスレッド
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        for(int iy=0; iy<8192 ;iy++)
        {
            float y = (float)iy / 8192f;
            for(int ix=0;ix<8192;ix++)
            {
                float x = (float)ix / 8192;
                int index = iy * 8192 + ix;

                colors[index] = new Color(x, y, 0f, 1f);
            }
        }

        sw.Stop();
        Debug.Log("シングルスレッド:"+sw.Elapsed);

        //マルチスレッド
        System.Threading.Tasks.Parallel.For(0, 8192, iy =>
          {
              float y = (float)iy / 8192f;
                  for (int ix = 0; ix < 8192; ix++)
                  {
                      float x = (float)ix / 8192;
                      int index = iy * 8192 + ix;

                      colors[index] = new Color(x, y, 0f, 1f);
                  }
          });

        sw.Stop();
        Debug.Log("マルチスレッド:" + sw.Elapsed);

        //png出力
        texture.SetPixels(colors);
        texture.Apply();
        byte[] png= texture.EncodeToPNG();
        System.IO.File.WriteAllBytes("Assets/out.png", png);
        AssetDatabase.Refresh();
        Debug.Log("出力完了");
    }
}
