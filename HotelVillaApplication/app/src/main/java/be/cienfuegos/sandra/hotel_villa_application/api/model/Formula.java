package be.cienfuegos.sandra.hotel_villa_application.api.model;

import java.io.Serializable;

import lombok.Getter;
import lombok.ToString;

@Getter
@ToString
public class Formula implements Serializable {
    private int formulaId;
    private String formulaName;
    private double priceAdult;
    private double priceChild;
    private double priceBaby;
}
