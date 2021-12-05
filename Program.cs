// See https://aka.ms/new-console-template for more information

int deletedLetter = StringsMakingAnagrams("fcrxzwscanmligyxyvym", "jxwtrhvujlmrpdoqbisbwhmgpmeoke");

int  StringsMakingAnagrams(string strA, string strB)
{
    int result = 0;
    char[] charA = strA.ToCharArray().OrderBy(i => i).ToArray(); 
    Dictionary<char, int> strADic = new Dictionary<char, int>();
    for (int i = 0; i < charA.Length; i++)
    {
        if (strADic.ContainsKey(charA[i]))
            strADic[charA[i]]++;
        else
            strADic.Add(charA[i], 1);
    }
    Dictionary<char, int> strBDic = new Dictionary<char, int>();

    char[] charB = strB.ToCharArray().OrderBy(i => i).ToArray();
    for (int i = 0; i < charB.Length; i++)
        if (strBDic.ContainsKey(charB[i]))
            strBDic[charB[i]]++;
        else
            strBDic.Add(charB[i], 1);

    foreach (var item in strADic.ToList())
    {
        if (!strBDic.ContainsKey(item.Key))
        {
            result += item.Value;
            strADic[item.Key] = 0;
        }
       
    }
  
    foreach (var item in strBDic.ToList())
    {
        if (!strADic.ContainsKey(item.Key))
        {
            result += item.Value;
            strBDic[item.Key] = 0;
        }
        else if (item.Value >= 1)
        {
            result += Math.Abs(strADic[item.Key] - item.Value);
        }

    }

    return result;
}