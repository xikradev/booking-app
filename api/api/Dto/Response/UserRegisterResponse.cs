namespace api.Dto.Response
{
    public class UserRegisterResponse
    {
        public bool IsSuccess { get; private set; }
        public List<string> Errors { get; private set; }

        public UserRegisterResponse() => Errors = new List<string>();

        public UserRegisterResponse(bool isSuccess = true) : this() { IsSuccess = isSuccess; }

        public void AddErrors(IEnumerable<string> errors) => Errors.AddRange(errors);

        public void AddError(string error)
        {
            Errors.Add(error);
        }
    }
}
