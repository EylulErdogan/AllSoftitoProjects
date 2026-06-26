$(document).ready(function () {
    ShowMovieData();
    LoadCategories();
    LoadDirectors();
});

function ShowMovieData() {

    $.ajax({
        url: '/Admin/MovieList',
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
                                    <img src="${item.imageUrl}" alt="">
                                    <a href="#" class="card__play">
                                        <i class="icon ion-ios-play"></i>
                                    </a>
                                </div>
                            </div>

                            <div class="col-12 col-sm-8">
                                <div class="card__content">

                                    <h3 class="card__title">
                                        <a href="#">${item.title}</a>
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
            alert("Filmler yüklenemedi.");
        }
    });
}

function LoadCategories() {

    $.ajax({
        url: '/Admin/GetCategories',
        type: 'GET',
        dataType: 'json',

        success: function (result) {

            $("#categoryId").empty();
            $("#categoryId").append('<option value="">Kategori Seçiniz</option>');

            $.each(result, function (index, item) {
                $("#categoryId").append(
                    `<option value="${item.id}">${item.name}</option>`
                );
            });
        }
    });
}

function LoadDirectors() {

    $.ajax({
        url: '/Admin/GetDirectors',
        type: 'GET',
        dataType: 'json',

        success: function (result) {

            $("#directorId").empty();
            $("#directorId").append('<option value="">Yönetmen Seçiniz</option>');

            $.each(result, function (index, item) {
                $("#directorId").append(
                    `<option value="${item.id}">${item.fullName}</option>`
                );
            });
        }
    });
}

function AddMovie() {

    var movie = {
        title: $("#title").val(),
        description: $("#description").val(),
        imageUrl: $("#imageUrl").val(),
        releaseYear: parseInt($("#releaseYear").val()),
        imdb: parseFloat($("#imdb").val()),

        categoryId: $("#categoryId").val() ? parseInt($("#categoryId").val()) : null,
        newCategoryName: $("#newCategoryName").val(),

        directorId: $("#directorId").val() ? parseInt($("#directorId").val()) : null,
        newDirectorName: $("#newDirectorName").val()
    };

    $.ajax({
        url: '/Admin/AddMovie',
        type: 'POST',
        data: JSON.stringify(movie),
        contentType: 'application/json; charset=utf-8',

        success: function () {
            alert("Film başarıyla eklendi.");

            ShowMovieData();
            LoadCategories();
            LoadDirectors();

            $("#title").val("");
            $("#description").val("");
            $("#imageUrl").val("");
            $("#releaseYear").val("");
            $("#imdb").val("");
            $("#categoryId").val("");
            $("#newCategoryName").val("");
            $("#directorId").val("");
            $("#newDirectorName").val("");
        },

        error: function () {
            alert("Film eklenirken hata oluştu.");
        }
    });
}