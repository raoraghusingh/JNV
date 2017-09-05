JNV.controller("AdminLoginController", ['$scope', function ($scope) {
    $scope.users = {};
    $scope.login = function () {

        //$state.go("AdminDashboard.Home");
        window.location = "#!/AdminDashboard/Home";
    }

}]);

JNV.controller("AdminDashboardController", ['$scope', function ($scope) {



}]);

JNV.controller('AdminhomeController', ['$scope', 'AdminFactory', '$rootScope', '$compile', function ($scope, AdminFactory, $rootScope, $compile) {

    AdminFactory.GetBirthdays(1).then(function (data) {
        var responsedata = data.data;
        $('#ulBirthdays').html("");

        var tabledatabody = '';
        if (responsedata.length) {
            for (var i = 0; i < responsedata.length; i++) {

                tabledatabody += '<li class="item"><div class="product-img"><img src="dist/img/default-50x50.gif" alt="Product Image"></div>';
                tabledatabody += '<div class="product-info"><a class="product-title">' + responsedata[i].Name + '<span class="pull-right"><i class="fa fa-birthday-cake"></i></span></a>';
                //tabledatabody += '<div class="product-info"><a href="javascript:void(0)" class="product-title">' + responsedata[i].Name + '<span class="pull-right"><i class="fa fa-birthday-cake"></i></span></a>';
                tabledatabody += '<span class="product-description">Birthday Today.</span></div></li>';
            }
        }
        else {
            tabledatabody = 'No Birthdays for today.';
        }
        
        $("#ulBirthdays").html(tabledatabody);
        $('.box-body').unblock();
    });

}]);


// About Us Started

JNV.controller('AboutUsController', ['$scope', 'AdminFactory', '$rootScope', function ($scope, AdminFactory, $rootScope) {
    $scope.vAboutUs = {};
    var data = new FormData();

    AdminFactory.GetAboutUs("1").then(function (response) {
        $scope.vAboutUs.AboutUsID = response.data[0].About_Us_ID;
        $scope.vAboutUs.AboutUs = response.data[0].About_Us;
        $scope.vAboutUs.CityID = response.data[0].City_ID;
    })
    debugger;
    $scope.Submit = function (valid) {
        debugger;

        if (valid) {

            //$scope.vAboutUs.aboutUs_Id = $scope.vAboutUs.aboutUs_Id;
            //$scope.vAboutUs.aboutUs = $scope.vAboutUs.aboutUs
            //$scope.vAboutUs.aboutUs_City = $scope.vAboutUs.aboutUs_City;

            angular.forEach($scope.vAboutUs, function (value, key) {

                data.append(key, value);
            });

            AdminFactory.AddAboutUs(data).then(function (response) {
                console.log(response);
                swal("About us  Saved", "", "success");
                DisplayAboutUs();
            }, function () {
                swal("About us  Saved", "", "success");
                DisplayAboutUs();
            });
        }
        else {
            $scope.submitted = true;
        }

    };

}]);

function EditAboutUS() {
    $("#editAbooutUs").attr("style", "display:block");
    $("#displayAbooutUs").attr("style", "display:none");
}

function DisplayAboutUs() {
    $("#editAbooutUs").attr("style", "display:none");
    $("#displayAbooutUs").attr("style", "display:block");
}

// About Us Ended

//Faculty Started

