using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AwesomeMvcDemo.Utils;

namespace AwesomeMvcDemo.Helpers
{
    public class CodeHelper : IHtmlString
    {
        private readonly HtmlHelper html;
        private readonly string path;
        private string mainPath = "\\Controllers\\";
        private string[] phrase = { "public", "class" };

        public CodeHelper(HtmlHelper html, string path)
        {
            this.html = html;
            this.path = path;
        }

        public CodeHelper Util()
        {
            phrase = new[] { "public", "static", "class" };
            mainPath = "\\Utils\\";
            return this;
        }

        public CodeHelper Cont(string o)
        {
            phrase = new[] { "public", "class", o + "Controller" };
            return this;
        }

        public CodeHelper Action(string o)
        {
            phrase = new[] { "public", "ActionResult", o };
            return this;
        }

        protected string Render()
        {
            var newpath = html.ServerMapPath() + mainPath + path;
            var str = File.ReadAllText(newpath);

            var res = StrUtil.FindMethod(str, phrase);

            var comments = StrUtil.GetCommentsAbove(str, res.Item1);

            var code = str.FromTo(res.Item1, res.Item2);

            var lines = comments.Concat(code.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)).ToArray();

            lines = StrUtil.RemStartSpace(lines);
            code = StrUtil.CodeLinesToStr(lines);
            return StrUtil.ParseStrToCode(code, path);
        }

        public string ToHtmlString()
        {
            return Render();
        }

        public override string ToString()
        {
            return Render();
        }
    }
}