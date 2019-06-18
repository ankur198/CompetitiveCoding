# https://www.hackerrank.com/challenges/magic-square-forming/problem

validSquares = [
    [
        [8, 1, 6],
        [3, 5, 7],
        [4, 9, 2]
    ],
    [
        [6, 1, 8],
        [7, 5, 3],
        [2, 9, 4]
    ],
    [
        [4, 9, 2],
        [3, 5, 7],
        [8, 1, 6]
    ],
    [
        [2, 9, 4],
        [7, 5, 3],
        [6, 1, 8]
    ],
    [
        [8, 3, 4],
        [1, 5, 9],
        [6, 7, 2]
    ],
    [
        [4, 3, 8],
        [9, 5, 1],
        [2, 7, 6]
    ],
    [
        [6, 7, 2],
        [1, 5, 9],
        [8, 3, 4]
    ],
    [
        [2, 7, 6],
        [9, 5, 1],
        [4, 3, 8]
    ]
]


def form(s):
    mini = 12345678
    for k in validSquares:
        diff = 0
        for i in range(3):
            for j in range(3):
                diff += abs(s[i][j] - k[i][j])
        mini = min(mini, diff)
    return mini

form([[4,9,2],[3,5,7],[8,1,5]])