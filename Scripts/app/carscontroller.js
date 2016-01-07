(function () {
    var app = angular.module('app', []);//set and get the angular module

    app.controller('carsController', ['$scope', '$http', carsController]);

    function carsController($scope, $http) {

        $scope.loading = true;
        $scope.addMode = false;

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
            this.cars.editMode = !this.cars.editMode;
        };

        //by pressing toggleAdd button ng-click in html, this method will be hit
        $scope.toggleAdd = function () {
            $scope.addMode = !$scope.addMode;
        };

        //Insert Car
        $scope.add = function () {
            $scope.loading = true;
            $http.post('/api/car/', this.newCar).success(function (data) {
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
        $scope.save = function () {
            alert("Edit");
            $scope.loading = true;

            alert(frien);
            $http.put('/api/car/' + this.car.carId, this.car).success(function (data) {
                alert("Saved Successfully!!");
                this.car.editMode = false;
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An Error has occured while Saving car! " + data;
                $scope.loading = false;
            });
        };

        //Delete Car
        $scope.deletecustomer = function () {
            $scope.loading = true;
            var Id = this.car.carId;
            $http.delete('/api/car/' + Id).success(function (data) {
                alert("Deleted Successfully!!");
                $.each($scope.cars, function (i) {
                    if ($scope.cars[i].Id === Id) {
                        $scope.cars.splice(i, 1);
                        return false;
                    }
                });
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An Error has occured while Saving Car! " + data;
                $scope.loading = false;
            });
        };
    }
})();