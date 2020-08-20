using System;

namespace provide.Model
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public string CreatedAt { get; set; }
        public Error[] Errors { get; set; }
        public string Message { get; set; }
    }
}