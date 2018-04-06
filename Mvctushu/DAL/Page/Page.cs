using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvctushu.DAL.Page
{
    public class Page
    {
        public int count = 0;//总个数
        public int pagecount = 5;//分页数量
        public int nuber = 0;//当前页
        public int pagenuber = 0;//总页数
        public int sky = 0;//跳转页

        //可读可写属性
        public int Count
        {
            get { return count;}
            set { value = count;}
        }

        public int Pagecount
        {
            get { return pagecount; }
            set { value = pagecount; }
        }

        public int Nuber
        {
            get { return nuber; }
            set { value = nuber; }
        }

        //只读属性
        public int Pagenuber
        {
            get {
                Comt();
                return pagenuber; }
        }

        public int Sky
        {
            get {
                Comt();
                return sky; }
        }

        public void Comt()
        {
            if (count <= 0)
            {
                count = 0;
                pagecount = 0;
                nuber = 0;
                pagenuber = 0;
                sky = 0;
                return;
            }
            pagenuber = count / pagecount;
            if (count % pagecount > 0)
            { 
               pagenuber++;
            }
            if (pagecount < 1)
            {
                pagecount = 5;
            }
            if (nuber < 1)
            {
                nuber = 1;
            }
            if (nuber > pagenuber)
            {
                nuber = pagenuber;
            }
            sky = pagecount * (nuber - 1);
        }
    }
}