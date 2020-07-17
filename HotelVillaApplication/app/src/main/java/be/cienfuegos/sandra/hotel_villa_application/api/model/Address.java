package be.cienfuegos.sandra.hotel_villa_application.api.model;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.ToString;

@Getter
@ToString
@AllArgsConstructor
public class Address {
    private Country country;
    private int countryId;
    private String lineOne;
    private String lineTwo;
    private String postCode;
    private String city;
}