# def create_staircase(nums):
#   while len(nums) != 0:
#     step = 1 #step is initialized to one everytime
#     subsets = [] ///subset is set to an empty list
#     if len(nums) >= step:
#       subsets.append(nums[0:step]) //subset 
#       nums = nums[step:]
#       step += 1 the false check is never hit
#     else:
#       return False

#   return subsets




def create_staircase(nums):
  step = 1
  subsets = []
  while len(nums) != 0:
    if len(nums) >= step:
      subsets.append(nums[0:step])
      nums = nums[step:]
      step += 1
    else:
      return False
      
  return subsets

arr = [1,2,3,4,5,6]
print(create_staircase(arr))