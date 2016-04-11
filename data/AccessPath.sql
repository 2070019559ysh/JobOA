USE JOB_OA
GO
--JOBOA系统数据初始化
--可访问路径与权限应该是一对一的关系
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET','/AdminTask/Index');--1
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET','/AdminHome/Index');--2
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET','/AdminProject/Index');--3
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET,POST','/AdminProject/AddProject');--4
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET,POST','/AdminProject/UpdateProject');--5
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET','/AdminProject/DelProject');--6
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET,POST','/AdminTask/AddMajorTask');--7
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET','/PersonalInfo/Information');--8
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('POST','/PersonalInfo/UpdateEmployeeInfo');--9
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET','/Administration/Index');--10
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET','/Administration/AddDepartment');--11
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET','/Administration/UpdateDepartment');--12
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET','/Administration/DelDepartment');--13
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET','/PersonalInfo/Inbox');--14
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET,POST','/PersonalInfo/SendMess');--15
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('POST','/PersonalInfo/GetOaMess');--16
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET,POST','/PersonalInfo/DeleteMess');--17
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET,POST','/AdminTask/UpdateMajorTask');--18
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET','/AdminTask/DelMajorTask');--19
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET','/AdminSubTask/Index');--20
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET,POST','/AdminSubTask/AddRecord');--21
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
INSERT INTO Permission([Description],AccessPathId) VALUES('进入页面并进行修改主任务操作',18);
INSERT INTO Permission([Description],AccessPathId) VALUES('删除主任务操作',19);
INSERT INTO Permission([Description],AccessPathId) VALUES('查看子任务列表',20);
INSERT INTO Permission([Description],AccessPathId) VALUES('进入添加子任务页，并进行添加操作',21);
GO
--角色
INSERT INTO Role(Name,IsEnabled,PermissionIds) VALUES('超级管理员',1,'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21');
--部门
INSERT INTO Department(Name) VALUES('软件开发部');
--员工信息
INSERT INTO Employee(UserName,[Password],RealName,Email,IsEnabled,RoleIds,DepartmentId,OnlineState)
VALUES('13726216934','4AF0C6F39E514D6E2244B33E8B2A6C0B','杨尚洪','2070019559@qq.com',1,1,1,0);
--OAUi记录发短信、邮件的账号
INSERT INTO OAUi(UiTitle,UiMess) VALUES('joboa_System_sms','uid=2070019559ysh;key=4bef75049eadb5c29cde');
INSERT INTO OAUi(UiTitle,UiMess) VALUES('joboa_System_email','server=smtp.163.com;from=tow070019559@163.com;password=503104plkj');
GO
--OaMessage消息
INSERT INTO OAMessage(Title,ExtraMessage,FromEmployeeId,ToEmployeeId,IsLookUp,SendDateTime)
VALUES('上班提醒','记得明天早上早起哦，别迟到了哦！',1,1,0,'2016-04-02 10:32:53')
INSERT INTO OAMessage(Title,ExtraMessage,FromEmployeeId,ToEmployeeId,IsLookUp,SendDateTime)
VALUES('任务提交','任务已经完成，请于2016-4-5前进行审核，并提交审核结果。谢谢！',1,1,0,'2016-04-02 10:36:41')
INSERT INTO OAMessage(Title,ExtraMessage,FromEmployeeId,ToEmployeeId,IsLookUp,SendDateTime)
VALUES('寄东西','请帮忙寄实习鉴定评语表到佛山，最晚后天寄过来哦。',1,1,0,'2016-03-31 10:36:32')
GO
--项目
INSERT INTO Project(Name, Description, IsSecrecy, [State])
VALUES('JobOA提高办事效率','few氛围锋，妃哦寄送的few咖啡来我家分icdfefewfef',0,0)
INSERT INTO Project(Name, Description, IsSecrecy, [State])
VALUES('网上书店','枫哥哥热greg个人热热歌greg人俄国人过热个人g',0,0)
GO
--主任务
INSERT INTO MajorTask(Name, ArrangePersonId, ExePersonId, CheckPersonId, Participator, StartTime, CompleteTime, CreateTime, [State], IsSecrecy, ProjectId)
VALUES('开发界面',1,1,1,1,'2016-02-07 05:12:23.000','2016-05-27 14:51:55.000','2016-04-04 10:01:36.643',0,0,1)
INSERT INTO MajorTask(Id, Name, ArrangePersonId, ExePersonId, CheckPersonId, Participator, StartTime, CompleteTime, CreateTime, [State], IsSecrecy, ProjectId)
VALUES('开发界面',1,1,1,1,'2016-02-07 05:12:23.000','2016-04-04 10:01:52.000','2016-04-04 10:01:56.753',0,0,2)
INSERT INTO MajorTask(Id, Name, ArrangePersonId, ExePersonId, CheckPersonId, Participator, StartTime, CompleteTime, CreateTime, [State], IsSecrecy, ProjectId)
VALUES('开发后台代码',1,1,1,1,'2016-04-04 10:02:11.000','2016-04-06 10:02:13.000','2016-04-04 10:02:16.000',0,0,1)
GO
--子任务
INSERT INTO SubTask([No], Name, ArrangePersonId, ExePersonId, CheckPersonId, Participator, StartTime, CompleteTime, CreateTime, TaskId, [State], IsSecrecy, SubmissionThing, CompletionCriteria, WorkMethod, Progress)
VALUES('1-1','构思界面框架',1,1,1,1,'2016-04-04 15:43:52.000','2016-04-05 15:43:57.000','2016-04-04 15:44:14.000',1,0,0,'界面设计图片','预览图片要到达一目了然效果','用ps和Dw设计',20)
INSERT INTO SubTask(Id, [No], Name, ArrangePersonId, ExePersonId, CheckPersonId, Participator, StartTime, CompleteTime, CreateTime, TaskId, [State], IsSecrecy, SubmissionThing, CompletionCriteria, WorkMethod, Progress)
VALUES('2-1','html和css设计静态页面',1,1,1,1,'2016-04-04 15:49:02.000','2016-04-02 15:49:07.000','2016-04-04 15:49:18.000',2,0,0,'静态网页源码文件','提供给后台开发人员使用，基本操作简明','用Dw和Blend',15)
