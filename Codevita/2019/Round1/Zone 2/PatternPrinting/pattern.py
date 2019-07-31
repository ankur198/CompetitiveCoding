n = 4

sp = 0
half1 = []
num = 1
for i in range(n):
    row = "*"*sp
    sp += 2
    for j in range(n-i):
        row += f"{num}0"
        num += 1
    half1.append(row)

half2 = []
for i in range(n):
    row = ""
    for j in range(i+1):
        row += f"{num}0"
        num += 1
    half2.append(row[:-1])

half2.reverse()

for i in range(n):
    print(half1[i]+half2[i])
