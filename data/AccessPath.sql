
--可访问路径与权限应该是一对一的关系
INSERT INTO AccessPath(HttpMethod,[Path])
SELECT 'GET','/Home/Index' UNION
SELECT 'GET','/Account/Index' UNION
SELECT 'GET','/AdminTask/Index' UNION
SELECT 'GET','/AdminHome/Index' UNION
SELECT 'GET','/AdminProject/Index' UNION
SELECT 'GET','/AdminProject/AddProject' UNION
SELECT 'POST','/AdminProject/AddProject'

INSERT INTO Permission([Description],AccessPathId)
SELECT '访问首页',1 UNION
SELECT '登录',2 UNION
SELECT '任务管理主页',3 UNION
SELECT '管理页面主页',4 UNION
SELECT '公司项目管理主页',5 UNION
SELECT '新增公司项目页',6 UNION
SELECT '执行新增公司项目',7