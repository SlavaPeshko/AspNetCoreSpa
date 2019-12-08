namespace AspNetCoreSpa.Domain.Entities
{
    public class Error
    {
        public ErrorCode Code { get; set; }
        public string Description { get; set; }

        public Error()
        {

        }

        public Error(ErrorCode code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}
