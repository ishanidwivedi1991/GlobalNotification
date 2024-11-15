let uri = 'https://localhost:7155/v1/notification/validate/';

function validateItem() {
    const validateData = document.getElementById('payload');

    const item = validateData.value.trim();

    // Options for the fetch request
    const options = {
        method: 'POST', // Use the POST method
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json' // Specify the content type
        },
        body: JSON.stringify(JSON.parse(item)) // Convert the data to JSON string
    };

    // Make the POST request
    fetch(uri, options)
        .then(response => response.json())
        .then(data => {
            console.log('Success:', data);
            $("#maxLimit").text(data.isMaxLimitReached);
            $("#counter").text(data.messageCount);
        }
        )
        .catch(error => console.error('Error:', error));
}