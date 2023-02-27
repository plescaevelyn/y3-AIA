package Lab1;

/*
Two 3x3 array are given,
- first matrix: R1 = [2 3 1], R2 = [7 1 6], R3 = [9 2 4]
- the second matrix: R1 = [8 5 3], R2 = [3 9 2], R3 = [2 7 3]
Calculate the sum and the product of the two matrices. Check the result.
 */

public class Exercise2 {
    int[][] sumMatrix = new int[3][3];
    int[][] productMatrix = new int[3][3];

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

    // calculating and displaying the sum of the matrices
    for (int i = 0; i < 3; i++) {
        for (int j = 0; j < 3; j++) {
            sumMatrix[i][j] = firstMatrix[i][j] + secondMatrix[i][j];
        }
    }

    // calculating and displaying the product of the matrices

}
