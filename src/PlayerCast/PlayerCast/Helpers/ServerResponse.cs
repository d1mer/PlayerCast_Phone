namespace PlayerCast.Helpers
{
    public class ServerResponse<TSuccess>
    {
        public TSuccess SuccessResult { get; set; }

        public bool IsSuccess { get; set; }

        public int Code { get; set; }
    }
}
