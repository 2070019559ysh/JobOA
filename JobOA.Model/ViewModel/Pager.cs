using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobOA.Model.ViewModel
{
    public class Pager
    {
        private int _pageIndex;
        private int _pageSize;
        private int _total ;
        private int _pageCount;
        private int _start;
        private int _end;
        private bool _hasPrev;
        private bool _hasNext;
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex
        {
            get { return _pageIndex; }
            set
            {
                if (value < 1)
                {
                    _pageIndex = 1;
                }
                else if (value > PageCount)
                {
                    _pageIndex = PageCount;
                }
                else
                {
                    _pageIndex = value;
                }
            }
        }
        /// <summary>
        /// 每页记录数
        /// </summary>
        public int PageSize {
            get
            {
                return _pageSize;
            }
            set
            {
                if (value < 1)
                {
                    _pageSize = 1;
                }
                else
                {
                    _pageSize = value;
                }
            }
        }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get
            {
                return _pageCount;
            }
        }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int Total
        {
            get
            {
                return _total;
            }
            set
            {
                if (value < 0)
                {
                    _total = 0;
                }
                else
                {
                    _total = value;
                }
            }
        }
        /// <summary>
        /// 起始页码
        /// </summary>
        public int Start
        {
            get
            {
                return _start;
            }
        }
        /// <summary>
        /// 结束页码
        /// </summary>
        public int End
        {
            get
            {
                return _end;
            }
        }
        /// <summary>
        /// 是否有上一页
        /// </summary>
        public bool HasPrev
        {
            get
            {
                return _hasPrev;
            }
        }
        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool HasNext
        {
            get
            {
                return _hasNext;
            }
        }

        /// <summary>
        /// 备注信息，可以保存其他信息，比如：查询条件
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 唯一的构造函数
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页显示记录数</param>
        /// <param name="total">总记录数</param>
        public Pager(int pageIndex,int pageSize,int total) {
            this._pageIndex = pageIndex;
            this.PageSize = pageSize;
            this.Total = total;
            _pageCount=_total % _pageSize == 0 ? _total / _pageSize : (_total / _pageSize) + 1;
            if (_pageCount < 1) _pageCount = 1;//至少要有一页
            _start = _pageIndex - 3 > 1 ? _pageIndex - 3 : 1;
            _end = _pageIndex + 3 < PageCount ? _pageIndex + 3 : PageCount;
            _hasPrev = _pageIndex > 1;
            _hasNext = _pageIndex < PageCount;
        }
    }
}