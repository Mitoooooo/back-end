using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace VinsportWebAPI
{
    public static class ODataModel
    {
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

            return builder.GetEdmModel();
        }
    }
}
