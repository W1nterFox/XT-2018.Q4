function calculateExpression() {
    var str = document.getElementById("textArea").value;
    var digitArr = String(str).match(/[0-9]+(\.[0-9]+)*/g);
    var operArr = String(str).match(/[+-]|[*/]|=/g);
    
    var value = digitArr[0] * 1;
    
    for (var i = 0; i < digitArr.length; i++) {
        if (operArr[i] != '=') {
            value = operation(value, digitArr[i+1], operArr[i]);
        }
    }

    document.getElementById("resultOfExpression").innerHTML = value.toFixed(2);
}

function operation(value, result, operation) {
    switch (operation) {
        case '+':
        {
            value += result * 1;
            break;
        }
            
        case '-':
        {
            value -= result;
            break;
        }
            
        case '*':
        {
            value *= result;
            break;
        }
            
        case '/':
        {
            value /= result;
            break;
        }
            
        default:
        {
            break;
        }
    }

    return value;
}