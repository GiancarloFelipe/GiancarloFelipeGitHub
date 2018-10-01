app.controller("petCtrl", function ($scope, petService) {

    $scope.ApplicatioName = "PetSure Application System";
    $scope.PetNamesLabel = "Make a claim for your pet";
    $scope.DefaultOption = "-- select your pet --";
    $scope.SpanMessage1 = "Attach";
    $scope.SpanMessage2 = "'s invoice for us here";
    $scope.ButtonName1 = "Submit";
    $scope.ButtonName2 = "Or save for later";
    $scope.Action = "Default";
 
    GetAllPets();
    // To Get All Records  
    function GetAllPets() {
        var getData = petService.getAllPets();
        getData.then(function (p) {
            $scope.pets = p.data;
        }, function () {
            alert('Error in getting records');
        });
    }
    
    // FOR: Submit Button - submitClaim
    $scope.submitClaim = function () {
        $scope.Action = "SubmitClaim";
        var PetServiceViewModels = {
            PetName: $scope.petselected.PetName,
            FileName: $scope.petFileName,
            FilePath: $scope.petFilePath
        };

        var getAction = $scope.Action;

        if (getAction == "SubmitClaim") {
            PetServiceViewModels.Id = $scope.petselected.PetId;
            var getData = petService.submitClaimService(PetServiceViewModels);
            getData.then(function (msg) {
                alert(msg.data);
                getAllPets();           
            }, function () {
                alert('Error in submitting the record');
            });
        } 
    }

    // FOR: SaveForLater Button - saveForLaterClaim
    $scope.saveForLaterClaim = function () {
        $scope.Action = "SaveForLater";
        var PetServiceViewModels = {
            PetName: $scope.petselected.PetName,
            FileName: $scope.petFileName,
            FilePath: $scope.petFilePath,
        };

        var getAction = $scope.Action;

        if (getAction == "SaveForLater") {
            PetServiceViewModels.Id = $scope.petselected.PetId;
            var getData = petService.saveForLaterService(PetServiceViewModels);
            getData.then(function (msg) {
                alert(msg.data);
                getAllPets();              
            }, function () {
                alert('Error in saving record for later');
            });
        }
    }

    // FOR: Select Option - selectedPetName
    $scope.selectedPetName = function () {
        var PetServiceViewModels = {
            Id: $scope.petselected.PetId,
            PetName: $scope.petselected.PetName,
            FileName: $scope.petFileName,
            FilePath: $scope.petFilePath,
        };
        var getData = petService.selectedPetService(PetServiceViewModels);
        getData.then(function (msg) {
            alert('You selected ' + $scope.petselected.PetName );
            getAllPets();         
        }, function () {
            alert('Error in selecting a Pet');
        });
    }
});