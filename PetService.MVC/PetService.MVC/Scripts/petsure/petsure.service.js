app.service("petService", function ($http) {

    //get All Pets
    this.getAllPets = function () {
        return $http.get("api/PetSure");
    };

    // POST: Submit Claim 
    this.submitClaimService = function (pets) {
        var response = $http({
            method: "post",
            url: "Home/SubmitClaim",
            data: JSON.stringify(pets),
            dataType: "json"
        });
        return response;
    }

    // POST: Save For Later 
    this.saveForLaterService = function (pets) {
        var response = $http({
            method: "post",
            url: "Home/SaveForLater",
            data: JSON.stringify(pets),
            dataType: "json"
        });
        return response;
    }

    // POST: Selected Pet
    this.selectedPetService = function (pets) {
        var response = $http({
            method: "post",
            url: "Home/SelectedPet",
            data: JSON.stringify(pets),
            dataType: "json"
        });
        return response;
    }
});
