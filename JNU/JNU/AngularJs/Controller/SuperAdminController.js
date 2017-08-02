JNV.controller("SuperAdminLoginController", ['$scope', 'LoginFactory', '$state', function ($scope, LoginFactory, $state) {
   
   
    $scope.users = {};
    $scope.login = function (valid) {
        debugger;
        if (valid) {
            $scope.submitted = false;
            //$scope.loading = true;
            $('#Loginformid').block({
                message: '<img src="dist/img/loading.gif" style="height:74px"></img>'

            });
            LoginFactory.LoginUser($scope.users).then(function successCallback(response) {
                debugger;

                if (response.status == 200) {
                    console.log(response)
                    //$state.go("Dashboard");
                    localStorage.setItem("RoleID", response.data.Role);
                    if(response.data.Role==1)
                    {
                        
                        window.location = "#!/Dashboard/ManageUser";
                    }
                    else if(response.data.Role==0)
                    {
                        window.location = "#!/DashboardNew/Home";
                    }
                    //window.location = "#!/Dashboard/Home";
                   // window.location = "#!/DashboardNew/Home";
                    
                }
                else {
                    $('#Loginformid').unblock();
                    swal("", response.data, "warning");
                }

                // 
            }, function errorCallback(response) {
                $('#Loginformid').unblock();
                swal("", "Something went wrong please try after sometime!", "danger");
            });
        }
        else {
            $scope.submitted = true;
        }
        // window.location = "#!/Dashboard/Home";
    }

}]);

JNV.controller("SADashboardController", ['$scope', function ($scope) {



}]);

JNV.controller("SAhomeController", ['$scope', function ($scope) {



}]);

