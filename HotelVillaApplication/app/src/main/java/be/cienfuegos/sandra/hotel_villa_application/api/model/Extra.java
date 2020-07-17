package be.cienfuegos.sandra.hotel_villa_application.api.model;

import lombok.Getter;
import lombok.ToString;

@Getter
@ToString
public class Extra {
    public boolean isSelected;
    public int number;
    
    private int extraId;
    private double extraPrice;
    private String extraName;
}
