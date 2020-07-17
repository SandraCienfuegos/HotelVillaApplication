package be.cienfuegos.sandra.hotel_villa_application.api.model;

import java.io.Serializable;

import lombok.Getter;
import lombok.ToString;

@Getter
@ToString
public class Equipment implements Serializable {
    private String equipmentId;
    private String iconFile;
    private String equipmentName;
}
