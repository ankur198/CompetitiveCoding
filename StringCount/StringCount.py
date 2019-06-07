def getScringCount(stringArray):
    # simple key value problem
    d = {}
    #iterate over each word
    for i in stringArray:
        #if we already have that word as a key then increment the count
        if i in d:
            d[i] += 1
        #else create a new key and set count to 1
        else:
            d[i] = 1
    return d


x = ['kasol', 'kasol', 'manali', 'delhi', 'delhi', 'manali', 'kasol']

# get input from user and split it using ' ' (space)
x = input("Input list of words seperated by ' '(space): ").split(' ')  # comment this line to run predefind test string
res = getScringCount(x)

# print output
for i in res:
    # key = value
    print(i, '=', res[i])