JNV.controller('FacultyController', ['$scope', 'AdminFactory', '$rootScope', '$compile', function ($scope, AdminFactory, $rootScope, $compile) {
    debugger;
    LoadFaculties();

    $scope.EditFaculty = function (FacultyID) {
        debugger;
        $rootScope.FacultyID = FacultyID;

        window.location = "#!/AdminDashboard/AddFaculty"
    }

    $scope.DeleteFaculty = function (FacultyID) {

        swal({
            title: 'Delete Faculty?',
            text: "Sure you want to delete this faculty?",
            type: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes'
        }, function () {
            $('.box-body').block({
                message: '<img src="dist/img/loading.gif" style="height:74px"></img>'

            });
            AdminFactory.DeleteFaculty(FacultyID).then(function (response) {
                debugger;
                console.log(response);
                $('.box-body').unblock();
                LoadFaculties();
                swal(
                    'Deleted!',
                    'Faculty has been deleted.',
                    'success'
                  )
            }, function () {
                $('.box-body').unblock();
                LoadFaculties();
                swal(
                   'Deleted!',
                   'Faculty has been deleted.',
                   'success'
                 )
            });
        })
    }
    function LoadFaculties() {
        debugger;
        $('.box-body').block({
            message: '<img src="dist/img/loading.gif" style="height:74px"></img>'

        });
        AdminFactory.GetFaculties(1).then(function (data) {
            var responsedata = data.data;
            $('#tblFaculty').DataTable().destroy();
            $("#tblFaculty tbody").empty();

            var tabledatabody = '';
            for (var i = 0; i < responsedata.length; i++) {

                tabledatabody += '<tr>';
                tabledatabody += ' <td>' + responsedata[i].Teacher_Name + '</td>';
                tabledatabody += ' <td>' + responsedata[i].Email + '</td>';
                tabledatabody += ' <td>' + responsedata[i].Phone + '</td>';
                tabledatabody += ' <td>' + responsedata[i].School + '</td>';
                tabledatabody += ' <td>' + responsedata[i].Subject + '</td>';
                tabledatabody += ' <td><a href="javascript:void(0)"  ng-click="EditFaculty(' + responsedata[i].Teacher_ID + ')"> Edit <i class="fa fa-edit"></i></a></td>';
                tabledatabody += ' <td><a href="javascript:void(0)" ng-click="DeleteFaculty(' + responsedata[i].Teacher_ID + ')">Delete <i class="fa fa-remove"></i></a></td>';
                tabledatabody += ' </tr>';
            }
            var tempatbledata = $compile(tabledatabody)($scope);
            $("#tblFaculty tbody").append(tempatbledata);
            $.fn.dataTable.ext.errMode = 'none';
            $('#tblFaculty').DataTable({
                "paging": true,
                "lengthChange": false,
                "searching": true,
                "ordering": true,
                "info": true,
                "autoWidth": false,
                "responsive": true
            });
            $('.box-body').unblock();
        }, function () {
            $('.box-body').unblock();
            alert("error occured");
        });
    }

}]);

JNV.controller('AddFacultyController', ['$scope', 'AdminFactory', '$rootScope', function ($scope, AdminFactory, $rootScope) {

    $scope.faculty = {}
    $scope.readonlyemail = false;
    var data = new FormData();

    $scope.faculty.CityList = [
       { name: 'Ajmer', value: '1' },
       { name: 'Alwar', value: '2' },

    ];
    $scope.faculty.City_ID = $scope.faculty.CityList[0];
    $scope.faculty.StateList = [
        { name: 'Rajasthan', value: '1' }
    ];
    $scope.faculty.State_ID = $scope.faculty.StateList[0];

    if ($rootScope.FacultyID != undefined && $rootScope.FacultyID > 0) {
        $('#addFacultyForm').block({
            message: '<img src="dist/img/loading.gif" style="height:74px"></img>'

        });
        $scope.readonlyemail = true;
        data.append("FacultyID", $rootScope.FacultyID);

        AdminFactory.GetFaculty($rootScope.FacultyID).then(function (response) {
            var responsedata = response.data;
            for (var i = 0; i < responsedata.length; i++) {
                debugger;
                $scope.faculty.Teacher_ID = responsedata[i].Teacher_ID;
                $scope.faculty.Teacher_Name = responsedata[i].Teacher_Name;
                $scope.faculty.Email = responsedata[i].Email;
                $scope.faculty.Phone = responsedata[i].Phone;
                $scope.faculty.School = responsedata[i].School;
                $scope.faculty.Subject = responsedata[i].Subject;
                $scope.faculty.City_ID = $scope.faculty.CityList[(responsedata[i].City_ID - 1)];
                $scope.faculty.State_ID = $scope.faculty.StateList[(responsedata[i].State_ID - 1)];

                $('#addFacultyForm').unblock();

            }
        }, function () {
            $('#addFacultyForm').unblock();
        });
    } else { data.append("FacultyID", 0); }

    // Submit Forn data
    $scope.Submit = function (valid) {
        debugger;
        if (valid) {
            $('#addFacultyForm').block({
                message: '<img src="dist/img/loading.gif" style="height:74px"></img>'
            });

            $scope.faculty.City_ID = $scope.faculty.City_ID.value;
            $scope.faculty.State_ID = $scope.faculty.State_ID.value;

            angular.forEach($scope.faculty, function (value, key) {

                data.append(key, value);
            });

            AdminFactory.AddUpdateFaculty(data).then(function (response) {
                console.log(response);
                $('#addFacultyForm').unblock();
                swal("Faculty saved successfully", "", "success");
                window.location = "#!/AdminDashboard/ManageFaculty";
            }, function () {
                $('#addFacultyForm').unblock();
                swal("Faculty saved successfully", "", "success");
                window.location = "#!/AdminDashboard/ManageFaculty";
            });
        }
        else {
            $scope.submitted = true;
        }

    };

}]);

