using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionPro.PreDefined
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsForModule(string module)
        {
            return new List<string>()
            {
                $"Permissions.{module}.Create",
                $"Permissions.{module}.View",
                $"Permissions.{module}.Edit",
                $"Permissions.{module}.Delete",
                
                $"Permissions.{module}.Verify",
                $"Permissions.{module}.Review",
            };
        }

        public static class Administrator
        {
            public const string Create = "Permissions.Administrator.Create";
            public const string View = "Permissions.Administrator.View";
            public const string Edit = "Permissions.Administrator.Edit";
            public const string Delete = "Permissions.Administrator.Delete";
            public const string Verify = "Permissions.Administrator.Verify";
            public const string Review = "Permissions.Administrator.Review";
        }
        public static class Products
        {
            public const string View = "Permissions.Products.View";
            public const string Create = "Permissions.Products.Create";
            public const string Edit = "Permissions.Products.Edit";
            public const string Delete = "Permissions.Products.Delete";
        }

        public static class TrainingHeads
        {
            public const string View = "Permissions.Training.View";
            public const string Create = "Permissions.Training.Create";
            public const string Edit = "Permissions.Training.Edit";
            public const string Delete = "Permissions.Training.Delete";
        }

    }
}
