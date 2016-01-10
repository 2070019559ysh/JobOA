
--可访问路径与权限应该是一对一的关系
INSERT INTO AccessPath(HttpMethod,[Path])
SELECT 'GET','/Home/Index' UNION
SELECT 'GET','/Account/Index' UNION
SELECT 'GET','/AdminTask/Index'

INSERT INTO Permission([Description],AccessPathId)
SELECT '访问首页',1 UNION
SELECT '登录',2 UNION
SELECT '任务管理主页',3