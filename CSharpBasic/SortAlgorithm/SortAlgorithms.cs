using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithm
{
    internal class SortAlgorithms
    {

        #region Bubble Sort
        //거품 정렬
        //처음부터 끝까지 순회하면서 바로 뒤의 요소가 현재 요소보다 작으면 스왑
        //위 과정을 n번(n-1번) 수행
        //한번 전체 스왑을 할 때마다 가장 마지막 자리가 고정
        //Stable : 정렬 후에 정렬전의 순서가 보장됨, 같은 숫자끼리는 안바꾼듯
        //O(n^2)
        public static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length-1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }

        }
        #endregion

        //그냥 int a, int b로 하면 값복사돼서 배열에선 안바뀜
        //배열의 값을 바꾸려면 배열의 요소의 주소를 참조해야함

        //ref 키워드
        //인자를 참조형태로 받을 때 사용
        private static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;

        }

    }
}
