USE JOB_OA
GO
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
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET,POST','/PersonalInfo/SendMess');
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('POST','/PersonalInfo/GetOaMess');
INSERT INTO AccessPath(HttpMethod,[Path]) VALUES('GET,POST','/PersonalInfo/DeleteMess');
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
GO
--��ɫ
INSERT INTO Role(Name,IsEnabled,PermissionIds) VALUES('��������Ա',1,'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17');
--����
INSERT INTO Department(Name) VALUES('���������');
--Ա����Ϣ
INSERT INTO Employee(UserName,[Password],RealName,Email,IsEnabled,RoleIds,DepartmentId,OnlineState)
VALUES('13726216934','4AF0C6F39E514D6E2244B33E8B2A6C0B','���к�','2070019559@qq.com',1,1,1,0);
--OAUi��¼�����š��ʼ����˺�
INSERT INTO OAUi(UiTitle,UiMess) VALUES('joboa_System_sms','uid=2070019559ysh;key=4bef75049eadb5c29cde');
INSERT INTO OAUi(UiTitle,UiMess) VALUES('joboa_System_email','server=smtp.163.com;from=tow070019559@163.com;password=503104plkj');
INSERT INTO OAUi(UiImg,UiTitle,UiMess) VALUES('oar2c1.jpg','joboa_System_PictureCarousel*Title=OAϵͳ�Ǹ�����ҵ��ʿ��ѡ��������','Ϊ��ҵ�ڲ��칫��߰���Ч��');
INSERT INTO OAUi(UiImg,UiTitle,UiMess) VALUES('40314.jpg','joboa_System_PictureCarousel*Title=OA�򵥹�������','�������̣����ɰ죬�������ɸ㶨');
INSERT INTO OAUi(UiImg,UiTitle,UiMess) VALUES('u1832.jpg','joboa_System_PictureCarousel*Title=����򵥣���Ч�칫','�򵥻���������Ϲ���ϰ�ߣ������Ӿ�Ч����ū��');
INSERT INTO OAUi(UiImg,UiTitle,UiMess) VALUES('yuming.jpg','joboa_System_PictureCarousel*Title=�칫OAϵͳ�����漰��������','����Ա����Ϣά����Ȩ��ά����������������ļ�������Ϣ����');
INSERT INTO OAUi(UiImg,UiTitle,UiMess) VALUES('foundation.png	joboa_System_InfoList*Title=Ϊ�ƶ�����','Amaze UI ���ƶ����ȣ�Mobile first��Ϊ�����С������չ������������ʵ��������Ļ���䣬��Ӧ�ƶ�����������');
INSERT INTO OAUi(UiImg,UiTitle,UiMess) VALUES('web.png','joboa_System_InfoList*Title=����ḻ��ģ�黯','Amaze UI ���� 20 �� CSS �����20 �� JS ��������ж��������ͬ����� Web ������ɿ��ٹ��������ɫ����������Ŀ���ҳ�棬�����������Ч�ʡ�');
INSERT INTO OAUi(UiImg,UiTitle,UiMess) VALUES('chinese.png','joboa_System_InfoList*Title=����ḻ��ģ�黯	��ȹ����ܣ�Amaze UI ��ע�����Ű棬�����û�����������壬ʵ�ָ��õ������Ű�Ч������˹�������������� App �������������֧�֡�');
INSERT INTO OAUi(UiImg,UiTitle,UiMess) VALUES('mobile.png','joboa_System_InfoList*Title=��������������','Amaze UI ���� HTML5 ������ʹ�� CSS3 ��������������ƽ������Ч�����ʺ��ƶ��豸���� Web Ӧ�ø��������롣');
INSERT INTO OAUi(UiImg,UiTitle,UiMess) VALUES(NULL,'joboa_System_FootHead*Title=վ�ھ��˵ļ����','Amaze UI ��ȡ�˺ܶ������������Դ��ͨ����Դ����ʽ������������');
INSERT INTO OAUi(UiImg,UiTitle,UiMess) VALUES(NULL,'joboa_System_FootContent*Title=MIT License','Amaze UI ʹ�� <a href="#" target="_blank">MIT ���֤</a>�������û���������ʹ�á����ơ��޸ġ��ϲ������淢�С�ɢ��������Ȩ������ Amaze UI ���丱����');
INSERT INTO OAUi(UiImg,UiTitle,UiMess) VALUES(NULL,'joboa_System_FootContent*Title=Heroes','<a href="#" target="_blank">�ο���ʹ�õ���Ŀ</a>��jQuery, Zepto.js, Seajs, LESS, normalize.css, FontAwesome, Bootstrap, Foundation, UIKit, Pure, Framework7, etc.');
INSERT INTO OAUi(UiImg,UiTitle,UiMess) VALUES(NULL,'joboa_System_FootContent*Title=Credits','����׷��׿Խ��Ȼʱ�䡢���顢�������ޡ�Amaze UI �кܶ಻��ĵط���ϣ����Ұ��ݡ����ߴͽ̣�����������������顣<a href="#" target="_blank">��л����</a>��');
INSERT INTO OAUi(UiTitle,UiMess) VALUES('joboa_System_Notice*Title=����','ʱ�⾲�ã�����ϸˮ���꣬���ͬ������ Amaze UI');
INSERT INTO OAUi(UiTitle,UiMess) VALUES('joboa_System_Notice*Title=Wiki','Welcome to the Amaze UI wiki!');
GO
--OaMessage��Ϣ
INSERT INTO OAMessage(Title,ExtraMessage,FromEmployeeId,ToEmployeeId,IsLookUp,SendDateTime)
VALUES('�ϰ�����','�ǵ�������������Ŷ����ٵ���Ŷ��',1,1,0,'2016-04-02 10:32:53')
INSERT INTO OAMessage(Title,ExtraMessage,FromEmployeeId,ToEmployeeId,IsLookUp,SendDateTime)
VALUES('�����ύ','�����Ѿ���ɣ�����2016-4-5ǰ������ˣ����ύ��˽����лл��',1,1,0,'2016-04-02 10:36:41')
INSERT INTO OAMessage(Title,ExtraMessage,FromEmployeeId,ToEmployeeId,IsLookUp,SendDateTime)
VALUES('�Ķ���','���æ��ʵϰ�����������ɽ���������Ĺ���Ŷ��',1,1,0,'2016-03-31 10:36:32')
GO