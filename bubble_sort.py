#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
冒泡排序算法实现
Bubble Sort Algorithm Implementation

这是一个完整的冒泡排序实现，包含优化版本和可视化输出
"""


def bubble_sort(arr, verbose=False):
    """
    冒泡排序算法 - 基础版本
    
    参数:
        arr: 待排序的列表
        verbose: 是否输出详细过程
    
    返回:
        排序后的列表
    
    时间复杂度:
        最优: O(n) - 当数组已经有序时
        平均: O(n²)
        最坏: O(n²)
    
    空间复杂度: O(1)
    稳定性: 稳定
    """
    n = len(arr)
    comparison_count = 0
    swap_count = 0
    
    if verbose:
        print("=" * 60)
        print("冒泡排序 - 详细过程")
        print("=" * 60)
        print(f"初始数组: {arr}")
        print()
    
    # 外层循环控制排序轮数
    for i in range(n):
        swapped = False
        
        if verbose:
            print(f"第 {i + 1} 轮排序:")
            print("-" * 60)
        
        # 内层循环进行相邻元素比较
        for j in range(0, n - i - 1):
            comparison_count += 1
            
            if verbose:
                print(f"  比较 arr[{j}]={arr[j]} 和 arr[{j+1}]={arr[j+1]}", end=" ")
            
            # 如果前面的元素大于后面的元素，交换它们
            if arr[j] > arr[j + 1]:
                arr[j], arr[j + 1] = arr[j + 1], arr[j]
                swapped = True
                swap_count += 1
                
                if verbose:
                    print(f"→ 交换! 当前数组: {arr}")
            else:
                if verbose:
                    print("→ 无需交换")
        
        if verbose:
            print(f"  第 {i + 1} 轮结束，数组状态: {arr}")
            print()
        
        # 如果本轮没有发生交换，说明已经有序
        if not swapped:
            if verbose:
                print(f"✓ 第 {i + 1} 轮没有发生交换，数组已有序，提前结束")
                print()
            break
    
    if verbose:
        print("=" * 60)
        print("排序完成!")
        print("=" * 60)
        print(f"最终数组: {arr}")
        print(f"比较次数: {comparison_count}")
        print(f"交换次数: {swap_count}")
        print()
    
    return arr


def bubble_sort_optimized(arr, verbose=False):
    """
    冒泡排序算法 - 优化版本
    优化1: 记录最后一次交换的位置，减少比较次数
    优化2: 提前检测数组是否已排序
    
    参数:
        arr: 待排序的列表
        verbose: 是否输出详细过程
    
    返回:
        排序后的列表
    """
    n = len(arr)
    comparison_count = 0
    swap_count = 0
    
    if verbose:
        print("=" * 60)
        print("冒泡排序 - 优化版本")
        print("=" * 60)
        print(f"初始数组: {arr}")
        print()
    
    # 记录最后一次交换的位置
    last_swap_pos = n - 1
    
    while last_swap_pos > 0:
        current_swap_pos = 0
        
        for j in range(0, last_swap_pos):
            comparison_count += 1
            
            if arr[j] > arr[j + 1]:
                arr[j], arr[j + 1] = arr[j + 1], arr[j]
                current_swap_pos = j
                swap_count += 1
        
        last_swap_pos = current_swap_pos
        
        if verbose:
            print(f"数组状态: {arr}, 下次比较到位置 {last_swap_pos}")
    
    if verbose:
        print("=" * 60)
        print("排序完成!")
        print("=" * 60)
        print(f"最终数组: {arr}")
        print(f"比较次数: {comparison_count}")
        print(f"交换次数: {swap_count}")
        print()
    
    return arr


def bubble_sort_bidirectional(arr, verbose=False):
    """
    双向冒泡排序（鸡尾酒排序）
    在两个方向上交替进行冒泡，可以更快地移动元素
    
    参数:
        arr: 待排序的列表
        verbose: 是否输出详细过程
    
    返回:
        排序后的列表
    """
    n = len(arr)
    left = 0
    right = n - 1
    
    if verbose:
        print("=" * 60)
        print("双向冒泡排序（鸡尾酒排序）")
        print("=" * 60)
        print(f"初始数组: {arr}")
        print()
    
    while left < right:
        # 从左到右冒泡
        for i in range(left, right):
            if arr[i] > arr[i + 1]:
                arr[i], arr[i + 1] = arr[i + 1], arr[i]
        right -= 1
        
        if verbose:
            print(f"从左到右: {arr}")
        
        # 从右到左冒泡
        for i in range(right, left, -1):
            if arr[i] < arr[i - 1]:
                arr[i], arr[i - 1] = arr[i - 1], arr[i]
        left += 1
        
        if verbose:
            print(f"从右到左: {arr}")
            print()
    
    if verbose:
        print("=" * 60)
        print("排序完成!")
        print("=" * 60)
        print(f"最终数组: {arr}")
        print()
    
    return arr


def test_sorting_algorithms():
    """
    测试所有排序算法
    """
    print("\n" + "█" * 70)
    print("█" + " " * 68 + "█")
    print("█" + " " * 20 + "冒泡排序算法测试套件" + " " * 24 + "█")
    print("█" + " " * 68 + "█")
    print("█" * 70)
    print()
    
    # 测试数据集
    test_cases = [
        {
            'name': '随机数组',
            'data': [64, 34, 25, 12, 22, 11, 90],
        },
        {
            'name': '已排序数组',
            'data': [11, 12, 22, 25, 34, 64, 90],
        },
        {
            'name': '逆序数组',
            'data': [90, 64, 34, 25, 22, 12, 11],
        },
        {
            'name': '包含重复元素',
            'data': [5, 2, 8, 2, 9, 1, 5, 5],
        },
        {
            'name': '单个元素',
            'data': [42],
        },
        {
            'name': '两个元素',
            'data': [2, 1],
        }
    ]
    
    for test_case in test_cases:
        print(f"\n{'=' * 70}")
        print(f"测试用例: {test_case['name']}")
        print(f"{'=' * 70}")
        
        # 测试基础版本
        data1 = test_case['data'].copy()
        print(f"\n【基础版本】")
        result1 = bubble_sort(data1, verbose=True)
        
        # 测试优化版本
        data2 = test_case['data'].copy()
        print(f"\n【优化版本】")
        result2 = bubble_sort_optimized(data2, verbose=True)
        
        # 测试双向版本
        data3 = test_case['data'].copy()
        print(f"\n【双向版本】")
        result3 = bubble_sort_bidirectional(data3, verbose=True)
        
        # 验证结果
        assert result1 == result2 == result3, "排序结果不一致!"
        print(f"✓ 所有版本结果一致: {result1}")
        print()


def performance_comparison():
    """
    性能对比测试
    """
    import time
    import random
    
    print("\n" + "█" * 70)
    print("█" + " " * 68 + "█")
    print("█" + " " * 22 + "性能对比测试" + " " * 30 + "█")
    print("█" + " " * 68 + "█")
    print("█" * 70)
    print()
    
    sizes = [100, 500, 1000]
    
    for size in sizes:
        print(f"\n{'=' * 70}")
        print(f"数组大小: {size} 个元素")
        print(f"{'=' * 70}")
        
        # 生成随机数组
        original_data = [random.randint(1, 1000) for _ in range(size)]
        
        # 测试基础版本
        data1 = original_data.copy()
        start = time.time()
        bubble_sort(data1)
        time1 = time.time() - start
        
        # 测试优化版本
        data2 = original_data.copy()
        start = time.time()
        bubble_sort_optimized(data2)
        time2 = time.time() - start
        
        # 测试双向版本
        data3 = original_data.copy()
        start = time.time()
        bubble_sort_bidirectional(data3)
        time3 = time.time() - start
        
        print(f"基础版本耗时: {time1:.4f} 秒")
        print(f"优化版本耗时: {time2:.4f} 秒 (提升 {(1 - time2/time1) * 100:.1f}%)")
        print(f"双向版本耗时: {time3:.4f} 秒 (提升 {(1 - time3/time1) * 100:.1f}%)")
        print()


def main():
    """
    主函数
    """
    import sys
    
    print("\n" + "█" * 70)
    print("█" + " " * 68 + "█")
    print("█" + " " * 15 + "冒泡排序算法 - Python实现示例" + " " * 19 + "█")
    print("█" + " " * 68 + "█")
    print("█" * 70)
    print()
    
    # 简单演示
    print("【简单演示】")
    print("-" * 70)
    data = [64, 34, 25, 12, 22, 11, 90]
    print(f"原始数组: {data}")
    sorted_data = bubble_sort(data.copy())
    print(f"排序后数组: {sorted_data}")
    print()
    
    # 检查命令行参数
    if len(sys.argv) > 1:
        if sys.argv[1] == '--test':
            test_sorting_algorithms()
        elif sys.argv[1] == '--performance':
            performance_comparison()
        elif sys.argv[1] == '--verbose':
            data = [64, 34, 25, 12, 22, 11, 90]
            bubble_sort(data, verbose=True)
    else:
        print("使用说明:")
        print("  python bubble_sort.py              # 简单演示")
        print("  python bubble_sort.py --test       # 运行测试套件")
        print("  python bubble_sort.py --verbose    # 详细输出过程")
        print("  python bubble_sort.py --performance # 性能对比测试")
        print()


if __name__ == "__main__":
    main()
