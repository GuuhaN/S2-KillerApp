$(".songBtn").on("click", function () {
    PlayMusic($(this).val(), false);
});

$("#openDeleteModal").click(function() {
    OpenModalDetails("delete");
});

$("#openEditModal").click(function () {
    OpenModalDetails("edit");
});

