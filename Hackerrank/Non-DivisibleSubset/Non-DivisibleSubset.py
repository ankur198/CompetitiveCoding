# https://www.hackerrank.com/challenges/non-divisible-subset/problem
from itertools import combinations


divisibilityCheck = 0
done = []
origList = []


class Node:
    def __init__(self):
        self.currentList = []
        self.index = 0

    def isFeasible(self):
        x = combinations(self.currentList, 2)
        return len(list(filter(lambda i: sum(i) % divisibilityCheck == 0, x))) == 0
        # for i in x:
        #     if sum(i) % divisibilityCheck == 0:
        #         return False
        # return True

    def add(self, value=None):
        if value != None:
            self.currentList.append(value)
        self.index += 1

    @staticmethod
    def copyNode(parentNode):
        newNode = Node()
        newNode.currentList = eval(str(parentNode.currentList))
        newNode.index = parentNode.index
        return newNode


def traverse(parentNode):
    if parentNode.isFeasible():
        done.append(parentNode.currentList)

        if parentNode.index < len(origList):
            child1 = Node.copyNode(parentNode)
            child2 = Node.copyNode(parentNode)
            child1.add(origList[child1.index])
            child2.add()

            traverse(child1)
            traverse(child2)


def main():
    traverse(Node())
    return max([len(i) for i in done])


divisibilityCheck = 3
origList = [1, 7, 2, 4]
print(main())
print(done)
