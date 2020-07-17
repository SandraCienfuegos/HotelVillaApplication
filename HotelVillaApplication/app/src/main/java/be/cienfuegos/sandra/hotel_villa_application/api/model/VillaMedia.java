package be.cienfuegos.sandra.hotel_villa_application.api.model;


import java.io.Serializable;

import lombok.Getter;
import lombok.ToString;

@Getter
@ToString
public class VillaMedia implements Serializable {
    private int mediaId;
    private int villaId;
    private String mediaName;
}
