class Home:
    def __init__(self, row, col, isReady):
        self.qualities = 0
        self.isReady = isReady
        self.location = [row, col]

    def __str__(self):
        return str(self.isReady)

    def __repr__(self):
        return self.__str__()

    def addQuality(self, home):
        if self.isReady == '1' and home.isReady == '1':
            self.qualities += 1
            home.qualities += 1


def createMatrix(row, col, isReady):
    res = []
    for i in range(row):
        res.append([])
        for j in range(col):
            res[i].append(Home(i, j, isReady[i][j]))
    return res


def findNeighbor(i, j, homeMatrix):
    row = len(homeMatrix)
    col = len(homeMatrix[0])

    neighbors = []

    el = homeMatrix[i][j]
    if i > 0:
        if j != col-1:
            #  not at the last column
            neighborTopRight = homeMatrix[i-1][j+1]
            neighbors.append(neighborTopRight)

        neighborTop = homeMatrix[i-1][j]
        neighbors.append(neighborTop)

        if j != 0:
            # not at first column
            neighborTopLeft = homeMatrix[i-1][j-1]
            neighbors.append(neighborTopLeft)

    if j != 0:
        neighborLeft = homeMatrix[i][j-1]
        neighbors.append(neighborLeft)

    return neighbors


def computeQuality(homeMatrix):
    row = len(homeMatrix)
    col = len(homeMatrix[0])

    closest = None
    maxQuality = 0

    for i in range(row-1, -1, -1):
        for j in range(col-1, -1, -1):
            el = homeMatrix[i][j]

            for n in findNeighbor(i, j, homeMatrix):
                el.addQuality(n)

            if closest == None:
                closest = el
                maxQuality = el.qualities

            elif maxQuality < el.qualities:
                maxQuality = el.qualities
                closest = el

            elif maxQuality == el.qualities:
                oldDistance = (
                    closest.location[0] - 0) + (closest.location[1]-0)
                newDistance = i-0+j-0
                if newDistance < oldDistance:
                    closest = el
    return closest

def Algorithm(matrix):
    
    closest = computeQuality(matrix)

    print(
        f'{closest.location[0]+1}:{closest.location[1]+1}:{closest.qualities}')

def RealInput():
    r, c = [int(x) for x in (input().split(' '))]
    isReady = []
    for i in range(r):
        isReady.append(input().split(' '))
    
    matrix = createMatrix(r, c, isReady)
    Algorithm(matrix)


def mockInput():
    r, c = [int(x) for x in ('6 6'.split(' '))]
    isReady = [[], [], [], [], [], []]
    isReady[0].extend('1 0 0 0 0 0'.split(' '))
    isReady[1].extend('0 0 0 0 0 0'.split(' '))
    isReady[2].extend('0 0 1 1 1 0'.split(' '))
    isReady[3].extend('0 0 1 1 1 0'.split(' '))
    isReady[4].extend('0 0 1 1 1 0'.split(' '))
    isReady[5].extend('0 0 1 1 1 0'.split(' '))

    x = createMatrix(r, c, isReady)
    
    Algorithm(x)
    verbosePrint(x)

def verbosePrint(matrix):
    for i in matrix:
        for j in i:
            print(j, end=' ')
        print()

    print('\n\n')

    for i in matrix:
        for j in i:
            print(j.qualities, end=' ')
        print()

    print()



# mockInput()
RealInput()