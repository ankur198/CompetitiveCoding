# https://www.hackerrank.com/challenges/climbing-the-leaderboard/problem?h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen

def makeDict(l):
    d = {}
    for i in l:
        if i in d:
            d[i] +=1
        else:
            d[i] = 1
    return d

def findRank(score,d):
    l = sorted(d.keys())
    l = l[::-1]
    pos = 1
    for i in l:
        if i==score:
            break
        else:
            pos+=1
    return pos

def climbingLeaderboard(scores, alice):
    od = set(scores)
    res = []
    for i in alice:
        d = eval(str(od))
        if i in d:
            d[i]+=1
        else:
            d[i] = 1
        res.append(findRank(i,d))
    return res

print(climbingLeaderboard([100,100,50,40,20,10],[5,25,50,120]))

    


