var service;

function pageLoad() {
    service = BlackJackOnline.BlackjackWebService;
}


function deal() {
    service.Deal(
    function(result) {
        // on success
        document.getElementById('summat').value = result[0].Cards[0].Name;
    }, 
    function() {
        // on fail

    },
    null)
}

function doHelloWorld() {
    service.HelloWorld(successHello, failHello, null);
}

function successHello(result) {
    document.getElementById('summat').value = result;
}

function failHello() {
    document.getElementById('summat').value = "didn't work";
}
