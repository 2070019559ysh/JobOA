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
GO
--角色
INSERT INTO Role(Name,IsEnabled,PermissionIds) VALUES('超级管理员',1,'1,2,3,4,5,6,7,8,9,10,11,12,13,14');
--部门
INSERT INTO Department(Name) VALUES('软件开发部');
--员工信息
INSERT INTO Employee(UserName,[Password],RealName,Email,IsEnabled,RoleIds,DepartmentId,OnlineState)
VALUES('13726216934','4AF0C6F39E514D6E2244B33E8B2A6C0B','杨尚洪','2070019559@qq.com',1,1,1,0);
--OAUi记录发短信、邮件的账号
INSERT INTO OAUi(UiTitle,UiMess) VALUES('joboa_System_sms','uid=2070019559ysh;key=4bef75049eadb5c29cde');
INSERT INTO OAUi(UiTitle,UiMess) VALUES('joboa_System_email','server=smtp.163.com;from=tow070019559@163.com;password=503104plkj');
GO