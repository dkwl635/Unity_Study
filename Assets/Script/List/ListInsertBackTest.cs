using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics;

public class ListInsertBackTest : MonoBehaviour
{
 void Start()
    {
        TestInsertBack();
    }
    
    void TestInsertBack()
    {
        UnityEngine.Debug.Log("=== 맨 뒤 삽입 비교 ===\n");
        
        // List - 용량 충분 (O(1))
        List<int> list1 = new List<int>(1000000);  // 미리 용량 확보
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < 1000000; i++)
        {
            list1.Add(i);  // 재할당 없음
        }
        sw.Stop();
        UnityEngine.Debug.Log($"List 맨 뒤 추가 (용량 충분): {sw.ElapsedMilliseconds}ms");
        
        // List - 용량 부족 (O(1) 평균, 가끔 O(n))
        sw.Restart();
        List<int> list2 = new List<int>();  // 용량 미지정
        for (int i = 0; i < 1000000; i++)
        {
            list2.Add(i);  // 가끔 재할당 발생
        }
        sw.Stop();
        UnityEngine.Debug.Log($"List 맨 뒤 추가 (용량 미지정): {sw.ElapsedMilliseconds}ms");
        UnityEngine.Debug.Log($"  → 재할당 발생으로 약 {sw.ElapsedMilliseconds}ms 느림");
        
        // 배열 - 맨 뒤 추가 불가능
        UnityEngine.Debug.Log("\n배열 맨 뒤 추가: 불가능 (크기 고정)");
        UnityEngine.Debug.Log("  → 새 배열 생성 + 복사 필요 = O(n)");
    }
}
