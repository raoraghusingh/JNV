JNV.controller("LoginController", ['$scope', function ($scope) {
    $scope.users = {};
    $scope.Login= function ($scope)
    {
        $state.go("home.public");
    }
     
}]);
JNV.controller("HomeController", ['$scope', function ($scope) {

    $scope.actioncategory = 'Dashboard';
    //alert("home controller");

}]);
JNV.controller("PostController", ['$scope', function ($scope) {

    //alert("Post controller");

}]);