package Lab1;

/*
Two 3x3 array are given,
- first matrix: R1 = [2 3 1], R2 = [7 1 6], R3 = [9 2 4]
- the second matrix: R1 = [8 5 3], R2 = [3 9 2], R3 = [2 7 3]
Calculate the sum and the product of the two matrices. Check the result.
 */

public class Exercise2 {
    public static void main(String[] args) {
        int[][] sumMatrix;
        int[][] productMatrix;

        int[][] firstMatrix = {
                {2, 3, 1},
                {7, 1, 6},
                {9, 2, 4},
        };

        int[][] secondMatrix = {
                {8, 5, 3},
                {3, 9, 2},
                {2, 7, 3},
        };

        System.out.println("The two initial matrices are: ");
        display3DMatrix(firstMatrix);
        System.out.println("\n");
        display3DMatrix(secondMatrix);

        sumMatrix = sumOfTheMatrices(firstMatrix, secondMatrix);
        productMatrix = productOfTheMatrices(firstMatrix, secondMatrix);
    }

    // function for displaying a three-dimensional matrix
    public static void display3DMatrix(int[][] matrix) {
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                System.out.print(matrix[i][j] + "\t");
            }
            System.out.println("\n");
        }
    }

    // calculating and displaying the sum of the matrices
    public static int[][] sumOfTheMatrices(int[][] firstMatrix, int[][] secondMatrix) {
        int[][] sumMatrix = new int[3][3];

        System.out.println("The sum of the two matrices is equal with: ");
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                sumMatrix[i][j] = firstMatrix[i][j] + secondMatrix[i][j];
            }
        }

        display3DMatrix(sumMatrix);

        return sumMatrix;
    }

    // calculating and displaying the product of the matrices
    public static int[][] productOfTheMatrices(int[][] firstMatrix, int[][] secondMatrix) {
        int[][] productMatrix = new int[3][3];

        System.out.println("The product of the two matrices is equal with: ");
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                for (int k = 0; k < 3; k++) {
                    productMatrix[i][j] += firstMatrix[i][k] * secondMatrix[k][j];
                }
            }
        }

        display3DMatrix(productMatrix);

        return productMatrix;
    }
}
