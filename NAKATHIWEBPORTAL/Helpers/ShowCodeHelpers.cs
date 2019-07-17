using System.Web;
using System.Web.Mvc;
using AwesomeMvcDemo.Utils;

namespace AwesomeMvcDemo.Helpers
{
    public static class ShowCodeHelpers
    {
        /// <summary>
        /// get the string value of code between the /*begin*/ and /*end*/ comment blocks  
        /// </summary>
        /// <param name="html"></param>
        /// <param name="path"> file location path</param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static IHtmlString Csrc(this HtmlHelper html, string path, object k = null)
        {
            var startWord = "/*begin" + k + "*/";
            var endWord = "/*end" + k + "*/";

            var newpath = html.ServerMapPath() + path;
            var lines = System.IO.File.ReadAllLines(newpath);
            var code = StrUtil.GetCode(lines, startWord, endWord);

            return new MvcHtmlString(StrUtil.ParseStrToCode(code, path));
        }

        public static CodeHelper Util(this HtmlHelper html, string path)
        {
            return new CodeHelper(html, path).Util();
        }

        public static CodeHelper Code(this HtmlHelper html, string path)
        {
            return new CodeHelper(html, path);
        }

        /// <summary>
        /// get the string value of the controller code between the /*begin(key)*/ and /*end(key)*/ comment blocks 
        /// </summary>
        /// <param name="html"></param>
        /// <param name="path"></param>
        /// <param name="k">key</param>
        /// <returns></returns>
        public static IHtmlString Csource(this HtmlHelper html, string path, object k = null)
        {
            var startWord = "/*begin" + k + "*/";
            var endWord = "/*end" + k + "*/";

            var newpath = html.ServerMapPath() + "\\Controllers\\" + path;
            var lines = System.IO.File.ReadAllLines(newpath);

            var code = StrUtil.GetCode(lines, startWord, endWord);

            return new MvcHtmlString(StrUtil.ParseStrToCode(code, path));
        }

        /// <summary>
        /// get the string value of js file between the /*begin*/ and /*end*/ comment blocks 
        /// </summary>
        /// <param name="html"></param>
        /// <param name="path"></param>
        /// <param name="k">key</param>
        /// <returns></returns>
        public static IHtmlString SourceJs(this HtmlHelper html, string path, object k = null)
        {
            var startWord = "/*begin" + k + "*/";
            var endWord = "/*end" + k + "*/";

            var newpath = html.ServerMapPath() + "\\Scripts\\" + path;
            var lines = System.IO.File.ReadAllLines(newpath);
            var code = StrUtil.GetCode(lines, startWord, endWord);

            return new MvcHtmlString(StrUtil.ParseStrToCode(code, path));
        }

        /// <summary>
        /// get the string value of the view code located between the begin+key and end+key comment blocks
        /// </summary>
        /// <param name="html"></param>
        /// <param name="path"></param>
        /// <param name="k">key</param>
        /// <param name="wrap">wrap with div class='code'</param>
        /// <returns></returns>
        public static IHtmlString Source(this HtmlHelper html, string path, object k = null, bool wrap = false)
        {
            var key = k == null ? "" : k.ToString();
            var newpath = html.ServerMapPath() + "\\Views\\" + path;
            var lines = System.IO.File.ReadAllLines(newpath);


            var code = path.EndsWith(".cshtml") ? StrUtil.GetCode(lines, "@*begin" + key + "*@", "@*end" + key + "*@") : StrUtil.GetCode(lines, "<%--begin" + key + "--%>", "<%--end" + key + "--%>");
            var result = StrUtil.ParseStrToCode(code, path);
            if (wrap) result = "<div class='code'>" + result + "</div>";

            return new MvcHtmlString(result);
        }
    }
}