using System;

class Program
{
    static void Main()
    {
        string input = "abcdu";
        string result = VowelShiftCipher(input);
        Console.WriteLine(result);
    }

    static string VowelShiftCipher(string s)
    {
        string vowels = "aeiou";
        char[] result = new char[s.Length];

        for (int i = 0; i < s.Length; i++)
        {
            char ch = s[i];

            if (vowels.Contains(ch))
            {
                result[i] = NextVowel(ch);
            }
            else
            {
                char next = (char)(ch + 1);
                if (vowels.Contains(next))
                {
                    next = (char)(next + 1);
                }
                result[i] = next;
            }
        }

        return new string(result);
    }

    static char NextVowel(char v)
    {
        switch (v)
        {
            case 'a': return 'e';
            case 'e': return 'i';
            case 'i': return 'o';
            case 'o': return 'u';
            case 'u': return 'a';
            default: return v;
        }
    }
}