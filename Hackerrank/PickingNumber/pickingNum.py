# https://www.hackerrank.com/challenges/picking-numbers/problem?h_r=next-challenge&h_v=zen

def makeDict(s):
    d = {}
    for i in s:
        if i in d:
            d[i]+=1
        else:
            d[i]=1
    return d

def getMaxSet(d):
    longest=0
    for i in d:
        curr = d[i]
        if i+1 in d:
            curr+=d[i+1]
        longest = max(longest,curr)
    return longest

def mainFun():
    l = [1,2,3,4,5,4,2,5,2,7]
    print(getMaxSet(makeDict(l)))

mainFun()