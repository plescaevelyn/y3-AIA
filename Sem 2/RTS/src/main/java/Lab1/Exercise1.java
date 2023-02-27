/*
There are two complex numbers: 2+5i and 4-i. To create an application that calculates the summation and the product of
the two numbers, to verify the results.
 */

package Lab1;
import java.util.Scanner;

public class Exercise1 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int[][] number = new int[2][2];
        int[][] sum = new int[2][2];

        System.out.print("Please enter the first number:\t");
        number[0][0] = scanner.nextInt();
        number[0][1] = scanner.nextInt();

        System.out.print("Please enter the second number:\t");
        number[1][0] = scanner.nextInt();
        number[1][1] = scanner.nextInt();

        // calculating and displaying the sum of the two complex numbers
        sum[0][0] = number[0][0] + number[1][0];
        sum[0][1] = number[0][1] + number[1][1];

        if (sum[0][1] < 0) {
            System.out.println("The sum of the two complex numbers is:\t" + sum[0][0] + " - " + sum[0][1] + "i");
        } else if (sum[0][1] > 0) {
            System.out.println("The sum of the two complex numbers is:\t" + sum[0][0] + " + " + sum[0][1] + "i");
        } else {
            System.out.println("The sum of the two complex numbers is:\t" + sum[0][0]);
        }

        // calculating and displaying the product of the two complex numbers
        int realProduct = number[0][0]*number[0][1];
        int imaginaryProduct = number[0][1]*number[1][0];

        if (imaginaryProduct < 0) {
            System.out.println("The sum of the two complex numbers is:\t" + realProduct + " - " + imaginaryProduct + "i");
        } else if (imaginaryProduct > 0) {
            System.out.println("The sum of the two complex numbers is:\t" + realProduct + " + " + imaginaryProduct + "i");
        } else {
            System.out.println("The sum of the two complex numbers is:\t" + realProduct);
        }
    }
}
