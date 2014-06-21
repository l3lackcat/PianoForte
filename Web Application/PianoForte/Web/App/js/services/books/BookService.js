'use strict';

goog.provide('PianoForte.Services.BookService');

PianoForte.Services.BookService = function ($http) {
    var databaseName = 'pianoforte_b01';
    
    return {
        getBookList: function (onSuccess, onError) {
            var data = {
                databaseName: databaseName
            };

            $http.post('/WebServices/BookWebService.asmx/getBookList', data).success(onSuccess).error(onError);
        }
    }
};