namespace Array
{
    #region 34. 在排序数组中查找元素的第一个和最后一个位置
    /*
     * 给你一个按照非递减顺序排列的整数数组 nums，和一个目标值 target。请你找出给定目标值在数组中的开始位置和结束位置。
        如果数组中不存在目标值 target，返回 [-1, -1]。
        你必须设计并实现时间复杂度为 O(log n) 的算法解决此问题。

        示例 1：
        输入：nums = [5,7,7,8,8,10], target = 8
        输出：[3,4]

        示例 2：
        输入：nums = [5,7,7,8,8,10], target = 6
        输出：[-1,-1]

        示例 3：
        输入：nums = [], target = 0
        输出：[-1,-1]

        提示：
        0 <= nums.length <= 105
        -109 <= nums[i] <= 109
        nums 是一个非递减数组
        -109 <= target <= 109
     */
    #endregion
    internal class find_first_and_last_position_of_element_in_sorted_array
    {
        /*
         * 情况一：target 在数组范围的右边或者左边，例如数组{3, 4, 5}，target为2或者数组{3, 4, 5},target为6，此时应该返回{-1, -1}
            情况二：target 在数组范围中，且数组中不存在target，例如数组{3,6,7},target为5，此时应该返回{-1, -1}
            情况三：target 在数组范围中，且数组中存在target，例如数组{3,6,7},target为6，此时应该返回{1, 1}
         */
        public static int[] SearchRange(int[] nums, int target)
        {
            int leftBorder = GetLeftBorder(nums, target);
            int rightBorder = GetRightBorder(nums, target);

            if (leftBorder == -2 || rightBorder == -2)
            {
                return [-1, -1];
            }
            if (rightBorder - leftBorder > 1)
            {
                return [leftBorder + 1, rightBorder - 1];
            }

            return [-1, -1];
        }
        /// <summary>
        /// 获取左边界
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        static int GetLeftBorder(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            int leftBorder = -2;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] >= target)
                { 
                    right = mid - 1;
                    leftBorder = right;
                }
                else
                {
                    left = mid + 1;
                    leftBorder = right;
                }
            }
            return leftBorder;
        }

        /// <summary>
        /// 获取右边界 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        static int GetRightBorder(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            int rightBorder = -2;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                    rightBorder = right;
                }
            }
            return rightBorder;
        }

        /// <summary>
        /// 34. 在排序数组中查找元素的第一个和最后一个位置
        /// </summary>
        public static void TestCase()
        {
            int[] nums = [5, 7, 7, 8, 8, 10];
            int target = 8;
            Console.WriteLine(string.Join(",", SearchRange(nums, target)));

            int target2 = 6;
            Console.WriteLine(string.Join(",", SearchRange(nums, target2)));

            int[] nums3 = [];
            int target3 = 0;
            Console.WriteLine(string.Join(",", SearchRange(nums3, target3)));
        }
    }
}
