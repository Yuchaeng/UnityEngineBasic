//namespace SortAlgorithm
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {

//        }
//    }
//}
using System.Linq;
using SortAlgorithm;
using System.Diagnostics;

int[] arr = { 1, 4, 3, 3, 9, 8, 7, 2, 5, 0 };
Random random = new Random();
//arr = Enumerable.Repeat(0,100000).Select(i => random.Next(0,100000)).ToArray();

Stopwatch stopWatch = Stopwatch.StartNew();

//SortAlgorithm.SortAlgorithms.BubbleSort(arr); //10만개 31818ms
//SortAlgorithm.SortAlgorithms.SelectionSort(arr); //10만개 7467ms
//SortAlgorithm.SortAlgorithms.InsertionSort(arr);  //10만개 4750ms
//SortAlgorithm.SortAlgorithms.MergeSort(arr);  //10만개 12000ms 재귀함수라서 함수 호출 시 오버헤드비용 발생
SortAlgorithm.SortAlgorithms.QuickSort(arr);

stopWatch.Stop();

//for (int i = 0; i < arr.Length; i++)
//{
//    Console.Write($"{arr[i]}, ");
//}
Console.WriteLine();
Console.WriteLine(stopWatch.ElapsedMilliseconds);