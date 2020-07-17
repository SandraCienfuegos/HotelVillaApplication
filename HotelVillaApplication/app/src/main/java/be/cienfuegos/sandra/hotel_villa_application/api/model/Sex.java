package be.cienfuegos.sandra.hotel_villa_application.api.model;

public enum Sex {
    MALE(1),
    FEMALE(2);

    public final int id;

    Sex(int id) {
        this.id = id;
    }
}
