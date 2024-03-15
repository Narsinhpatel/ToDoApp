using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace ToDoApp.Helpers
{
    public static class CustomeHelper
    {

        public static MvcHtmlString StatusColumn<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> isCheckedExpression)
        {
            var isCheckedMetaData = ModelMetadata.FromLambdaExpression(isCheckedExpression, htmlHelper.ViewData);
            bool isChecked = (bool)isCheckedMetaData.Model;

            string statusText = isChecked ? "Completed" : "Pending";

            TagBuilder span = new TagBuilder("span");
            span.AddCssClass(isChecked ? "text-success" : "text-danger"); // Apply different styles based on checkbox value
            span.SetInnerText(statusText);

            return MvcHtmlString.Create(span.ToString());
        }
    }
}