from itertools import permutations

n = 6

allWays = permutations((range(n)), n)
correctWays = []
c=0
for i in allWays:
    c+=1
    for j in range(n):
        if i[j] == j:
            break
    else:
        correctWays.append(i)

print(len(correctWays))
#print(c)
