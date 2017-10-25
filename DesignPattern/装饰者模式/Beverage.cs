using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.装饰者模式
{
    /// <summary>
    /// 饮料基类
    /// </summary>
    public abstract class Beverage
    {
        protected const string GRANDE = "GRANDE";
        protected const string TALL = "TALL";
        protected const string VENTI = "VENTI";
        /// <summary>
        /// 描述
        /// </summary>
        protected string description = "未知饮料";

        public Beverage()
        {

        }

        public Beverage(int size)
        {
            this.size = size;
        }

        /// <summary>
        /// 大小
        /// </summary>
        protected int size;

        /// <summary>
        /// 获取饮料价格
        /// </summary>
        /// <returns></returns>
        public abstract double Cost();

        /// <summary>
        /// 获取描述信息
        /// </summary>
        /// <returns></returns>

        public abstract string GetDescription();
    }
}
