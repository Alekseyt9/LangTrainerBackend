﻿

namespace LangTrainerEntity.Entities
{
    public class TrainingInfo
    {
        public Guid Id { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        public DateTime? LastSuccessTime { get; set; }

        public int Stage { get; set; }

    }
}
