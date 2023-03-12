result=0;

 function printValue(divId, value){
 $("#"+divId).html(value)
}

$("#sum").on('click', sum);
function sum(){
	var firstNumberText = +$('#firstNumber').val();
	var secondNumberText = +$('#secondNumber').val();
	result = firstNumberText + secondNumberText;

}

$("#dif").on('click', dif);
function dif(){
	var firstNumberText = +$('#firstNumber').val();
	var secondNumberText = +$('#secondNumber').val();
	result = firstNumberText - secondNumberText;
	
}

$("#mul").on('click', mul);
function mul(){
	var firstNumberText = +$('#firstNumber').val();
	var secondNumberText = +$('#secondNumber').val();
	result = firstNumberText * secondNumberText;

}

$("#sub").on('click', sub);
function sub(){
	var firstNumberText = +$('#firstNumber').val();
	var secondNumberText = +$('#secondNumber').val();
	result = firstNumberText / secondNumberText;

}

$("#equal").on('click', equal);
function equal(){
	printValue('result', result);
}
