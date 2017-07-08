var JNV = angular.module('JNV', ['ui.router']);
JNV.constant("JNV_Constants", {
    "BaseApiUrl": "http://localhost:11308/api/Login/",
     "BaseAdminUrl": "http://localhost:11308/api/SuperAdmin/"
})
JNV.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/');

    $stateProvider

        // HOME STATES AND NESTED VIEWS ========================================
        .state('/', {
            url: '/',
            templateUrl: 'HTMLPages/Login.html',
            controller: "LoginController"
        })
        // nested list with custom controller
        .state('home', {
            url: '/home',
            templateUrl: 'HTMLPages/Home.html',
            controller:"HomeController"
        })

        // nested list with just some random string data
        .state('home.public', {
            url: '/Public',
            templateUrl: 'HTMLPages/Public.html',
            controller: "PostController"
        })
     .state('home.gallery', {
         url: '/Gallery',
         templateUrl: 'HTMLPages/Gallary.html',
         controller: "PostController"
     })

    // super admin routing 
       .state('/SuperAdmin', {
           url: '/SuperAdmin',
           templateUrl: 'SuperAdminHtml/SuperAdminLogin.html',
           controller: "SuperAdminLoginController"
       })
     .state('/Dashboard', {
         url: '/Dashboard',
         templateUrl: 'SuperAdminHtml/SuperDashboard.html',
         controller: "SADashboardController"
     })
    //.state('/Dashboard.Home', {
    //    url: '/Home',
    //    templateUrl: 'SuperAdminHtml/SAhome.html',
    //    controller: "SAhomeController"
    //})
      
    .state('/Dashboard.ManageUser', {
        url: '/ManageUser',
        templateUrl: 'SuperAdminHtml/ManageUser.html',
        controller: "SAManagerController"
    })

        //duper admin
        .state('/DashboardNew', {
            url: '/DashboardNew',
            templateUrl: 'SuperAdminHtml/DAdmin.html',
            controller: "SADashboardController"
        })
    .state('/DashboardNew.Home', {
        url: '/Home',
        templateUrl: 'SuperAdminHtml/SAhome.html',
        controller: "SAhomeController"
    })

    .state('/DashboardNew.ManageUser', {
        url: '/ManageUser',
        templateUrl: 'SuperAdminHtml/ManageUser.html',
        controller: "SAManagerController"
    })
        // end
    .state('/Dashboard.Notification', {
        url: '/Notification',
        templateUrl: 'SuperAdminHtml/Notification.html',
        controller: "SANotificationController"
    })
     .state('/Dashboard.AddAdmin', {
         url: '/AddAdmin',
         templateUrl: 'SuperAdminHtml/AddAdmin.html',
         controller: "AddAdminController"
     })



    //end

    // admin routing start

    // super admin routing 
       .state('/Admin', {
           url: '/Admin',
           templateUrl: 'AdminHtml/AdminLogin.html',
           controller: "AdminLoginController"
       })
     .state('/AdminDashboard', {
         url: '/AdminDashboard',
         templateUrl: 'AdminHtml/AdminDashboard.html',
         controller: "AdminDashboardController"
     })
    .state('/AdminDashboard.Home', {
        url: '/Home',
        templateUrl: 'AdminHtml/Adminhome.html',
        controller: "AdminhomeController"
    })
    .state('/AdminDashboard.ManageFaculty', {
        url: '/ManageFaculty',
        templateUrl: 'AdminHtml/ManageFaculty.html',
        controller: "AdminManagerFacultyController"
    })
    

    //end


        // ABOUT PAGE AND MULTIPLE NAMED VIEWS =================================
        //.state('about', {
        //    url: '/about',
        //    views: {
        //        '': { templateUrl: 'partial-about.html' },
        //        'columnOne@about': { template: 'Look I am a column!' },
        //        'columnTwo@about': {
        //            templateUrl: 'table-data.html',
        //            controller: 'scotchController'
        //        }
        //    }

        //});

});

JNV.directive('ngFiles', ['$parse', function ($parse) {

    function fn_link(scope, element, attrs) {

        var onChange = $parse(attrs.ngFiles);

        element.on('change', function (event) {
            onChange(scope, { $files: event.target.files });
        });
        element.on('dragover', function (e) {
            e.preventDefault();
            e.stopPropagation();
        });
        element.on('dragenter', function (e) {
            e.preventDefault();
            e.stopPropagation();
        });
        element.on('drop', function (e) {
            e.preventDefault();
            e.stopPropagation();
            if (e.originalEvent.dataTransfer) {
                if (e.originalEvent.dataTransfer.files.length > 0) {
                    //upload(e.originalEvent.dataTransfer.files);
                    onChange(scope, { $files: e.originalEvent.dataTransfer.files });
                }
            }
            return false;
        });

    };

    return {
        link: fn_link
    }
}]);


