int lengthOfSequences = int.Parse(Console.ReadLine());

string input = Console.ReadLine();

int bestStartIndex = int.MaxValue;
int bestSequenceIndex = int.MaxValue;
int bestSequenceSum = 0;
int bestSequenceLength = 0;
int[] bestDNA = new int[lengthOfSequences];

int sequenceIndex = 0;

while (input != "Clone them!")
{
    int[] DNA = input.Split('!', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
    
    sequenceIndex++;

    int currentLength = 0;
    int sequenceLength = 0;
    int lastSequenceLength = 0;
    int endIndex = 0;
    int lastEndIndex = 0;
    bool isSequence = false;

    for (int i = 0; i < lengthOfSequences; i++)
    {
        if (DNA[i] == 0)
        {
            lastSequenceLength = sequenceLength;
            lastEndIndex = endIndex;
            isSequence = false;
            currentLength = 0;
            continue;
        }
        else if (!isSequence)
        {
            isSequence = true;
            currentLength++;
        }
        else if (isSequence)
        {
            currentLength++;
            sequenceLength = currentLength;
            endIndex = i;
        }

        if (lastSequenceLength > sequenceLength)
        {
            sequenceLength = lastSequenceLength;
            endIndex = lastEndIndex;
        }
    }

    int startIndex = endIndex - sequenceLength;

    if (bestSequenceLength < sequenceLength  
        || (bestSequenceLength == sequenceLength && bestStartIndex > startIndex) 
        || (bestSequenceLength == sequenceLength && bestStartIndex == startIndex && bestSequenceSum < DNA.Sum())
        )
    {
        bestSequenceLength = sequenceLength;
        bestSequenceIndex = sequenceIndex;
        bestStartIndex = startIndex;
        bestSequenceSum = DNA.Sum();
        Array.Copy(DNA, bestDNA, bestDNA.Length);
    }

    input = Console.ReadLine();
}

bestSequenceSum = bestDNA.Sum();

// print result
Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}.");
Console.WriteLine(string.Join(" ", bestDNA));
