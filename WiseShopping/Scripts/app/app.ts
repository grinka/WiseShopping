/// <reference path="../angular/angular.d.ts" />
var app = angular.module("TheBestShopping", []);
app.controller("home_controller", ['$scope', ($scope) => new TheBestShopping.home_controller($scope)]);