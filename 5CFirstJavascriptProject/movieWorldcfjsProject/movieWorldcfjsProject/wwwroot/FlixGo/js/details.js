$(document).ready(function () {

    var id = $("#movieId").val();

    $.ajax({

        url: "/Home/GetMovieById/" + id,
        type: "GET",
        dataType: "json",

        success: function (item) {

            $("#movieTitle").text(item.title);

            $("#movieImage").attr("src", item.imageUrl);

            $("#movieImdb").html(
                '<i class="icon ion-ios-star"></i> ' + item.imdb
            );

            $("#movieCategory").text(item.category.name);

            $("#movieDirector").text(item.director.fullName);

            $("#movieYear").text(item.releaseYear);

            $("#movieDescription").text(item.description);

        }

    });

});