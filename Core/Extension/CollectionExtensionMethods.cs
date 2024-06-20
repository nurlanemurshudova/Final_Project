using Core.Validation;
using System.Text;

namespace Core.Extension
{
    public static class CollectionExtensionMethods
    {
        public static string ValidationErrorMessagesWithNewLine(this List<ValidationErrorModel> errors)
        {
            StringBuilder sb = new();
            foreach (var error in errors)
            {
                sb.Append("\n"+error.ErrorMessage);
                sb.Append(error.PropertyName);
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
