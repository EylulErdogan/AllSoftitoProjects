$(document).ready(function () {
    LoadMovies();
    LoadCategoriesTable();
    LoadDirectorsTable();
});

function LoadMovies() {
    $.ajax({
        url: '/Admin/MovieList',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var html = '';

            $.each(result, function (index, item) {
                html += `
                <tr>
                    <th>${item.id}</th>
                    <td>
                        <input type="text" id="movieTitle${item.id}" value="${item.title}" class="sign__input">
                    </td>
                    <td>
                        <input type="number" id="movieYear${item.id}" value="${item.releaseYear}" class="sign__input">
                    </td>
                    <td>
                        <input type="text" id="movieImdb${item.id}" value="${item.imdb}" class="sign__input">
                    </td>
                    <td>
                        <button class="filter__btn" onclick="UpdateMovie(${item.id})">Güncelle</button>
                        <button class="filter__btn" onclick="DeleteMovie(${item.id})">Sil</button>
                    </td>
                </tr>`;
            });

            $("#movieTable").html(html);
        }
    });
}

function LoadCategoriesTable() {
    $.ajax({
        url: '/Admin/GetCategories',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var html = '';

            $.each(result, function (index, item) {
                html += `
                <tr>
                    <th>${item.id}</th>
                    <td>
                        <input type="text" id="categoryName${item.id}" value="${item.name}" class="sign__input">
                    </td>
                    <td>
                        <button class="filter__btn" onclick="UpdateCategory(${item.id})">Güncelle</button>
                        <button class="filter__btn" onclick="DeleteCategory(${item.id})">Sil</button>
                    </td>
                </tr>`;
            });

            $("#categoryTable").html(html);
        }
    });
}

function LoadDirectorsTable() {
    $.ajax({
        url: '/Admin/GetDirectors',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var html = '';

            $.each(result, function (index, item) {
                html += `
                <tr>
                    <th>${item.id}</th>
                    <td>
                        <input type="text" id="directorName${item.id}" value="${item.fullName}" class="sign__input">
                    </td>
                    <td>
                        <button class="filter__btn" onclick="UpdateDirector(${item.id})">Güncelle</button>
                        <button class="filter__btn" onclick="DeleteDirector(${item.id})">Sil</button>
                    </td>
                </tr>`;
            });

            $("#directorTable").html(html);
        }
    });
}

function UpdateCategory(id) {
    $.post('/Admin/UpdateCategory', {
        id: id,
        name: $("#categoryName" + id).val()
    }, function () {
        alert("Kategori güncellendi.");
        LoadCategoriesTable();
    });
}

function UpdateDirector(id) {
    $.post('/Admin/UpdateDirector', {
        id: id,
        fullName: $("#directorName" + id).val()
    }, function () {
        alert("Yönetmen güncellendi.");
        LoadDirectorsTable();
    });
}

function DeleteCategory(id) {
    if (confirm("Kategori silinsin mi?")) {
        $.post('/Admin/DeleteCategory', { id: id }, function () {
            alert("Kategori silindi.");
            LoadCategoriesTable();
        });
    }
}

function DeleteDirector(id) {
    if (confirm("Yönetmen silinsin mi?")) {
        $.post('/Admin/DeleteDirector', { id: id }, function () {
            alert("Yönetmen silindi.");
            LoadDirectorsTable();
        });
    }
}

function DeleteMovie(id) {
    if (confirm("Film silinsin mi?")) {
        $.post('/Admin/DeleteMovie', { id: id }, function () {
            alert("Film silindi.");
            LoadMovies();
        });
    }
}