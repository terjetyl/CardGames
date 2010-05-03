var service;
var resultHolder;

//var dealerHand;
//var playerHand;

var dealerUL;
var playerUL;

var delay;


function pageLoad() {
    service = BlackJackOnline.BlackjackWebService;

    service.set_defaultSucceededCallback(callbackSuccess);
    service.set_defaultFailedCallback(callbackFail);

    service.GetSnapshot(refreshHands);

    dealerUL = $('#dealerHand ul');
    playerUL = $('#playerHand ul');
}

function callbackSuccess(result) {

}

function callbackFail(error, userContext, methodName) {

}


// following 3 methods call the webservice.

function deal() {
    $('#btnDeal').attr('disabled', 'true');
    service.Deal(refreshHands);
}

function hit() {
    service.Hit(refreshHands);
}

function stand() {
    service.Stand(refreshHands);
}



// once a the webservice is called, the result is returned to the
// refreshHands method

function refreshHands(result, userContext, methodName) {
    // store the result in a global variable that will be passed to the setTimeout function.
    resultHolder = result;

    delay = 0;
    var increment = 1000;
    function increaseDelay() {
        delay = delay + increment;
    }

    var playerLICount = $(playerUL).children('li').size();
    var dealerLICount = $(dealerUL).children('li').size();

    if (methodName == 'Deal') {
        
        // if dealing, reset the table
        
        $('#dealerHand .total').empty();
        $('#playerHand .total').empty();
        
        $('#dealerHand .scores .outcome').empty();
        $('#dealerHand .scores .outcome').removeClass('win');
        $('#dealerHand .scores .outcome').removeClass('bust');
        
        $('#playerHand .scores .outcome').empty();
        $('#playerHand .scores .outcome').removeClass('win');
        $('#playerHand .scores .outcome').removeClass('bust');

        dealerUL.empty();
        playerUL.empty();
        

        // refresh both hands alternately
        for (var i = 0; i < 2; i++) {
            setTimeout("addCardToHandUL(playerUL, resultHolder.PlayerHand.Cards[" + i + "])", delay);
            increaseDelay();
            playerLICount++; // must increase the count manually, as the LI's aren't actually added until later.

            setTimeout("addCardToHandUL(dealerUL, resultHolder.DealerHand.Cards[" + i + "])", delay);
            increaseDelay();
            dealerLICount++; // must increase the count manually, as the LI's aren't actually added until later.
        }
    }



    // then refresh any cards above what are already there, first player hand, then dealer hand.

    for (var i = playerLICount; i < resultHolder.PlayerHand.CardCount; i++) {
        setTimeout("addCardToHandUL(playerUL, resultHolder.PlayerHand.Cards[" + i + "])", delay);
        increaseDelay();
    }

    if (methodName == 'Stand' || result.PlayerTotal == 21) {
        // reveal the hole card
        setTimeout(revealHoleCard, delay);
        increaseDelay();
    }


    for (var i = dealerLICount; i < resultHolder.DealerHand.CardCount; i++) {
        setTimeout("addCardToHandUL(dealerUL, resultHolder.DealerHand.Cards[" + i + "])", delay);
        increaseDelay();
    }

    setTimeout(refreshTotals, delay);
    setTimeout(refreshScores, delay);
    setTimeout("changeButtonState(resultHolder.GameInProgress)", delay);

}



function changeButtonState(gameInProgress) {
    
    // refresh button state to reflect gameplay choices

    if (gameInProgress) {
        $('#btnDeal').attr('disabled', 'disabled');
        $('#btnHit').removeAttr('disabled');
        $('#btnStand').removeAttr('disabled');
    } else {
        $('#btnDeal').removeAttr('disabled');
        $('#btnHit').attr('disabled', 'disabled');
        $('#btnStand').attr('disabled', 'disabled');
    }
}

function revealHoleCard() {
    var hole = $(dealerUL).children('li').get(1);
    $(hole).hide().attr('class', resultHolder.DealerHand.Cards[1].ShortName).show('normal');
    //refreshTotals();
}

function refreshTotals() {


    $('#dealerHand .total').empty();
    if ($(dealerUL).children('li').size() > 0) {
        $('#dealerHand .total').append(resultHolder.DealerTotal);
    }

    $('#playerHand .total').empty();
    if (resultHolder.PlayerTotal != "0") {
        $('#playerHand .total').append(resultHolder.PlayerTotal);
    }

}

function refreshScores() {


    // refresh scores

    $('#dealerHand .scores .score').empty();
    $('#dealerHand .scores .score').append(resultHolder.DealerScore);

    $('#dealerHand .scores .outcome').empty();
    if (resultHolder.DealerBust) {
        $('#dealerHand .scores .outcome').append("BUST").addClass('bust');
    }

    $('#playerHand .scores .score').empty();
    $('#playerHand .scores .score').append(resultHolder.PlayerScore);

    $('#playerHand .scores .outcome').empty();
    if (resultHolder.PlayerBust) {
        $('#playerHand .scores .outcome').append("BUST").addClass('bust');
    }

    if (resultHolder.GameOverArgs != null) {
        switch (resultHolder.GameOverArgs.Result) {
            case 1:
                $('#playerHand .scores .outcome').append("WIN").addClass('win');
                break;
            case 2:
                $('#dealerHand .scores .outcome').append("WIN").addClass('win');
        }
    }
    
}

function addCardToHandUL(handUL, card) {
    $(handUL).append('<li/>');
    $(handUL).children('li:last').hide();
    $(handUL).children('li:last').addClass(card.ShortName).text(card.Name);
    $(handUL).children('li:last').show('normal');
}

