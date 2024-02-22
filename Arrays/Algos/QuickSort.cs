public static int[] QuickSort(int[] arr, int start, int end)
{
    if(end-start + 1 <= 1) return arr;

    //set the pivot as the last element
    int pivot = arr[e];
    //set the pointer as the 0 index
    int pointer = start;

    for(int i = start; i <= end; i++)
    {
        if(arr[i] < pivot)
        {
            int temp = arr[left];
            arr[left] = arr[i];
            arr[i] = temp;
            left++;
        }
    }

    arr[e] = arr[left];
    arr[left] = pivot;

    //sort left
    QuickSort(arr, start, left-1);

    //sort right
    QuickSort(arr, left+1, end);

    return arr;
}