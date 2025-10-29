using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AlgorithmVisualization
{
    /// <summary>
    /// 冒泡排序算法实现
    /// Bubble Sort Algorithm Implementation
    /// 
    /// 时间复杂度:
    ///   最优: O(n) - 当数组已经有序时
    ///   平均: O(n²)
    ///   最坏: O(n²)
    /// 
    /// 空间复杂度: O(1)
    /// 稳定性: 稳定
    /// </summary>
    public class BubbleSort
    {
        /// <summary>
        /// 冒泡排序 - 基础版本
        /// </summary>
        /// <param name="arr">待排序的数组</param>
        /// <param name="verbose">是否输出详细过程</param>
        public static void Sort(int[] arr, bool verbose = false)
        {
            int n = arr.Length;
            int comparisonCount = 0;
            int swapCount = 0;

            if (verbose)
            {
                Console.WriteLine("".PadRight(60, '='));
                Console.WriteLine("冒泡排序 - 详细过程");
                Console.WriteLine("".PadRight(60, '='));
                Console.WriteLine($"初始数组: [{string.Join(", ", arr)}]");
                Console.WriteLine();
            }

            // 外层循环控制排序轮数
            for (int i = 0; i < n; i++)
            {
                bool swapped = false;

                if (verbose)
                {
                    Console.WriteLine($"第 {i + 1} 轮排序:");
                    Console.WriteLine("".PadRight(60, '-'));
                }

                // 内层循环进行相邻元素比较
                for (int j = 0; j < n - i - 1; j++)
                {
                    comparisonCount++;

                    if (verbose)
                    {
                        Console.Write($"  比较 arr[{j}]={arr[j]} 和 arr[{j + 1}]={arr[j + 1]} ");
                    }

                    // 如果前面的元素大于后面的元素，交换它们
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                        swapCount++;

                        if (verbose)
                        {
                            Console.WriteLine($"→ 交换! 当前数组: [{string.Join(", ", arr)}]");
                        }
                    }
                    else
                    {
                        if (verbose)
                        {
                            Console.WriteLine("→ 无需交换");
                        }
                    }
                }

                if (verbose)
                {
                    Console.WriteLine($"  第 {i + 1} 轮结束，数组状态: [{string.Join(", ", arr)}]");
                    Console.WriteLine();
                }

                // 如果本轮没有发生交换，说明已经有序
                if (!swapped)
                {
                    if (verbose)
                    {
                        Console.WriteLine($"✓ 第 {i + 1} 轮没有发生交换，数组已有序，提前结束");
                        Console.WriteLine();
                    }
                    break;
                }
            }

            if (verbose)
            {
                Console.WriteLine("".PadRight(60, '='));
                Console.WriteLine("排序完成!");
                Console.WriteLine("".PadRight(60, '='));
                Console.WriteLine($"最终数组: [{string.Join(", ", arr)}]");
                Console.WriteLine($"比较次数: {comparisonCount}");
                Console.WriteLine($"交换次数: {swapCount}");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 冒泡排序 - 优化版本
        /// 优化1: 记录最后一次交换的位置，减少比较次数
        /// 优化2: 提前检测数组是否已排序
        /// </summary>
        /// <param name="arr">待排序的数组</param>
        /// <param name="verbose">是否输出详细过程</param>
        public static void SortOptimized(int[] arr, bool verbose = false)
        {
            int n = arr.Length;
            int comparisonCount = 0;
            int swapCount = 0;

            if (verbose)
            {
                Console.WriteLine("".PadRight(60, '='));
                Console.WriteLine("冒泡排序 - 优化版本");
                Console.WriteLine("".PadRight(60, '='));
                Console.WriteLine($"初始数组: [{string.Join(", ", arr)}]");
                Console.WriteLine();
            }

            // 记录最后一次交换的位置
            int lastSwapPos = n - 1;

            while (lastSwapPos > 0)
            {
                int currentSwapPos = 0;

                for (int j = 0; j < lastSwapPos; j++)
                {
                    comparisonCount++;

                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        currentSwapPos = j;
                        swapCount++;
                    }
                }

                lastSwapPos = currentSwapPos;

                if (verbose)
                {
                    Console.WriteLine($"数组状态: [{string.Join(", ", arr)}], 下次比较到位置 {lastSwapPos}");
                }
            }

            if (verbose)
            {
                Console.WriteLine("".PadRight(60, '='));
                Console.WriteLine("排序完成!");
                Console.WriteLine("".PadRight(60, '='));
                Console.WriteLine($"最终数组: [{string.Join(", ", arr)}]");
                Console.WriteLine($"比较次数: {comparisonCount}");
                Console.WriteLine($"交换次数: {swapCount}");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 双向冒泡排序（鸡尾酒排序）
        /// 在两个方向上交替进行冒泡，可以更快地移动元素
        /// </summary>
        /// <param name="arr">待排序的数组</param>
        /// <param name="verbose">是否输出详细过程</param>
        public static void SortBidirectional(int[] arr, bool verbose = false)
        {
            int n = arr.Length;
            int left = 0;
            int right = n - 1;

            if (verbose)
            {
                Console.WriteLine("".PadRight(60, '='));
                Console.WriteLine("双向冒泡排序（鸡尾酒排序）");
                Console.WriteLine("".PadRight(60, '='));
                Console.WriteLine($"初始数组: [{string.Join(", ", arr)}]");
                Console.WriteLine();
            }

            while (left < right)
            {
                // 从左到右冒泡
                for (int i = left; i < right; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                    }
                }
                right--;

                if (verbose)
                {
                    Console.WriteLine($"从左到右: [{string.Join(", ", arr)}]");
                }

                // 从右到左冒泡
                for (int i = right; i > left; i--)
                {
                    if (arr[i] < arr[i - 1])
                    {
                        int temp = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = temp;
                    }
                }
                left++;

                if (verbose)
                {
                    Console.WriteLine($"从右到左: [{string.Join(", ", arr)}]");
                    Console.WriteLine();
                }
            }

            if (verbose)
            {
                Console.WriteLine("".PadRight(60, '='));
                Console.WriteLine("排序完成!");
                Console.WriteLine("".PadRight(60, '='));
                Console.WriteLine($"最终数组: [{string.Join(", ", arr)}]");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 测试所有排序算法
        /// </summary>
        public static void TestSortingAlgorithms()
        {
            Console.WriteLine("\n" + new string('█', 70));
            Console.WriteLine("█" + new string(' ', 68) + "█");
            Console.WriteLine("█" + new string(' ', 20) + "冒泡排序算法测试套件" + new string(' ', 24) + "█");
            Console.WriteLine("█" + new string(' ', 68) + "█");
            Console.WriteLine(new string('█', 70));
            Console.WriteLine();

            // 测试数据集
            var testCases = new List<(string name, int[] data)>
            {
                ("随机数组", new[] { 64, 34, 25, 12, 22, 11, 90 }),
                ("已排序数组", new[] { 11, 12, 22, 25, 34, 64, 90 }),
                ("逆序数组", new[] { 90, 64, 34, 25, 22, 12, 11 }),
                ("包含重复元素", new[] { 5, 2, 8, 2, 9, 1, 5, 5 }),
                ("单个元素", new[] { 42 }),
                ("两个元素", new[] { 2, 1 })
            };

            foreach (var testCase in testCases)
            {
                Console.WriteLine($"\n{new string('=', 70)}");
                Console.WriteLine($"测试用例: {testCase.name}");
                Console.WriteLine(new string('=', 70));

                // 测试基础版本
                int[] data1 = (int[])testCase.data.Clone();
                Console.WriteLine("\n【基础版本】");
                Sort(data1, verbose: true);

                // 测试优化版本
                int[] data2 = (int[])testCase.data.Clone();
                Console.WriteLine("\n【优化版本】");
                SortOptimized(data2, verbose: true);

                // 测试双向版本
                int[] data3 = (int[])testCase.data.Clone();
                Console.WriteLine("\n【双向版本】");
                SortBidirectional(data3, verbose: true);

                // 验证结果
                bool resultsMatch = data1.SequenceEqual(data2) && data2.SequenceEqual(data3);
                if (resultsMatch)
                {
                    Console.WriteLine($"✓ 所有版本结果一致: [{string.Join(", ", data1)}]");
                }
                else
                {
                    Console.WriteLine("✗ 错误: 排序结果不一致!");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 性能对比测试
        /// </summary>
        public static void PerformanceComparison()
        {
            Console.WriteLine("\n" + new string('█', 70));
            Console.WriteLine("█" + new string(' ', 68) + "█");
            Console.WriteLine("█" + new string(' ', 22) + "性能对比测试" + new string(' ', 30) + "█");
            Console.WriteLine("█" + new string(' ', 68) + "█");
            Console.WriteLine(new string('█', 70));
            Console.WriteLine();

            int[] sizes = { 100, 500, 1000 };
            Random random = new Random();

            foreach (int size in sizes)
            {
                Console.WriteLine($"\n{new string('=', 70)}");
                Console.WriteLine($"数组大小: {size} 个元素");
                Console.WriteLine(new string('=', 70));

                // 生成随机数组
                int[] originalData = Enumerable.Range(0, size)
                    .Select(_ => random.Next(1, 1001))
                    .ToArray();

                // 测试基础版本
                int[] data1 = (int[])originalData.Clone();
                Stopwatch sw = Stopwatch.StartNew();
                Sort(data1);
                sw.Stop();
                double time1 = sw.Elapsed.TotalSeconds;

                // 测试优化版本
                int[] data2 = (int[])originalData.Clone();
                sw.Restart();
                SortOptimized(data2);
                sw.Stop();
                double time2 = sw.Elapsed.TotalSeconds;

                // 测试双向版本
                int[] data3 = (int[])originalData.Clone();
                sw.Restart();
                SortBidirectional(data3);
                sw.Stop();
                double time3 = sw.Elapsed.TotalSeconds;

                Console.WriteLine($"基础版本耗时: {time1:F4} 秒");
                Console.WriteLine($"优化版本耗时: {time2:F4} 秒 (提升 {(1 - time2 / time1) * 100:F1}%)");
                Console.WriteLine($"双向版本耗时: {time3:F4} 秒 (提升 {(1 - time3 / time1) * 100:F1}%)");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 主函数
        /// </summary>
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("\n" + new string('█', 70));
            Console.WriteLine("█" + new string(' ', 68) + "█");
            Console.WriteLine("█" + new string(' ', 13) + "冒泡排序算法 - .NET Core C# 实现示例" + new string(' ', 15) + "█");
            Console.WriteLine("█" + new string(' ', 68) + "█");
            Console.WriteLine(new string('█', 70));
            Console.WriteLine();

            // 简单演示
            Console.WriteLine("【简单演示】");
            Console.WriteLine(new string('-', 70));
            int[] data = { 64, 34, 25, 12, 22, 11, 90 };
            Console.WriteLine($"原始数组: [{string.Join(", ", data)}]");
            int[] sortedData = (int[])data.Clone();
            Sort(sortedData);
            Console.WriteLine($"排序后数组: [{string.Join(", ", sortedData)}]");
            Console.WriteLine();

            // 检查命令行参数
            if (args.Length > 0)
            {
                switch (args[0].ToLower())
                {
                    case "--test":
                        TestSortingAlgorithms();
                        break;
                    case "--performance":
                        PerformanceComparison();
                        break;
                    case "--verbose":
                        data = new[] { 64, 34, 25, 12, 22, 11, 90 };
                        Sort(data, verbose: true);
                        break;
                    default:
                        PrintUsage();
                        break;
                }
            }
            else
            {
                PrintUsage();
            }
        }

        /// <summary>
        /// 打印使用说明
        /// </summary>
        private static void PrintUsage()
        {
            Console.WriteLine("使用说明:");
            Console.WriteLine("  dotnet run                    # 简单演示");
            Console.WriteLine("  dotnet run --test             # 运行测试套件");
            Console.WriteLine("  dotnet run --verbose          # 详细输出过程");
            Console.WriteLine("  dotnet run --performance      # 性能对比测试");
            Console.WriteLine();
        }
    }
}
