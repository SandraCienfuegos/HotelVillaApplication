using System;

namespace API.Controllers.Response
{
    public class VillaHotelApiStatus
    {
        public DateTime Timestamp { get; }

        public int ErrorCode { get; }

        public string ErrorMessage { get; }

        public VillaHotelApiStatus() : this(0, null)
        {
        }

        public VillaHotelApiStatus(int errorCode, string errorMessage)
        {
            Timestamp = DateTime.Now;
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
    }
}