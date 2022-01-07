class BookmarksCreatePage {

    constructor() {
    }

    init(categoriesInputid) {
        $('input#' + categoriesInputid).typeahead({},
            {
                name: 'categories',
                display: 'name',
                source: function (query, syncResults, asyncResults) {
                    $.get('/api/categories/search?query=' + query, function (data) {
                        asyncResults(data);
                    });
                }
            });

    }

}
