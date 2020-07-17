package be.cienfuegos.sandra.hotel_villa_application.api.model;

import java.util.Date;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.ToString;

@Getter
@ToString
@AllArgsConstructor()
public class SignUpCustomer {
    private Address address;
    private String firstName;
    private String lastName;
    private String phoneNumber;
    private String email;
    private String password;
    private Date birthdayDate;
    private int sex;
}