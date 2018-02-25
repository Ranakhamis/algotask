using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Algo_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[100];
            Random r = new Random();
            for (int i = 0; i < arr.Length; i++)
                arr[i] = r.Next(0, 10);

            Stopwatch time = Stopwatch.StartNew();
            //quick_sort(arr, 0, arr.Length - 1);
            //selection_sort(arr, arr.Length);
            //merge_sort(arr, 0, arr.Length - 1);
            //insertion_sort(arr, arr.Length);
            time.Stop();

            print_array(arr, arr.Length);

            Console.WriteLine(time.Elapsed.TotalSeconds + " Seconds");
        }

        static void swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr">your array variable name</param>
        /// <param name="size">size of array</param>
        private static void selection_sort(int[] arr, int size)
        {
            int min;
            for (int i = 0; i < size - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < size; j++)
                    if (arr[j] < arr[min])
                        min = j;
                swap(ref arr[min], ref arr[i]);
            }
        }
        static int partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    swap(ref arr[j], ref arr[i]);
                }
            }
            swap(ref arr[high], ref arr[i + 1]);
            return i + 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr">your array variable name</param>
        /// <param name="low">index of first element</param>
        /// <param name="high">index of last element</param>
        private static void quick_sort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pr = partition(arr, low, high);

                quick_sort(arr, low, pr - 1);
                quick_sort(arr, pr + 1, high);
            }
        }

        static public void merge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[100000];
            int eol, num, pos;

            eol = (mid - 1);
            pos = left;
            num = (right - left + 1);

            while ((left <= eol) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[pos++] = numbers[left++];
                else
                    temp[pos++] = numbers[mid++];
            }

            while (left <= eol)
                temp[pos++] = numbers[left++];

            while (mid <= right)
                temp[pos++] = numbers[mid++];

            for (int i = 0; i < num; i++)
            {
                numbers[right] = temp[right];

                right--;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numbers">your array variable name</param>
        /// <param name="left">index of first element</param>
        /// <param name="right">index of last element</param>
        static public void merge_sort(int[] numbers, int left, int right)
        {
            if (left < right)
            {
                int mid = (right + left) / 2;
                merge_sort(numbers, left, mid);
                merge_sort(numbers, (mid + 1), right);

                merge(numbers, left, (mid + 1), right);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputarray">your array variable name</param>
        /// <param name="size">the size of array</param>
        static private void insertion_sort(int[] inputarray, int size)
        {
            for (int i = 0; i < size - 1; i++)
            {
                int j = i + 1;
                while (j > 0)
                {
                    if (inputarray[j - 1] > inputarray[j])
                    {
                        int temp = inputarray[j - 1];
                        inputarray[j - 1] = inputarray[j];
                        inputarray[j] = temp;
                    }
                    j--;
                }
            }
        }

        static private void print_array(int[] arr, int size)
        {
            for (int i = 0; i < size; i++)
            {
                if (i != size - 1)
                    Console.Write(arr[i] + ", ");
            }
            Console.WriteLine();
        }
    }
}
