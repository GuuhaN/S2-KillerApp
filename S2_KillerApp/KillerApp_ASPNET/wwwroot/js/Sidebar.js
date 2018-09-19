$(document).ready(function () {
    $(".menuBtn").unbind("click").click(function(event) {
        var menuBtnVal = $(this).attr("value");
        SideBarInterfaces($("#mainPartial"), menuBtnVal);
        event.preventDefault();
    });

    $("#openCreateNewPlaylistModal").click(function () {
        OpenModalDetails("create");
    });
})