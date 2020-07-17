namespace API.Controllers.Response
{
    public class VillaHotelApiResponse<T>
    {
        public T Data { get; }

        public VillaHotelApiStatus Status { get; }

        public VillaHotelApiResponse(T data)
        {
            Data = data;
            Status = new VillaHotelApiStatus();
        }

        public VillaHotelApiResponse(int errorCode, string errorMessage)
        {
            Status = new VillaHotelApiStatus(errorCode, errorMessage);
        }
    }
}