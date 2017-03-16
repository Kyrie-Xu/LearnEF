using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MyFrameWork.WebAPI.Attributes
{
    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string controllerName = filterContext.Controller.GetType().FullName;
            string methodName = filterContext.ActionDescriptor.ActionName;
            string form = "";

            if (filterContext.HttpContext.Request.Form.Count > 0)
            {
                form = string.Join("&", filterContext.HttpContext.Request.Form.AllKeys.Select(k => string.Format("{0}={1}", k, filterContext.HttpContext.Request.Form[k])));
            }

            string files = "";
            if (filterContext.HttpContext.Request.Files.Count > 0)
            {
                List<string> tempList = new List<string>();
                for (int i = 0; i < filterContext.HttpContext.Request.Files.Count; i++)
                {
                    tempList.Add(string.Format("{0}:{1}b", Path.GetFileName(filterContext.HttpContext.Request.Files[i].FileName), filterContext.HttpContext.Request.Files[i].ContentLength));
                }
                files = string.Join("&", tempList);
            }

            string msg = string.Format("开始调用:{0}.{1}\t 参数:{2}\t 路由:{3}\t 路径:{4}\t 表单:{5}\t 文件:{6}\t 戳:{7}",
                controllerName,
                methodName,
                string.Join(",", filterContext.ActionParameters.Select(p => string.Format("{0}:{1}", p.Key, p.Value))),
                string.Join(",", filterContext.RouteData.Values.Select(p => string.Format("{0}:{1}", p.Key, p.Value))),
                filterContext.RequestContext.HttpContext.Request.Url.ToString(),
                form,
                files,
                DateTime.Now.ToString("mm.ss.ffff")
            );
            ThreadPool.QueueUserWorkItem(state =>
            {
                ILog _log = LogManager.GetLogger(controllerName);
                _log.Debug(msg);
            });

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string controllerName = filterContext.Controller.GetType().FullName;
            string methodName = filterContext.ActionDescriptor.ActionName;
            string msg = string.Format("结束调用:{0}.{1}\t 返回:{2}\t 路径:{3}\t 戳:{4}", controllerName, methodName, GetResult(filterContext.Result), filterContext.RequestContext.HttpContext.Request.Url.ToString(), DateTime.Now.ToString("mm.ss.ffff"));
            Exception error = null;
            if (filterContext.Exception != null && !filterContext.ExceptionHandled)
            {
                error = filterContext.Exception;
                //filterContext.ExceptionHandled = true;
            }
            ThreadPool.QueueUserWorkItem(state =>
            {
                ILog _log = LogManager.GetLogger(controllerName);
                _log.Debug(msg);
                if (error != null)
                    _log.Error(error);
            });

            base.OnActionExecuted(filterContext);
        }

        private string GetResult(ActionResult result)
        {
            if (result != null)
            {
                if (result is JsonResult)
                {
                    return string.Format("JsonResult Data:{0}", ((result as JsonResult).Data ?? "").ToString());
                }
                else if (result is RedirectResult)
                {
                    return string.Format("RedirectResult Url:{0}", (result as RedirectResult).Url);
                }
                else if (result is RedirectToRouteResult)
                {
                    return string.Format("RedirectToRouteResult Route:{0}", (result as RedirectToRouteResult).RouteName);
                }
                else if (result is FileResult)
                {
                    return string.Format("FileResult FileName:{0}", (result as FileResult).FileDownloadName);
                }
                else if (result is ContentResult)
                {
                    var temp = (result as ContentResult);
                    return string.Format("ContentResult Content:{0} 类型:{1} 编码:{2}", temp.Content, temp.ContentType, temp.ContentEncoding);
                }

                return result.ToString();
            }

            return string.Empty;
        }
    }
}