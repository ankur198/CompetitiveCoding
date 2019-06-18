def swapDiagonals(matrix):
    matrixOrder = len(matrix)
    for i in range(matrixOrder):
        matrix[i][i], matrix[i][matrixOrder -
                                i-1] = matrix[i][matrixOrder-i-1], matrix[i][i]
    return matrix

print(swapDiagonals([[1,2,3],[4,5,6],[7,8,9]]))