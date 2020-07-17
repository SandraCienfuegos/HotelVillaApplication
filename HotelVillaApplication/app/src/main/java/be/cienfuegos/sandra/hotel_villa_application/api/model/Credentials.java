package be.cienfuegos.sandra.hotel_villa_application.api.model;

import java.io.Serializable;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.ToString;

@Getter
@ToString
@AllArgsConstructor
public class Credentials implements Serializable {
    private String email;
    private String password;
}