// Faculty Ended

//Events Started

JNV.controller('EventController', ['$scope', 'AdminFactory', '$rootScope', '$compile', '$filter', function ($scope, AdminFactory, $rootScope, $compile, $filter) {
    debugger;
    LoadEvents();

    $scope.EditEvent = function (EventID) {
        debugger;
        $rootScope.EventID = EventID;

        window.location = "#!/AdminDashboard/AddEvent"
    }

    $scope.DeleteEvent = function (EventID) {

        swal({
            title: 'Delete Event?',
            text: "Sure you want to delete this Event?",
            type: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes'
        }, function () {
            $('.box-body').block({
                message: '<img src="dist/img/loading.gif" style="height:74px"></img>'

            });
            AdminFactory.DeleteEvent(EventID).then(function (response) {
                debugger;
                console.log(response);
                $('.box-body').unblock();
                LoadEvents();
                swal(
                    'Deleted!',
                    'Event has been deleted.',
                    'success'
                  )
            }, function () {
                $('.box-body').unblock();
                LoadEvents();
                swal(
                   'Deleted!',
                   'Event has been deleted.',
                   'success'
                 )
            });
        })
    }
    function LoadEvents() {
        debugger;
        $('.box-body').block({
            message: '<img src="dist/img/loading.gif" style="height:74px"></img>'

        });
        AdminFactory.GetEvents(1).then(function (data) {
            var responsedata = data.data;
            $('#tblEvent').DataTable().destroy();
            $("#tblEvent tbody").empty();

            var tabledatabody = '';
            for (var i = 0; i < responsedata.length; i++) {

                tabledatabody += '<tr>';
                tabledatabody += ' <td>' + responsedata[i].Event_Name + '</td>';
                tabledatabody += ' <td>' + $filter('date')(responsedata[i].Event_Date, "dd/MM/yyyy") + '</td>';
                tabledatabody += ' <td><a href="javascript:void(0)"  ng-click="EditEvent(' + responsedata[i].Event_ID + ')"> Edit <i class="fa fa-edit"></i></a></td>';
                tabledatabody += ' <td><a href="javascript:void(0)" ng-click="DeleteEvent(' + responsedata[i].Event_ID + ')">Delete <i class="fa fa-remove"></i></a></td>';
                tabledatabody += ' </tr>';
            }
            var tempatbledata = $compile(tabledatabody)($scope);
            $("#tblEvent tbody").append(tempatbledata);
            $.fn.dataTable.ext.errMode = 'none';
            $('#tblEvent').DataTable({
                "paging": true,
                "lengthChange": false,
                "searching": true,
                "ordering": true,
                "info": true,
                "autoWidth": false,
                "responsive": true
            });
            $('.box-body').unblock();
        }, function () {
            $('.box-body').unblock();
            alert("error occured");
        });
    }

}]);

