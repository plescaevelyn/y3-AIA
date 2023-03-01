document.getElementById("firstNumber").addEventListener('input',inputNumbers);
document.getElementById("secondNumber").addEventListener('input',inputNumbers);

add = document.getElementById("add").addEventListener("click",add);
subs = document.getElementById("subs").addEventListener("click",substract);
multiply = document.getElementById("multiply").addEventListener("click",multiply);
divide = document.getElementById("divide").addEventListener("click",divide);
equal = document.getElementById("equal").addEventListener("click",equal);

function inputNumbers() {
  var firstNumber = parseInt(document.getElementById("firstNumber").value);
  var secondNumber = parseInt(document.getElementById("secondNumber").value);

  if (equal) {
    return printValue;
  }
}

function printValue(divId, value) {
  document.getElementById(divId).innerHTML = value;
}
printValue("counter", 0);

function add(firstNumber,secondNumber) {
  if (add) {
    printValue(divId, firstNumber + secondNumber);
    return firstNumber + secondNumber;
  }
}

function substract(firstNumber,secondNumber) {
  if (substract) {
    printValue(divId, firstNumber - secondNumber);
    return firstNumber - secondNumber;
  }
}

function multiply(firstNumber,secondNumber) {
  if (multiply) {
    printValue(divId, firstNumber * secondNumber);
    return firstNumber * secondNumber;
  }
}

function divide(firstNumber,secondNumber) {
  if (divide) {
    printValue(divId, firstNumber / secondNumber);
    return firstNumber / secondNumber;
  }
}
