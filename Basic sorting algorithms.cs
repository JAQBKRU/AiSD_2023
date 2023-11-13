//https://www.programiz.com/dsa/sorting-algorithm
https://lamfo-unb.github.io/2019/04/21/Sorting-algorithms/

//get data from user input
//function to convert input data from "1 7 3 4   " to [1, 7, 3, 4]
int[] convertData()
{
    return inputUser.Text.Trim().Split(' ').Select(s => int.Parse(s)).ToArray();
}

//run after button clicked
private void btn_Click(object sender. EventArgs e)
{
    labelObject = "";
    int[] arr = convertData();
    algorithmsToRun(arr);
    labelObject += string.Join(", ", arr); //from array [1, 3, 4, 7] to string 1, 3, 4, 7
}

//bubbleSort
void bubbleSort(int[] arr)
{
    int cbz = 1;
    while(cbz == 1)
    {
        cbz = 0;
        for(int i=0; i < arr.Length - 1; i++)
        {
            if (arr[i] > arr[i+1])
            {
                (arr[i+1], arr[i]) = (arr[i], arr[i+1]);
                cbz = 1;
            }
        }
        if(cbz == 0)
        {
            break;
        }
    }
}

//selectionSort
//get minValue for selectionSort
int[] minValue(int[] arr, int index)
{
    int[] minElement = { arr[index], index };
    for(int i = index; i < arr.Length; i++)
    {
        if (arr[i] < minElement[0]) (minElement[0], minElement[1]) = (arr[i], i);// < - ACS, > - DESC
    }

    return minElement;
}

void selectionSort(int[] arr)
{
    for(int i = 0; i < arr.Length - 1; i++)
    {
        int[] minELement = minValue(arr, i);
        (arr[i], arr[minELement[1]]) = (minELement[0], arr[i]);
    }
}

//insertionSort
void insertionSort(int[] arr)
{
    for(int i = 0; i < arr.Length - 1; i++)
    {
        int aktualny = arr[i + 1];
        int j = i;
        while(j >= 0 && arr[j] > aktualny)
        {
            arr[j+1] = arr[j];
            j--;
        }
        arr[j+1] = aktualny;
    }
}


//margeSort
// Merge two subarrays L and M into arr
void merge(int[] arr, int p, int q, int r)
{
    // Create L ← A[p..q] and M ← A[q+1..r]
    int n1 = q - p + 1;
    int n2 = r - q;

    int[] L = new int[n1];
    int[] M = new int[n2];

    for (int ii = 0; ii < n1; ii++)
        L[ii] = arr[p + ii];
    for (int jj = 0; jj < n2; jj++)
        M[jj] = arr[q + 1 + jj];

    // Maintain current index of sub-arrays and main array
    int i, j, k;
    i = 0;
    j = 0;
    k = p;

    // Until we reach either end of either L or M, pick larger among
    // elements L and M and place them in the correct position at A[p..r]
    while (i < n1 && j < n2)
    {
        if(L[i] <= M[j]) arr[k++] = L[i++];
        else arr[k++] = M[j++];
    }

    // When we run out of elements in either L or M,
    // pick up the remaining elements and put in A[p..r]
    while (i < n1)
    {
        arr[k++] = L[i++];
    }

    while (j < n2)
    {
        arr[k++] = M[j++];
    }
}

void mergeSort(int[] arr, int l, int size)//execute like: mergeSort(arr, 0, arr.Length - 1);
{
    if (l < size)
    {
        int indexDividingSubarrays = l + (size - l) / 2;
        mergeSort(arr, l, indexDividingSubarrays);
        mergeSort(arr, indexDividingSubarrays + 1, size);

        //merging sorted subarrays
        merge(arr, l, indexDividingSubarrays, size);
    }
}

//quickSort


//heapSort


//countingSort


//radixSort


//bucketSort


//przybornik
//label - np. WYNIK:
//button - np. SB
//textBox - np. 1 7 3 4