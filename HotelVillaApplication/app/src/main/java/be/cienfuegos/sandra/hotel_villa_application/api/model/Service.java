package be.cienfuegos.sandra.hotel_villa_application.api.model;

import lombok.Getter;
import lombok.ToString;

@Getter
@ToString
public class Service {
    public boolean isSelected;

    private int serviceId;
    private double servicePrice;
    private String serviceName;
}
