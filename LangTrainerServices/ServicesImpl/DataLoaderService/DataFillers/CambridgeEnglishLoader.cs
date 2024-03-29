﻿
using System.Text;
using HtmlAgilityPack;
using LangTrainerEntity.Entities;
using LangTrainerServices.Helpers;
using LangTrainerServices.Model;
using LangTrainerServices.Services;

namespace LangTrainerServices.ServicesImpl
{
    [DataLoader("dictionary.cambridge.org_eng", "english")]
    internal class CambridgeEnglishLoader : IDataLoader
    {
        public async Task<Expression> GetData(DataLoaderContext ctx, DataLoaderParams pars)
        {
            var expr = new Expression()
            {
                Text = pars.Token,
                Language = ctx.LanguageService.GetLanguage("english")
            };

            var web = new HtmlWeb();
            var doc = web.Load($"https://dictionary.cambridge.org/dictionary/english/{pars.Token}");

            LoadTranslates(ctx, doc, expr);
            await LoadSounds(doc, expr);

            if (expr.Translates == null || expr.Translates.Count == 0)
            {
                return null;
            }

            return expr;
        }

        private void LoadTranslates(DataLoaderContext ctx, HtmlDocument doc, Expression expr)
        {
            var wordNode = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'entry-body__el')]");
            if (wordNode == null)
            {
                return;
            }

            var partNode = wordNode.SelectSingleNode(".//span[contains(@class, 'pos dpos')]");
            var pos = partNode.InnerText;

            var posObj = ctx.LanguageService.GetPartOfSpeech(pos, ctx.LanguageService.GetLanguage("english").Id);

            var meanNode = wordNode.SelectSingleNode(".//div[contains(@class, 'dsense')]");
            if (meanNode == null)
            {
                return;
            }

            var defNode = meanNode.SelectSingleNode(".//div[contains(@class, 'ddef_d')]");
            var tr = new Translate()
            {
                Language = ctx.LanguageService.GetLanguage("english"),
                Text = GetText(defNode),
                PartOfSpeech = posObj
            };
            expr.Translates.Add(tr);

            LoadSamples(meanNode, tr);
        }

        private void LoadSamples(HtmlNode meanNode, Translate tr)
        {
            var exsNode = meanNode.SelectSingleNode(".//div[contains(@class, 'ddef_b')]");
            var exNodes = exsNode.SelectNodes(".//span[contains(@class, 'eg deg')]");

            if (exNodes == null)
            {
                return;
            }

            foreach (var child in exNodes)
            {
                tr.Samples.Add(new Sample()
                {
                    Text = GetText(child)
                });
            }
        }

        private string GetText(HtmlNode node)
        {
            var sb = new StringBuilder(node.InnerHtml.Length);
            foreach (var child in node.ChildNodes)
            {
                sb.Append(child.InnerHtml);
            }

            return sb.ToString();
        }

        private async Task LoadSounds(HtmlDocument doc, Expression expr)
        {
            var audioNode = doc.DocumentNode.SelectSingleNode("//audio[@id='audio2']/source[@type='audio/mpeg']");
            var url = audioNode.GetAttributeValue("src", null);
            var soundUrl = $"https://dictionary.cambridge.org{url}";

            var data = await HttpHelper.LoadFile(soundUrl);
            expr.Sounds.Add(new Sound()
            {
                Id = Guid.NewGuid(),
                Data = data,
                Hash = data.GetMd5Hash(),
                Url = soundUrl
            });

        }

    }
}
