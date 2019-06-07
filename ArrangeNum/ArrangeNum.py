def haveBigNosBtwSmallNos(numbers):
    # Using python built in Tim Sort have avg complexity of O(n log n)    
    numbers.sort()

    # creating for final result and appending first item
    res = []
    res.append(numbers[0])

    ''' 
    traversing through the list with a step of two
    so that we can swap items
    '''
    for i in range(1,len(numbers),2):

        '''
        first appending front item (if possible) then
        the current item to make a swap
        '''

        if(i+1<len(numbers)):
            res.append(numbers[i+1])
        res.append(numbers[i])

        
    return res


l = [1,4,7,9,1,3,5,10,11] # 9 list items
print(haveBigNosBtwSmallNos(l))

l = [1,4,7,9,1,3,5,10] # 8 list items
print(haveBigNosBtwSmallNos(l))
