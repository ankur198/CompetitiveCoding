# Approach is to first sort them them swap each alternative items

# time complexity   = O (n log n)
# space complextity = O (n) 

def haveBigNosBtwSmallNos(numbers):
    
    # Using python built in Tim Sort have avg complexity of O(n log n)    
    numbers.sort()

    ''' 
    traversing through the list with a step of two
    so that we can swap items
    '''
    for i in range(1,len(numbers),2):

        if(i+1<len(numbers)):
            
            # storing front item (if possible) then
            # the current item to make a swap

            numbers[i+1],numbers[i] = numbers[i],numbers[i+1]

    return numbers


l = [1,4,7,9,1,3,5,10,11] # 9 list items
print(haveBigNosBtwSmallNos(l))

l = [1,4,7,9,1,3,5,10] # 8 list items
print(haveBigNosBtwSmallNos(l))
