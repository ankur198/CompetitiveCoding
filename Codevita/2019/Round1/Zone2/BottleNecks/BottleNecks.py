class cap:
    def __init__(self, value):
        self.value = value
        self.inside = None

    def __str__(self):
        return self.value

    def __repr__(self):
        return self.value


def minimize(l):
    minEl = 0
    minSel = None
    for i in range(len(l)):
        if l[minEl].value > l[i].value:
            minEl = i
    chota = l.pop(minEl)

    for i in range(len(l)):
        if l[i].inside == None and chota.value < l[i].value:
            if minSel == None:
                minSel = i
            elif l[minSel].value > l[i].value:
                minSel = i

    if minSel != None:
        l[minSel].inside = chota
        return True
    else:
        l.insert(minEl, chota)


l = list(map(int, input().split(' ')))
# l = [1, 1, 2, 3, 4, 5, 5, 4]
# l = [10,9,8,7,6,5,4,3,2,1]
# l = [8, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1]

for i in range(len(l)):
    l[i] = cap(l[i])

val = minimize(l)
while val:
    val = minimize(l)
    for i in l:
        print(str(i.value)+',', end='')
    print()

print(len(l), end='')
