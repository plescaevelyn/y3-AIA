document.getElementById("n").addEventListener('input',inputFibonacci);

function test() {
    console.log(getFibonacci(1)==[1]?"Passed":"Failed");
    console.log(getFibonacci(2)==[1 1]?"Passed":"Failed");
    console.log(getFibonacci(3)=="1 1 2"?"Passed":"Failed");
    console.log(getFibonacci(5)=="1 1 2 3 4"?"Passed":"Failed");
    console.log(getFibonacci(10)=="1 1 2 3 5 8 13 21 34 54"?"Passed":"Failed");
    console.log(getFibonacci(11)=="not allowed"?"Passed":"Failed");
    console.log(getFibonacci()=="not allowed");
    console.log(getFibonacci("a")=="not allowed");
}

test();
