﻿

namespace LangTrainerServices.Helpers
{
    public static class TrainingHelper
    {
        /*
        public static ICollection<TrainingInfo> TrainingNextStage(
            ICollection<TrainingInfo> trInfos, TrainingResult tRes)
        {
            var map = new Dictionary<Guid, Tuple<TrainingInfo, TrainingResultItem>>();

            var res = new List<TrainingInfo>();

            foreach (var i1 in trInfos)
            {
                var i2 = tRes.Items
                    .First(x => x.ExpressionInGroupId == i1.TranslateInGroupId);
                res.Add(NextStage(i1, i2));
            }

            return res;
        }

        private static TrainingInfo NextStage(TrainingInfo ti, TrainingResultItem tr)
        {
            if (tr.IsSuccess)
            {
                return new TrainingInfo()
                {
                    Id = ti.Id,
                    TranslateInGroup = ti.TranslateInGroup,
                    TranslateInGroupId = ti.TranslateInGroupId,
                    LastSuccessTime = DateTime.Now,
                    LastUpdateTime = DateTime.Now,
                    Stage = ti.Stage + 1
                };
            }

            return new TrainingInfo()
            {
                Id = ti.Id,
                TranslateInGroup = ti.TranslateInGroup,
                TranslateInGroupId = ti.TranslateInGroupId,
                LastSuccessTime = ti.LastSuccessTime,
                LastUpdateTime = DateTime.Now,
                Stage = ti.Stage,
            };

        }*/

    }
}
