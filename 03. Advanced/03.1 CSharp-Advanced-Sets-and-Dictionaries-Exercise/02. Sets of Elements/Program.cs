int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
int n = size[0];
int m = size[1];

HashSet<int> setN = new HashSet<int>();

for(int i = 0; i < n; i++)
{
    setN.Add(int.Parse(Console.ReadLine()));
}

HashSet<int> setM = new HashSet<int>();

for(int i = 0;i < m; i++)
{
    setM.Add(int.Parse(Console.ReadLine()));
}

setN.IntersectWith(setM);
Console.WriteLine(string.Join(" ", setN));
