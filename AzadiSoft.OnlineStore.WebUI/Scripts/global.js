function ajaxCall(url, data, method, successFn, failFn) {

    $.ajax({
        type: method,
        url: url,
        data: data,
        success: function(data, status, xhr) {
            debugger;
            if (successFn) {
                successFn(data);
            }
        },
        error: function(jqXhr, textStatus, errorMessage) {
            debugger;

            if (failFn) {
                failFn(errorMessage);
            }
        },
        
    });

}