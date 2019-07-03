using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using RazorAlerts.Extensions.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorAlerts
{
    public static class AlertExtensions
    {
        public static string AlertKey = "Alerts";

        public static List<Alert> GetAlertList(this Controller controller)
        {
            return controller.TempData.GetAlertList();
        }

        public static bool TryGetAlertList(this ITempDataDictionary tempdata, out List<Alert> alerts )
        {
            alerts = null;

            return (tempdata.ContainsKey(AlertKey) &&
                tempdata[AlertKey] is string listString &&
                listString.TryParseJson(out alerts)) ;
        }

        public static List<Alert> GetAlertList(this ITempDataDictionary tempdata)
        {
            if (tempdata.TryGetAlertList(out var list))
                return list;
            else
                return new List<Alert>();
        }

        public static void SaveAlertList(this Controller controller, List<Alert> list)
        {
            controller.TempData.SaveAlertList(list);
        }
        public static void SaveAlertList(this ITempDataDictionary tempdata, List<Alert> list)
        {
            tempdata[AlertKey] = Newtonsoft.Json.JsonConvert.SerializeObject(list);
        }


        public static void AddSuccess(this Controller controller, string title, string body)
        {
            controller.AddAlert(AlertTypeEnum.Success, title, body, false);
        }

        public static void AddWarning(this Controller controller, string title, string body)
        {
            controller.AddAlert(AlertTypeEnum.Warning, title, body, false);
        }

        public static void AddInfo(this Controller controller, string title, string body)
        {
            controller.AddAlert(AlertTypeEnum.Info, title, body, false);
        }

        public static void AddAlert(this Controller controller, AlertTypeEnum alertType, string title, string body)
        {
            controller.AddAlert(alertType, title, body, false);
        }

        public static void AddAlert(this Controller controller, AlertTypeEnum alertType, string title, string body, bool dismissable)
        {
            controller.AddAlert(new Alert() { Type = alertType, Title = title, Body = body, Dismissable = dismissable });
        }

        public static void AddAlert(this Controller controller, Alert alert)
        {
            var list = controller.GetAlertList();
            list.Add(alert);
            controller.SaveAlertList(list);


        }

        public static  string GetHtmlString(this IHtmlContent content)
        {
            var writer = new System.IO.StringWriter();
            content.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
            return writer.ToString();
        }

    }
}
