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
        positiveTokenPool.Add(0, new FlashToken(tokenController, "점멸", "[Shift] 키를 눌러 짧은 거리를 점멸합니다. 사용 후 쿨다운이 필요합니다.", Rarity.Common, true, 3));
        positiveTokenPool.Add(1, new BonusJumpToken(tokenController, "점프 부스터", "공중에서 점프합니다. 점프 횟수를 모두 사용하면 착지해야 다시 점프할 수 있습니다.", Rarity.Common, true, 3));
        positiveTokenPool.Add(2, new GhostLifeToken(tokenController, "영혼 체력 추가", "영혼 체력을 1 추가합니다. 피격 시 일반 체력 대신 감소하는 일회성 추가 체력입니다.", Rarity.Common, true, -1));
        positiveTokenPool.Add(3, new MaxLifePlusToken(tokenController, "체력 추가", "최대 체력을 1 추가합니다. 매 스테이지마다 플레이어가 최대 체력만큼의 체력을 가진 채로 시작합니다.", Rarity.Rare, true, -1));
        positiveTokenPool.Add(4, new InvincibleToken(tokenController, "무적", "스테이지 시작 후 잠깐동안 피격 면역 상태를 유지합니다. 즉사를 제외한 모든 피해에 면역입니다.", Rarity.Rare, true, 5));
        positiveTokenPool.Add(5, new LastMercyToken(tokenController, "마지막 자비", "사망 시 모든 능력 토큰을 파괴하고 1회 부활합니다.", Rarity.Epic, true, 1));
        positiveTokenPool.Add(6, new HighShieldToken(tokenController, "하이 실드", "치명적 피격을 일반 피격으로 바꿔주는 하이 실드를 1개 추가합니다. 하이 실드는 치명적 피격 시 차감됩니다", Rarity.Epic, true, 3));
        positiveTokenPool.Add(7, new OneMoreTime(tokenController, "한판만", "사망 시 모든 토큰을 파괴하고 1회 부활합니다.", Rarity.Legendary, true, 1));

        negativeTokenPool.Add(100, new GenerateWalkerToken(tokenController, "뚜벅이 생성", "랜덤한 플랫폼 위에 적‘뚜벅이'가 생성됩니다.", Rarity.Common, false, 10));
        negativeTokenPool.Add(101, new PlaceSpikeToken(tokenController, "가시 생성", "랜덤한 플랫폼 위에 가시가 추가됩니다. 플레이어에게 피격을 가합니다.", Rarity.Common, false, 15));
        negativeTokenPool.Add(102, new RemovePosToken(tokenController, "능력 압수", "능력 토큰을 무작위로 하나 파괴하고 같이 파괴됩니다.", Rarity.Common, false, 1));
        negativeTokenPool.Add(103, new SpeedDownToken(tokenController, "피로", "플레이어의 속도를 느리게 합니다.", Rarity.Common, false, 10));
        negativeTokenPool.Add(104, new PlaceCriticalSpikeToken(tokenController, "아픈 가시", "랜덤한 플랫폼 위에 아픈 가시가 추가됩니다. 플레이어에게 치명적 피격을 가합니다.", Rarity.Rare, false, 7));
        negativeTokenPool.Add(105, new ReverseInputToken(tokenController, "조작 반전", "스테이지 시작 시 가끔 좌우 조작이 반전됩니다.", Rarity.Rare, false, 4));
        negativeTokenPool.Add(106, new ExchangeToken(tokenController, "등가교환", "능력 토큰이 남아있을 경우, 피격 시 체력 대신 무작위 능력 토큰을 파괴하고 같이 파괴됩니다.", Rarity.Rare, false, 3));
        negativeTokenPool.Add(107, new TimeAttackToken(tokenController, "타임어택", "스테이지 시작 후 일정시간이 지나면 즉사합니다.", Rarity.Epic, false, 5));
        negativeTokenPool.Add(108, new SpeedToken(tokenController, "스피드", "플레이어가 오래 정지할 경우 즉사합니다.", Rarity.Epic, false, 5));
        negativeTokenPool.Add(109, new AlwaysCriticalToken(tokenController, "나약한 육체", "모든 피격이 치명적 피격이 됩니다.", Rarity.Epic, false, 1));
        negativeTokenPool.Add(110, new GhostToken(tokenController, "필연", "유령이 플레이어 뒤를 서서히 쫓아옵니다. 충돌하면 치명적 피격을 가합니다.", Rarity.Legendary, false, 1));

        foreach (var token in positiveTokenPool)
        {
            token.Value.setID(token.Key);
            token.Value.LoadImage(token.Key.ToString());
        }
        foreach (var token in negativeTokenPool)
        {
            token.Value.setID(token.Key);
            token.Value.LoadImage(token.Key.ToString());
        }
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
        var remainPositiveTokens = positiveTokenPool.Values.Where(x => (x.MaxLevel == -1) || (x.CurLevel < x.MaxLevel));
        var remainNegativeTokens = negativeTokenPool.Values.Where(x => (x.MaxLevel == -1) || (x.CurLevel < x.MaxLevel));
        int returnSize = 0;

        for (int i = 0; i < 4; i++)
        {
            var remainP = remainPositiveTokens.Where(x => x.Rarity == (Rarity)i).Count();
            var remainN = remainNegativeTokens.Where(x => x.Rarity == (Rarity)i).Count();

            returnSize += Mathf.Min(remainP, remainN);
        }

        returnSize = Mathf.Min(3, returnSize);

        Dictionary<int, TokenBase> poppedPositiveTokens = new(returnSize);
        Dictionary<int, TokenBase> poppedNegativeTokens = new(returnSize);
        List<TokenPair> tokens = new(returnSize);

        for (int i = 0; i < returnSize; i++)
        {
            TokenBase positive = null, negative = null;
            while (true)
            {
                var rarity = GetRandomRarity();
                var positiveQuery = remainPositiveTokens
                    .Where(x =>
                        !(poppedPositiveTokens.TryGetValue(x.Id, out var token)) &&
                        rarity == x.Rarity).OrderBy(_ => random.Next()).ToList();
                var negativeQuery = remainNegativeTokens
                    .Where(x =>
                        !(poppedNegativeTokens.TryGetValue(x.Id, out var token)) &&
                        rarity == x.Rarity).OrderBy(_ => random.Next()).ToList();
                if (positiveQuery.Any() && negativeQuery.Any())
                {
                    positive = positiveQuery.First();
                    negative = negativeQuery.First();
                    break;
                }
            }

            poppedPositiveTokens.TryAdd(positive.Id, positive);
            poppedNegativeTokens.TryAdd(negative.Id, negative);

            TokenPair pair = new TokenPair
            {
                PositiveToken = positive,
                NegativeToken = negative
            };
            tokens.Add(pair);
        }

        return tokens;
    }
}