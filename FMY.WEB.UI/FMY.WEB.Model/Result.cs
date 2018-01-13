using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FMY.WEB.Model
{
    public class Result
    {
        #region [          ctor          ]
        public Result() : this(false, string.Empty, 0, string.Empty)
        {

        }

        public Result(bool isSuccess) : this(isSuccess, string.Empty, 0, string.Empty)
        {

        }

        public Result(bool isSuccess, string data) : this(isSuccess, data, 0, string.Empty)
        {

        }



        public Result(bool isSuccess, string data, int status, string info)
        {
            this.IsSuccess = isSuccess;
            this.Data = data;
            this.Status = status;
            this.Info = info;
        } 
        #endregion

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// 返回状态码
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 附加信息
        /// </summary>
        public string Info { get; set; }
    }
}
