JNV.factory('LoginFactory', ['$http', 'JNV_Constants', function ($http, JNV_Constants) {

    return {
        LoginUser: function (userObj) {

            url = JNV_Constants.BaseApiUrl + "UserValidate/";
            return $http.post(url, userObj);
        },
    };
}]);