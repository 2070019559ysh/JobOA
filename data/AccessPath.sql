USE JOB_OA
GO
--JOBOAϵͳ���ݳ�ʼ��
--�ɷ���·����Ȩ��Ӧ����һ��һ�Ĺ�ϵ
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
INSERT INTO Permission([Description],AccessPathId) VALUES('�ռ����﷢����Ϣ',15);
INSERT INTO Permission([Description],AccessPathId) VALUES('�ռ����������Ϣҳ����ת����ȡָ��ҳ��Ϣ����',16);
INSERT INTO Permission([Description],AccessPathId) VALUES('�ռ����������Ϣɾ������',17);
INSERT INTO Permission([Description],AccessPathId) VALUES('����ҳ�沢�����޸����������',18);
INSERT INTO Permission([Description],AccessPathId) VALUES('ɾ�����������',19);
INSERT INTO Permission([Description],AccessPathId) VALUES('�鿴�������б�',20);
INSERT INTO Permission([Description],AccessPathId) VALUES('�������������ҳ����������Ӳ���',21);
GO
--��ɫ
INSERT INTO Role(Name,IsEnabled,PermissionIds) VALUES('��������Ա',1,'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21');
--����
INSERT INTO Department(Name) VALUES('���������');
--Ա����Ϣ
INSERT INTO Employee(UserName,[Password],RealName,Email,IsEnabled,RoleIds,DepartmentId,OnlineState)
VALUES('13726216934','4AF0C6F39E514D6E2244B33E8B2A6C0B','���к�','2070019559@qq.com',1,1,1,0);
--OAUi��¼�����š��ʼ����˺�
INSERT INTO OAUi(UiTitle,UiMess) VALUES('joboa_System_sms','uid=2070019559ysh;key=4bef75049eadb5c29cde');
INSERT INTO OAUi(UiTitle,UiMess) VALUES('joboa_System_email','server=smtp.163.com;from=tow070019559@163.com;password=503104plkj');
GO
--OaMessage��Ϣ
INSERT INTO OAMessage(Title,ExtraMessage,FromEmployeeId,ToEmployeeId,IsLookUp,SendDateTime)
VALUES('�ϰ�����','�ǵ�������������Ŷ����ٵ���Ŷ��',1,1,0,'2016-04-02 10:32:53')
INSERT INTO OAMessage(Title,ExtraMessage,FromEmployeeId,ToEmployeeId,IsLookUp,SendDateTime)
VALUES('�����ύ','�����Ѿ���ɣ�����2016-4-5ǰ������ˣ����ύ��˽����лл��',1,1,0,'2016-04-02 10:36:41')
INSERT INTO OAMessage(Title,ExtraMessage,FromEmployeeId,ToEmployeeId,IsLookUp,SendDateTime)
VALUES('�Ķ���','���æ��ʵϰ�����������ɽ���������Ĺ���Ŷ��',1,1,0,'2016-03-31 10:36:32')
GO
--��Ŀ
INSERT INTO Project(Name, Description, IsSecrecy, [State])
VALUES('JobOA��߰���Ч��','few��Χ�棬��Ŷ���͵�few�������Ҽҷ�icdfefewfef',0,0)
INSERT INTO Project(Name, Description, IsSecrecy, [State])
VALUES('�������','������greg�������ȸ�greg�˶���˹��ȸ���g',0,0)
GO
--������
INSERT INTO MajorTask(Name, ArrangePersonId, ExePersonId, CheckPersonId, Participator, StartTime, CompleteTime, CreateTime, [State], IsSecrecy, ProjectId)
VALUES('��������',1,1,1,1,'2016-02-07 05:12:23.000','2016-05-27 14:51:55.000','2016-04-04 10:01:36.643',0,0,1)
INSERT INTO MajorTask(Id, Name, ArrangePersonId, ExePersonId, CheckPersonId, Participator, StartTime, CompleteTime, CreateTime, [State], IsSecrecy, ProjectId)
VALUES('��������',1,1,1,1,'2016-02-07 05:12:23.000','2016-04-04 10:01:52.000','2016-04-04 10:01:56.753',0,0,2)
INSERT INTO MajorTask(Id, Name, ArrangePersonId, ExePersonId, CheckPersonId, Participator, StartTime, CompleteTime, CreateTime, [State], IsSecrecy, ProjectId)
VALUES('������̨����',1,1,1,1,'2016-04-04 10:02:11.000','2016-04-06 10:02:13.000','2016-04-04 10:02:16.000',0,0,1)
GO
--������
INSERT INTO SubTask([No], Name, ArrangePersonId, ExePersonId, CheckPersonId, Participator, StartTime, CompleteTime, CreateTime, TaskId, [State], IsSecrecy, SubmissionThing, CompletionCriteria, WorkMethod, Progress)
VALUES('1-1','��˼������',1,1,1,1,'2016-04-04 15:43:52.000','2016-04-05 15:43:57.000','2016-04-04 15:44:14.000',1,0,0,'�������ͼƬ','Ԥ��ͼƬҪ����һĿ��ȻЧ��','��ps��Dw���',20)
INSERT INTO SubTask(Id, [No], Name, ArrangePersonId, ExePersonId, CheckPersonId, Participator, StartTime, CompleteTime, CreateTime, TaskId, [State], IsSecrecy, SubmissionThing, CompletionCriteria, WorkMethod, Progress)
VALUES('2-1','html��css��ƾ�̬ҳ��',1,1,1,1,'2016-04-04 15:49:02.000','2016-04-02 15:49:07.000','2016-04-04 15:49:18.000',2,0,0,'��̬��ҳԴ���ļ�','�ṩ����̨������Աʹ�ã�������������','��Dw��Blend',15)
