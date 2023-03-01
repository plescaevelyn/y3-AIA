document.getElementById("n").addEventListener('input',inputSum);

function inputSum() {
  var inputNumber = parseInt(document.getElementById("n").value);
  sum(inputNumber);
}

function sum(n) {
  if (isNaN(n)) {
    return "Operation cannot be performed! Non-integer data type!";
  }

  var sum = 0;
  for (var i = 1; i <= n; i++) {
    sum += i;
  }

  return sum;
}
