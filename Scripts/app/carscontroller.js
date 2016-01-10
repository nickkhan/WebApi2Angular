(function () {
    
    //var app = angular.module('app', []);//set and get the angular module    
    var app = angular.module('app', ['angular-loading-bar', 'ngAnimate']).config(['cfpLoadingBarProvider', function (cfpLoadingBarProvider) {
        cfpLoadingBarProvider.includeBar = false;
        cfpLoadingBarProvider.includeSpinner = true;
    }]);

    app.controller('carsController', ['$scope', '$http', carsController]);

    function carsController($scope, $http) {

        $scope.loading = true;
        $scope.addMode = false;
        $scope.editMode = false;

        //get all cars
        $http.get('/api/cars/').success(function (data) {
            $scope.cars = data;
            $scope.loading = false;
        })
        .error(function () {
            $scope.error = "An Error has occured while fetching list!";
            $scope.loading = false;
        });


        //by pressing toggleEdit button ng-click in html, this method will be hit
        $scope.toggleEdit = function () {
            $scope.editMode = !$scope.editMode;
        };

        //by pressing toggleAdd button ng-click in html, this method will be hit
        $scope.toggleAdd = function () {
            $scope.addMode = !$scope.addMode;
        };

        //Insert Car
        $scope.add = function (newcar) {
            $scope.loading = true;
            $http.put('/api/car/put', newcar).success(function (data) {
                alert("Car Added Successfully!!");
                $scope.addMode = false;
                $scope.cars.push(data);
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An Error has occured while Adding Cars! " + data;
                $scope.loading = false;
            });
        };

        //Edit Car
        $scope.save = function (car) {           
            $scope.loading = true;
            var Id = car.carId;
            $http.patch('/api/car/', car).success(function (data) {
                alert("Saved Successfully!!");
                $scope.editMode = false;
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An Error has occured while Saving car! " + data;
                $scope.loading = false;
            });
        };

        //Delete Car
        $scope.deletecar = function (car) {
            $scope.loading = true;
            var Id = car.carId;
            $http.delete('/api/car/' + Id).success(function (data) {                
                $.each($scope.cars, function (i) {
                    if ($scope.cars[i].carId === Id) {
                        $scope.cars.splice(i, 1);
                        return false;
                    }
                });
                $scope.loading = false;
                alert("car deleted Successfully!!");
            }).error(function (data) {
                $scope.error = "Error while trying to delete" + data;
                $scope.loading = false;
            });
        };
    }
})();