JNV.controller('AddEventController', ['$scope', 'AdminFactory', '$rootScope', '$filter', function ($scope, AdminFactory, $rootScope, $filter) {

    $scope.event = {}
    var data = new FormData();

    $scope.event.CityList = [
       { name: 'Ajmer', value: '1' },
       { name: 'Alwar', value: '2' },

    ];
    $scope.event.City_ID = $scope.event.CityList[0];

    if ($rootScope.EventID != undefined && $rootScope.EventID > 0) {
        $('#addEventForm').block({
            message: '<img src="dist/img/loading.gif" style="height:74px"></img>'

        });
        $scope.readonlyemail = true;
        data.append("EventID", $rootScope.EventID);

        AdminFactory.GetEvent($rootScope.EventID).then(function (response) {
            var responsedata = response.data;
            for (var i = 0; i < responsedata.length; i++) {
                debugger;
                $scope.event.Event_ID = responsedata[i].Event_ID;
                $scope.event.Event_Name = responsedata[i].Event_Name;
                $scope.event.Event_Date = new Date(responsedata[i].Event_Date);
                $scope.event.City_ID = $scope.event.CityList[(responsedata[i].City_ID - 1)];

                $('#addEventForm').unblock();

            }
        }, function () {
            $('#addEventForm').unblock();
        });
    } else { data.append("EventID", 0); }

    // Submit Forn data
    $scope.Submit = function (valid) {
        debugger;
        if (valid) {
            $('#addEventForm').block({
                message: '<img src="dist/img/loading.gif" style="height:74px"></img>'
            });

            $scope.event.Event_Date = $filter('date')($scope.event.Event_Date, "yyyy-MM-dd");
            $scope.event.City_ID = $scope.event.City_ID.value;

            angular.forEach($scope.event, function (value, key) {

                data.append(key, value);
            });

            AdminFactory.AddUpdateEvent(data).then(function (response) {
                console.log(response);
                $('#addEventForm').unblock();
                swal("Event saved successfully", "", "success");
                window.location = "#!/AdminDashboard/ManageEvents";
            }, function () {
                $('#addEventForm').unblock();
                swal("Event saved successfully", "", "success");
                window.location = "#!/AdminDashboard/ManageEvents";
            });
        }
        else {
            $scope.submitted = true;
        }

    };

}]);

// Events Ended

//Contact Us Started
JNV.controller('ContactUsController', ['$scope', 'AdminFactory', '$rootScope', function ($scope, AdminFactory, $rootScope) {
    $scope.vContactUs = {};
    var data = new FormData();

    AdminFactory.GetContactUs("1").then(function (response) {
        debugger;
        $scope.vContactUs.Contact_Us_ID = response.data[0].Contact_Us_ID;
        $scope.vContactUs.Contact_Us = response.data[0].Contact_Us;
        $scope.vContactUs.CityID = response.data[0].City_ID;
    })
    debugger;
    $scope.Submit = function (valid) {
        debugger;

        if (valid) {
            
            angular.forEach($scope.vContactUs, function (value, key) {

                data.append(key, value);
            });

            AdminFactory.AddContactUs(data).then(function (response) {
                console.log(response);
                swal("Contact us  Saved", "", "success");
                DisplayContactUs();
            }, function () {
                swal("Contact us  Saved", "", "success");
                DisplayContactUs();
            });
        }
        else {
            $scope.submitted = true;
        }

    };

}]);

function EditContactUS() {
    $("#editContactUs").attr("style", "display:block");
    $("#displayContactUs").attr("style", "display:none");
}

function DisplayContactUs() {
    $("#editContactUs").attr("style", "display:none");
    $("#displayContactUs").attr("style", "display:block");
}
//Contact Us Ended

//Advertisement Started

