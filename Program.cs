class ele
{
    public int count, index, val;
};

class comp : Comparer<ele>
{
    public override int Compare(ele a, ele b)
    {
        return (a.val.CompareTo(b.val));
    }
};

class comp2 : Comparer<ele>
{
    public override int Compare(ele a, ele b)
    {
        if (a.count == b.count)
        {
            return (b.val).CompareTo(a.val);
        }
        return (a.count).CompareTo(b.count);
    }
};

class Solver
{

    static void sortByFrequency(int[] arr, int n)
    {
        ele[] element = new ele[n];
        for (int i = 0; i < n; i++)
        {

            element[i] = new ele();
            element[i].index = i;

            element[i].count = 0;

            element[i].val = arr[i];
        }

        Array.Sort(element, new comp());

        element[0].count = 1;

        for (int j = 1; j < n; j++)
        {
            if (element[j].val == element[j - 1].val)
            {
                element[j].count += element[j - 1].count + 1;
                element[j - 1].count = -1;
            }
            else
            {
                element[j].count = 1;
            }
        }

        Array.Sort(element, new comp2());

        for (int i = n - 1, index = 0; i >= 0; i--)
        {
            if (element[i].count != -1)
                for (int j = 0; j < element[i].count; j++)
                    arr[index++] = element[i].val;
        }
    }

    public static void Main(string[] args)
    {
        int[] arr = { 2, 5, 2, 6, -1, 9999999, 5, 8, 8, 8 };
        int n = arr.Length;

        sortByFrequency(arr, n);

        for (int i = 0; i < n; i++)
            Console.Write(arr[i] + " ");
    }

}