JNV.controller("SAManagerController", ['$scope', '$rootScope', 'SuperAdminFactory', '$compile', function ($scope, $rootScope, SuperAdminFactory, $compile) {
    LoadAdminData();
    function LoadAdminData() {
        debugger;
        $('.box-body').block({
            message: '<img src="dist/img/loading.gif" style="height:74px"></img>'
          
        });
        SuperAdminFactory.GetAdmin().then(function (data) {
            var responsedata = data.data;
            $('#tbladminuser').DataTable().destroy();
            $("#tbladminuser tbody").empty();

            var tabledatabody = '';
            for (var i = 0; i < responsedata.length; i++)
            {
               // console.log(responsedata[i].Name);
                tabledatabody += '<tr>';
                // if (value.Isactive == 1) { userstatus = 'Active'; } else { userstatus = 'Inactive'; }
                tabledatabody += ' <td>' + responsedata[i].Name + '</td>';
                tabledatabody += ' <td>' + responsedata[i].Phone + '</td>';
                tabledatabody += ' <td>' + responsedata[i].WhatsApp_Number + '</td>';
                tabledatabody += ' <td>' + responsedata[i].Email + '</td>';
                tabledatabody += ' <td><a href="javascript:void(0)"  ng-click="EditUser(' + responsedata[i].UserID + ')"> Edit <i class="fa fa-edit"></i></a></td>';
                tabledatabody += ' <td><a href="javascript:void(0)" ng-click="DeleteUser(' + responsedata[i].UserID + ')">Delete <i class="fa fa-remove"></i></a></td>';
                tabledatabody += ' </tr>';
            }
            var tempatbledata = $compile(tabledatabody)($scope);
            $("#tbladminuser tbody").append(tempatbledata);
            $.fn.dataTable.ext.errMode = 'none';
            $('#tbladminuser').DataTable({
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

    $scope.EditUser=function(EditUserID)
    {
        debugger;
        $rootScope.EditUserID = EditUserID;
        
        window.location = "#!/Dashboard/AddAdmin"
    }

    $scope.DeleteUser = function (DeleteUserID) {
        if (confirm("Are you sure ?")) {
            // $rootScope.EditUserID = DeleteUserID;
             $('.box-body').block({
            message: '<img src="dist/img/loading.gif" style="height:74px"></img>'
          
        });
            SuperAdminFactory.DeleteAdmin(DeleteUserID).then(function (response) {
                debugger;
                console.log(response);
                 $('.box-body').unblock();
                LoadAdminData();
            }, function () {
                $('.box-body').unblock();
                LoadAdminData();
            });
        }
     
    }

    


}]);

JNV.controller("SANotificationController", ['$scope', function ($scope) {



}]);


JNV.controller('AddAdminController', ['$scope', 'SuperAdminFactory', '$rootScope', function ($scope, SuperAdminFactory, $rootScope) {
    debugger;
    $('#datepicker').datepicker({
        autoclose: true
    });
    $scope.admins = {}
    $scope.readonlyemail = false;
    $scope.imagesrc = [];
    //FILL FormData WITH FILE DETAILS.
    var data = new FormData();

    if ($rootScope.EditUserID != undefined && $rootScope.EditUserID > 0) {
        $('#addadminform').block({
            message: '<img src="dist/img/loading.gif" style="height:74px"></img>'

        });
        $scope.readonlyemail = true;
        data.append("UserID", $rootScope.EditUserID);
        SuperAdminFactory.GetAdminByID($rootScope.EditUserID).then(function (response) {
            var responsedata = response.data;
            for (var i = 0; i < responsedata.length; i++) {
                debugger;
                $scope.admins.Name = responsedata[i].Name;
                $scope.admins.Nick_name = responsedata[i].Nick_name;
                $scope.admins.Email = responsedata[i].Email;
                $scope.admins.Password = responsedata[i].Password;
                $scope.admins.Phone = responsedata[i].Phone;
                $scope.admins.WhatsApp_Number = responsedata[i].WhatsApp_Number;
                $scope.admins.City_ID = $scope.admins.statusTaskList[(responsedata[i].City_ID - 1)];
                //var date = new Date(convertjsontodate(responsedata[i].Birthday))
                
                $scope.admins.Birthday = responsedata[i].Birthday;

                $scope.admins.Gender = $scope.admins.Genders[(responsedata[i].Gender - 1)];
                $scope.admins.Marital_Status = $scope.admins.Maritals[(responsedata[i].Marital_Status - 1)];
                $scope.admins.village = responsedata[i].Village;
                $scope.admins.Hobbies = responsedata[i].Hobbies;
                $scope.admins.Profession_Detail = responsedata[i].Profession_Detail;
                $scope.admins.Home_Address = responsedata[i].Home_Address;
                $scope.admins.Current_Address = responsedata[i].Current_Address;
                $scope.admins.Facebook_ID = responsedata[i].Facebook_ID;
                $scope.admins.LinkedIn_ID = responsedata[i].LinkedIn_ID;
                $scope.admins.Twitter_ID = responsedata[i].Twitter_ID;

                if (responsedata[i].Photo != undefined && responsedata[i].Photo != "") {
                    var image = {};

                    image.Src = responsedata[i].Photo;
                    $scope.imagesrc.push(image);
                }
                $('#addadminform').unblock();
                // $scope.$apply();


            }
        }, function () {
            $('#addadminform').unblock();
        });
    } else { data.append("UserID", 0); }

    
   // $scope.admins.City = "Bhilwara";
    $scope.admins.statusTaskList = [
        { name: 'Bhilwara', value: '1' },
        { name: 'Jaipur', value: '2' },
        
    ];
    $scope.admins.City_ID = $scope.admins.statusTaskList[0]; // 0 -> Open 

    $scope.admins.Genders = [
        { name: 'Male', value: '1' },
        { name: 'Female', value: '2' },
        { name: 'Other', value: '3' },

    ];
    $scope.admins.Gender = $scope.admins.Genders[0]; // 0 -> Open 
    $scope.admins.Maritals = [
        { name: 'Single', value: '1' },
        { name: 'Married', value: '2' },
        

    ];
    $scope.admins.Marital_Status = $scope.admins.Maritals[0]; // 0 -> Open 

    //Add File start.....
    $scope.getTheFiles = function ($files) {
     
       

        for (var i = 0; i < $files.length; i++) {

            var reader = new FileReader();
            reader.fileName = $files[i].name;

            reader.onload = function (event) {

                var image = {};
                image.Name = event.target.fileName;
                image.Size = (event.total / 1024).toFixed(2);
                image.Src = event.target.result;
                $scope.imagesrc.length = 0;
                $scope.imagesrc.push(image);
                $scope.$apply();
            }
            reader.readAsDataURL($files[i]);
        }

        $scope.Files = $files;

    };
    //Add File End...

    // Submit Forn data
    $scope.Submit = function (valid) {
        debugger;
        
        if (valid) {
            $('#addadminform').block({
                message: '<img src="dist/img/loading.gif" style="height:74px"></img>'

            });
            $scope.admins.City_ID = $scope.admins.City_ID.value;
            $scope.admins.Gender = $scope.admins.Gender.value;
            $scope.admins.Marital_Status = $scope.admins.Marital_Status.value;
            //var date = new Date(convertjsontodate($scope.admins.Birthday))
            
            //$scope.admins.Birthday = convert($scope.admins.Birthday);

            //console.log(date);


         
           

            angular.forEach($scope.Files, function (value, key) {
                data.append(key, value);
            });
            angular.forEach($scope.admins, function (value, key) {
              
                data.append(key, value);
            });
            var RoleID = localStorage.getItem("RoleID");
            data.append('RoleID', RoleID);
            //anguar.forEach($scope.admins,function(value)
            //data.append("DealModel", JSON.stringify($scope.admins));
            // fd.append('formdata',JSON.stringify($scope.dataform));
            SuperAdminFactory.AddNewAdmin(data).then(function (response) {
                console.log(response);
                $('#addadminform').unblock();
                swal("User Detail Saved", "", "success");
                window.location = "#!/Dashboard/ManageUser";
            }, function () {
                $('#addadminform').unblock();
                swal("User Detail Saved", "", "success");
                window.location = "#!/Dashboard/ManageUser";
            });
        }
        else {
            $scope.submitted = true;
        }


    };

    function convertjsontodate(str) {
        var date = new Date(str),
            mnth = ("0" + (date.getMonth() + 1)).slice(-2),
            day = ("0" + date.getDate()).slice(-2);
        return [day,mnth, date.getFullYear()].join("-");
    }
    
    

}]);



