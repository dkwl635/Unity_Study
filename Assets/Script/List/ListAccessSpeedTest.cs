using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics;

public class ListAccessSpeedTest : MonoBehaviour
{
    void Start()
    {
        CompareAccessSpeed();
    }
    
    void CompareAccessSpeed()
    {
        int size = 10000000;  // 1000만 개
        
        // 데이터 준비
        int[] array = new int[size];
        List<int> list = new List<int>(size);
        
        for (int i = 0; i < size; i++)
        {
            array[i] = i;
            list.Add(i);
        }
        
        UnityEngine.Debug.Log("=== 읽기 성능 비교 (1000만 번) ===");
        
        // 1. 배열 읽기
        Stopwatch sw = Stopwatch.StartNew();
        long sum1 = 0;
        for (int i = 0; i < size; i++)
        {
            sum1 += array[i];
        }
        sw.Stop();
        UnityEngine.Debug.Log($"배열 읽기: {sw.ElapsedMilliseconds}ms ({sw.ElapsedTicks} ticks)");
        
        // 2. List 읽기 (인덱서)
        sw.Restart();
        long sum2 = 0;
        for (int i = 0; i < size; i++)
        {
            sum2 += list[i];
        }
        sw.Stop();
        UnityEngine.Debug.Log($"List 읽기: {sw.ElapsedMilliseconds}ms ({sw.ElapsedTicks} ticks)");
        
        // 3. List Count 프로퍼티 캐싱 비교
        sw.Restart();
        long sum3 = 0;
        int count = list.Count;  // 캐싱
        for (int i = 0; i < count; i++)
        {
            sum3 += list[i];
        }
        sw.Stop();
        UnityEngine.Debug.Log($"List 읽기 (Count 캐싱): {sw.ElapsedMilliseconds}ms ({sw.ElapsedTicks} ticks)");
        
        // 4. foreach 비교
        sw.Restart();
        long sum4 = 0;
        foreach (int item in array)
        {
            sum4 += item;
        }
        sw.Stop();
        UnityEngine.Debug.Log($"배열 foreach: {sw.ElapsedMilliseconds}ms");
        
        sw.Restart();
        long sum5 = 0;
        foreach (int item in list)
        {
            sum5 += item;
        }
        sw.Stop();
        UnityEngine.Debug.Log($"List foreach: {sw.ElapsedMilliseconds}ms");
    }
}
