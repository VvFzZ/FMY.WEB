﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMY.RedisClient
{
    public class RedisSet : RedisBase
    {
        #region 添加

        /// <summary>
        /// key集合中添加value值
        /// </summary>
        public static void Add(string key, string value)
        {
            RedisBase.Core.AddItemToSet(key, value);
        }

        /// <summary>
        /// key集合中添加list集合
        /// </summary>
        public static void Add(string key, List<string> list)
        {
            RedisBase.Core.AddRangeToSet(key, list);
        }

        #endregion

        #region 获取

        /// <summary>
        /// 随机获取key集合中的一个值
        /// </summary>
        public static string GetRandomItemFromSet(string key)
        {
            return RedisBase.Core.GetRandomItemFromSet(key);
        }

        /// <summary>
        /// 获取key集合值的数量
        /// </summary>
        public static long GetCount(string key)
        {
            return RedisBase.Core.GetSetCount(key);
        }

        /// <summary>
        /// 获取所有key集合的值
        /// </summary>
        public static HashSet<string> GetAllItemsFromSet(string key)
        {
            return RedisBase.Core.GetAllItemsFromSet(key);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 随机删除key集合中的一个值
        /// </summary>
        public static string PopItemFromSet(string key)
        {
            return RedisBase.Core.PopItemFromSet(key);
        }

        /// <summary>
        /// 删除key集合中的value
        /// </summary>
        public static void RemoveItemFromSet(string key, string value)
        {
            RedisBase.Core.RemoveItemFromSet(key, value);
        }

        #endregion

        #region 其它

        /// <summary>
        /// 从fromkey集合中移除值为value的值，并把value添加到tokey集合中
        /// </summary>
        public static void MoveBetweenSets(string fromkey, string tokey, string value)
        {
            RedisBase.Core.MoveBetweenSets(fromkey, tokey, value);
        }

        /// <summary>
        /// 返回keys多个集合中的并集，返还hashset
        /// </summary>
        public static HashSet<string> GetUnionFromSets(string[] keys)
        {
            return RedisBase.Core.GetUnionFromSets(keys);
        }

        /// <summary>
        /// keys多个集合中的并集，放入newkey集合中
        /// </summary>
        public static void StoreUnionFromSets(string newkey, string[] keys)
        {
            RedisBase.Core.StoreUnionFromSets(newkey, keys);
        }

        /// <summary>
        /// 把fromkey集合中的数据与keys集合中的数据对比，fromkey集合中不存在keys集合中，则把这些不存在的数据放入newkey集合中
        /// </summary>
        public static void StoreDifferencesFromSet(string newkey, string fromkey, string[] keys)
        {
            RedisBase.Core.StoreDifferencesFromSet(newkey, fromkey, keys);
        }

        #endregion
    }
}
