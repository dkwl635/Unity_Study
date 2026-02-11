using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics;

public class ListInsertDeleteTest : MonoBehaviour
{    
    void Start()
    {
        CompareInsertDelete();
    }
    
    void CompareInsertDelete()
    {
        int size = 100000;
        
        UnityEngine.Debug.Log("=== 중간 삽입 성능 (10만 개 중 중간에 삽입) ===");
        
        // 배열 - 수동 삽입
        int[] array = new int[size + 1];
        for (int i = 0; i < size; i++)
            array[i] = i;
        
        var sw = System.Diagnostics.Stopwatch.StartNew();
        int insertPos = size / 2;
        // 중간 삽입 시뮬레이션
        for (int i = size; i > insertPos; i--)
        {
            array[i] = array[i - 1];
        }
        array[insertPos] = 999;
        sw.Stop();
        UnityEngine.Debug.Log($"배열 중간 삽입 (수동): {sw.ElapsedMilliseconds}ms");
        
        // List - Insert
        List<int> list = new List<int>(size);
        for (int i = 0; i < size; i++)
            list.Add(i);
        
        sw.Restart();
        list.Insert(size / 2, 999);
        sw.Stop();
        UnityEngine.Debug.Log($"List Insert: {sw.ElapsedMilliseconds}ms");
        
        UnityEngine.Debug.Log("\n=== 끝에 추가 성능 ===");
        
        // 배열 - 불가능 (크기 고정)
        UnityEngine.Debug.Log("배열 끝 추가: 불가능 (크기 고정)");
        
        // List - Add
        sw.Restart();
        list.Add(1000);
        sw.Stop();
        UnityEngine.Debug.Log($"List Add: {sw.ElapsedTicks} ms (거의 0ms)");
        
        UnityEngine.Debug.Log("\n=== 삭제 성능 ===");
        
        // 배열 - 수동 삭제
        sw.Restart();
        int deletePos = size / 2;
        for (int i = deletePos; i < size - 1; i++)
        {
            array[i] = array[i + 1];
        }
        sw.Stop();
        UnityEngine.Debug.Log($"배열 중간 삭제 (수동): {sw.ElapsedMilliseconds}ms");
        
        // List - RemoveAt
        sw.Restart();
        list.RemoveAt(size / 2);
        sw.Stop();
        UnityEngine.Debug.Log($"List RemoveAt: {sw.ElapsedMilliseconds}ms");
    }
}
