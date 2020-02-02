using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class DnaSequenceGenerator
{
    private static Dictionary<char, Color> baseColors = new Dictionary<char, Color>()
    {
        {'A', Color.magenta},
        {'T', Color.green},
        {'C', Color.red},
        {'G', Color.yellow},
    };
    
    public DnaSequenceGenerator()
    {
    }

    public char BaseMatch(char basis, bool isWrong = false)
    {
        if (isWrong)
        {
            
            switch (basis)
            {
                case 'A':
                    return 'C';
                case 'T':
                    return 'G';
                case 'C':
                    return 'A';
                case 'G':
                    return 'T';
            }
        }
        switch (basis)
        {
            case 'A':
                return 'T';
            case 'T':
                return 'A';
            case 'C':
                return 'G';
            case 'G':
                return 'C';
        }

        throw new Exception("No match found for " + basis);
    }

    public char[] GenerateSequence(int length)
    {
        char[] bases = {'A', 'G', 'C', 'T'};
        char[] resutltArray = new char[length] ;
        Random rnd = new Random();
        for (int i = 0; i < length; i++)
        {
            resutltArray[i] = bases[rnd.Next(0, 4)];
        }

        return resutltArray;
    }

    public static Color getBaseColor(char basis)
    {
        return baseColors[basis];
    }

    public static char GetNextBase(char prev)
    {
        switch (prev)
        {
            case 'A':
                return 'T';
            case 'T':
                return 'G';
            case 'G':
                return 'C';
            case 'C':
                return 'A';
        }

        throw new Exception("Wrong previous character " + prev);
    }
}