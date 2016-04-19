$(document).ready(function () {
    var regionPhone = $("#UserName").val();//原号码
    var regionEmail = $("#Email").val();//原Email
    var mess = $("#mess").val();//信息显示
    if (mess) {
        var modal = new Modal("JobOA-系统提示","joboa-mess");
        modal.alert(mess);
        $("#mess").val("");
    }
    //计算验证码的有效时间
    var validateTime=function(min){
        $("#get-validate").addClass("am-disabled");
        var i = min*60;//设置几分钟后重新获取
        var interval;
        interval = window.setInterval(function () {
            $("#get-validate").text(i + "秒后重新获取");
            i--;
            if (i < 0) {
                $("#get-validate").removeClass("am-disabled");
                $("#get-validate").text("获取验证码");
                window.clearInterval(interval);
            }
        }, 1000);
    }
    if ($("#validate").val() === "true") {
        validateTime(3);
    }
    /* 实现文件上传 */
    var uploadFile = new UploadFile(".oa-upload", "/PersonalInfo/UploadImg", true, {
        mime_types: [{
            title: 'image files',
            extensions: 'gif,png,jpg,ico'
        }],
        max_file_size: '4096kb',//不能大于4mb
        prevent_duplicates: true //不允许选取重复文件，大小和名字相同
    });
    //绑定事件：点击头像图片，左键应用此图片，右键删除此图片（删除前要提示确认）
    var imgSelect = $(".am-text-nowrap").get(0);
    imgSelect.oncontextmenu = function () {
        return false;
    }
    //给图片绑定左右键点击事件
    var eventFunc = function () {
        $(".am-text-nowrap img").mouseup(function (e) {
            var src = $(this).attr("src");
            var en = window.event || e;
            var value = en.button;
            if (value === 2 || value === 3) {
                //点击右键
                var isSucre = window.confirm("确定要删除服务器的图片吗？\n" + src);
                var self = this;
                if (isSucre) {
                    $.ajax({
                        url: "DelHeadPicture",
                        data: "src="+src,
                        type:"POST",
                        dataType: "json",
                        //beforeSend: function (xhr) {},
                        success: function (data,textStatus) {
                            if (data) {
                                $(self).remove();//移除指定图片，应用最后一张图片
                                var lastSrc = $(".am-text-nowrap img").last().attr("src");
                                if (!lastSrc) lastSrc = "/Content/images/oaui/default.jpg";
                                $("#headPicture").attr("src", lastSrc);
                                $("#head-picture").attr("src", lastSrc);
                            }
                        },
                        complete: function (xhr,textStatus) {
                            if (xhr.status !== 200) {
                                alert("请求删除您指定的头像失败：" + textStatus+"\nHTTP状态码："+xhr.status);
                            }
                        },
                        async:true
                    });
                }
            } else {
                //点击左键
                $("#headImg").attr("src", src);
            }
        });
    }
    eventFunc();
    //每上传完一个图片就重新请求图片进行显示出来
    var callbackFunc = function (responseObj) {
        $.ajax({
            url: "GetHeadPicture",
            type: "POST",
            dataType: "json",
            //beforeSend: function (xhr) {},
            success: function (data, textStatus) {
                if (data) {
                    $(".am-text-nowrap").empty();//移除指定图片，应用最后一张图片
                    var html="";
                    data.forEach(function (headImg,index,data) {
                        html+="<img class=\"am-img-thumbnail\" src=\""+headImg+"\" alt=\"头像\" title=\"点击左键应用，右键删除\" />";
                    });
                    $(".am-text-nowrap").html(html);
                    eventFunc();
                }
            },
            async: true
        });
    }
    uploadFile.fileDialog("browseFile",null,callbackFunc);

    $("form").submit(function () {
        var src=$("#headImg").attr("src");
        var headPictures=new Array();
        $(".am-text-nowrap img").each(function () {
            headPictures.push($(this).attr("src"));
        });
        for (var i = 0; i < headPictures.length; i++) {
            if (headPictures[i] === src) {
                var temp = headPictures[0];
                headPictures[0] = headPictures[i];
                headPictures[i] = temp;
            }
        }
        $("#HeadPicture").val(headPictures.join(","));
    });

    /* 实现获取验证码 */
    //验证手机号和邮箱
    function validateNum(phone, email) {
        if (!(/^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$/).test(phone)) {
            $("#tip-mess").text("您的手机号码格式有误！");
            $("#UserName").focus();
            return false;
        }
        if (email&&!(/^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$/).test(email)) {
            $("#tip-mess").text("您的邮箱格式有误！");
            $("#Email").focus();
            return false;
        }
        var isPass = false;
        if (phone !== regionPhone) {
            $.ajax({
                url: "/Account/CheckUserNameUnique",
                type: "POST",
                data: "userName=" + phone,
                beforeSend: function () {
                    $("#tip-mess").text("开始验证账号（手机号）是否可注册");
                },
                error: function (xhr, textStatus) {
                    $("#tip-mess").text("请求验证出错，http状态码：" + xhr.status + "，请求结果：" + textStatus);
                },
                success: function (data) {
                    if (data.isUnique) {
                        $("#tip-mess").text("");
                        isPass = true;
                    } else {
                        $("#tip-mess").text("已被注册过，请更换账号（手机号）");
                        $("#UserName").focus();
                    }
                },
                dataType: "json",
                async: false
            });
        } else {
            isPass = true;
        }
        return isPass;
    }
    //点击获取验证码，先验证手机号和邮箱，再请求发送验证码给手机或邮箱
    $("#get-validate").click(function () {
        var phone = $("#UserName").val();
        var email = $("#Email").val();
        var phoneCheck = $("#phone-check").val();
        var emailCheck = $("#emailCheck").val();
        if (validateNum(phone, email)) {
            var checkModal = new Modal("请求验证码前的验证提示", "checkModal");
            var confirmFun = function (e) {
                e.data = $("#checkModal").find(".am-modal-prompt-input").val();
                //请求服务器验证验证码是否正确
                $.post("CheckVerificationCode", { 'vaildCode': e.data }, function (data) {
                    var imgTag = $("#checkModal").find(".am-modal-bd img");
                    if (!data.result) {
                        var insertElement = '<span class="am-inline-block am-text-danger" style="margin:0px 10px;">验证码错误</span>';
                        if (imgTag.next("span").length > 0) {
                            imgTag.next("span").replaceWith(insertElement);
                        } else {
                            imgTag.after(insertElement);
                        }
                    } else {
                        if (imgTag.next("span").length > 0) {
                            imgTag.next("span").replaceWith('<span class="am-inline-block am-text-success" style="margin:0px 10px;">验证通过</span>');
                        } else {
                            imgTag.after('<span class="am-inline-block am-text-success" style="margin:0px 10px;">验证通过</span>');
                        }
                        window.setTimeout(function () {
                            $("#checkModal").modal('close');
                        }, 300);
                        //请求服务器发验证码
                        var isSend = false;
                        if (phone !== regionPhone) {
                            $.post("GetVerificationCode", { 'num': phone, 'type': "phone" }, function (data) {
                                if (!isSend) {
                                    validateTime(3);
                                }
                                isSend = true;
                            }, "json");
                        } else {
                            $("#phone-check").val(parseInt(Math.random()*10000));
                        }
                        if (email&&email!==regionEmail) {
                            $.post("GetVerificationCode", { 'num': email, 'type': "email" }, function (data) {
                                if (!isSend) {
                                    validateTime(3);
                                }
                                isSend = true;
                            },"json");
                        } else {
                            $("#emailCheck").val(parseInt(Math.random() * 10000));
                        }
                    }
                }, "json");
            }
            checkModal.prompt('请输入验证码：<img src="GetVerificationImg" onclick="this.src=this.src+\'?\'"/>', "", false, confirmFun);
        }
    });
});