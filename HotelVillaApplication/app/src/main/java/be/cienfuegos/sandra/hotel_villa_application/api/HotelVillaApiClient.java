package be.cienfuegos.sandra.hotel_villa_application.api;


import android.annotation.SuppressLint;
import android.util.Log;

import com.google.gson.reflect.TypeToken;

import java.io.IOException;
import java.io.Reader;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Locale;
import java.util.Objects;

import be.cienfuegos.sandra.hotel_villa_application.api.constant.HotelVillaLanguage;
import be.cienfuegos.sandra.hotel_villa_application.api.model.AuthenticatedCustomer;
import be.cienfuegos.sandra.hotel_villa_application.api.model.Country;
import be.cienfuegos.sandra.hotel_villa_application.api.model.Credentials;
import be.cienfuegos.sandra.hotel_villa_application.api.model.Equipment;
import be.cienfuegos.sandra.hotel_villa_application.api.model.Extra;
import be.cienfuegos.sandra.hotel_villa_application.api.model.Formula;
import be.cienfuegos.sandra.hotel_villa_application.api.model.NewReservation;
import be.cienfuegos.sandra.hotel_villa_application.api.model.Service;
import be.cienfuegos.sandra.hotel_villa_application.api.model.SignUpCustomer;
import be.cienfuegos.sandra.hotel_villa_application.api.model.Villa;
import be.cienfuegos.sandra.hotel_villa_application.api.model.VillaHotelApiResponse;
import be.cienfuegos.sandra.hotel_villa_application.api.model.VillaMedia;
import be.cienfuegos.sandra.hotel_villa_application.tool.Json;
import be.cienfuegos.sandra.hotel_villa_application.tool.UnsafeOkHttpClient;
import okhttp3.MediaType;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.RequestBody;
import okhttp3.Response;

/**
 * Classe utilitaire qui requête le WEB Service écrit en C#
 */
public class HotelVillaApiClient {
    /**
     * Url de base du WEB Service
     */
    private static final String BASE_URL = "https://10.0.2.2:5001";

    /**
     * Client HTTP non sécurisé qui permet d'effectuer les requêtes
     */
    private static final OkHttpClient CLIENT = UnsafeOkHttpClient.getUnsafeOkHttpClient();

    /**
     * MediaType de type JSON utilisé lors des requêtes de type POST
     */
    private static final MediaType JSON = MediaType.parse("application/json; charset=utf-8");

    /**
     * Instance de la classe
     */
    private static HotelVillaApiClient instance = new HotelVillaApiClient();

    /**
     * Getter statique qui retourne l'instance de la classe
     *
     * @return Instance de la classe
     */
    public static HotelVillaApiClient getInstance() {
        return instance;
    }

    /**
     * Langue dans laquelle les données vont être récupérer
     * Pour l'instant, la valeur est définit en dur dans le code Locale.getDefault()
     */
    private HotelVillaLanguage language = HotelVillaLanguage.detect(Locale.getDefault());

    private String customerToken;

    /**
     * Méthode permettant d'executer une requête
     *
     * @param request la requête à executer
     * @return le flux de caractére de la réponse
     */
    private static Reader executeRequest(Request request) {
        try {
            Response response = CLIENT.newCall(request).execute();
            return Objects.requireNonNull(response.body()).charStream();
        } catch (IOException e) {
            e.printStackTrace();
            throw new RuntimeException("Error");
        }
    }

    public String getEquipmentMediaUrl(Equipment equipment) {
        return String.format("%s/media/icons/%s", BASE_URL, equipment.getIconFile());
    }

    public String getVillaMediaUrl(VillaMedia villaMedia) {
        return String.format("%s/media/pictures/%s.jpg", BASE_URL, villaMedia.getMediaName());
    }

    /**
     * Méthode qui retourne la liste des pays
     *
     * @return la liste des pays
     */
    public List<Country> getCountries() {
        final Request request = new Request.Builder()
                .url(String.format("%s/countries", BASE_URL))
                .build();

        return Json.deserialize(executeRequest(request), new TypeToken<ArrayList<Country>>() {
        }.getType());
    }

    /**
     * Méthode qui retourne la liste de villas avec comme informations supplémentaires:
     * -    Les équipements
     * -    Les formules
     * -    Les dates de réservations
     *
     * @return la liste de villas
     */
    public List<Villa> getVillas() {
        final Request request = new Request.Builder()
                .url(String.format("%s/%s/villas", BASE_URL, language.getIsoCode()))
                .build();

        List<Villa> villas = Json.deserialize(executeRequest(request), new TypeToken<ArrayList<Villa>>() {
        }.getType());

        for (Villa villa : villas) {
            villa.setEquipments(getVillaEquipments(villa.getVillaId()));
            villa.setFormulas(getVillaFormulas(villa.getVillaId()));
        }

        return villas;
    }

