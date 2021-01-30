using System.Linq;

namespace Management
{
    public class HintManager : Singleton<HintManager>
    {
        private int i;
        private readonly ProgressManager p = ProgressManager.Instance;

        public void GetHint()
        {
            var ec = p.CriticalEvidence.Count;
            if (ec == 0)
            {
                return;
            }
            if (i == ec-1)
            {
                i = 0;
            }
            var evidenceList = p.CriticalEvidence.Select(
                (value, index) => new {value.id, index});
            var evidence = evidenceList.Where(e => e.index == i).Select(e=>e.id).FirstOrDefault();
            i++;
            //todo: call dialog trigger with [var evidance]
        }
    }
}