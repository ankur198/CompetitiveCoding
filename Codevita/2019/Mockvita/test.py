from itertools import combinations
class Solution:
    def find132pattern(self, nums):
        smallest = {'index':-1,'value':None}
        largest = {'index':-1,'value':None}
        greaterThanSmallest = {'index':-1,'value':None}
        
        for i in range(len(nums)):
            el = nums[i]
            if smallest['value'] == None or el<smallest['value'] :
                smallest['index']=i
                smallest['value']=el
                largest['index']=i
                largest['value']=el
                
            elif largest['value'] == None or el>largest['value']:
                largest['index']=i
                largest['value']=el
            
            elif el>smallest['value'] and el<largest['value']:
                greaterThanSmallest['value'] = el
                greaterThanSmallest['index'] = i
            if smallest['index']<largest['index'] and greaterThanSmallest['index'] > largest['index']:
                return True
        return False
    
print(Solution().find132pattern([3,5,0,3,4]))