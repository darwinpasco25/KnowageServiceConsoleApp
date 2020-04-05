using System;
using Microsoft.AspNetCore.Http;

namespace KnowageService.Models
{
    public class AppSettings
    {
        public static string ScheduledTasksConnectionString { get; set; }
        public static string SSOConnectionString { get; set; }
        public static string DPUConnectionString { get; set; }
        public static string RCDConnectionString { get; set; }
        public static string KnowageConnectionString { get; set; }
    }

    public class Paths
    {
        public static string ImportPath { get; set; }
        public static string ExportPath { get; set; }
        public static string FileLogPath { get; set; }
    }

    public class URLs
    {
        public static string KnowageURL { get; set; }
    }

    public class KnowageHeaders //HTTP Headers
    {
        public static string Host { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
    }

    public class SMTPConfig
    {
        public static string SMTPServer { get; set; }
        public static string SMTPPort { get; set; }
        public static string EmailAddress { get; set; }
        public static string Password { get; set; }

        public IFormFileCollection Attachments { get; set; }
    }
}
