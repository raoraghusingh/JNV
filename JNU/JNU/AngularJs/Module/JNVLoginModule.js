﻿var JNVLogin = angular.module('JNVLogin', ['ui.router']);
JNVLogin.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/');

    $stateProvider

        // HOME STATES AND NESTED VIEWS ========================================
        .state('', {
            url: '/',
            templateUrl: 'HTMLpages/Login.html',
            controller: "LoginController"
        })

        // nested list with custom controller
        //.state('home.list', {
        //    url: '/list',
        //    templateUrl: 'partial-home-list.html',
        //    controller: function ($scope) {
        //        $scope.dogs = ['Bernese', 'Husky', 'Goldendoodle'];
        //    }
        //})

        // nested list with just some random string data
        //.state('home.paragraph', {
        //    url: '/paragraph',
        //    template: 'I could sure use a drink right now.'
        //})

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