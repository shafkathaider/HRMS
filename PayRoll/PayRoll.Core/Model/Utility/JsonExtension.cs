using System.Web.Mvc;

namespace PayRoll.Core.Model.Utility
{
    public class JsonExtension : JsonResult
    {
        public JsonExtension(object staffCurrent)
        {
            Data = staffCurrent;
            ContentType = "application/json charset=utf-8";
            ContentEncoding = System.Text.Encoding.UTF8;
            JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            MaxJsonLength = int.MaxValue;
        }
    }
}
