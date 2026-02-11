using UnityEngine;
using System.Collections.Generic;

public class ListMemoryComparison : MonoBehaviour
{
     void Start()
    {
        CompareMemory();
    }
    
    void CompareMemory()
    {
        int count = 1000;
        
        // 배열
        long arrayMemory = count * sizeof(int);  // 4000 바이트
        Debug.Log($"배열 메모리: {arrayMemory} 바이트 ({arrayMemory / 1024f:F2} KB)");
        
        // List (최악의 경우 - 용량이 2배일 때)
        int listCapacity = GetNextPowerOfTwo(count);  // 1024
        long listMemory = 16 + (listCapacity * sizeof(int));  // 16 + 4096 = 4112 바이트
        Debug.Log($"List 메모리: {listMemory} 바이트 ({listMemory / 1024f:F2} KB)");
        Debug.Log($"추가 메모리: {listMemory - arrayMemory} 바이트");
        
        // 실제 측정
        MeasureActualMemory();
    }
    
    void MeasureActualMemory()
    {
        Debug.Log("\n=== 실제 메모리 측정 ===");
        
        // GC 실행하여 정확한 측정
        System.GC.Collect();
        System.GC.WaitForPendingFinalizers();
        System.GC.Collect();
        
        long before = System.GC.GetTotalMemory(false);
        
        // 배열 생성
        int[] array = new int[1000];
        for (int i = 0; i < 1000; i++)
            array[i] = i;
        
        long afterArray = System.GC.GetTotalMemory(false);
        Debug.Log($"배열: {afterArray - before} 바이트");
        
        // List 생성
        List<int> list = new List<int>();
        for (int i = 0; i < 1000; i++)
            list.Add(i);
        
        long afterList = System.GC.GetTotalMemory(false);
        Debug.Log($"List: {afterList - afterArray} 바이트");
        Debug.Log($"차이: {(afterList - afterArray) - (afterArray - before)} 바이트");
    }
    
    int GetNextPowerOfTwo(int n)
    {
        int power = 4;  // List 기본 용량
        while (power < n)
            power *= 2;
        return power;
    }
}
