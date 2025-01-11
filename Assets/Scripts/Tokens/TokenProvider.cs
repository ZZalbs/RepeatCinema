using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TokenProvider : MonoBehaviour
{
    private TokenController tokenController;

    private Dictionary<int, TokenBase> positiveTokenPool;
    private Dictionary<int, TokenBase> negativeTokenPool;

    private System.Random random;

    private void Awake()
    {
        random = new();
    }

    private Rarity GetRandomRarity()
    {
        int prob = Random.Range(0, 100);

        Rarity rarity = prob switch
        {
            < 60 => Rarity.Common,
            < 90 => Rarity.Rare,
            < 99 => Rarity.Epic,
            < 100 => Rarity.Legendary,
            _ => Rarity.Common
        };

        return rarity;
    }

    public List<TokenPair> GetRandomTokens()
    {
        Dictionary<int, TokenBase> poppedPositiveTokens = new(3);
        Dictionary<int, TokenBase> poppedNegativeTokens = new(3);
        List<TokenPair> tokens = new(3);

        for (int i = 0; i < 3; i++)
        {
            var rarity = GetRandomRarity();
            var positive = positiveTokenPool.Where(x => !(poppedPositiveTokens.ContainsKey(x.Key)) && rarity == x.Value.Rarity).OrderBy(_ => random.Next()).First();
            var negative = negativeTokenPool.Where(x => !(poppedNegativeTokens.ContainsKey(x.Key)) && rarity == x.Value.Rarity).OrderBy(_ => random.Next()).First();

            poppedPositiveTokens.Add(positive.Key, positive.Value);
            poppedNegativeTokens.Add(negative.Key, negative.Value);


            TokenPair pair = new TokenPair
            {
                PositiveToken = positive.Value,
                NegativeToken = negative.Value
            };
            tokens.Add(pair);
        }
 
        return tokens;
    }
}