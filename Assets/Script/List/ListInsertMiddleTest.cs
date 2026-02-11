using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics;

public class ListInsertMiddleTest : MonoBehaviour
{
      void Start()
    {
        TestInsertMiddle();
    }
    
    void TestInsertMiddle()
    {
        UnityEngine.Debug.Log("=== 중간 삽입 비교 ===\n");
        
        int[] sizes = { 1000, 10000, 100000, 1000000 };
        
        foreach (int size in sizes)
        {
            TestArrayInsertMiddle(size);
            TestListInsertMiddle(size);
            UnityEngine.Debug.Log("");
        }
    }
    
    void TestArrayInsertMiddle(int size)
    {
        int[] array = new int[size + 1];
        for (int i = 0; i < size; i++)
            array[i] = i;
        
        var sw = Stopwatch.StartNew();
        
        // 중간에 삽입
        int mid = size / 2;
        for (int i = size; i > mid; i--)
        {
            array[i] = array[i - 1];
        }
        array[mid] = 999;
        
        sw.Stop();
        UnityEngine.Debug.Log($"배열[{size}] 중간 삽입: {sw.ElapsedTicks} ticks");
    }
    
    void TestListInsertMiddle(int size)
    {
        List<int> list = new List<int>(size);
        for (int i = 0; i < size; i++)
            list.Add(i);
        
        var sw = Stopwatch.StartNew();
        
        // 중간에 삽입
        list.Insert(size / 2, 999);
        
        sw.Stop();
        UnityEngine.Debug.Log($"List[{size}] 중간 삽입: {sw.ElapsedTicks} ticks");
    }
}
