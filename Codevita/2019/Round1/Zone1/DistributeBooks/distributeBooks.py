from itertools import permutations

n = 4

allWays = permutations((range(n)),n)
correctWays = []

for i in allWays:
    for j in range(n):
        if i[j] == j:
            break
    else:
        correctWays.append(i)

print(len(correctWays))