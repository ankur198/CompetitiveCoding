N = 3
T = 8
persons = ["2 2 4 3 5 2 6 2 3", "3 5 7 4 3 9 3 2 2", "1 2 4 2 7 5 3 2 4"]

computedDistance = []
for i in persons:
    data = list(map(int, i.split()))
    steps = data[-1]
    lapTimes = [0]
    for j in range(1, T-1, 2):
        totalStpes = lapTimes[-1] + steps*(data[j]+data[j-1])
        lapTimes.append(totalStpes)
    computedDistance.append(lapTimes[1:])

# counting

fastest = [0]*N

for i in range((T-1)//2):

    # getfastest
    faster = 0
    for j in range(N):
        faster = max(computedDistance[j][i], faster)

    # update count
    for j in range(N):
        if computedDistance[j][i] == faster:
            fastest[j] += 1

maxCount = max(fastest)
for i in range(len(fastest)):
    if fastest[i] == maxCount:
        print(i+1)
        break
