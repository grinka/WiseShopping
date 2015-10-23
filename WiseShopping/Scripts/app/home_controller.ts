/// <reference path="../angular/angular.d.ts" />
declare var Model: any;

module TheBestShopping {
    export class home_controller {
        static $inject = ['$scope'];
        constructor(private $scope: any) {
            this.$scope = $scope;
            this.$scope.Data = Model.Data;
        }
    }
}
