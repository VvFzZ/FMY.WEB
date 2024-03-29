﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMY.Core.RedisClient
{
    public class RedisZSet : RedisBase
    {
        #region 添加

        /// <summary>
        /// 添加key/value，默认分数是从1.多*10的9次方以此递增的,自带自增效果
        /// </summary>
        public static bool AddItemToSortedSet(string key, string value)
        {
            return RedisBase.Core.AddItemToSortedSet(key, value);
        }

        /// <summary>
        /// 添加key/value,并设置value的分数
        /// </summary>
        public static bool AddItemToSortedSet(string key, string value, double score)
        {
            return RedisBase.Core.AddItemToSortedSet(key, value, score);
        }

        /// <summary>
        /// 为key添加values集合，values集合中每个value的分数设置为score
        /// </summary>
        public static bool AddRangeToSortedSet(string key, List<string> values, double score)
        {
            return RedisBase.Core.AddRangeToSortedSet(key, values, score);
        }

        /// <summary>
        /// 为key添加values集合，values集合中每个value的分数设置为score
        /// </summary>
        public static bool AddRangeToSortedSet(string key, List<string> values, long score)
        {
            return RedisBase.Core.AddRangeToSortedSet(key, values, score);
        }

        #endregion

        #region 获取

        /// <summary>
        /// 获取key的所有集合
        /// </summary>
        public static List<string> GetAllItemsFromSortedSet(string key)
        {
            return RedisBase.Core.GetAllItemsFromSortedSet(key);
        }

        /// <summary>
        /// 获取key的所有集合，倒叙输出
        /// </summary>
        public static List<string> GetAllItemsFromSortedSetDesc(string key)
        {
            return RedisBase.Core.GetAllItemsFromSortedSetDesc(key);
        }

        /// <summary>
        /// 获取可以的说有集合，带分数
        /// </summary>
        public static IDictionary<string, double> GetAllWithScoresFromSortedSet(string key)
        {
            return RedisBase.Core.GetAllWithScoresFromSortedSet(key);
        }

        /// <summary>
        /// 获取key为value的下标值
        /// </summary>
        public static long GetItemIndexInSortedSet(string key, string value)
        {
            return RedisBase.Core.GetItemIndexInSortedSet(key, value);
        }

        /// <summary>
        /// 倒叙排列获取key为value的下标值
        /// </summary>
        public static long GetItemIndexInSortedSetDesc(string key, string value)
        {
            return RedisBase.Core.GetItemIndexInSortedSetDesc(key, value);
        }

        /// <summary>
        /// 获取key为value的分数
        /// </summary>
        public static double GetItemScoreInSortedSet(string key, string value)
        {
            return RedisBase.Core.GetItemScoreInSortedSet(key, value);
        }

        /// <summary>
        /// 获取key所有集合的数据总数
        /// </summary>
        public static long GetSortedSetCount(string key)
        {
            return RedisBase.Core.GetSortedSetCount(key);
        }

        /// <summary>
        /// key集合数据从分数为fromscore到分数为toscore的数据总数
        /// </summary>
        public static long GetSortedSetCount(string key, double fromScore, double toScore)
        {
            return RedisBase.Core.GetSortedSetCount(key, fromScore, toScore);
        }

        /// <summary>
        /// 获取key集合从高分到低分排序数据，分数从fromscore到分数为toscore的数据
        /// </summary>
        public static List<string> GetRangeFromSortedSetByHighestScore(string key, double fromscore, double toscore)
        {
            return RedisBase.Core.GetRangeFromSortedSetByHighestScore(key, fromscore, toscore);
        }

        /// <summary>
        /// 获取key集合从低分到高分排序数据，分数从fromscore到分数为toscore的数据
        /// </summary>
        public static List<string> GetRangeFromSortedSetByLowestScore(string key, double fromscore, double toscore)
        {
            return RedisBase.Core.GetRangeFromSortedSetByLowestScore(key, fromscore, toscore);
        }

        /// <summary>
        /// 获取key集合从高分到低分排序数据，分数从fromscore到分数为toscore的数据，带分数
        /// </summary>
        public static IDictionary<string, double> GetRangeWithScoresFromSortedSetByHighestScore(string key, double fromscore, double toscore)
        {
            return RedisBase.Core.GetRangeWithScoresFromSortedSetByHighestScore(key, fromscore, toscore);
        }

        /// <summary>
        ///  获取key集合从低分到高分排序数据，分数从fromscore到分数为toscore的数据，带分数
        /// </summary>
        public static IDictionary<string, double> GetRangeWithScoresFromSortedSetByLowestScore(string key, double fromscore, double toscore)
        {
            return RedisBase.Core.GetRangeWithScoresFromSortedSetByLowestScore(key, fromscore, toscore);
        }

        /// <summary>
        ///  获取key集合数据，下标从fromRank到分数为toRank的数据
        /// </summary>
        public static List<string> GetRangeFromSortedSet(string key, int fromRank, int toRank)
        {
            return RedisBase.Core.GetRangeFromSortedSet(key, fromRank, toRank);
        }

        /// <summary>
        /// 获取key集合倒叙排列数据，下标从fromRank到分数为toRank的数据
        /// </summary>
        public static List<string> GetRangeFromSortedSetDesc(string key, int fromRank, int toRank)
        {
            return RedisBase.Core.GetRangeFromSortedSetDesc(key, fromRank, toRank);
        }

        /// <summary>
        /// 获取key集合数据，下标从fromRank到分数为toRank的数据，带分数
        /// </summary>
        public static IDictionary<string, double> GetRangeWithScoresFromSortedSet(string key, int fromRank, int toRank)
        {
            return RedisBase.Core.GetRangeWithScoresFromSortedSet(key, fromRank, toRank);
        }

        /// <summary>
        ///  获取key集合倒叙排列数据，下标从fromRank到分数为toRank的数据，带分数
        /// </summary>
        public static IDictionary<string, double> GetRangeWithScoresFromSortedSetDesc(string key, int fromRank, int toRank)
        {
            return RedisBase.Core.GetRangeWithScoresFromSortedSetDesc(key, fromRank, toRank);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除key为value的数据
        /// </summary>
        public static bool RemoveItemFromSortedSet(string key, string value)
        {
            return RedisBase.Core.RemoveItemFromSortedSet(key, value);
        }

        /// <summary>
        /// 删除下标从minRank到maxRank的key集合数据
        /// </summary>
        public static long RemoveRangeFromSortedSet(string key, int minRank, int maxRank)
        {
            return RedisBase.Core.RemoveRangeFromSortedSet(key, minRank, maxRank);
        }

        /// <summary>
        /// 删除分数从fromscore到toscore的key集合数据
        /// </summary>
        public static long RemoveRangeFromSortedSetByScore(string key, double fromscore, double toscore)
        {
            return RedisBase.Core.RemoveRangeFromSortedSetByScore(key, fromscore, toscore);
        }

        /// <summary>
        /// 删除key集合中分数最大的数据
        /// </summary>
        public static string PopItemWithHighestScoreFromSortedSet(string key)
        {
            return RedisBase.Core.PopItemWithHighestScoreFromSortedSet(key);
        }

        /// <summary>
        /// 删除key集合中分数最小的数据
        /// </summary>
        public static string PopItemWithLowestScoreFromSortedSet(string key)
        {
            return RedisBase.Core.PopItemWithLowestScoreFromSortedSet(key);
        }

        #endregion

        #region 其它

        /// <summary>
        /// 判断key集合中是否存在value数据
        /// </summary>
        public static bool SortedSetContainsItem(string key, string value)
        {
            return RedisBase.Core.SortedSetContainsItem(key, value);
        }

        /// <summary>
        /// 为key集合值为value的数据，分数加scoreby，返回相加后的分数
        /// </summary>
        public static double IncrementItemInSortedSet(string key, string value, double scoreBy)
        {
            return RedisBase.Core.IncrementItemInSortedSet(key, value, scoreBy);
        }

        /// <summary>
        /// 获取keys多个集合的交集，并把交集添加的newkey集合中，返回交集数据的总数
        /// </summary>
        public static long StoreIntersectFromSortedSets(string newkey, string[] keys)
        {
            return RedisBase.Core.StoreIntersectFromSortedSets(newkey, keys);
        }

        /// <summary>
        /// 获取keys多个集合的并集，并把并集数据添加到newkey集合中，返回并集数据的总数
        /// </summary>
        public static long StoreUnionFromSortedSets(string newkey, string[] keys)
        {
            return RedisBase.Core.StoreUnionFromSortedSets(newkey, keys);
        }

        #endregion
    }
}
