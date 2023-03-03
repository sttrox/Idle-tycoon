using Cysharp.Threading.Tasks;
using IdleTycoon.Ads;

namespace IdleTycoon.AdShowcases
{
    public interface IAdShowcase
    {
        UniTask<(bool isCompleted, AdShowResultEnum status)> ShowRewardAdAsync();
    }
}