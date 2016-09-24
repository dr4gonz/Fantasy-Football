$(document).ready(function () {
    var playerInfo = {
        PlayerId: null,
        TeamId: null
    };
    $("#assignPlayer").submit(function (event) {
        event.preventDefault();
        playerInfo.PlayerId = parseInt($("#Players").val());
        playerInfo.TeamId = parseInt($("#teamId").val());
        console.log(playerInfo);
        $.ajax({
            url: '/Teams/Assign',
            type: "POST",
            dataType: 'json',
            data: playerInfo,
            error: function (e) {
                console.log(e);
            },
            success: function (result) {
                $("#playerTable").append('<tr><td>' + result.name +'</td><td>' + result.position + '</td></tr>');
            }

        });
    });
});