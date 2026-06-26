console.log("custom.js çalıştı");
$(document).ready(function () {
    ShowMovieData();
});

function ShowMovieData() {

    $.ajax({

        url: '/Home/MovieList',
        type: 'GET',
        dataType: 'json',

        success: function (result) {

            var object = '';

            $.each(result, function (index, item) {

                object += `
                <div class="col-6 col-sm-12 col-lg-6">
                    <div class="card card--list">
                        <div class="row">

                            <div class="col-12 col-sm-4">
                                <div class="card__cover">
                                   <a href="/Home/Details/${item.id}">
                                     <img src="${item.imageUrl}" alt="">
                                    </a>
                                  <a href="/Home/Details/${item.id}" class="card__play">
                                        <i class="icon ion-ios-play"></i>
                                    </a>
                                </div>
                            </div>

                            <div class="col-12 col-sm-8">
                                <div class="card__content">

                                    <h3 class="card__title">
                                       <a href="/Home/Details/${item.id}">${item.title}</a>
                                    </h3>

                                    <span class="card__category">
                                        <a href="#">${item.category.name}</a>
                                    </span>

                                    <div class="card__wrap">
                                        <span class="card__rate">
                                            <i class="icon ion-ios-star"></i>
                                            ${item.imdb}
                                        </span>

                                        <ul class="card__list">
                                            <li>HD</li>
                                            <li>${item.releaseYear}</li>
                                        </ul>
                                    </div>

                                    <div class="card__description">
                                        <p>${item.description}</p>
                                    </div>

                                </div>
                            </div>

                        </div>
                    </div>
                </div>`;
            });

            $("#movieList").html(object);
        },

        error: function () {
            alert("Movies could not be loaded.");
        }
    });
}
function SearchMovie() {

    var searchText = $("#searchMovie").val();

    if (searchText.trim() === "") {
        ShowMovieData();
        return;
    }

    $.ajax({
        url: '/Home/SearchMovie',
        type: 'GET',
        dataType: 'json',
        data: { searchText: searchText },

        success: function (result) {
            var object = '';

            $.each(result, function (index, item) {
                object += `
                <div class="col-6 col-sm-12 col-lg-6">
                    <div class="card card--list">
                        <div class="row">
                            <div class="col-12 col-sm-4">
                                 <div class="card__cover">
                                   <a href="/Home/Details/${item.id}">
                                     <img src="${item.imageUrl}" alt="">
                                    </a>
                                  <a href="/Home/Details/${item.id}" class="card__play">
                                        <i class="icon ion-ios-play"></i>
                                    </a>
                                </div>
                            </div>

                            <div class="col-12 col-sm-8">
                                <div class="card__content">
                                    <h3 class="card__title">
                                       <a href="/Home/Details/${item.id}">${item.title}</a>
                                    </h3>

                                    <span class="card__category">
                                        <a href="#">${item.category.name}</a>
                                    </span>

                                    <div class="card__wrap">
                                        <span class="card__rate">
                                            <i class="icon ion-ios-star"></i>
                                            ${item.imdb}
                                        </span>

                                        <ul class="card__list">
                                            <li>HD</li>
                                            <li>${item.releaseYear}</li>
                                        </ul>
                                    </div>

                                    <div class="card__description">
                                        <p>${item.description}</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>`;
            });

            $("#movieList").html(object);
        }
    });
}
$(document).on("keyup", "#searchMovie", function (e) {
    if (e.key === "Enter") {
        SearchMovie();
    }
});