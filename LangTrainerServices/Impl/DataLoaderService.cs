
using System.Reflection;
using LangTrainerClientModel.Services;
using LangTrainerEntity.Entities.Lang;
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
                //if (type.IsInstanceOfType(typeof(IDataLoader)))
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
                target = Union(target, expr);
            }

            return target;
        }

        public Expression Union(Expression target, Expression expr)
        {
            if (target == null)
            {
                return expr;
            }

            foreach (var val in expr.Translates)
            {
                var old = target.Translates.FirstOrDefault(x => x.EqualsTranslate(val));
                if (old == null)
                {
                    target.Translates.Add((Translate)((ICloneable)val).Clone());
                }
            }

            foreach (var val in expr.Samples)
            {
                var old = target.Samples.FirstOrDefault(x => x.EqualsSample(val));
                if (old == null)
                {
                    target.Translates.Add((Translate)((ICloneable)val).Clone());
                }
            }

            foreach (var val in expr.Sounds)
            {
                var old = target.Sounds.FirstOrDefault(x => x.EqualsSound(val));
                if (old == null)
                {
                    target.Sounds.Add((Sound)((ICloneable)val).Clone());
                }
            }

            return target;
        }

    }
}
