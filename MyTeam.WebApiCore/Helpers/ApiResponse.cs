﻿namespace MyTeam.WebApiCore.Helpers
{
    public class ApiResponse
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}
