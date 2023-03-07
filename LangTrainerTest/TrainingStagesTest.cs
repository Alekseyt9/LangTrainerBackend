
using LangTrainerEntity.Entities;
using LangTrainerServices.Helpers;
using LangTrainerServices.Services.TrainingService;
using Xunit;

namespace LangTrainerTest
{
    public class TrainingStagesTest
    {
        [Fact]
        public void Test()
        {
            var trList = new List<TrainingInfo>
            {
                new()
                {
                    ExpressionInGroupId = Guid.Parse("60F84D0F-A80C-4219-B913-57C30D2E0B39"),
                    LastSuccessTime = DateTime.Now - new TimeSpan(5, 0, 0, 0),
                    LastUpdateTime = DateTime.Now - new TimeSpan(5, 0, 0, 0),
                    Stage = 0
                },
                new()
                {
                    ExpressionInGroupId = Guid.Parse("E2768C55-4072-4E6D-985D-BA047B1CA66A"),
                    LastSuccessTime = DateTime.Now - new TimeSpan(4, 0, 0, 0),
                    LastUpdateTime = DateTime.Now - new TimeSpan(4, 0, 0, 0),
                    Stage = 1
                },
            };

            var resData = new TrainingResult()
            {
                Items = new List<TrainingResultItem>()
                {
                    new()
                    {
                        ExpressionInGroupId = Guid.Parse("60F84D0F-A80C-4219-B913-57C30D2E0B39"),
                        IsSuccess = true
                    },
                    new()
                    {
                        ExpressionInGroupId = Guid.Parse("E2768C55-4072-4E6D-985D-BA047B1CA66A"),
                        IsSuccess = false
                    }
                }
            };

            var res = TrainingHelper.TrainingNextStage(trList, resData);

            Assert.NotNull(res);
        }

    }
}
