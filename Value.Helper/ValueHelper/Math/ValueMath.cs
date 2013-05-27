using System;
using System.Linq;
using System.Collections.Generic;
using ValueHelper.Infrastructure;
using ValueHelper.Math.Infrastructure;

namespace ValueHelper.Math
{
    public class ValueMath
    {
        private ValueMath() { }

        private static ValueMath instance;
        public static ValueMath GetInstance()
        {
            if (instance == null)
                instance = new ValueMath();
            return instance;
        }

        #region 合计

        public Int32 Sum(Int32[] list)
        {
            return Sum(list, 0, list.Length);
        }

        public Int32 Sum(Int32[] list, Int32 start, Int32 end)
        {
            var sum = 0;
            for (int i = start; i < end; i++)
            {
                sum += list[i];
            }
            return sum;
        }

        #endregion

        #region 最大值

        /// <summary>
        ///  获得最大值
        /// </summary>
        public float Max(params float[] parameters)
        {
            float max = parameters[0];
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] > max)
                    max = parameters[i];
            }
            return max;
        }

        /// <summary>
        ///  获得最大值
        /// </summary>
        public Double Max(params Double[] parameters)
        {
            Double max = parameters[0];
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] > max)
                    max = parameters[i];
            }
            return max;
        }

        /// <summary>
        ///  获得最大值
        /// </summary>
        public Int32 Max(params Int32[] parameters)
        {
            Int32 max = parameters[0];
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] > max)
                    max = parameters[i];
            }
            return max;
        }

        /// <summary>
        ///  获得最大值索引值
        /// </summary>
        public float MaxIndex(params float[] parameters)
        {
            var max = this.Max(parameters);
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] == max)
                    return i;
            }
            return 0;
        }

        /// <summary>
        ///  获得最大值索引值
        /// </summary>
        public Double MaxIndex(params Double[] parameters)
        {
            var max = this.Max(parameters);
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] == max)
                    return i;
            }
            return 0;
        }

        /// <summary>
        ///  获得最大值索引值
        /// </summary>
        public Int32 MaxIndex(params Int32[] parameters)
        {
            var max = this.Max(parameters);
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] == max)
                    return i;
            }
            return 0;
        }

        #endregion

        #region 最小值

        /// <summary>
        ///  获得最小值
        /// </summary>
        public float Min(params float[] parameters)
        {
            float min = parameters[0];
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] < min)
                    min = parameters[i];
            }
            return min;
        }

        /// <summary>
        ///  获得最小值
        /// </summary>
        public Double Min(params Double[] parameters)
        {
            Double min = parameters[0];
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] < min)
                    min = parameters[i];
            }
            return min;
        }

        /// <summary>
        ///  获得最小值
        /// </summary>
        public Int32 Min(params Int32[] parameters)
        {
            Int32 min = parameters[0];
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] < min)
                    min = parameters[i];
            }
            return min;
        }

        /// <summary>
        ///  获得最小值索引值
        /// </summary>
        public float MinIndex(params float[] parameters)
        {
            var min = this.Min(parameters);
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] == min)
                    return i;
            }
            return 0;
        }

        /// <summary>
        ///  获得最小值索引值
        /// </summary>
        public Double MinIndex(params Double[] parameters)
        {
            var min = this.Min(parameters);
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] == min)
                    return i;
            }
            return 0;
        }

        /// <summary>
        ///  获得最小值索引值
        /// </summary>
        public Int32 MinIndex(params Int32[] parameters)
        {
            var min = this.Min(parameters);
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] == min)
                    return i;
            }
            return 0;
        }

        #endregion

        #region 平均数

        /// <summary>
        ///  获得平均数
        /// </summary>
        public float Average(params float[] parameters)
        {
            Double sum = 0F;
            for (int i = 0; i < parameters.Length; i++)
            {
                sum += parameters[i];
            }

            return (float)(sum / parameters.Length);
        }

        /// <summary>
        ///  获得平均数
        /// </summary>
        public Double Average(params Double[] parameters)
        {
            Double sum = 0D;
            for (int i = 0; i < parameters.Length; i++)
            {
                sum += parameters[i];
            }

            return sum / parameters.Length;
        }

        /// <summary>
        ///  获得平均数
        /// </summary>
        public Int32 Average(params Int32[] parameters)
        {
            Int64 sum = 0;
            for (int i = 0; i < parameters.Length; i++)
            {
                sum += parameters[i];
            }

            return (Int32)(sum / parameters.Length);
        }

        #endregion

        #region 排序

        /// <summary>
        ///  冒泡排序
        /// </summary>
        public void BubbleSort(IList<Int32> list, SortMode mode)
        {
            switch (mode)
            {
                case SortMode.Descending:
                    this.BubbleDescending(list);
                    break;
                case SortMode.Ascending:
                default:
                    this.BubbleAscending(list);
                    break;
            }
        }

        /// <summary>
        ///  搅拌排序
        /// </summary>
        public void ChurningSort(IList<Int32> list, SortMode mode)
        {
            switch (mode)
            {

                case SortMode.Ascending:
                    this.ChurningAscending(list);
                    break;
                case SortMode.Descending:
                default:
                    this.ChurningDescending(list);
                    break;
            }
        }

        /// <summary>
        ///  插入算法
        ///  Φ(n^2)
        /// </summary>
        public void InsertionSort(IList<Int32> list, SortMode mode)
        {
            switch (mode)
            {

                case SortMode.Ascending:
                    this.InsertionAscending(list);
                    break;
                case SortMode.Descending:
                default:
                    this.InsertionDescending(list);
                    break;
            }
        }

        /// <summary>
        ///  归并算法
        ///  Φ(nlgn)
        /// </summary>
        public void MergenSort(IList<Int32> list, SortMode mode)
        {
            switch (mode)
            {
                case SortMode.Ascending:
                    this.MergenAscending(list, 0, list.Count);
                    break;
                case SortMode.Descending:
                default:
                    this.MergenDescending(list, 0, list.Count);
                    break;
            }
        }

        #region 排序升序

        public void BubbleAscending(IList<Int32> list)
        {
            var temp = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }

        public void ChurningAscending(IList<Int32> list)
        {
            var temp = 0;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i; j < list.Count - 1 - i; j++)
                {
                    if (list[j] < list[j + 1])
                    {
                        temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }

                for (int j = list.Count - 2 - i; j >= i; j--)
                {
                    if (list[j] < list[j + 1])
                    {
                        temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }

        public void InsertionAscending(IList<Int32> list)
        {
            var temp = 0;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }

        public void MergenAscending(IList<Int32> list, Int32 start, Int32 end)
        {
            if (start + 1 < end)
            {
                var mid = (start + end) / 2;
                MergenAscending(list, start, mid);
                MergenAscending(list, mid, end);

                var tempList = new Queue<Int32>();
                var iA = start;
                var iB = mid;
                while (iA < mid && iB < end)
                {
                    if (list[iA] > list[iB])
                    {
                        tempList.Enqueue(list[iB]);
                        iB++;
                    }
                    else
                    {
                        tempList.Enqueue(list[iA]);
                        iA++;
                    }
                }

                while (iA < mid)
                {
                    tempList.Enqueue(list[iA]);
                    iA++;
                }

                while (iB < end)
                {
                    tempList.Enqueue(list[iB]);
                    iB++;
                }

                var index = 0;
                while (tempList.Count > 0)
                {
                    list[start + index] = tempList.Dequeue();
                    index++;
                }
            }
        }

        #endregion

        #region 排序降序

        public void BubbleDescending(IList<Int32> list)
        {
            var temp = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (list[j] < list[j + 1])
                    {
                        temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }

        public void ChurningDescending(IList<Int32> list)
        {
            var temp = 0;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i; j < list.Count - 1 - i; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }

                for (int j = list.Count - 2 - i; j >= i; j--)
                {
                    if (list[j] > list[j + 1])
                    {
                        temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }

        public void InsertionDescending(IList<Int32> list)
        {
            var temp = 0;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (list[j] < list[j + 1])
                    {
                        temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }

        public void MergenDescending(IList<Int32> list, Int32 start, Int32 end)
        {
            if (start + 1 < end)
            {
                var mid = (start + end) / 2;
                MergenDescending(list, start, mid);
                MergenDescending(list, mid, end);

                var tempList = new Queue<Int32>();
                var iA = start;
                var iB = mid;
                while (iA < mid && iB < end)
                {
                    if (list[iA] < list[iB])
                    {
                        tempList.Enqueue(list[iB]);
                        iB++;
                    }
                    else
                    {
                        tempList.Enqueue(list[iA]);
                        iA++;
                    }
                }

                while (iA < mid)
                {
                    tempList.Enqueue(list[iA]);
                    iA++;
                }

                while (iB < end)
                {
                    tempList.Enqueue(list[iB]);
                    iB++;
                }

                var index = 0;
                while (tempList.Count > 0)
                {
                    list[start + index] = tempList.Dequeue();
                    index++;
                }
            }
        }

        #endregion

        #endregion

        #region Ostu阈值

        public Int32 OstuThreshold(Int32[] frequency, Int32 radix)
        {
            var length = frequency.Length;
            var probability = new float[length];
            for (int i = 0; i < length; i++)
            {
                probability[i] = (float)frequency[i] / radix;
            }

            var max = 0F;
            var index = 0;
            for (int i = 1; i < length; i++)
            {
                var w0 = 0F;
                for (int t = 0; t < i; t++)
                {
                    w0 += probability[i];
                }
                var A = 0F;
                for (int t = 0; t < i; t++)
                {
                    A += probability[i] * i;
                }
                var uA = A / w0;

                var w1 = 1 - w0;
                var B = 0F;
                for (int t = i; t < length; t++)
                {
                    B += probability[i] * i;
                }
                var uB = B / w1;

                var ft = w0 * (uA - i) * (uA - i) + w1 * (uB - i) * (uB - i);
                if (ft > max)
                {
                    max = ft;
                    index = i;
                }
            }

            return index;
        }

        #endregion

        #region 高斯运算

        public float Gauss(float x, float sigma)
        {
            float value;
            if (sigma == 0) return 0F;
            value = (float)System.Math.Exp((Double)((-x * x) / (2 * sigma * sigma)));
            return value;
        }

        #endregion
    }

}
