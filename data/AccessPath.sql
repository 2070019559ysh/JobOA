USE JOB_OA
GO
--JOBOA系统数据初始化
--可访问路径与权限应该是一对一的关系
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET','/AdminTask/Index');
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET','/AdminHome/Index');
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET','/AdminProject/Index');
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET,POST','/AdminProject/AddProject');
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET,POST','/AdminProject/UpdateProject');
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET','/AdminProject/DelProject');
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET,POST','/AdminTask/AddMajorTask');
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET','/PersonalInfo/Information');
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('POST','/PersonalInfo/UpdateEmployeeInfo');
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET','/Administration/Index');
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET','/Administration/AddDepartment');
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET','/Administration/UpdateDepartment');
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET','/Administration/DelDepartment');
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET','/PersonalInfo/Inbox');
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET,POST','/PersonalInfo/SendMess');
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('POST','/PersonalInfo/GetOaMess');
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET,POST','/PersonalInfo/DeleteMess');
GO
--权限
INSERT INTO Permission([Description],AccessPathId) VALUES('任务管理主页',1);
INSERT INTO Permission([Description],AccessPathId) VALUES('管理页面主页',2);
INSERT INTO Permission([Description],AccessPathId) VALUES('公司项目管理主页',3);
INSERT INTO Permission([Description],AccessPathId) VALUES('新增公司项目操作',4);
INSERT INTO Permission([Description],AccessPathId) VALUES('修改公司项目操作',5);
INSERT INTO Permission([Description],AccessPathId) VALUES('执行删除公司项目',6);
INSERT INTO Permission([Description],AccessPathId) VALUES('添加主任务操作',7);
INSERT INTO Permission([Description],AccessPathId) VALUES('查看个人信息资料',8);
INSERT INTO Permission([Description],AccessPathId) VALUES('修改个人信息',9);
INSERT INTO Permission([Description],AccessPathId) VALUES('进入部门信息管理页',10);
INSERT INTO Permission([Description],AccessPathId) VALUES('新增部门信息',11);
INSERT INTO Permission([Description],AccessPathId) VALUES('修改部门信息',12);
INSERT INTO Permission([Description],AccessPathId) VALUES('删除部门信息',13);
INSERT INTO Permission([Description],AccessPathId) VALUES('进入个人收件箱',14);
INSERT INTO Permission([Description],AccessPathId) VALUES('收件箱里发送消息',15);
INSERT INTO Permission([Description],AccessPathId) VALUES('收件箱里进行消息页面跳转，获取指定页消息数据',16);
INSERT INTO Permission([Description],AccessPathId) VALUES('收件箱里进行消息删除操作',17);
GO
--角色
INSERT INTO Role(Name,IsEnabled,PermissionIds) VALUES('超级管理员',1,'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17');
--部门
INSERT INTO Department(Name) VALUES('软件开发部');
--员工信息
INSERT INTO Employee(UserName,[Password],RealName,Email,IsEnabled,RoleIds,DepartmentId,OnlineState)
VALUES('13726216934','4AF0C6F39E514D6E2244B33E8B2A6C0B','杨尚洪','2070019559@qq.com',1,1,1,0);
--OAUi记录发短信、邮件的账号
INSERT INTO OAUi(UiTitle,UiMess) VALUES('joboa_System_sms','uid=2070019559ysh;key=4bef75049eadb5c29cde');
INSERT INTO OAUi(UiTitle,UiMess) VALUES('joboa_System_email','server=smtp.163.com;from=tow070019559@163.com;password=503104plkj');
INSERT INTO OAUi(UiImg,UiTitle,UiMess) VALUES('oar2c1.jpg','joboa_System_PictureCarousel*Title=OA系统是各行企业人士的选择与信赖','为企业内部办公提高办事效率');
INSERT INTO OAUi(UiImg,UiTitle,UiMess) VALUES('40314.jpg','joboa_System_PictureCarousel*Title=OA简单工作流程','自由流程，自由办，工作轻松搞定');
INSERT INTO OAUi(UiImg,UiTitle,UiMess) VALUES('u1832.jpg','joboa_System_PictureCarousel*Title=界面简单，高效办公','简单化界面更符合工作习惯，不做视觉效果的奴隶');
INSERT INTO OAUi(UiImg,UiTitle,UiMess) VALUES('yuming.jpg','joboa_System_PictureCarousel*Title=办公OA系统开发涉及内容甚多','基本员工信息维护，权限维护，工作任务管理，文件管理，消息管理');
INSERT INTO OAUi(UiImg,UiTitle,UiMess) VALUES('foundation.png	joboa_System_InfoList*Title=为移动而生','Amaze UI 以移动优先（Mobile first）为理念，从小屏逐步扩展到大屏，最终实现所有屏幕适配，适应移动互联潮流。');
INSERT INTO OAUi(UiImg,UiTitle,UiMess) VALUES('web.png','joboa_System_InfoList*Title=组件丰富，模块化','Amaze UI 含近 20 个 CSS 组件、20 余 JS 组件，更有多个包含不同主题的 Web 组件，可快速构建界面出色、体验优秀的跨屏页面，大幅提升开发效率。');
INSERT INTO OAUi(UiImg,UiTitle,UiMess) VALUES('chinese.png','joboa_System_InfoList*Title=组件丰富，模块化	相比国外框架，Amaze UI 关注中文排版，根据用户代理调整字体，实现更好的中文排版效果；兼顾国内主流浏览器及 App 内置浏览器兼容支持。');
INSERT INTO OAUi(UiImg,UiTitle,UiMess) VALUES('mobile.png','joboa_System_InfoList*Title=轻量级，高性能','Amaze UI 面向 HTML5 开发，使用 CSS3 来做动画交互，平滑、高效，更适合移动设备，让 Web 应用更快速载入。');
INSERT INTO OAUi(UiImg,UiTitle,UiMess) VALUES(NULL,'joboa_System_FootHead*Title=站在巨人的肩膀上','Amaze UI 汲取了很多优秀的社区资源，通过开源的形式来回馈社区。');
INSERT INTO OAUi(UiImg,UiTitle,UiMess) VALUES(NULL,'joboa_System_FootContent*Title=MIT License','Amaze UI 使用 <a href="#" target="_blank">MIT 许可证</a>发布，用户可以自由使用、复制、修改、合并、出版发行、散布、再授权及贩售 Amaze UI 及其副本。');
INSERT INTO OAUi(UiImg,UiTitle,UiMess) VALUES(NULL,'joboa_System_FootContent*Title=Heroes','<a href="#" target="_blank">参考、使用的项目</a>：jQuery, Zepto.js, Seajs, LESS, normalize.css, FontAwesome, Bootstrap, Foundation, UIKit, Pure, Framework7, etc.');
INSERT INTO OAUi(UiImg,UiTitle,UiMess) VALUES(NULL,'joboa_System_FootContent*Title=Credits','我们追求卓越，然时间、经验、能力有限。Amaze UI 有很多不足的地方，希望大家包容、不吝赐教，给我们提意见、建议。<a href="#" target="_blank">感谢你们</a>！');
INSERT INTO OAUi(UiTitle,UiMess) VALUES('joboa_System_Notice*Title=公告','时光静好，与君语；细水流年，与君同。—— Amaze UI');
INSERT INTO OAUi(UiTitle,UiMess) VALUES('joboa_System_Notice*Title=Wiki','Welcome to the Amaze UI wiki!');
GO
--OaMessage消息
INSERT INTO OAMessage(Title,ExtraMessage,FromEmployeeId,ToEmployeeId,IsLookUp,SendDateTime)
VALUES('上班提醒','记得明天早上早起哦，别迟到了哦！',1,1,0,'2016-04-02 10:32:53')
INSERT INTO OAMessage(Title,ExtraMessage,FromEmployeeId,ToEmployeeId,IsLookUp,SendDateTime)
VALUES('任务提交','任务已经完成，请于2016-4-5前进行审核，并提交审核结果。谢谢！',1,1,0,'2016-04-02 10:36:41')
INSERT INTO OAMessage(Title,ExtraMessage,FromEmployeeId,ToEmployeeId,IsLookUp,SendDateTime)
VALUES('寄东西','请帮忙寄实习鉴定评语表到佛山，最晚后天寄过来哦。',1,1,0,'2016-03-31 10:36:32')
GO