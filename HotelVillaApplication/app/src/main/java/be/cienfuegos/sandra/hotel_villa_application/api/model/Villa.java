package be.cienfuegos.sandra.hotel_villa_application.api.model;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

import lombok.Getter;
import lombok.Setter;
import lombok.ToString;

@Getter
@Setter
@ToString
public class Villa implements Serializable {
    private int villaId;
    private String villaName;
    private String villaPath;
    private int numberOfBeds;
    private int surfaceArea;
    private double priceOnline;
    private double priceOnSite;
    private String description;
    private List<VillaMedia> medias;
    private List<Equipment> equipments;
    private List<Formula> formulas;
    private List<Date> bookedDates;
}
