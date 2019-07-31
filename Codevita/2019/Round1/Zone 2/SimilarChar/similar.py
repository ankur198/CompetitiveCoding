# # L = int(input())
# s = "abacsddaa"

# Q = 2

# for _ in range(Q):
#     i = int(input())
#     c = s[i-1]
#     print(s.count(c, 0, i-1))


L = int(input())
s = input()

Q = int(input())

res = []
for _ in range(Q):
    i = int(input())
    c = s[i-1]
    count = 0
    for l in range(i-1):
        if s[l] == c:
            count += 1
    res.append(count)

for i in res[:-1]:
    print(i)
print(res[-1], end='')
