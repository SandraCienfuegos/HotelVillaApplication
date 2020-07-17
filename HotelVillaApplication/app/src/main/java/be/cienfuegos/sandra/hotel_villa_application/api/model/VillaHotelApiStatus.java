package be.cienfuegos.sandra.hotel_villa_application.api.model;

import lombok.Getter;
import lombok.ToString;

@Getter
@ToString
public class VillaHotelApiStatus {
    private String timestamp;
    private int errorCode;
    private String errorMessage;
}
