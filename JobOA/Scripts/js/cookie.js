var Cookie = (function () {
    /* 设置cookie，time以毫秒为单位
     * @param name cookie的名字
     * @param value cookie的值
     * @param time cookie距离现在的有效时间（毫秒）
     * @return undefined
     */
    function setCookie(name, value, time) {
        var exdate = new Date();
        exdate.setTime(exdate.getTime() + time);//time以毫秒为单位
        //如果时间不为空则设置过期时间
        document.cookie = name + "=" + encodeURIComponent(value) + (time != null ? ";expires=" + exdate.toUTCString() : "");
    }
    /* 获取cookie
     * @param name cookie的名字
     * @return String cookie的值
     */
    function getCookie(name) {
        if (document.cookie.length > 0) {
            var c_start = document.cookie.indexOf(name + "=");
            if (c_start !== -1) {
                c_start = c_start + name.length + 1;
                var c_end = document.cookie.indexOf(";", c_start);
                if (c_end === -1) {
                    c_end = document.cookie.length;
                }
                return decodeURIComponent(document.cookie.substring(c_start, c_end));
            } else {
                return null;
            }
        } else {
            return null;
        }
    }
    /* 删除cookie
     * @return undefined
     */
    function delCookie(name) {
        if (getCookie(name) != null) {
            setCookie(name, "", -6000);//设置一个过期的cookie值
        }
    }
    return {
        setCookie: setCookie,
        getCookie: getCookie,
        delCookie: delCookie
    };
})();