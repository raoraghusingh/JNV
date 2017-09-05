JNV.factory('AdminFactory', ['$http', 'JNV_Constants', function ($http, JNV_Constants) {

    var ArAdminfactory = {};
    var ApiAboutUsUrl = JNV_Constants.BaseUrl + "AboutUs/";
    var ApiFacultyUrl = JNV_Constants.BaseUrl + "Faculty/";
    var ApiEventUrl = JNV_Constants.BaseUrl + "Event/";
    var ApiContactUsUrl = JNV_Constants.BaseUrl + "ContactUs/";
    var ApiBirthdayUrl = JNV_Constants.BaseUrl + "Birthday/";
    var ApiImageUrl = JNV_Constants.BaseUrl + "Image/";
    var ApiVideoUrl = JNV_Constants.BaseUrl + "Video/";
    var ApiAlbumUrl = JNV_Constants.BaseUrl + "Album/";
    var ApiAdvertisementUrl = JNV_Constants.BaseUrl + "Advertisement/";

    // About US Started

    ArAdminfactory.AddAboutUs = function (data) {
        return $http.post(ApiAboutUsUrl + "AboutUs/", data, {
            withCredentials: true,
            headers: { 'Content-Type': undefined },
            transformRequest: angular.identity
        })
    }
    ArAdminfactory.GetAboutUs = function (Id) {
        return $http.get(ApiAboutUsUrl + "GetAboutUsByCityID?CityID=" + Id, {

        })
    }

    // About Us Ended

    //  Faculty Started

    ArAdminfactory.GetFaculties = function (Id) {
        return $http.get(ApiFacultyUrl + "GetFacultiesByCityID?CityID=" + Id, {

        })
    }
    ArAdminfactory.GetFaculty = function (Id) {
        return $http.get(ApiFacultyUrl + "GetFacultyByID?FacultyID=" + Id, {

        })
    }
    ArAdminfactory.DeleteFaculty = function (Id) {
        return $http.get(ApiFacultyUrl + "DeleteFaculty?FacultyID=" + Id, {

        })
    }
    ArAdminfactory.AddUpdateFaculty = function (data) {
        return $http.post(ApiFacultyUrl + "AddUpdateFaculty/", data, {
            withCredentials: true,
            headers: { 'Content-Type': undefined },
            transformRequest: angular.identity
        })
    }

    // Faculty Ended

    //  Events Started

    ArAdminfactory.GetEvents = function (Id) {
        return $http.get(ApiEventUrl + "GetEventsByCityID?CityID=" + Id, {

        })
    }
    ArAdminfactory.GetEvent = function (Id) {
        return $http.get(ApiEventUrl + "GetEventByID?EventID=" + Id, {

        })
    }
    ArAdminfactory.DeleteEvent = function (Id) {
        return $http.get(ApiEventUrl + "DeleteEvent?EventID=" + Id, {

        })
    }
    ArAdminfactory.AddUpdateEvent = function (data) {
        return $http.post(ApiEventUrl + "AddUpdateEvent/", data, {
            withCredentials: true,
            headers: { 'Content-Type': undefined },
            transformRequest: angular.identity
        })
    }

    // Events Ended
    
    // Contact US Started

    ArAdminfactory.AddContactUs = function (data) {
        return $http.post(ApiContactUsUrl + "ContactUs/", data, {
            withCredentials: true,
            headers: { 'Content-Type': undefined },
            transformRequest: angular.identity
        })
    }
    ArAdminfactory.GetContactUs = function (Id) {
        return $http.get(ApiContactUsUrl + "GetContactUsByCityID?CityID=" + Id, {

        })
    }

    // Contact Us Ended

    //  Birthday Starts

    ArAdminfactory.GetBirthdays = function (Id) {
        return $http.get(ApiBirthdayUrl + "GetBirthdayByCityID?CityID=" + Id, {

        })
    }
        
    //  Birthday Ends

    // Images Starts

    ArAdminfactory.GetImages = function (Id) {
        return $http.get(ApiImageUrl + "GetPicturesByAlbumID?AlbumID=" + Id, {

        })
    }
    ArAdminfactory.DeleteImage = function (Id) {
        return $http.get(ApiImageUrl + "DeletePicture?AlbumID=" + Id, {

        })
    }
    ArAdminfactory.AddImage = function (data) {
        return $http.post(ApiImageUrl + "AddPicture/", data, {
            withCredentials: true,
            headers: { 'Content-Type': undefined },
            transformRequest: angular.identity
        })
    }

   
    // Images Ends

    // Videos starts

    ArAdminfactory.GetVideos = function (Id) {
        return $http.get(ApiVideoUrl + "GetVideosByAlbumID?AlbumID=" + Id, {

        })
    }
    ArAdminfactory.DeleteVideo = function (Id) {
        return $http.get(ApiVideoUrl + "DeleteVideo?AlbumID=" + Id, {

        })
    }
    ArAdminfactory.AddVideo = function (data) {
        return $http.post(ApiVideoUrl + "AddVideo/", data, {
            withCredentials: true,
            headers: { 'Content-Type': undefined },
            transformRequest: angular.identity
        })
    }

    // Videos Ends


    //Album starts

    ArAdminfactory.GetAlbums = function (Id) {
        return $http.get(ApiAlbumUrl + "GetAlbumsByCityID?CityID=" + Id, {

        })
    }
    ArAdminfactory.DeleteAlbum = function (Id) {
        return $http.get(ApiAlbumUrl + "DeleteAlbum?AlbumID=" + Id, {

        })
    }
    ArAdminfactory.AddAlbum = function (data) {
        return $http.post(ApiAlbumUrl + "AddAlbum/", data, {
            withCredentials: true,
            headers: { 'Content-Type': undefined },
            transformRequest: angular.identity
        })
    }

    // Albums Ends

    //  Advertisement Started

    ArAdminfactory.GetAdvertisements = function (Id) {
        return $http.get(ApiAdvertisementUrl + "GetAdvertisementByCityID?CityID=" + Id, {

        })
    }
    ArAdminfactory.GetAdvertisement = function (Id) {
        return $http.get(ApiAdvertisementUrl + "GetAdvertisementByAdvertisementID?AdvertisementID=" + Id, {

        })
    }
    ArAdminfactory.DeleteAdvertisement = function (Id) {
        return $http.get(ApiAdvertisementUrl + "DeleteFaculty?AdvertisementID=" + Id, {

        })
    }
    ArAdminfactory.AddUpdateAdvertisement = function (data) {
        return $http.post(ApiAdvertisementUrl + "AddUpdateFaculty/", data, {
            withCredentials: true,
            headers: { 'Content-Type': undefined },
            transformRequest: angular.identity
        })
    }

    // Advertisement Ended

    return ArAdminfactory;
}]);