import math

records = []
days = 0
totalIntrest = 0


class statement:
    intrestPercent = 0

    def __init__(self, stringRecord):
        stringRecord = stringRecord.split(' ')
        self.id = int(stringRecord[0])
        self.amount = int(stringRecord[1])
        self.isCredit = stringRecord[2] == 'credit'
        self.balance = int(stringRecord[3])
        self.intrest = self.balance*self.intrestPercent/365


def fakeInput():
    global records, days, totalIntrest

    statement.intrestPercent = 8.0/100
    days = 10
    records.append(statement('1 355 credit 355'))
    records.append(statement('2 202 debit 153'))
    records.append(statement('3 59 debit 94'))
    records.append(statement('4 31 debit 63'))
    records.append(statement('7 355 debit 261'))
    records.append(statement('8 253 credit 514'))
    records.append(statement('9 308 debit 206'))
    records.append(statement('10 69 debit 137'))

    totalIntrest = 0.6084383561643835


def realInput():
    global records, days, totalIntrest

    statement.intrestPercent = float(input())
    days = int(input())
    for i in range(days-2):
        records.append(statement(input()))

    totalIntrest = float(input())


def main():
    # fakeInput()
    realInput()
    computedIntrest = GetComputedTotalIntrest()
    differenceIntrest = totalIntrest-computedIntrest
    differenceAmount = getAmountForIntrest(differenceIntrest)
    for i in (getMissingStatement(differenceAmount)):
        print(i)
    print(GetComputedTotalIntrest())


def GetComputedTotalIntrest():
    res = 0
    for record in records:
        res += record.intrest
        # print(record.balance,record.intrest)
    return res


def getAmountForIntrest(intrest):
    res = (intrest*365)/(statement.intrestPercent)
    return res


def getMissingId():
    ids = list(range(1, days+1))
    for i in records:
        ids.remove(i.id)

    return ids


def getMissingStatement(amount):
    amounts = math.ceil(amount/2), math.floor(amount/2)
    ids = getMissingId()
    stringStatements = []

    for i in range(len(amounts)):

        prevBalance = getBalance(ids[i]-1)

        isCredit = 'debit'
        if amounts[i]-prevBalance > 0:
            isCredit = 'credit'

        stringStatement = f'{ids[i]} {abs(amounts[i]-prevBalance)} {isCredit} {amounts[i]}'
        records.append(statement(stringStatement))
        stringStatements.append(stringStatement)
    return stringStatements


def getBalance(statementId):
    for i in records:
        if i.id == statementId:
            return i.balance


main()
