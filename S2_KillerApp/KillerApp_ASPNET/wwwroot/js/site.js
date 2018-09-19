var playlistPos = 0;
var allPlaylistSongs, initializedPlaylistSongs;

var menuBtnVal = "";

var mySound;

$(document).ready(function () {
    RenderSideBar($("#sideBar"));
    $(".playpause").click(function() {
        PauseResumeMusic();
    });
});

// -- VOLUME SLIDER -- 
$("#volumeSlider").on("input",
    function() {
        mySound.setVolume($(this).val());
    });

// -- GETS SONGS IN PLAYLIST --
function GetPlaylistSongs() {
    allPlaylistSongs.clear();
    allPlaylistSongs.add($(".songBtn").val());
    alert(allPlaylistSongs[0]);
}

// -- PLAY MUSIC --
function PlayMusic(songname, shuffle) {
    var songUrl = "";

    if (mySound != null) {
        mySound.unload("mainSound");
    }

    if (allPlaylistSongs != null)
        songUrl = "/Songs/" + $(allPlaylistSongs[playlistPos]).val() + ".mp3";
    else {
        allPlaylistSongs = initializedPlaylistSongs;
        songUrl = "/Songs/" + $(initializedPlaylistSongs[playlistPos]).val() + ".mp3";
    }
    if (shuffle) {
        playlistPos = Math.floor(Math.random() * allPlaylistSongs.length);
        songname = $(allPlaylistSongs[playlistPos]).val();
    }
    if (songname !== "") {
        allPlaylistSongs = initializedPlaylistSongs;
        songUrl = "/Songs/" + songname + ".mp3";
        for (var i = 0; i < allPlaylistSongs.length; i++) {
            if ($(allPlaylistSongs[i]).val() === songname) {
                playlistPos = i;
            }
        }
    }

    mySound = soundManager.createSound({
        id: "mainSound",
        onplay: function() {
            $("#playpauseIcon").removeClass("glyphicon-play");
            $("#playpauseIcon").addClass("glyphicon-pause");
        },
        onfinish:
        function () {
                NextSong();
            }
    });

    mySound.unload("mainSound");
    mySound.url = songUrl;
    $("#barSongTitle").html($(allPlaylistSongs[playlistPos]).val());
    mySound.load();
    mySound.play();
}

// -- RESUMES AND PAUSES MUSIC THAT IS PLAYING
function PauseResumeMusic() {
    if (!mySound.paused) {
        mySound.pause();
        $("#playpauseIcon").removeClass("glyphicon-pause");
        $("#playpauseIcon").addClass("glyphicon-play");
    }
    else {
        mySound.play();
        $("#playpauseIcon").removeClass("glyphicon-play");
        $("#playpauseIcon").addClass("glyphicon-pause");
    }
}

// -- GOES NEXT SONG IN THE PLAYLIST -- 
function NextSong() {
    if (playlistPos < allPlaylistSongs.length - 1)
        playlistPos++;
    else
        playlistPos = 0;

    PlayMusic("", false);
}

// -- GOES PREVIOUS SONG IN THE PLAYLIST -- 
function PreviousSong() {
    if (playlistPos < allPlaylistSongs.length - 1 && playlistPos <= 0)
        playlistPos = allPlaylistSongs.length - 1;
    else if (playlistPos <= allPlaylistSongs.length - 1 && playlistPos > 0)
        playlistPos--;

    PlayMusic("", false);
}
// -- OPENS CORRESPONDING MODAL --
function OpenModalDetails(mdlType) {
    var value = 0;
    if (!mdlType.includes("create"))
        value = $("#dropdownPlaylist").attr("value");

    ModalDetails(value, mdlType);
}

// -- CREATES SIDE BAR INFORMATION AJAX FUNCTION
function SideBarInterfaces(div, btnVal) {
    $.ajax({
        url: "/SideBar/SideBarActions",
        type: "get",
        data: { menuBtnVal: btnVal },
        datatype: "json",
        success: function (data) {
            $(div).html(data);
            initializedPlaylistSongs = $(document).find(".songBtn");
        }
    });
}

// -- RENDERS SIDE BAR AJAX FUNCTION
function RenderSideBar(div) {
    $.ajax({
        url: "/SideBar/RenderSideBar",
        type: "get",
        datatype: "json",
        success: function (data) {
            $(div).html(data);
        }
    });
}

// -- ADD SONGS TO PLAYLIST AJAX FUNCTION -- 
function AddSongToPlaylist(songId, pId) {
    $.ajax({
        url: "/Playlist/AddSongToPlaylist",
        type: "post",
        data: {songId: songId, playlistId: pId},
        datatype: "json",
        success: function () {
            RenderSideBar($("#sideBar"));
            event.preventDefault();
        }
    });
}

// -- CREATE NEW PLAYLIST AJAX FUNCTION -- 
function CreateNewPlaylist(div) {
    $.ajax({
        url: "/Playlist/CreatePlaylist",
        type: "post",
        data: $(div).serialize(),
        datatype: "json",
        success: function() {
            RenderSideBar($("#sideBar"));
        }
    });
}

// -- UPDATE PLAYLIST AJAX FUNCTION --
function UpdatePlaylist(pId, div) {
    $.ajax({
        url: "/Playlist/UpdatePlaylist",
        type: "post",
        data: $(div).serialize() + "&playlistId=" + pId,
        datatype: "json",
        success: function () {
            RenderSideBar($("#sideBar"));
            SideBarInterfaces($("#mainPartial"), "playlist " + pId);
        }
    });
}

// -- DELETE PLAYLIST AJAX FUNCTION -- 
function DeletePlaylist(pId) {
    $.ajax({
        url: "/Playlist/DeletePlaylist",
        type: "post",
        data: { playlistId: pId },
        datatype: "json",
        success: function () {
            RenderSideBar($("#sideBar"));
        }
    });
}

// Shows all modals 
function ModalDetails(pId, mdlType) {

    $.ajax({
        url: "/Playlist/ModalDetails",
        type: "post",
        data: { playlistId: pId, modalType: mdlType },
        datatype: "json",
        success: function(data) {
            $("#detailsModal").html(data);

            // -- CREATE PLAYLIST MODAL --
            if (mdlType.includes("create")) {
                $("#createPlaylistModal").modal("show");
                $("#detailsModal").find("#createPlaylist").unbind("submit").on("submit", function () {
                    CreateNewPlaylist(this);
                    $("#createPlaylistModal").modal("hide");
                    event.preventDefault();
                });
            }
            // -- EDIT PLAYLIST MODAL --
            else if (mdlType.includes("edit")) {
                $("#editPlaylistModal").modal("show");
                $("#detailsModal").find("#editPlaylist").unbind("submit").on("submit", function () {
                    UpdatePlaylist(pId, this);
                    $("#editPlaylistModal").modal("hide");
                    event.preventDefault();
                });
            }

            // -- DELETE PLAYLIST MODAL --
            else if (mdlType.includes("delete")) {
                $("#deletePlaylistModal").modal("show");
                $("#detailsModal").find("#deletePlaylist").on("submit", function () {
                    DeletePlaylist(pId);
                    $("#deletePlaylistModal").modal("hide");
                });
            }
        }
    });
}