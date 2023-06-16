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

        #region Selection Sort
        //선택정렬
        //처음부터 끝까지 순회하면서 현재 값보다 작은 값을 가진 인덱스를 찾아 스왑
        //한번 Outer 돌 때마다 가장 작은 인덱스가 고정됨
        //O(N^2)
        //밖 - n번 돌음, 안 - n/2번 돌음
        //기본적으로는 unstable
        public static void SelectionSort(int[] arr)
        {
            int minIdx = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                minIdx = i;
                // i 뒤의 가장 작은 값을 가진 인덱스 찾기
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIdx])
                    {
                        minIdx = j;
                    }
                }

                // i 뒤에 더 작은값의 인덱스를 찾았으면 스왑
                if (i != minIdx)
                    Swap(ref arr[i], ref arr[minIdx]);
            }
        }
        #endregion

        #region Insertion Sort
        //삽입정렬
        //현재 위치보다 이전위치들중에서 더 큰값이 있으면 더 큰 값으로 현재 위치에 덮어쓰고
        //덮어쓰기가 끝나면 마지막으로 덮어쓸 때 참조했던 위치에 현재 위치 값을 덮어씀
        //현재 탐색 위치 이전까지의 모든 인덱스가 정렬된 상태를 유지하면서 정렬 진행
        //Stable
        //O(N^2)
        public static void InsertionSort(int[] arr)
        {
            int j, key; //현재 탐색 중인 숫자 넣을 변수 key

            for (int i = 1; i < arr.Length; i++)
            {
                key = arr[i];
                j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }
        #endregion

        #region Merge Sort
        // 병합정렬
        // O(NLogN) 최선 평균 최악 모두 시간복잡도 같음
        // 공간복잡도 O(N) merge할 때마다 배열 새로 만들어야돼서 연산할 때 추가적인 공간 필요함, 공간 많이 잡아먹음
        // Stable
        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }

        public static void MergeSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int mid = end + (start - end) / 2 - 1;  // == end/2 + start/2 == (start+end)/2  int끼리의 덧셈에서 오버플로우 방지용
                MergeSort(arr, start, mid);
                MergeSort(arr, mid + 1, end); //mid+1하니까 오버플로우 안뜸 

                Merge(arr, start, mid, end);
            }
           
        }

        private static void Merge(int[] arr, int start, int mid, int end)
        {
            int[] origin = new int[end + 1];
            for (int i = 0; i < end + 1; i++)
            {
                origin[i] = arr[i];
            }

            int part1 = start;
            int part2 = mid + 1;
            int tmp = start;

            while (part1 <= mid && part2 <= end)
            {
                if (origin[part1] <= origin[part2])
                {
                    arr[tmp++] = origin[part1++];
                    //part1++;
                    //tmp++;
                }
                else
                {
                    arr[tmp++] = origin[part2++];
                }
            }

            //남은 part1 들을 tmp 위치에 쭉 이어서 덮어쓴다

            for (int i = 0; i < mid - part1; i++)
            {
                arr[tmp + i] = origin[part1 + i];
            }
        }
        #endregion

        #region Quick Sort
        //빠른 정렬
        //Ω(NLogN)
        //θ(NLogN)
        //O(N^2) 최악, 근데 merge sort보다 빠르고 추가적인 공간 필요없음
        //unstable
        public static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }

        public static void QuickSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition(arr, start, end);
                QuickSort(arr, start, pivot - 1); //pivot값은 pivot으로 정해진순간 고정됨 -> 배열 나눌 때 pivot 빼고 나눔
                QuickSort(arr, pivot + 1, end);
            }
        }

        private static int Partition(int[] arr, int start, int end)
        {
            int standard = arr[end + (start - end) / 2];  // == mid의 값

            while (true)
            {
                while (arr[start] < standard) start++;
                while (arr[end] > standard) end--;

                if (start < end)
                    Swap(ref arr[start], ref arr[end]);
                else
                    return end;
            }
        }
        #endregion

        #region Heap Sort
        //힙 정렬
        //Heap 자료구조로 변환하여 정렬하는 방법
        //한번 SIFT 연산할 때마다 Min 혹은 Max 값이 하나씩 고정됨
        //트리 형태 구조 특성상 O(NLogN)의 시간복잡도를 가짐

        public static void HeapSort(int[] arr)
        {
            // Max Heap 구조로 변환
            //HeapifyBottomUp(arr);
            HeapifyTopDown(arr);

            InverseHeapify(arr);
        }

        //힙정렬된거를 오름차순으로 
        public static void InverseHeapify(int[] arr)
        {
            int end = arr.Length - 1;
            while (end > 0)
            {
                Swap(ref arr[0], ref arr[end]);
                end--;
                SIFT_Down(arr, end, 1);   //루트 다음꺼부터 넣어야 갱신됨
            }
        }

        //O(N)
        public static void HeapifyBottomUp(int[] arr)
        {
            int end = arr.Length - 1;
            int current = end;

            while (current >= 0)
            {
                SIFT_Down(arr, end, current--);
            }
        }

        //O(NLogN)
        public static void HeapifyTopDown(int[] arr)
        {
            int end = 1;
            while (end < arr.Length)
            {
                SIFT_Up(arr, 0, end++);
            }
        }

        //제일 마지막에 있는 노드를 가능할 때까지 위로 올림
        public static void SIFT_Up(int[] arr, int root, int current)  //root, current, parent는 인덱스
        {
            int parent = (current - 1) / 2;
            while (current > root)
            {
                if (arr[current] > arr[parent])
                {
                    Swap(ref arr[current], ref arr[parent]);
                    current = parent;  //기존 parent자리로 갔으니까 기존 parent의 인덱스로 갱신
                    parent = (current - 1) / 2;  //자리바꾸고 새로운 parent의 인덱스
                }
                else
                {
                    return;
                }
            }
        }

        //노드를 밑으로 내림
        public static void SIFT_Down(int[] arr, int end, int current)
        {
            int parent = (current - 1) / 2;
            while (current <= end)
            {
                //오른쪽 자식이 더 크면 오른쪽을 스왑
                if(current + 1 <= end && arr[current] < arr[current + 1])
                {
                    current++;
                }

                //비교해서 바꾸는 로직
                if (arr[current] > arr[parent])
                {
                    Swap(ref arr[current], ref arr[parent]);
                    parent = current;
                    current = parent * 2 + 1; //왼쪽 자식으로 감
                }
                else
                {
                    return;
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
