$(function () {
    /*
    * 显示在输入框后面的提示信息
    * @param {Object} $input 输入框jquery对象
    * @param {String} mess 显示的提示信息
    * @param {Boolean} isred 是否红色字体显示，默认是红色
    * @returns undefined 
    */
    function showMess($input,mess,isred){
        if ($input.next("span").length < 1) {
            $input.after("<span></span>");
        }
        if (typeof(isred)==="undefined"||isred) {
            $input.next("span").replaceWith("<span class=\"am-text-danger\">" + mess + "</span>");
        } else {
            $input.next("span").replaceWith("<span class=\"am-text-success\">" + mess + "</span>");
        }
    }
    var id, name;
    //点击新增部门
    $("#add-department").click(function () {
        var modal = new Modal("新增部门", "addDepartment");
        var confirm = function () {
            var $input=$("#addDepartment").find("input")
            var departmentVal = $input.val();
            if(departmentVal){
                location.href = "AddDepartment?departName=" + departmentVal;
            } else {
                showMess($input, "部门信息不能为空");
            }
        }
        modal.prompt("请输入新部门名称：","",false,confirm);
    });
    $(".update-department").click(function () {
        var $tr = $(this).parents("tr:first");
        id = $tr.children("td:first").text();
        var depName = $tr.children("td:eq(1)").text();
        var modal = new Modal("更新部门", "updateDepartment");
        var confirm = function () {
            var $input = $("#updateDepartment").find("input");
            name = $input.val();
            if (name) {
                location.href = "UpdateDepartment?Id="+id+"&Name="+name;
            } else {
                showMess($input, "部门信息不能为空！");
            }
        }
        modal.prompt("请输入新部门名称：", depName, false, confirm);
    });

    $(".del-department").click(function () {
        var $tr = $(this).parents("tr:first");
        id = $tr.children("td:first").text();
        name = $tr.children("td:eq(1)").text();
        var modal = new Modal("删除部门", "delDepartment");
        var confirm = function () {
            location.href = "DelDepartment?departmentId="+id;
        }
        modal.confirm("确定要删除部门：" + name + "?", true, confirm);
    });
});