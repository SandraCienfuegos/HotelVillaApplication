package be.cienfuegos.sandra.hotel_villa_application.api.model;

import java.util.Date;
import java.util.List;

import lombok.AllArgsConstructor;
import lombok.ToString;

@ToString
@AllArgsConstructor
public class NewReservation {
    private int villaId;
    private int formulaId;
    private int numberAdults;
    private int numberChildren;
    private int numberBabies;
    private int priceChoice;
    private Date checkInDate;
    private Date checkOutDate;
    List<ReservationExtra> extras;
    List<ReservationService> services;
}
