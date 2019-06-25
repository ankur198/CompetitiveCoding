from itertools import permutations

factors = []


def getFactors(n):
    global factors
    f = []
    for i in range(1, n+1):
        if n % i == 0:
            f.append(i)
    factors = f
    return f


def isValidPermutation(permutation):
    for i in range(len(permutation)-1):
        firstEl = permutation[i]
        secondEl = permutation[i+1]

        for j in range(len(factors)-1):
            orderedF = factors[j]
            orderedS = factors[j+1]

            if firstEl == orderedF and secondEl == orderedS:
                return False
    return True

cases = int(input())
for i in range(cases):
    print(len(list(filter(isValidPermutation, list(permutations(getFactors(int(input())), len(factors)))))))
