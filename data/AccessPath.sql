
--�ɷ���·����Ȩ��Ӧ����һ��һ�Ĺ�ϵ
INSERT INTO AccessPath(HttpMethod,[Path])
SELECT 'GET','/Home/Index' UNION
SELECT 'GET','/Account/Index' UNION
SELECT 'GET','/AdminTask/Index' UNION
SELECT 'GET','/AdminHome/Index' UNION
SELECT 'GET','/AdminProject/Index' UNION
SELECT 'GET,POST','/AdminProject/AddProject' UNION
SELECT 'GET,POST','/AdminProject/UpdateProject' UNION
SELECT 'GET','/AdminProject/DelProject' UNION
SELECT 'GET,POST','/AdminTask/AddMajorTask' UNION
SELECT 'GET','/PersonalInfo/Information'

INSERT INTO Permission([Description],AccessPathId)
SELECT '������ҳ',1 UNION
SELECT '��¼',2 UNION
SELECT '���������ҳ',3 UNION
SELECT '����ҳ����ҳ',4 UNION
SELECT '��˾��Ŀ������ҳ',5 UNION
SELECT '������˾��Ŀ����',6 UNION
SELECT '�޸Ĺ�˾��Ŀ����',7 UNION
SELECT 'ִ��ɾ����˾��Ŀ',8 UNION
SELECT '������������',9
SELECT '�鿴������Ϣ����',10
