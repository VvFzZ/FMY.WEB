using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/*
 * Gloable配置模板引擎
 *     ViewEngines.Engines.Insert(0, new StaticFileViewEngine());
 */

namespace FMY.WEB.UI.Framework.View
{
    public class StaticFileViewEngine : IViewEngine
    {
        private Dictionary<ViewEngineResultCacheKey, ViewEngineResult> 
            viewEnginResults = new Dictionary<ViewEngineResultCacheKey, ViewEngineResult>();

        private object syncHelper = new object();

        /// <summary>
        /// 
        /// ViewResult.ExcuteResult调用 ViewResult.FindView
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="partialViewName"></param>
        /// <param name="useCache"></param>
        /// <returns></returns>
        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            return FindView(controllerContext, partialViewName, null, useCache);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="viewName">默认为ActionName</param>
        /// <param name="masterName"></param>
        /// <param name="useCache"></param>
        /// <returns></returns>
        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string mastserName, bool useCache)
        {
            string controllerName = controllerContext.RouteData.GetRequiredString("controller");
            ViewEngineResultCacheKey key =
                new ViewEngineResultCacheKey(controllerName, viewName);
            ViewEngineResult result;

            if (useCache)
            {
                result = InternalFindView(controllerContext, viewName, controllerName);
                viewEnginResults[key] = result;
                return result;
            }

            if (viewEnginResults.TryGetValue(key, out result))
                return result;

            lock (syncHelper)
            {
                if (viewEnginResults.TryGetValue(key, out result))
                {
                    return result;
                }
            }

            return InternalFindView(controllerContext, viewName, controllerName);
        }

        public void ReleaseView(ControllerContext controllerContext, IView view)
        {

        }



        private ViewEngineResult InternalFindView(ControllerContext controllerContex, string viewName, string controllerName)
        {
            string[] searchLocations = new string[] {
                string.Format("~/views/{0}/{1}.html",controllerName,viewName),
                string.Format("~/views/Shared/{0}.html",viewName)
            };

            string fileName = controllerContex.HttpContext.Request.MapPath(searchLocations[0]);

            if (System.IO.File.Exists(fileName))
            {
                return new ViewEngineResult(new StaticFileView(fileName), this);
            }

            fileName = string.Format(@"\views\Shared\{0}.html", viewName);

            if (System.IO.File.Exists(fileName))
            {
                return new ViewEngineResult(new StaticFileView(fileName), this);
            }

            return new ViewEngineResult(searchLocations);
        }
    }
}