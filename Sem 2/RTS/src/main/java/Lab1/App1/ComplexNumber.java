/*
There are two complex numbers: 2+5i and 4-i. To create an application that calculates the summation and the product of
the two numbers, to verify the results.
 */


package Lab1.App1;

public class ComplexNumber {
    int real;
    int imaginary;

    public ComplexNumber() {
    }

    public ComplexNumber(int real, int imaginary) {
        this.real = real;
        this.imaginary = imaginary;
    }

    public int getReal() {
        return real;
    }

    public void setReal(int real) {
        this.real = real;
    }

    public int getImaginary() {
        return imaginary;
    }

    public void setImaginary(int imaginary) {
        this.imaginary = imaginary;
    }
}
