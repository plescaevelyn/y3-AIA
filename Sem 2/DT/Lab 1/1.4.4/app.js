document.getElementById("n").addEventListener('input',inputFibonacci);

function inputFibonacci() {
  var inputNumber = parseInt(document.getElementById("n").value);
  sum(inputNumber);
}

function getFibonacci(n) {
  if (isNaN(n)) {
    return "not allowed";
  }

  if (n < 1 && n > 10) {
    return "not allowed"
  }

  var n1 = 1;
  var n2 = 1;
  var nextTerm;

  var fibonacci = [...Array(n).keys()];

  for (i = 1; i <= n; i++) {
      fibonacci.push(n1);
      console.log(n1);
      nextTerm = n1 + n2;
      n1 = n2;
      n2 = nextTerm;
  }

  console.log(fibonacci);
  return fibonacci;
}
