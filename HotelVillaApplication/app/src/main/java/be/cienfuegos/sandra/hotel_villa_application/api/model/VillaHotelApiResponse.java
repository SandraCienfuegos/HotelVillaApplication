package be.cienfuegos.sandra.hotel_villa_application.api.model;

import lombok.Getter;
import lombok.ToString;

@Getter
@ToString
public class VillaHotelApiResponse<T> {
    private T data;
    private VillaHotelApiStatus status;

    public boolean isSuccess() {
        return status.getErrorCode() == 0;
    }
}