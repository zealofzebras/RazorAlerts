using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
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
            if (controller.TempData.ContainsKey(AlertKey) && controller.TempData[AlertKey] is List<Alert> list)
            {
                return list;
            }
            else
            {
                list = new List<Alert>();
                controller.TempData[AlertKey] = list;
                return list;
            }
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
           
        }

        public static  string GetHtmlString(this IHtmlContent content)
        {
            var writer = new System.IO.StringWriter();
            content.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
            return writer.ToString();
        }

    }
}
