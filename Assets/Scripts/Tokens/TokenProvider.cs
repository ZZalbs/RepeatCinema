using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TokenProvider : MonoBehaviour
{
    [SerializeField] private TokenController tokenController;

    private Dictionary<int, TokenBase> positiveTokenPool;
    private Dictionary<int, TokenBase> negativeTokenPool;

    private System.Random random;

    private void Awake()
    {
        random = new();
        positiveTokenPool = new();
        negativeTokenPool = new();
    }


    private void Start()
    {
        positiveTokenPool.Add(0, new FlashToken(tokenController, "점멸", "Shift 키를 눌러 바라보는 방향으로 최대 <Level>회 연속으로 짧은 거리를 점멸합니다.\r\n점멸 횟수를 모두 사용하면 착지 후 3 - 0.67 * (<Level> - 1) 초만큼의 쿨타임 필요합니다.", Rarity.Common, true, 3));
        positiveTokenPool.Add(1, new BonusJumpToken(tokenController, "점멸", "Shift 키를 눌러 바라보는 방향으로 최대 <Level>회 연속으로 짧은 거리를 점멸합니다.\r\n점멸 횟수를 모두 사용하면 착지 후 3 - 0.67 * (<Level> - 1) 초만큼의 쿨타임 필요합니다.", Rarity.Common, true, 3));
        positiveTokenPool.Add(2, new MaxLifePlusToken(tokenController, "점멸", "Shift 키를 눌러 바라보는 방향으로 최대 <Level>회 연속으로 짧은 거리를 점멸합니다.\r\n점멸 횟수를 모두 사용하면 착지 후 3 - 0.67 * (<Level> - 1) 초만큼의 쿨타임 필요합니다.", Rarity.Common, true, 3));
        negativeTokenPool.Add(0, new SpeedDownToken(tokenController, "점멸", "Shift 키를 눌러 바라보는 방향으로 최대 <Level>회 연속으로 짧은 거리를 점멸합니다.\r\n점멸 횟수를 모두 사용하면 착지 후 3 - 0.67 * (<Level> - 1) 초만큼의 쿨타임 필요합니다.", Rarity.Common, false, 3));
        negativeTokenPool.Add(1, new RemovePosToken(tokenController, "점멸", "Shift 키를 눌러 바라보는 방향으로 최대 <Level>회 연속으로 짧은 거리를 점멸합니다.\r\n점멸 횟수를 모두 사용하면 착지 후 3 - 0.67 * (<Level> - 1) 초만큼의 쿨타임 필요합니다.", Rarity.Common, false, 3));
        negativeTokenPool.Add(2, new AlwaysCriticalToken(tokenController, "점멸", "Shift 키를 눌러 바라보는 방향으로 최대 <Level>회 연속으로 짧은 거리를 점멸합니다.\r\n점멸 횟수를 모두 사용하면 착지 후 3 - 0.67 * (<Level> - 1) 초만큼의 쿨타임 필요합니다.", Rarity.Common, false, 3));
        negativeTokenPool.Add(3, new PlaceSpikeToken(tokenController, "점멸", "Shift 키를 눌러 바라보는 방향으로 최대 <Level>회 연속으로 짧은 거리를 점멸합니다.\r\n점멸 횟수를 모두 사용하면 착지 후 3 - 0.67 * (<Level> - 1) 초만큼의 쿨타임 필요합니다.", Rarity.Common, false, 3));
        
        for(int i=0;i<positiveTokenPool.Count;i++)
        {
            positiveTokenPool[i].setID(i);
            Debug.Log(i);
        }
        for (int i = 0; i < negativeTokenPool.Count; i++)
        {
            negativeTokenPool[i].setID(i);
        }
    }

    private Rarity GetRandomRarity()
    {
        int prob = Random.Range(0, 100);

        Rarity rarity = prob switch
        {
            < 160 => Rarity.Common, // 확률조작용. 60 90 99 100
            < 190 => Rarity.Rare,
            < 199 => Rarity.Epic,
            < 1100 => Rarity.Legendary,
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
                PositiveToken = tokenController.PositiveTokens.ContainsKey(positive.Key) ? tokenController.PositiveTokens[positive.Key] : positive.Value,
                NegativeToken = tokenController.NegativeTokens.ContainsKey(negative.Key) ? tokenController.NegativeTokens[positive.Key] : negative.Value
            };
            tokens.Add(pair);
        }
 
        return tokens;
    }
}