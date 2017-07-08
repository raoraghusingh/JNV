JNV.controller("AdminLoginController", ['$scope', function ($scope) {
    $scope.users = {};
    $scope.login = function () {
      
        $state.go("AdminDashboard.Home");
    }

}]);

JNV.controller("AdminDashboardController", ['$scope', function ($scope) {



}]);

JNV.controller("AdminhomeController", ['$scope', function ($scope) {



}]);

JNV.controller("AdminManagerFacultyController", ['$scope', function ($scope) {



}]);




