using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics; 

public class ListWriteSpeedTest : MonoBehaviour
{
    void Start()
    {
        CompareWriteSpeed();
    }
    
    void CompareWriteSpeed()
    {
        int size = 10000000;
        
        UnityEngine.Debug.Log("=== 쓰기 성능 비교 (1000만 번) ===");
        
        // 1. 배열 쓰기
        int[] array = new int[size];
        var sw = System.Diagnostics.Stopwatch.StartNew();
        for (int i = 0; i < size; i++)
        {
            array[i] = i * 2;
        }
        sw.Stop();
        UnityEngine.Debug.Log($"배열 쓰기: {sw.ElapsedMilliseconds}ms");
        
        // 2. List 쓰기 (인덱서)
        List<int> list = new List<int>(size);
        for (int i = 0; i < size; i++)
            list.Add(0);  // 미리 채우기
        
        sw.Restart();
        for (int i = 0; i < size; i++)
        {
            list[i] = i * 2;
        }
        sw.Stop();
        UnityEngine.Debug.Log($"List 쓰기 (인덱서): {sw.ElapsedMilliseconds}ms");
        
        // 3. List Add (용량 미리 지정)
        sw.Restart();
        List<int> list2 = new List<int>(size);
        for (int i = 0; i < size; i++)
        {
            list2.Add(i * 2);
        }
        sw.Stop();
        UnityEngine.Debug.Log($"List Add (용량 지정): {sw.ElapsedMilliseconds}ms");
        
        // 4. List Add (용량 미지정)
        sw.Restart();
        List<int> list3 = new List<int>();
        for (int i = 0; i < size; i++)
        {
            list3.Add(i * 2);
        }
        sw.Stop();
        UnityEngine.Debug.Log($"List Add (용량 미지정): {sw.ElapsedMilliseconds}ms");
    }
}
