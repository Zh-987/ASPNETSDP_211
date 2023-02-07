$(document).ready(function () {
    //LogIn
    $('#btnLogin').click(function () {
        var nickName = ('#txtUserName').val();
        if (nickName) {
            var href = "/Chat?user" + encodeURIComponent(nickName);
            href = href + "&logOn=true";
            $('#LoginButton').attr("href", href).click();
            $('#UserName').text(nickName);
        }
    });
});

function Refresh() {
    var href = "/Chat?user=" + encodeURIComponent($'#UserName').text();
}

function ChatOnFailure() {
    $('#Error').text(result.responseText);
    setTimeout("$'#Error'.empty()", 2000);
}
function ChatOnSuccess() {
    Scroll();
    ShowLastRefresh();
}

function Scroll() {
    var win = $('#Message')
    var height = win[0].scrollHeight;
    win.scrollTop(height)
}
function ShowLastRefresh() {
    var dt = new Date();
    var time = dt.getHours() + ":" + dt.getMinutes + ":" + dt.getSeconds;
    $('#LastRefresh').text("Last update :" + time);
}
