
--�ɷ���·����Ȩ��Ӧ����һ��һ�Ĺ�ϵ
INSERT INTO AccessPath(HttpMethod,[Path])
SELECT 'GET','/Home/Index' UNION
SELECT 'GET','/Account/Index' UNION
SELECT 'GET','/AdminTask/Index' UNION
SELECT 'GET','/AdminHome/Index' UNION
SELECT 'GET','/AdminProject/Index'

INSERT INTO Permission([Description],AccessPathId)
SELECT '������ҳ',1 UNION
SELECT '��¼',2 UNION
SELECT '���������ҳ',3 UNION
SELECT '����ҳ����ҳ',4 UNION
SELECT '��˾��Ŀ������ҳ',5