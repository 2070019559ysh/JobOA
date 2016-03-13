--JOBOAϵͳ���ݳ�ʼ��
--�ɷ���·����Ȩ��Ӧ����һ��һ�Ĺ�ϵ
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
--Ȩ��
INSERT INTO Permission([Description],AccessPathId) VALUES('���������ҳ',1);
INSERT INTO Permission([Description],AccessPathId) VALUES('����ҳ����ҳ',2);
INSERT INTO Permission([Description],AccessPathId) VALUES('��˾��Ŀ������ҳ',3);
INSERT INTO Permission([Description],AccessPathId) VALUES('������˾��Ŀ����',4);
INSERT INTO Permission([Description],AccessPathId) VALUES('�޸Ĺ�˾��Ŀ����',5);
INSERT INTO Permission([Description],AccessPathId) VALUES('ִ��ɾ����˾��Ŀ',6);
INSERT INTO Permission([Description],AccessPathId) VALUES('������������',7);
INSERT INTO Permission([Description],AccessPathId) VALUES('�鿴������Ϣ����',8);
INSERT INTO Permission([Description],AccessPathId) VALUES('�޸ĸ�����Ϣ',9);
INSERT INTO Permission([Description],AccessPathId) VALUES('���벿����Ϣ����ҳ',10);
INSERT INTO Permission([Description],AccessPathId) VALUES('����������Ϣ',11);
INSERT INTO Permission([Description],AccessPathId) VALUES('�޸Ĳ�����Ϣ',12);
INSERT INTO Permission([Description],AccessPathId) VALUES('ɾ��������Ϣ',13);
INSERT INTO Permission([Description],AccessPathId) VALUES('��������ռ���',14);
GO
--��ɫ
INSERT INTO Role(Name,IsEnabled,PermissionIds) VALUES('��������Ա',1,'1,2,3,4,5,6,7,8,9,10,11,12,13,14');
--����
INSERT INTO Department(Name) VALUES('���������');
--Ա����Ϣ
INSERT INTO Employee(UserName,[Password],RealName,Email,IsEnabled,RoleIds,DepartmentId,OnlineState)
VALUES('13726216934','4AF0C6F39E514D6E2244B33E8B2A6C0B','���к�','2070019559@qq.com',1,1,1,0);
--OAUi��¼�����š��ʼ����˺�
INSERT INTO OAUi(UiTitle,UiMess) VALUES('joboa_System_sms','uid=2070019559ysh;key=4bef75049eadb5c29cde');
INSERT INTO OAUi(UiTitle,UiMess) VALUES('joboa_System_email','server=smtp.163.com;from=tow070019559@163.com;password=503104plkj');
GO