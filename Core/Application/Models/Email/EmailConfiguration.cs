﻿namespace CleanArchitectureSample.Application.Models.Email
{
    public class EmailConfiguration
    {
        public string FromAddress { get; set; }
        public string FromName { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }
        public string ApiKey { get; set; }
    }
}