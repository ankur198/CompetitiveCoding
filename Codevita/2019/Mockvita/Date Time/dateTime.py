digits = map(int, '0,0,1,2,2,2,3,5,9,9,9,9'.split(',').reverse())


def getTime():
    hour = getHour()


def getHour():
    hour = ''
    for i in digits:
        if(i < 2):
            hour += str(i)
            digits.remove(i)
            break

    if int(hour) > 0:
        for i in digits:
            if(i < 3):
                hour += str(i)
                digits.remove(i)
                return
    else:
        hour+=str(digits[-1])
        digits.remove(i)
        