    /**
     * Méthode qui retourne la liste d'équipement pour une villa
     *
     * @param villaId id de la villa
     * @return la liste des équipements
     */
    @SuppressLint("DefaultLocale")
    public List<Equipment> getVillaEquipments(int villaId) {
        final Request request = new Request.Builder()
                .url(String.format("%s/%s/villas/%d/equipments", BASE_URL, language.getIsoCode(), villaId))
                .build();

        return Json.deserialize(executeRequest(request), new TypeToken<ArrayList<Equipment>>() {
        }.getType());
    }

    /**
     * Méthode qui retourne la liste de formules pour une villa
     *
     * @param villaId id de la villa
     * @return la liste des formules
     */
    @SuppressLint("DefaultLocale")
    public List<Formula> getVillaFormulas(int villaId) {
        final Request request = new Request.Builder()
                .url(String.format("%s/%s/villas/%d/formulas", BASE_URL, language.getIsoCode(), villaId))
                .build();

        return Json.deserialize(executeRequest(request), new TypeToken<ArrayList<Formula>>() {
        }.getType());
    }

    /**
     * Méthode qui retourne la liste des dates de réservations pour une villa
     *
     * @param villaId id de la villa
     * @return la liste des dates de réservations
     */
    @SuppressLint("DefaultLocale")
    public List<Date> getVillaBookedDates(int villaId) {
        final Request request = new Request.Builder()
                .url(String.format("%s/%s/villas/%d/booked_dates", BASE_URL, language.getIsoCode(), villaId))
                .build();

        return Json.deserialize(executeRequest(request), new TypeToken<ArrayList<Date>>() {
        }.getType());
    }

    public List<Service> getServices() {
        final Request request = new Request.Builder()
                .url(String.format("%s/%s/services", BASE_URL, language.getIsoCode()))
                .build();

        return Json.deserialize(executeRequest(request), new TypeToken<ArrayList<Service>>() {
        }.getType());
    }

    public List<Extra> getExtras() {
        final Request request = new Request.Builder()
                .url(String.format("%s/%s/extras", BASE_URL, language.getIsoCode()))
                .build();

        return Json.deserialize(executeRequest(request), new TypeToken<ArrayList<Extra>>() {
        }.getType());
    }

    /**
     * Méthode qui permet l'authentification d'un utilisateur
     * Elle retourne l'utilisateur connecté
     *
     * @param credentials identifiants de l'utilisateur
     * @return l'utilisateur connecté
     */
    @SuppressLint("DefaultLocale")
    public VillaHotelApiResponse<AuthenticatedCustomer> signInUser(Credentials credentials) {
        final Request request = new Request.Builder()
                .url(String.format("%s/customers/sign_in", BASE_URL))
                .post(RequestBody.create(Json.serialize(credentials), JSON))
                .build();
        VillaHotelApiResponse<AuthenticatedCustomer> authenticatedCustomerVillaHotelApiResponse = Json.deserialize(executeRequest(request), new TypeToken<VillaHotelApiResponse<AuthenticatedCustomer>>() {
        }.getType());
        if (authenticatedCustomerVillaHotelApiResponse.isSuccess()) {
            customerToken = authenticatedCustomerVillaHotelApiResponse.getData().getToken();
        }
        return authenticatedCustomerVillaHotelApiResponse;
    }

    public VillaHotelApiResponse<Boolean> signUpUser(SignUpCustomer signUpCustomer) {
        final Request request = new Request.Builder()
                .url(String.format("%s/customers/sign_up", BASE_URL))
                .post(RequestBody.create(Json.serialize(signUpCustomer), JSON))
                .build();
        return Json.deserialize(executeRequest(request), new TypeToken<VillaHotelApiResponse<Boolean>>() {
        }.getType());
    }

    public VillaHotelApiResponse<Boolean> book(NewReservation newReservation) {
        Log.d("DEBUG", customerToken);
        final Request request = new Request.Builder()
                .url(String.format("%s/reservations", BASE_URL))
                .header("Authorization", String.format("Bearer %s", customerToken))
                .post(RequestBody.create(Json.serialize(newReservation), JSON))
                .build();
        return Json.deserialize(executeRequest(request), new TypeToken<VillaHotelApiResponse<Boolean>>() {
        }.getType());
    }
}
