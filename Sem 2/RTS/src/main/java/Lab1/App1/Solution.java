/*
There are two complex numbers: 2+5i and 4-i. To create an application that calculates the summation and the product of
the two numbers, to verify the results.
 */

package Lab1.App1;

import java.util.Scanner;

public class Solution {
    public static void main(String[] args) {
        ComplexNumber firstNumber = new ComplexNumber();
        ComplexNumber secondNumber = new ComplexNumber();
        Scanner scanner = new Scanner(System.in);

        // reading the complex numbers from the console
        System.out.println("Please enter the first complex number: \t");
        firstNumber.setReal(scanner.nextInt());
        firstNumber.setImaginary(scanner.nextInt());

        System.out.println("Please enter the second complex number: \t");
        secondNumber.setReal(scanner.nextInt());
        secondNumber.setImaginary(scanner.nextInt());

        ComplexNumber sum = addComplexNumbers(firstNumber, secondNumber);
        ComplexNumber product = multiplyComplexNumbers(firstNumber, secondNumber);
    }

    // displaying the complex numbers
    public static void displayComplexNumber(ComplexNumber complexNumber) {
        if (complexNumber.getImaginary() < 0) {
            System.out.println("The sum of the two complex numbers is:\t" + complexNumber.getReal() + complexNumber.getImaginary() + "i");
        } else if (complexNumber.getImaginary() > 0) {
            System.out.println("The sum of the two complex numbers is:\t" + complexNumber.getReal() + "+" + complexNumber.getImaginary() + "i");
        } else {
            System.out.println("The sum of the two complex numbers is:\t" + complexNumber.getReal());
        }
    }


    // calculating and displaying the sum of the two complex numbers
    public static ComplexNumber addComplexNumbers(ComplexNumber firstNumber, ComplexNumber secondNumber) {
        int realSum = firstNumber.getReal() + secondNumber.getReal();
        int imaginarySum = firstNumber.getImaginary() + secondNumber.getImaginary();

        displayComplexNumber(new ComplexNumber(realSum, imaginarySum));

        return new ComplexNumber(realSum, imaginarySum);
    }

    // calculating and displaying the product of the two complex numbers
    public static ComplexNumber multiplyComplexNumbers(ComplexNumber firstNumber, ComplexNumber secondNumber) {
        int realProduct = firstNumber.getReal() * secondNumber.getReal() - firstNumber.getImaginary() * secondNumber.getImaginary();
        int imaginaryProduct = firstNumber.getReal() * secondNumber.getImaginary() + firstNumber.getImaginary() * secondNumber.getReal();

        displayComplexNumber(new ComplexNumber(realProduct, imaginaryProduct));

        return new ComplexNumber(realProduct, imaginaryProduct);
    }
}
