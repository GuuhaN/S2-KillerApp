$("#confirmSearch").submit(function () {
    GetSearchResults($("#searchTerm").val());
    event.preventDefault();
});

function GetSearchResults(searchTerm) {
    $.ajax({
        url: "/Search/Browse",
        type: "get",
        data: { searchTerm: searchTerm },
        datatype: "json",
        success: function(data) {
            $("#mainPartial").html(data);
        }
    });
}

var songId = 0;
var playlistId = 0;
var modalSongTitle = "";

$(".searchSongResult").click(function() {
    modalSongTitle = $(this).attr("resource");
});

$(".addSongToPlaylist").click(function () {
    songId = $(this).attr("resource");
    $("#modalSongTitle").html(modalSongTitle);
    $("#addSongToPlaylistModal").modal("show");
});

$(".playlistBtn").click(function () {
    playlistId = $(this).attr("resource");
});

$(".modalPlaylistSelect").click(function () {
    $(this).addClass("selected").siblings().removeClass("selected");
});

$("#addSongToPlaylist").unbind("submit").on("submit",
    function () {
        AddSongToPlaylist(songId, playlistId);
        $("#addSongToPlaylistModal").modal("hide");
        $(this).siblings().removeClass("selected");
        event.preventDefault();
    });