JNV.controller('AdvertisementController', ['$scope', 'AdminFactory', '$rootScope', '$compile', function ($scope, AdminFactory, $rootScope, $compile) {
    debugger;
    LoadAdvertisements();

    $scope.EditAdvertisement = function (Advertisement_ID) {
        debugger;
        $rootScope.Advertisement_ID = Advertisement_ID;

        window.location = "#!/AdminDashboard/AddAdvertisement"
    }

    $scope.DeleteAdvertisement = function (Advertisement_ID) {

        swal({
            title: 'Delete AddAdvertisement?',
            text: "Sure you want to delete this AddAdvertisement?",
            type: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes'
        }, function () {
            $('.box-body').block({
                message: '<img src="dist/img/loading.gif" style="height:74px"></img>'

            });
            AdminFactory.DeleteAdvertisement(Advertisement_ID).then(function (response) {
                debugger;
                console.log(response);
                $('.box-body').unblock();
                LoadAdvertisements();
                swal(
                    'Deleted!',
                    'Advertisements has been deleted.',
                    'success'
                  )
            }, function () {
                $('.box-body').unblock();
                LoadAdvertisements();
                swal(
                   'Deleted!',
                   'LoadAdvertisements has been deleted.',
                   'success'
                 )
            });
        })
    }

    function LoadAdvertisements() {
        debugger;
        $('.box-body').block({
            message: '<img src="dist/img/loading.gif" style="height:74px"></img>'

        });
        AdminFactory.GetAdvertisements(1).then(function (data) {
            var responsedata = data.data;
            $('#tblAdvertisement').DataTable().destroy();
            $("#tblAdvertisement tbody").empty();

            var tabledatabody = '';
            for (var i = 0; i < responsedata.length; i++) {

                tabledatabody += '<tr>';
                tabledatabody += ' <td>' + responsedata[i].Advertisement_Name + '</td>';
                tabledatabody += ' <td>' + responsedata[i].Position + '</td>';
                tabledatabody += ' <td><a href="javascript:void(0)"  ng-click="EditAdvertisement(' + responsedata[i].Advertisement_ID + ')"> Edit <i class="fa fa-edit"></i></a></td>';
                tabledatabody += ' <td><a href="javascript:void(0)" ng-click="DeleteAdvertisement(' + responsedata[i].Advertisement_ID + ')">Delete <i class="fa fa-remove"></i></a></td>';
                tabledatabody += ' </tr>';
            }
            var tempatbledata = $compile(tabledatabody)($scope);
            $("#tblAdvertisement tbody").append(tempatbledata);
            $.fn.dataTable.ext.errMode = 'none';
            $('#tblAdvertisement').DataTable({
                "paging": true,
                "lengthChange": false,
                "searching": true,
                "ordering": true,
                "info": true,
                "autoWidth": false,
                "responsive": true
            });
            $('.box-body').unblock();
        }, function () {
            $('.box-body').unblock();
            alert("error occured");
        });
    }

}]);

JNV.controller('AddAdvertisementController', ['$scope', 'AdminFactory', '$rootScope', function ($scope, AdminFactory, $rootScope) {

    $scope.advertisement = {}
    $scope.readonlyemail = false;
    var data = new FormData();

    $scope.advertisement.CityList = [
       { name: 'Ajmer', value: '1' },
       { name: 'Alwar', value: '2' },

    ];
    $scope.advertisement.City_ID = $scope.advertisement.CityList[0];
    $scope.advertisement.StateList = [
        { name: 'Rajasthan', value: '1' }
    ];
    //$scope.advertisement.State_ID = $scope.advertisement.StateList[0];

    if ($rootScope.Advertisement_ID != undefined && $rootScope.Advertisement_ID > 0) {
        $('#addAdvertisementForm').block({
            message: '<img src="dist/img/loading.gif" style="height:74px"></img>'

        });
        $scope.readonlyemail = true;
        data.append("Advertisement_ID", $rootScope.Advertisement_ID);

        AdminFactory.GetAdvertisement($rootScope.Advertisement_ID).then(function (response) {
            var responsedata = response.data;
            for (var i = 0; i < responsedata.length; i++) {
                debugger;
                $scope.advertisement.Advertisement_ID = responsedata[i].Advertisement_ID;
                $scope.advertisement.Advertisement_Name = responsedata[i].Advertisement_Name;
                $scope.advertisement.Position = responsedata[i].Position;
                $scope.advertisement.City_ID = $scope.advertisement.CityList[(responsedata[i].City_ID - 1)];
                

                $('#Advertisement_ID').unblock();

            }
        }, function () {
            $('#addAdvertisementForm').unblock();
        });
    } else { data.append("Advertisement_ID", 0); }

    // Submit Forn data
    $scope.Submit = function (valid) {
        debugger;
        if (valid) {
            $('#addAdvertisementForm').block({
                message: '<img src="dist/img/loading.gif" style="height:74px"></img>'
            });

            $scope.advertisement.City_ID = $scope.advertisement.City_ID.value;
            
            angular.forEach($scope.faculty, function (value, key) {

                data.append(key, value);
            });

            AdminFactory.AddUpdateAdvertisement(data).then(function (response) {
                console.log(response);
                $('#addAdvertisementForm').unblock();
                swal("Advertisement saved successfully", "", "success");
                window.location = "#!/AdminDashboard/ManageAdvertisement";
            }, function () {
                $('#addAdvertisementForm').unblock();
                swal("Advertisement saved successfully", "", "success");
                window.location = "#!/AdminDashboard/ManageAdvertisement";
            });
        }
        else {
            $scope.submitted = true;
        }

    };

}]);

// Advertisement Ended