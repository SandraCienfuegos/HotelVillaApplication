package be.cienfuegos.sandra.hotel_villa_application.api.model;

import lombok.Getter;
import lombok.ToString;

@Getter
@ToString
public class AuthenticatedCustomer {
    private int customerId;
    private String firstName;
    private String lastName;
    private String email;
    private String token;
}