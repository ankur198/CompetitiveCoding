import math
from decimal import Decimal
from fractions import Fraction


def fact(n):
    return math.factorial(n)


def getCombination(n, r):
    return fact(n)/(fact(n-r)*fact(r))


def getWinProb(string):
    t = list(map(int, string.split()))
    A = t[0]
    H = t[1]
    P = t[2]/t[3]
    Chances = t[4]
    Boost = t[5]

    remHealth = H-A*Chances
    if remHealth > Boost*Chances:
        return "RIP"

    favConditions = []
    probabilityInEachCase = []
    maxZero = 0
    for numZeros in range(Chances+1):
        if Boost*(Chances-numZeros) >= remHealth:
            totalWays = getCombination(
                Chances+numZeros, Chances) - sum(favConditions)

            prob = 1
            if Chances-numZeros > 0:
                prob *= float(Decimal(str(P))**(Chances-numZeros))
            if numZeros > 0:
                prob *= float((1-(Decimal(str(P))))**numZeros)

            favConditions.append(totalWays)
            probabilityInEachCase.append(prob*totalWays)
        else:
            break

    s = sum(probabilityInEachCase)
    s = Fraction(s).limit_denominator()
    return str(s)


# raw = "10 33 7 10 3 2"
# dec = getWinProb(raw)
# print(dec)
res = []
N = int(input())
for i in range(N):
    s = input()
    res.append(getWinProb(s))

for i in res:
    print(i)
