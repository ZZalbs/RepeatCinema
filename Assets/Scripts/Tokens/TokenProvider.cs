using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TokenProvider : MonoBehaviour
{
    struct TokenPair
    {
        public int PositiveId;
        public int NegativeId;
    }

    private TokenController tokenController;

    private List<TokenPair> tokenPairs;

    private Dictionary<int, TokenBase> positiveTokenPool;
    private Dictionary<int, TokenBase> negativeTokenPool;

    private System.Random random;

    private void Awake()
    {
        random = new();
    }

    public List<TokenBase> GetRandomTokens()
    {
        List<TokenBase> result = positiveTokenPool.Values.Where(x => {
            int prob = Random.Range(0, 100);

            Rarity rarity = prob switch
            {
                < 60 => Rarity.Common,
                < 90 => Rarity.Rare,
                < 99 => Rarity.Epic,
                < 100 => Rarity.Legendary,
                _ => Rarity.Common
            };

            return x.Rarity == rarity;
        }).OrderBy(x => random.Next()).Take(3).ToList();

        foreach (var token in result) {
            for(int i = 0; i < 3; i++)
            {
                if(token.Id == result[i].Id) result[i] = token;
            }
        }

        return result;
    }
}