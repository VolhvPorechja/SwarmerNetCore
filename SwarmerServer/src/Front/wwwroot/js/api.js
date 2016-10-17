var api = {
    callapi: function(url, request, onSuccess, onFail) {
        $.ajax({
                url: "api/" + url.trimLeft("/"),
                type: "POST",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                data: JSON.stringify(request)
            })
            .success(onSuccess)
            .fail(onFail);
    },
    login: function(request, onSuccess, onFail) {
        this.callapi("login", request, onSuccess, onFail);
    },

    presignup: function(request, onSuccess, onFail) {
        this.callapi("presignup", request, onSuccess, onFail);
    },

    signup: function(request, onSuccess, onFail) {
        this.callapi("signup", request, onSuccess, onFail);
    }
}