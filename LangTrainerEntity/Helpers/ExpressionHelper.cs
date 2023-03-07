
using LangTrainerEntity.Entities;

namespace LangTrainerEntity.Helpers
{
    public static class ExpressionHelper
    {
        public static Expression Union(this Expression target, Expression expr)
        {
            if (target == null)
            {
                return expr;
            }

            foreach (var tr in expr.Translates)
            {
                var oldTr = target.Translates.FirstOrDefault(x => x.EqualsTranslate(tr));
                if (oldTr == null)
                {
                    target.Translates.Add((Translate)((ICloneable)tr).Clone());
                }

                foreach (var smp in tr.Samples)
                {
                    var oldSmp = oldTr.Samples.FirstOrDefault(x => x.EqualsSample(smp));
                    if (oldSmp == null)
                    {
                        target.Translates.Add((Translate)((ICloneable)smp).Clone());
                    }
                }
            }

            foreach (var snd in expr.Sounds)
            {
                var oldSnd = target.Sounds.FirstOrDefault(x => x.EqualsSound(snd));
                if (oldSnd == null)
                {
                    target.Sounds.Add((Sound)((ICloneable)snd).Clone());
                }
            }

            return target;
        }

    }
}
