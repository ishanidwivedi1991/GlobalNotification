let uri = 'https://localhost:7155/v1/notification/validate/';

function getError(data) {
    var result = data;
}

function getResult(data) {
    var result = data;
}

function validateItem() {
    const validateData = document.getElementById('payload');

    const item = validateData.value.trim();
    ajaxCall();

    //fetch(uri, {
    //    method: 'POST',
    //    headers: {
    //        'Accept': 'application/json',
    //        'Content-Type': 'application/json'
    //    },
    //    body: item
    //})
    //    .then(Result => Result.json())
    //    .then(string => {

    //        // Printing our response
    //        console.log(string);

    //        // Printing our field of our response
    //        console.log(`Title of our response :  ${string.title}`);
    //    })
    //    .catch(errorMsg => { console.log(errorMsg); });


        //.then(response => getResult(response.json()))
        //.catch(error => getError(error));
        //.catch(error => console.error('Unable to validate data.', error));
}

function ajaxCall() {
    let item = $('#payload').val();

    $.ajax({
        url:'https://localhost:7155/v1/notification/validate/',
        type: "POST",
        data: item,
        success: function (data) {
            let x = JSON.stringify(data);
            console.log(x);
        },

        error: function (error) {
            console.log(`Error ${error}`);
        }
    });
}


