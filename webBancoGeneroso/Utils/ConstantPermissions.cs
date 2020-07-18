using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webBancoGeneroso.Utils
{
    public static class ConstantPermissions
    {
        public const string permission = "Permission";
        public const string ready = "Ready";
        public const string delete = "Delete";
        public const string write = "EditAndWrite";
        public const string report = "Report"; 

        public static string todasPermission = string.Format("{0},{1},{2},{3}", ready, write, delete, report);
    }

    public static class ConstantMessage
    {
        public const string information = "Informação";
        public const string alerts = "Atenção";
        public const string erro = "Erro";

        public const string msgInsert = "{0} inserido com sucesso!";
    }
}
