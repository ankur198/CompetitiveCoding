# Overlapping Boxes

## Problem Description

There are N rectangular boxes(Bi) and each has a special value(Power) Pi. These rectangular boxes are placed in the first quadrants of the x-y plane.
These boxes are represented by two coordinates,bottom-left and top-right.

### Example:
Below rectangle(highlighted with yellow) is represented as (1,1) i.e. bottom-left and (3,6) i.e. top-right
 
If two boxes(B1 & B2 with special value P1 & P2 respectively) overlap each other, then the special value of the common area is P1+P2.
Find the total area with maximum Power.

#### Constraints

    1<=N<=10^5
    0<=x,y <= 10^4 i.e.the lowest co-ordinate of bottom-left corner is (0,0) and the highest coordinate of top-right corner is (10000,10000)
    1<=P<=100

#### Input Format

The first line contains the number of boxes N
In next N lines, each line contains five integers where
The first two integers represent the (x, y) coordinates of bottom-left corner
Next two integers represent the (x, y) coordinates of top-right corner respectively
The last integer represents the special value or power, P

#### Output

Total area with maximum power
Test Case

##### Explanation
##### Example 1
2
1 1 3 6 5
2 2 4 4 8

#### Sample output #1
2
#### Explanation #1
 
The area highlighted with red has the highest value of P and its area is 2

#### Example 2
5
21 46 38 56 13
26 28 47 38 8
18 32 38 38 5
31 35 42 51 8
39 31 45 38 5
#### output
65

#### Explanation #1
 
Above image is only for illustration. Not a scaled image.
Total Area with P=21 is 65.

