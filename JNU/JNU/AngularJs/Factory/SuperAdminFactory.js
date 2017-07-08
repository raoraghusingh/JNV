JNV.factory('SuperAdminFactory', ['$http', 'JNV_Constants', function ($http, JNV_Constants) {

    var Adminfactory = {};

    Adminfactory.AddNewAdmin = function (data) {
        return $http.post(JNV_Constants.BaseAdminUrl + "AdminRegistration/", data, {
            withCredentials: true,
            headers: { 'Content-Type': undefined },
            transformRequest: angular.identity
        })
    }
    Adminfactory.GetAdmin = function () {
        return $http.get(JNV_Constants.BaseAdminUrl + "GetAdminDetails/", {
           
        })
    }
    Adminfactory.GetAdminByID = function (ID) {
        return $http.get(JNV_Constants.BaseAdminUrl + "GetAdminDetailsByID/"+ID, {

        })
    }
    Adminfactory.DeleteAdmin = function (ID) {
        return $http.get(JNV_Constants.BaseAdminUrl + "DeleteAdmin/" + ID, {

        })
    }

    return Adminfactory;
}]);