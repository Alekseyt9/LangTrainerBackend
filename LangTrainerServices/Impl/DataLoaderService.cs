
using System.Reflection;
using LangTrainerClientModel.Services;
using LangTrainerEntity.Entities;
using LangTrainerEntity.Helpers;
using LangTrainerServices.Model.DataFillers;
using LangTrainerServices.Services;
using LangTrainerServices.Services.DataLoader;

namespace LangTrainerServices.Impl
{
    internal class DataLoaderService : IDataLoaderService
    {
        private readonly Dictionary<DataLoaderInfo, IDataLoader> m_Loaders = new();

        public DataLoaderService()
        {
            InitLoaders();
        }

        private void InitLoaders()
        {
            var asms = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var type in asms
                         .Where(x => x.GetCustomAttributes(typeof(DataLoaderAssemblyAttribute)).Any() )
                         .SelectMany(x => x.GetTypes()))
            {
                if (typeof(IDataLoader).IsAssignableFrom(type))
                {
                    var attr = type.GetCustomAttribute<DataLoaderAttribute>();
                    if (attr != null)
                    {
                        m_Loaders.Add(
                            new DataLoaderInfo() { Languages = attr.Languages },
                            (IDataLoader)Activator.CreateInstance(type)
                        );
                    }
                }
            }
        }

        public async Task<Expression> LoadExpressionData(TokenInfo info)
        {
            Expression target = null;
            foreach (var key in m_Loaders.Keys.Where(x => x.Languages.Contains(info.Language)))
            {
                var loader = m_Loaders[key];
                var expr = await loader.GetData(info.Expression, info.Language);
                target = target.Union(expr);
            }

            return target;
        }



    }
}
