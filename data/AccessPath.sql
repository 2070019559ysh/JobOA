
--可访问路径与权限应该是一对一的关系
INSERT INTO AccessPath(HttpMethod,[Path])
SELECT 'GET','/Account/Index' UNION
SELECT 'GET','/AdminTask/Index' UNION
SELECT 'GET','/AdminHome/Index' UNION
SELECT 'GET','/AdminProject/Index' UNION
SELECT 'GET,POST','/AdminProject/AddProject' UNION
SELECT 'GET,POST','/AdminProject/UpdateProject' UNION
SELECT 'GET','/AdminProject/DelProject' UNION
SELECT 'GET,POST','/AdminTask/AddMajorTask' UNION
SELECT 'GET','/PersonalInfo/Information' UNION
SELECT 'POST','/PersonalInfo/UpdateEmployeeInfo'
SELECT 'GET','/Administration/Index' UNION
SELECT 'GET','/Administration/AddDepartment' UNION
SELECT 'GET','/Administration/UpdateDepartment' UNION
SELECT 'GET','/Administration/DelDepartment'

INSERT INTO Permission([Description],AccessPathId)
SELECT '登录',1 UNION
SELECT '任务管理主页',2 UNION
SELECT '管理页面主页',3 UNION
SELECT '公司项目管理主页',4 UNION
SELECT '新增公司项目操作',5 UNION
SELECT '修改公司项目操作',6 UNION
SELECT '执行删除公司项目',7 UNION
SELECT '添加主任务操作',8 UNION
SELECT '查看个人信息资料',9 UNION
SELECT '修改个人信息',10 UNION
SELECT '进入部门信息管理页',11 UNION
SELECT '新增部门信息',12 UNION
SELECT '修改部门信息',13 UNION
SELECT '删除部门信息',14
