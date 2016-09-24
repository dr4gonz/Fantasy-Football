$(document).ready(function () {
    var newTeam = {
        Name: "",
        LeagueId: "",
        UserId: ""

    };
    $("#newTeamForm").submit(function (event) {
        event.preventDefault();
        newTeam.Name = $("#teamName").val();
        newTeam.LeagueId = $("#LeagueId").val();
        newTeam.UserId = $("#UserId").val();
        console.log(newTeam);
        $.ajax({
            url: '/Leagues/NewTeam',
            type: "POST",
            dataType: 'json',
            data: newTeam,
            error: function(e) {
                console.log(e);
            },
            success: function (result) {
                console.log(result);
                $("#teamList").append('<li><a href="/Teams/Details/' + result.id + '">' + result.name + '</a></li>');
            }
        });
    });
});