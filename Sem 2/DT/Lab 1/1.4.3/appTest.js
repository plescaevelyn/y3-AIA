document.getElementById("n").addEventListener('input',inputSum);

function test() {
    console.log(sum(0)==0?"Passed":"Failed");
    console.log(sum(2)==3?"Passed":"Failed");
    console.log(sum(4)==10?"Passed":"Failed");
    console.log(sum()=="Operation cannot be performed! Non-integer data type!");
    console.log(sum("a")=="Operation cannot be performed! Non-integer data type!")
}

test();
