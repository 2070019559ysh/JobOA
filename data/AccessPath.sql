
--�ɷ���·����Ȩ��Ӧ����һ��һ�Ĺ�ϵ
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
SELECT '��¼',1 UNION
SELECT '���������ҳ',2 UNION
SELECT '����ҳ����ҳ',3 UNION
SELECT '��˾��Ŀ������ҳ',4 UNION
SELECT '������˾��Ŀ����',5 UNION
SELECT '�޸Ĺ�˾��Ŀ����',6 UNION
SELECT 'ִ��ɾ����˾��Ŀ',7 UNION
SELECT '������������',8 UNION
SELECT '�鿴������Ϣ����',9 UNION
SELECT '�޸ĸ�����Ϣ',10 UNION
SELECT '���벿����Ϣ����ҳ',11 UNION
SELECT '����������Ϣ',12 UNION
SELECT '�޸Ĳ�����Ϣ',13 UNION
SELECT 'ɾ��������Ϣ',14
