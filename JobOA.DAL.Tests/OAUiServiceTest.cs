using JobOA.DAL.Implement;
using JobOA.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL.Tests
{
    /// <summary>
    /// OA界面信息关联数据库测试类
    /// </summary>
    [TestFixture]
    public class OAUiServiceTest
    {
        private OAUiService _oaUiService = new OAUiService();
        private int[] _deleteId;//保存测试结束时要删除的记录Id

        /// <summary>
        /// 执行每个测试方法前，初始化数据，添加测试记录
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _deleteId = new int[] { 0, 0 };
            //添加用于查找、删除或修改的记录
            using (OaModel dbContext = new OaModel())
            {
                OAUi oaUi = new OAUi() { UiTitle = "单元测试", UiMess = "NUnit 单元测试", UiImg = "NUnitTest.png" };
                dbContext.OAUi.Add(oaUi);
                dbContext.SaveChanges();
                _deleteId[0] = oaUi.UiId;
            }
        }

        /// <summary>
        /// 执行每个测试方法后，释放占用的资源，删除测试中添加的记录
        /// </summary>
        [TearDown]
        public void Teardown()
        {
            //删除测试中添加的记录
            using (OaModel dbContext = new OaModel())
            {
                for (int i = 0; i < _deleteId.Length; i++)
                {
                    if (_deleteId[i] != 0)
                    {
                        OAUi oaUi = new OAUi() { UiId = _deleteId[i] };
                        dbContext.OAUi.Attach(oaUi);
                        dbContext.OAUi.Remove(oaUi);
                    }
                }
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// 通过Id查找OA界面信息测试
        /// </summary>
        [Test]
        public void SearchOAUiByIdTest()
        {
            OAUi oaUi = _oaUiService.SearchOAUiById(_deleteId[0]);
            Assert.IsNotNull(oaUi);
        }

        /// <summary>
        /// 添加OA界面信息测试
        /// </summary>
        [Test]
        public void AddOAUiTest()
        {
            OAUi oaUi = new OAUi() { UiTitle = "添加单元测试", UiMess = "Add NUnit 单元测试", UiImg = "AddNUnitTest.png" };
            int actual = _oaUiService.AddOAUi(oaUi);
            _deleteId[1] = oaUi.UiId;//记录测试完成时要删除此记录
            Assert.AreEqual(1, actual);
        }

        /// <summary>
        /// 删除OA界面信息测试
        /// </summary>
        [Test]
        public void DeleteOAUiTest()
        {
            int actual = _oaUiService.DeleteOAUi(_deleteId[0]);
            _deleteId[0] = 0;//标志已经删除，测试完成时不要再重复删除此记录
            Assert.AreEqual(1, actual);
        }

        /// <summary>
        /// 更新OA界面信息测试
        /// </summary>
        [Test]
        public void UpdateOAUiTest()
        {
            OAUi oaUi = new OAUi() { UiId = _deleteId[0], UiTitle = "修改单元测试",
                UiMess = "Update NUnit 单元测试", UiImg = "UpdateNUnitTest.png" };
            int actual = _oaUiService.UpdateOAUi(oaUi);
            Assert.AreEqual(1, actual);
        }
    }
}
