N = 3

tHoles = "21 3 6"
holes = []

capacity = 1
for i in tHoles.strip().split(' '):
    holes.append({"dia": int(i), "cap": capacity, "balls": []})
    capacity += 1

nBalls = "11"
Balls = list(map(int, "20 15 5 7 10 4 2 1 3 6 8".split(' ')))

holes.reverse()
res = []
for ball in Balls:
    done = False
    for hole in holes:
        if hole["dia"] >= ball and hole["cap"] > len(hole["balls"]):
            hole["balls"].append(ball)
            res.append(str(hole["cap"]))
            done = True
            break
    if not done:
        res.append("0")
print(" ".join(res))
