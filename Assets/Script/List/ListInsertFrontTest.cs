using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics;   

public class ListInsertFrontTest : MonoBehaviour
{
     void Start()
    {
        TestInsertFront();
    }
    
    void TestInsertFront()
    {
        UnityEngine.Debug.Log("=== 맨 앞 삽입 비교 ===\n");
        
        // 다양한 크기로 테스트
        int[] sizes = { 1000, 10000, 100000, 1000000 };
        
        foreach (int size in sizes)
        {
            TestArrayInsertFront(size);
            TestListInsertFront(size);
            UnityEngine.Debug.Log("");
        }
    }
    
    void TestArrayInsertFront(int size)
    {
        // 배열 준비 (여분 공간 포함)
        int[] array = new int[size + 1];
        for (int i = 0; i < size; i++)
            array[i] = i;
        
        var sw = Stopwatch.StartNew();
        
        // 맨 앞에 삽입 (모든 요소 이동)
        for (int i = size; i > 0; i--)
        {
            array[i] = array[i - 1];
        }
        array[0] = 999;
        
        sw.Stop();
        UnityEngine.Debug.Log($"배열[{size}] 맨 앞 삽입: {sw.ElapsedTicks} ticks");
    }
    
    void TestListInsertFront(int size)
    {
        // List 준비
        List<int> list = new List<int>(size);
        for (int i = 0; i < size; i++)
            list.Add(i);
        
        var sw = Stopwatch.StartNew();
        
        // 맨 앞에 삽입
        list.Insert(0, 999);
        
        sw.Stop();
        UnityEngine.Debug.Log($"List[{size}] 맨 앞 삽입: {sw.ElapsedTicks} ticks");
    }
}
