using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics;

public class ListIndexAccessTest : MonoBehaviour
{
void Start()
    {
        TestArrayIndexAccess();
        TestListIndexAccess();
    }
    
    void TestArrayIndexAccess()
    {
        UnityEngine.Debug.Log("=== 배열 인덱스 접근 ===");
        
        int[] array = new int[10000000];  // 1000만 개
        for (int i = 0; i < array.Length; i++)
            array[i] = i;
        
        Stopwatch sw = Stopwatch.StartNew();
        
        // 앞쪽 접근
        int sum1 = 0;
        for (int i = 0; i < 1000000; i++)
            sum1 += array[i];  // 인덱스 0~99만
        
        sw.Stop();
        long time1 = sw.ElapsedTicks;
        
        // 뒤쪽 접근
        sw.Restart();
        int sum2 = 0;
        for (int i = 9000000; i < 10000000; i++)
            sum2 += array[i];  // 인덱스 900만~999만
        
        sw.Stop();
        long time2 = sw.ElapsedTicks;
        
        UnityEngine.Debug.Log($"앞쪽 100만 개 접근: {time1} ticks");
        UnityEngine.Debug.Log($"뒤쪽 100만 개 접근: {time2} ticks");
        UnityEngine.Debug.Log($"차이: {Mathf.Abs(time2 - time1)} ticks (거의 동일!)");
    }
    
    void TestListIndexAccess()
    {
        UnityEngine.Debug.Log("\n=== List 인덱스 접근 ===");
        
        List<int> list = new List<int>(10000000);
        for (int i = 0; i < 10000000; i++)
            list.Add(i);
        
        Stopwatch sw = Stopwatch.StartNew();
        
        // 앞쪽 접근
        int sum1 = 0;
        for (int i = 0; i < 1000000; i++)
            sum1 += list[i];
        
        sw.Stop();
        long time1 = sw.ElapsedTicks;
        
        // 뒤쪽 접근
        sw.Restart();
        int sum2 = 0;
        for (int i = 9000000; i < 10000000; i++)
            sum2 += list[i];
        
        sw.Stop();
        long time2 = sw.ElapsedTicks;
        
        UnityEngine.Debug.Log($"앞쪽 100만 개 접근: {time1} ticks");
        UnityEngine.Debug.Log($"뒤쪽 100만 개 접근: {time2} ticks");
        UnityEngine.Debug.Log($"차이: {Mathf.Abs(time2 - time1)} ticks (거의 동일!)");
    }


}
