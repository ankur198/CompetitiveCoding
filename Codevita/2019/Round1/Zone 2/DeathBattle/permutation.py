import itertools

case = [2, 2, 2, 2,0]
x = list(itertools.combinations(case, 4))
print(x, len(x))
